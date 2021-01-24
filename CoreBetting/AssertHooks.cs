using AventStack.ExtentReports;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CoreBetting
{
    public class AssertHooks
	{
        public static void AssertBoolean(bool assertedValue, string reportingMessage)
        {
            ExtentTest reportStep = ScenarioStepContext.Current.Get<ExtentTest>();
            try
            {
				Assert.IsTrue(assertedValue);
				reportStep.Pass(reportingMessage);
            }
            catch (AssertionException)
            {
                reportStep.Fail("Failure occurred when executing check '" + reportingMessage + "'");
                throw;
            }
        }

		public static void AssertIsNotNull(int value, string reportingMessage)
		{
			ExtentTest reportStep = ScenarioStepContext.Current.Get<ExtentTest>();
			try
			{
				Assert.IsNotNull(value);
				reportStep.Pass(reportingMessage);
			}
			catch (AssertionException)
			{
				reportStep.Fail("Failure occurred '" + reportingMessage + "'");
				throw;
			}
		}

		public static void AssertTrue(ExtentTest extentTest, bool assertedValue, string reportingMessage)
		{
			ExtentTest reportStep = ScenarioStepContext.Current.Get<ExtentTest>();
			try
			{
				Assert.IsTrue(assertedValue);
				reportStep.Pass(reportingMessage);
			}
			catch (AssertionException)
			{
				reportStep.Fail("Failure occurred when executing check '" + reportingMessage + "'");
				throw;
			}
		}

		public static void AssertStringEquals(ExtentTest extentTest, string actualValue, string expectedValue, string reportingMessage)
		{
			ExtentTest reportStep = ScenarioStepContext.Current.Get<ExtentTest>();
			try
			{
				Assert.AreEqual(expectedValue, actualValue);
				reportStep.Pass(reportingMessage);
			}
			catch (AssertionException)
			{

				reportStep.Fail("Failure occurred when executing check '" + reportingMessage + "'");
				throw;
			}
		}

		public static void AssertIntEquals(ExtentTest extentTest, int actualValue, int expectedValue, string reportingMessage)
		{
			ExtentTest reportStep = ScenarioStepContext.Current.Get<ExtentTest>();
			try
			{
				Assert.AreEqual(expectedValue, actualValue);
				reportStep.Pass(reportingMessage);
			}
			catch (AssertionException)
			{
				reportStep.Fail("Failure occurred when executing check '" + reportingMessage + "', actual value was " + actualValue);
				throw;
			}
		}

		public static void AssertStringNotEquals(ExtentTest extentTest, string actualValue, string expectedValue, string reportingMessage)
		{
			ExtentTest reportStep = ScenarioStepContext.Current.Get<ExtentTest>();
			try
			{
				Assert.AreNotEqual(expectedValue, actualValue);
				reportStep.Pass(reportingMessage);
			}
			catch (AssertionException)
			{

				reportStep.Fail("Failure occurred when executing check '" + reportingMessage + "'");
				throw;
			}
		}

		public static void AssertFalse(ExtentTest extentTest, bool assertedValue, string reportingMessage)
		{
			ExtentTest reportStep = ScenarioStepContext.Current.Get<ExtentTest>();
			try
			{
				Assert.IsFalse(assertedValue);
				reportStep.Pass(reportingMessage);
			}
			catch (AssertionException)
			{
				reportStep.Fail("Failure occurred when executing check '" + reportingMessage + "'");
				throw;
			}
		}
	}
}
