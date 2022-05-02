using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    internal class BaseTestClass
    {
        IWebDriver driver;

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
