using System;
using TechTalk.SpecFlow.Tracing;

namespace CoreBetting.Report
{
	public class Logger : ITraceListener
	{
		static public string LastGherkinMessage;

		public void WriteTestOutput(string message)
		{
			LastGherkinMessage = message;

			Console.WriteLine(message);
		}

		public void WriteToolOutput(string message)
		{
			Console.WriteLine(message);
		}
	}
}
