using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProject.Helpers
{
    class WElement
    {
        public static IWebDriver driver = BrowserDriver.Driver;
        private By selector;

        public WElement(By selector)
        {
            this.selector = selector;
        }
        public static WElement Find(By selector)
        {
            return new WElement(selector);
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
        public void ExpectedConditionsElement(int waitInterval = 20)
        {
            new WebDriverWait(BrowserDriver.Driver, TimeSpan.FromSeconds(waitInterval)).Until(ExpectedConditions.ElementIsVisible(selector));
            new WebDriverWait(BrowserDriver.Driver, TimeSpan.FromSeconds(waitInterval)).Until(ExpectedConditions.ElementToBeClickable(selector));
        }
    }
}
