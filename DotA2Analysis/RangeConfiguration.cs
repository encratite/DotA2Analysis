using System;
using System.Collections.Generic;

namespace DotA2Analysis
{
	class RangeConfiguration
	{
		public readonly int MeleeCount;
		public readonly int RangedCount;

		public RangeConfiguration(List<Hero> team)
		{
			MeleeCount = 0;
			RangedCount = 0;
			foreach (Hero hero in team)
			{
				if (hero.IsRanged)
					RangedCount++;
				else
					MeleeCount++;
			}
		}

		public bool Equals(RangeConfiguration configuration)
		{
			return MeleeCount == configuration.MeleeCount && RangedCount == configuration.RangedCount;
		}

		public string GetDescription()
		{
			return string.Format("Melee: {0}, Ranged: {1}", MeleeCount, RangedCount);
		}
	}

	class RangeConfigurationComparer : IEqualityComparer<RangeConfiguration>
	{
		public bool Equals(RangeConfiguration x, RangeConfiguration y)
		{
			return x.Equals(y);
		}

		public int GetHashCode(RangeConfiguration configuration)
		{
			return configuration.MeleeCount | (configuration.RangedCount << 3);
		}
	}

	class RangeConfigurationEvaluation : ConfigurationEvaluation, IComparable
	{
		public readonly RangeConfiguration Configuration;

		public RangeConfigurationEvaluation(RangeConfiguration configuration, SetupStatistics statistics)
			: base(configuration.GetDescription(), statistics)
		{
			Configuration = configuration;
		}

		public int CompareTo(object other)
		{
			var evaluation = other as RangeConfigurationEvaluation;
			return -Statistics.GetWinRatio().CompareTo(evaluation.Statistics.GetWinRatio());
		}
	}
}
