namespace DotA2Analysis
{
	class SetupStatistics
	{
		public int Wins;
		public int Losses;

		public SetupStatistics()
		{
			Wins = 0;
			Losses = 0;
		}

		public void ProceessOutcome(bool isRadiant, bool radiantVictory)
		{
			if ((isRadiant && radiantVictory) || (!isRadiant && !radiantVictory))
				Wins++;
			else
				Losses++;
		}

		public float GetWinRatio()
		{
			return (float)Wins / GetGames();
		}

		public int GetGames()
		{
			return Wins + Losses;
		}
	}
}
