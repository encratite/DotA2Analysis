using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DotA2Analysis
{
	class RoleConfiguration
	{
		public Dictionary<HeroRole, int> RoleCounts;

		public RoleConfiguration(List<Hero> team, HeroRole[] rolesConsidered)
		{
			RoleCounts = new Dictionary<HeroRole, int>();
			foreach (HeroRole role in rolesConsidered)
				RoleCounts[role] = 0;
			foreach (Hero hero in team)
			{
				foreach (HeroRole role in rolesConsidered)
				{
					if(Array.IndexOf(hero.Roles, role) != -1)
						RoleCounts[role]++;
				}
			}
		}

		public bool Equals(RoleConfiguration configuration)
		{
			foreach (var pair in RoleCounts)
			{
				if (pair.Value != configuration.RoleCounts[pair.Key])
					return false;
			}
			return true;
		}

		public string GetDescription()
		{
			var units = new List<string>();
			foreach (var pair in RoleCounts)
				units.Add(string.Format("{0}: {1}", pair.Key.ToString(), pair.Value));
			return string.Join(", ", units);
		}
	}

	class RoleConfigurationComparer : IEqualityComparer<RoleConfiguration>
	{
		public bool Equals(RoleConfiguration x, RoleConfiguration y)
		{
			return x.Equals(y);
		}

		public int GetHashCode(RoleConfiguration configuration)
		{
			int hash = 0;
			foreach (var pair in configuration.RoleCounts)
			{
				hash <<= 3;
				hash |= pair.Value;
			}
			return hash;
		}
	}

	class RoleConfigurationEvaluation : IComparable
	{
		public readonly RoleConfiguration Configuration;
		public readonly SetupStatistics Statistics;

		public RoleConfigurationEvaluation(RoleConfiguration configuration, SetupStatistics statistics)
		{
			Configuration = configuration;
			Statistics = statistics;
		}

		public int CompareTo(object other)
		{
			var evaluation = other as RoleConfigurationEvaluation;
			return -Statistics.GetWinRatio().CompareTo(evaluation.Statistics.GetWinRatio());
		}
	}

	class RoleEvaluationClass
	{
		public readonly string Description;
		public readonly HeroRole[] Roles;
		public readonly Dictionary<RoleConfiguration, SetupStatistics> Statistics;

		public RoleEvaluationClass(string description, HeroRole[] roles)
		{
			Description = description;
			Roles = roles;
			Statistics = new Dictionary<RoleConfiguration, SetupStatistics>(new RoleConfigurationComparer());
		}
	}

	class Analysis
	{
		const int TeamSize = 5;

		RoleEvaluationClass[] RoleEvaluationClasses;

		bool GenerateAttributeStatistics;
		bool GenerateRoleStatistics;

		Dictionary<AttributeConfiguration, SetupStatistics> AttributeStatistics;

		public Analysis(string path, bool generateAttributeStatistics, bool generateRoleStatistics)
		{
			GenerateAttributeStatistics = generateAttributeStatistics;
			GenerateRoleStatistics = generateRoleStatistics;

			AttributeStatistics = new Dictionary<AttributeConfiguration, SetupStatistics>(new AttributeConfigurationComparer());

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
			
			LoadMatches(path);
		}

		void LoadMatches(string path)
		{
			int progress = 1;
			string[] files = Directory.GetFiles(path);
			foreach (string file in files)
			{
				//if (progress > 3000)
				//	break;
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
				throw new Exception("Unable to determine the result of the match");
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
		}

		void ProcessTeam(List<Hero> heroes, bool isRadiant, bool radiantVictory)
		{
			if (GenerateAttributeStatistics)
			{
				AttributeConfiguration attributeConfiguration = new AttributeConfiguration(heroes);
				SetupStatistics statistics;
				if (!AttributeStatistics.TryGetValue(attributeConfiguration, out statistics))
				{
					statistics = new SetupStatistics();
					AttributeStatistics[attributeConfiguration] = statistics;
				}
				statistics.ProceessOutcome(isRadiant, radiantVictory);
			}

			if (GenerateRoleStatistics)
			{
				foreach (var evaluationClass in RoleEvaluationClasses)
					ProcessTeamRoles(heroes, isRadiant, radiantVictory, evaluationClass.Roles, evaluationClass.Statistics);
			}
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
			if (GenerateAttributeStatistics)
			{
				const int attributeStatisticsMinimumOutcomeCount = 50;
				var evaluations = new List<AttributeConfigurationEvaluation>();
				foreach (var pair in AttributeStatistics)
				{
					var configuration = pair.Key;
					var statistics = pair.Value;
					if (statistics.GetGames() < attributeStatisticsMinimumOutcomeCount)
						continue;
					var evaluation = new AttributeConfigurationEvaluation(configuration, statistics);
					evaluations.Add(evaluation);
				}
				evaluations.Sort();

				foreach (var evaluation in evaluations)
				{
					Console.WriteLine("{0} - {1:F1}%", evaluation.Configuration.GetString(), evaluation.Statistics.GetWinRatio() * 100);
				}
			}

			if (GenerateRoleStatistics)
			{
				foreach (var evaluationClass in RoleEvaluationClasses)
					PrintRoleStatistics(evaluationClass.Description, evaluationClass.Statistics);
			}
		}

		public void PrintRoleStatistics(string description, Dictionary<RoleConfiguration, SetupStatistics> container)
		{
			Console.WriteLine("{0}:", description);

			const int minimumOutcomeCount = 50;
			var evaluations = new List<RoleConfigurationEvaluation>();
			foreach (var pair in container)
			{
				var configuration = pair.Key;
				var statistics = pair.Value;
				if (statistics.GetGames() < minimumOutcomeCount)
					continue;
				var evaluation = new RoleConfigurationEvaluation(configuration, statistics);
				evaluations.Add(evaluation);
			}
			evaluations.Sort();

			foreach (var evaluation in evaluations)
			{
				Console.WriteLine("{0} - {1:F1}%", evaluation.Configuration.GetDescription(), evaluation.Statistics.GetWinRatio() * 100);
			}

			Console.WriteLine("");
		}
	}
}
