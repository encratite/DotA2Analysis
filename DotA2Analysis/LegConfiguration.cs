using System;
using System.Collections.Generic;

namespace DotA2Analysis
{
	class LegConfiguration
	{
		public readonly int LeglessCount;

		public LegConfiguration(List<Hero> team)
		{
			LeglessCount = 0;
			foreach (Hero hero in team)
			{
				if (!hero.HasLegs)
					LeglessCount++;
			}
		}

		public bool Equals(LegConfiguration configuration)
		{
			return LeglessCount == configuration.LeglessCount;
		}

		public string GetDescription()
		{
			return string.Format("Heroes without legs: {0}", LeglessCount);
		}
	}

	class LegConfigurationComparer : IEqualityComparer<LegConfiguration>
	{
		public bool Equals(LegConfiguration x, LegConfiguration y)
		{
			return x.Equals(y);
		}

		public int GetHashCode(LegConfiguration configuration)
		{
			return configuration.LeglessCount;
		}
	}

	class LegConfigurationEvaluation : ConfigurationEvaluation, IComparable
	{
		public readonly LegConfiguration Configuration;

		public LegConfigurationEvaluation(LegConfiguration configuration, SetupStatistics statistics)
			: base(configuration.GetDescription(), statistics)
		{
			Configuration = configuration;
		}

		public int CompareTo(object other)
		{
			var evaluation = other as LegConfigurationEvaluation;
			return -Statistics.GetWinRatio().CompareTo(evaluation.Statistics.GetWinRatio());
		}
	}
}
