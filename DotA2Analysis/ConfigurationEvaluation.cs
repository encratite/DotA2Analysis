namespace DotA2Analysis
{
	class ConfigurationEvaluation
	{
		public readonly string Description;
		public readonly SetupStatistics Statistics;

		public ConfigurationEvaluation(string description, SetupStatistics statistics)
		{
			Description = description;
			Statistics = statistics;
		}
	}
}
