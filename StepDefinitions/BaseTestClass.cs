using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    internal class BaseTestClass
    {
        [BeforeScenario]
        public void BeforEvryScenario()
        {
            BrowserDriver.InitBrowser();
        }
        [AfterScenario]
        public void AfterEvryScenario()
        {
            BrowserDriver.CloseBrowser();
        }
    }
}
