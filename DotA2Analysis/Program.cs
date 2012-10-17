using System;

namespace DotA2Analysis
{
	class Program
	{
		static void Main(string[] arguments)
		{
			if (arguments.Length != 2)
			{
				Console.WriteLine("Usage:");
				Console.WriteLine("{0} <path to directory containing match files> <path to output file>");
				return;
			}

			string matchesDirectory = arguments[0];
			string outputPath = arguments[1];
			Analysis analysis = new Analysis(matchesDirectory, outputPath, false);
			analysis.Analyse();
			analysis.PrintStatistics();
		}
	}
}
