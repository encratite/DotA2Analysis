using System;
using System.Collections.Generic;

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
					if (Array.IndexOf(hero.Roles, role) != -1)
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

	class RoleConfigurationEvaluation : ConfigurationEvaluation, IComparable
	{
		public readonly RoleConfiguration Configuration;

		public RoleConfigurationEvaluation(RoleConfiguration configuration, SetupStatistics statistics)
			: base(configuration.GetDescription(), statistics)
		{
			Configuration = configuration;
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
}
