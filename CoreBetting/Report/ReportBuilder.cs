using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using TechTalk.SpecFlow.Bindings;

namespace CoreBetting.Report
{
    [Binding]
    public class ReportBuilder
    {
        private static ExtentReports extentReports;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(ReportDefinition.ReportingFolder() + "index.html");
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void InitializeFeature()
        {
            string featureTitle = FeatureContext.Current.FeatureInfo.Title;
            ExtentTest feature = extentReports.CreateTest<Feature>(featureTitle);
            FeatureContext.Current.Set<ExtentTest>(feature);
        }

        [BeforeScenario]
        public static void AddScenario()
        {
            string scenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
            ExtentTest feature = FeatureContext.Current.Get<ExtentTest>();
            ExtentTest scenario = feature.CreateNode<Scenario>(scenarioTitle);
            ScenarioContext.Current.Set<ExtentTest>(scenario);
        }

        [BeforeStep]
        public static void AddStep()
        {
            ExtentTest scenario = ScenarioContext.Current.Get<ExtentTest>();
            StepInfo step = ScenarioStepContext.Current.StepInfo;
            ExtentTest testStep = null;
            switch (step.StepDefinitionType)
            {
                case StepDefinitionType.Given:
                    testStep = scenario.CreateNode<Given>(step.Text);
                    break;
                case StepDefinitionType.When:
                    testStep = scenario.CreateNode<When>(step.Text);
                    break;
                case StepDefinitionType.Then:
                    testStep = scenario.CreateNode<Then>(step.Text);
                    break;
            }
            ScenarioStepContext.Current.Set<ExtentTest>(testStep);
        }



        [AfterTestRun]
        public static void FlushReport()
        {
            extentReports.Flush();
        }
    }
}
