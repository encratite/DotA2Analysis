using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DotA2Analysis
{
	class Analysis
	{
		const int TeamSize = 5;
		const int MinimumOutcomeCount = 50;

		RoleEvaluationClass[] RoleEvaluationClasses;

		bool TestMode;

		Dictionary<RangeConfiguration, SetupStatistics> RangeStatistics;
		Dictionary<AttributeConfiguration, SetupStatistics> AttributeStatistics;
		Dictionary<LegConfiguration, SetupStatistics> LegStatistics;

		string MatchesDirectory;
		string OutputPath;

		StreamWriter ScriptWriter;

		int ValidSamples;

		public Analysis(string matchesDirectory, string outputPath, bool testMode)
		{
			MatchesDirectory = matchesDirectory;
			OutputPath = outputPath;

			TestMode = testMode;

			ValidSamples = 0;

			RangeStatistics = new Dictionary<RangeConfiguration, SetupStatistics>(new RangeConfigurationComparer());
			AttributeStatistics = new Dictionary<AttributeConfiguration, SetupStatistics>(new AttributeConfigurationComparer());
			LegStatistics = new Dictionary<LegConfiguration, SetupStatistics>(new LegConfigurationComparer());

			InitialiseEvaluationClasses();
		}

		void InitialiseEvaluationClasses()
		{
			RoleEvaluationClasses = new RoleEvaluationClass[]
			{
				new RoleEvaluationClass("Optimal number of carries per team", new HeroRole[] { HeroRole.Carry }),
				new RoleEvaluationClass("Optimal number of disablers per team", new HeroRole[] { HeroRole.Disabler }),
				new RoleEvaluationClass("Optimal number of durable heroes per team", new HeroRole[] { HeroRole.Durable }),
				new RoleEvaluationClass("Optimal number heroes with escapes per team", new HeroRole[] { HeroRole.Escape }),
				new RoleEvaluationClass("Optimal number of initiators per team", new HeroRole[] { HeroRole.Initiator }),
				new RoleEvaluationClass("Optimal number of junglers per team", new HeroRole[] { HeroRole.Jungler }),
				new RoleEvaluationClass("Optimal number of lane supports per team", new HeroRole[] { HeroRole.LaneSupport }),
				new RoleEvaluationClass("Optimal number of nukers per team", new HeroRole[] { HeroRole.Nuker }),
				new RoleEvaluationClass("Optimal number of pushers per team", new HeroRole[] { HeroRole.Pusher }),
				new RoleEvaluationClass("Optimal number of supports per team", new HeroRole[] { HeroRole.Support }),

				new RoleEvaluationClass("Optimal number of carries and disablers per team", new HeroRole[] { HeroRole.Carry, HeroRole.Disabler }),
				new RoleEvaluationClass("Optimal number of carries and initiators per team", new HeroRole[] { HeroRole.Carry, HeroRole.Initiator }),
				new RoleEvaluationClass("Optimal number of carries and lane supports per team", new HeroRole[] { HeroRole.Carry, HeroRole.LaneSupport }),
				new RoleEvaluationClass("Optimal number of carries, disablers and initiators per team", new HeroRole[] { HeroRole.Carry, HeroRole.Disabler, HeroRole.Initiator }),
			};
		}

		public void Analyse()
		{
			LoadMatches(MatchesDirectory);
		}

		void LoadMatches(string path)
		{
			int progress = 1;
			string[] files = Directory.GetFiles(path);
			foreach (string file in files)
			{
				if (TestMode && progress > 3000)
					break;
				if (progress % 100 == 1)
					Console.WriteLine("Loading match {0}/{1}", progress, files.Length);
				string matchData = File.ReadAllText(file);
				LoadMatch(matchData);
				progress++;
			}
		}

		void LoadMatch(string matchData)
		{
			Match outcomeMatch = Regex.Match(matchData, "<div class=\"match-result\"><span class=\"team .+?\">(.+?) Victory</span></div>");
			if (!outcomeMatch.Success)
			{
				//throw new Exception("Unable to determine the result of the match");
				return;
			}
			string teamString = outcomeMatch.Groups[1].Value;
			bool radiantVictory = teamString == "Radiant";
			Regex heroPattern = new Regex("a href=\"/heroes/.+?\" class=\"hero-link\">(.+?)</a>", RegexOptions.Singleline);
			MatchCollection matches = heroPattern.Matches(matchData);
			if (matches.Count != TeamSize * 2)
				throw new Exception("Invalid number of heroes in teams");
			var radiantHeroes = GetTeamHeroes(matches, 0);
			var direHeroes = GetTeamHeroes(matches, TeamSize);
			ProcessTeam(radiantHeroes, true, radiantVictory);
			ProcessTeam(direHeroes, false, radiantVictory);
			ValidSamples += 2;
		}

		void ProcessTeam(List<Hero> heroes, bool isRadiant, bool radiantVictory)
		{
			ProcessRangeStatistics(heroes, isRadiant, radiantVictory);
			ProcessAttributeStatistics(heroes, isRadiant, radiantVictory);
			ProcessLegStatistics(heroes, isRadiant, radiantVictory);

			foreach (var evaluationClass in RoleEvaluationClasses)
				ProcessTeamRoles(heroes, isRadiant, radiantVictory, evaluationClass.Roles, evaluationClass.Statistics);
		}

		void ProcessRangeStatistics(List<Hero> heroes, bool isRadiant, bool radiantVictory)
		{
			var configuration = new RangeConfiguration(heroes);
			SetupStatistics statistics;
			if (!RangeStatistics.TryGetValue(configuration, out statistics))
			{
				statistics = new SetupStatistics();
				RangeStatistics[configuration] = statistics;
			}
			statistics.ProceessOutcome(isRadiant, radiantVictory);
		}

		void ProcessAttributeStatistics(List<Hero> heroes, bool isRadiant, bool radiantVictory)
		{
			var configuration = new AttributeConfiguration(heroes);
			SetupStatistics statistics;
			if (!AttributeStatistics.TryGetValue(configuration, out statistics))
			{
				statistics = new SetupStatistics();
				AttributeStatistics[configuration] = statistics;
			}
			statistics.ProceessOutcome(isRadiant, radiantVictory);
		}

		void ProcessLegStatistics(List<Hero> heroes, bool isRadiant, bool radiantVictory)
		{
			var configuration = new LegConfiguration(heroes);
			SetupStatistics statistics;
			if (!LegStatistics.TryGetValue(configuration, out statistics))
			{
				statistics = new SetupStatistics();
				LegStatistics[configuration] = statistics;
			}
			statistics.ProceessOutcome(isRadiant, radiantVictory);
		}

		void ProcessTeamRoles(List<Hero> heroes, bool isRadiant, bool radiantVictory, HeroRole[] roles, Dictionary<RoleConfiguration, SetupStatistics> container)
		{
			RoleConfiguration configuration = new RoleConfiguration(heroes, roles);
			SetupStatistics statistics;
			if (!container.TryGetValue(configuration, out statistics))
			{
				statistics = new SetupStatistics();
				container[configuration] = statistics;
			}
			statistics.ProceessOutcome(isRadiant, radiantVictory);
		}

		List<Hero> GetTeamHeroes(MatchCollection matches, int offset)
		{
			var output = new List<Hero>();
			for (int i = 0; i < TeamSize; i++)
			{
				string heroName = matches[offset + i].Groups[1].Value;
				Hero hero = Hero.Get(heroName);
				output.Add(hero);
			}
			return output;
		}

		public void PrintStatistics()
		{
			ScriptWriter = new StreamWriter(OutputPath);

			ScriptWriter.Write("var statistics = new Statistics({0});\n\n", ValidSamples);

			PrintStatistics<RangeConfiguration, RangeConfigurationEvaluation>("Melee vs. ranged composition", RangeStatistics);
			PrintStatistics<AttributeConfiguration, AttributeConfigurationEvaluation>("Hero attribute type composition", AttributeStatistics);
			PrintStatistics<LegConfiguration, LegConfigurationEvaluation>("Number of heroes without legs", LegStatistics);

			foreach (var evaluationClass in RoleEvaluationClasses)
				PrintStatistics<RoleConfiguration, RoleConfigurationEvaluation>(evaluationClass.Description, evaluationClass.Statistics);

			ScriptWriter.Write("statistics.generateStatistics();");

			ScriptWriter.Close();
		}

		void WriteScriptIntro(string description)
		{
			ScriptWriter.Write("statistics.addStatistics(\n    \"{0}\",\n    [\n", description);
		}

		void WriteScriptOutro()
		{
			ScriptWriter.Write("    ]\n);\n\n");
		}

		void WriteScriptData(string description, int samples, float winRatio)
		{
			string output = string.Format("        [\"{0}\", {1}, {2}],\n", description, samples, winRatio);
			ScriptWriter.Write(output);
		}

		void PrintStatistics<KeyType, EvaluationType>(string description, Dictionary<KeyType, SetupStatistics> container) where EvaluationType : ConfigurationEvaluation
		{
			WriteScriptIntro(description);

			var evaluations = new List<EvaluationType>();
			foreach (var pair in container)
			{
				var configuration = pair.Key;
				var statistics = pair.Value;
				if (statistics.GetGames() < MinimumOutcomeCount)
					continue;
				//var evaluation = new EvaluationType(configuration, statistics);
				EvaluationType evaluation = (EvaluationType)Activator.CreateInstance(typeof(EvaluationType), configuration, statistics);
				evaluations.Add(evaluation);
			}
			evaluations.Sort();

			foreach (var evaluation in evaluations)
				WriteScriptData(evaluation.Description, evaluation.Statistics.GetGames(), evaluation.Statistics.GetWinRatio());

			WriteScriptOutro();
		}
	}
}
