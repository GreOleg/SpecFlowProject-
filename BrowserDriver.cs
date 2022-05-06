using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(4)]
namespace SpecFlowProject
{
    [Binding]
    public class WebDriverHooks
    {
        private readonly IObjectContainer container;
        public WebDriverHooks(IObjectContainer container)
        {
            this.container = container;
        }
        [BeforeScenario]
        public void CreateWebDriver()
        {
            ChromeDriver driver = new ChromeDriver();
            container.RegisterInstanceAs<IWebDriver>(driver);
            driver.Manage().Window.Maximize();
        }
        [AfterScenario]
        public void DestroyWebDriver()
        {
            var driver = container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}