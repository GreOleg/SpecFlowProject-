using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProject.Helpers
{
    class WElement
    {
        private By selector;
        private readonly IWebDriver driver;
        public WElement(By selector, IWebDriver driver)
        {
            this.selector = selector;
            this.driver = driver;
        }
        public static WElement Find(By selector, IWebDriver driver)
        {
            return new WElement(selector, driver);
        }
        public void EClick(int countOfClicks = 1, int waitInterval = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInterval)).Until(ExpectedConditions.ElementToBeClickable(selector));
            while (countOfClicks > 0)
            {
                driver.FindElement(selector).Click();
                countOfClicks--;
            }
        }
        public void InputText(string text, int waitInterval = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInterval)).Until(ExpectedConditions.ElementToBeClickable(selector));
            driver.FindElement(selector).SendKeys(text);
        }
        public void InputNumber(int num, int waitInterval = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInterval)).Until(ExpectedConditions.ElementToBeClickable(selector));
            driver.FindElement(selector).SendKeys(num.ToString());
        }
        public void InputNumber(decimal num, int waitInterval = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInterval)).Until(ExpectedConditions.ElementToBeClickable(selector));
            driver.FindElement(selector).SendKeys(num.ToString());
        }
        public void WaitElement(int waitInterval = 10)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(waitInterval)).Until(ExpectedConditions.ElementIsVisible(selector));
                LogManager.GetCurrentClassLogger().Info($"Element - {selector.ToString} is visible");
            }

            catch (StaleElementReferenceException sere)
            {
                // simply retry finding the element in the refreshed DOM
                driver.FindElement(selector).Click();
            }
            catch (TimeoutException toe)
            {
                LogManager.GetCurrentClassLogger().Error("Element identified by " + selector.ToString() + " was not visiblee after" + waitInterval + "seconds");
            }
        }
        public void ExpectedConditionsElementVisibleAndClickable(int waitInterval = 20)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInterval)).Until(ExpectedConditions.ElementIsVisible(selector));
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInterval)).Until(ExpectedConditions.ElementToBeClickable(selector));
        }
        public static void AssertAndWaitPartOfTitle(string partOfTitle, IWebDriver driver, int interval = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(interval)).Until(ExpectedConditions.TitleContains(partOfTitle));
        }
        public static void AssertAndWaitPartOfUrl(string partOfUrl, IWebDriver driver, int interval = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(interval)).Until(ExpectedConditions.UrlContains(partOfUrl));
        }
        public void SelectValue(string value) => new SelectElement(driver.FindElement(selector)).SelectByValue(value);
    }
}
