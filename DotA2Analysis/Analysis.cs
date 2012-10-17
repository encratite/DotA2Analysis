using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DotA2Analysis
{
	class Analysis
	{
		const int TeamSize = 5;

		bool GenerateAttributeStatistics;

		Dictionary<AttributeConfiguration, SetupStatistics> AttributeStatistics;

		public Analysis(string path, bool generateAttributeConfigurationStatistics)
		{
			GenerateAttributeStatistics = generateAttributeConfigurationStatistics;

			AttributeStatistics = new Dictionary<AttributeConfiguration, SetupStatistics>(new AttributeConfigurationComparer());
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
		}
	}
}
