using System;

namespace DotA2Analysis
{
	class Program
	{
		static void Main(string[] arguments)
		{
			if (arguments.Length != 1)
			{
				Console.WriteLine("Usage:");
				Console.WriteLine("{0} <path to directory containg match files>");
				return;
			}

			string path = arguments[0];
			Analysis analysis = new Analysis(path);
			analysis.PrintStatistics();
		}
	}
}
