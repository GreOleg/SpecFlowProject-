using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProject
{
    class BrowserDriver
    {
        private static IWebDriver driver;
        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }
        public static void InitBrowser()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }
        public static void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}