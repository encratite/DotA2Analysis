using System;
using System.Collections.Generic;

namespace DotA2Analysis
{
	class AttributeConfiguration
	{
		public readonly int StrengthCount;
		public readonly int AgilityCount;
		public readonly int IntelligenceCount;

		public AttributeConfiguration(List<Hero> team)
		{
			StrengthCount = 0;
			AgilityCount = 0;
			IntelligenceCount = 0;
			foreach (Hero hero in team)
			{
				switch (hero.Attribute)
				{
					case HeroAttribute.Strength:
						StrengthCount++;
						break;

					case HeroAttribute.Agility:
						AgilityCount++;
						break;

					case HeroAttribute.Intelligence:
						IntelligenceCount++;
						break;
				}
			}
		}

		public bool Equals(AttributeConfiguration configuration)
		{
			return
				StrengthCount == configuration.StrengthCount &&
				AgilityCount == configuration.AgilityCount &&
				IntelligenceCount == configuration.IntelligenceCount;
		}

		public string GetString()
		{
			return string.Format("Strength: {0}, Agility: {1}, Intelligence: {2}", StrengthCount, AgilityCount, IntelligenceCount);
		}
	}

	class AttributeConfigurationComparer : IEqualityComparer<AttributeConfiguration>
	{
		public bool Equals(AttributeConfiguration x, AttributeConfiguration y)
		{
			return x.Equals(y);
		}

		public int GetHashCode(AttributeConfiguration configuration)
		{
			int hash = configuration.StrengthCount | (configuration.AgilityCount << 3) | (configuration.IntelligenceCount << 6);
			return hash;
		}
	}

	class AttributeConfigurationEvaluation : IComparable
	{
		public AttributeConfiguration Configuration;
		public SetupStatistics Statistics;

		public AttributeConfigurationEvaluation(AttributeConfiguration configuration, SetupStatistics statistics)
		{
			Configuration = configuration;
			Statistics = statistics;
		}

		public int CompareTo(object other)
		{
			if (other == null)
				return 1;
			var evaluation = other as AttributeConfigurationEvaluation;
			return -Statistics.GetWinRatio().CompareTo(evaluation.Statistics.GetWinRatio());
		}
	}
}
