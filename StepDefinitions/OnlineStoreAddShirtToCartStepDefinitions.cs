using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject.Helpers;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    class OnlineStoreAddShirtToCartStepDefinitions
    {
        IWebDriver driver = BrowserDriver.Driver;

        [Given(@"I open the App")]
        public void GivenOpenApp()
        {
            driver.Navigate().GoToUrl(@"http://automationpractice.com/index.php");
        }

        [When("I enter the \"(.*?)\" in the Search field")]
        public void WhenEnterSearchItem(string searchItem)
        {
            WElement.Element(By.XPath("//input[@id='search_query_top']")).InputText(searchItem);
        }

        [Then("I expect for the element search tooltip \"(.*?)\" to appear")]
        public void ThenExpectElementIntoTooltip(string searchItem)
        {
            WElement.Element(By.XPath($"//li[contains(text(),'{searchItem}')]")).WaitElement();
        }

        [When("I click on the element search tooltip \"(.*?)\"")]
        public void WhenClickElementIntoTooltip(string searchItem)
        {
            WElement.Element(By.XPath($"//li[contains(text(),'{searchItem}')]")).EClick();
        }

        [Then(@"I expect for the product page to appear")]
        public void ThenExpectProductPageToAppear()
        {
            WElement.Element(By.XPath("//body[@id='product']")).WaitElement();
        }

        [Then("I expect that the product name is \"(.*?)\"")]
        public void ThenExpectProductName(string actualProductName)
        {
            string productTitle = driver.FindElement(By.XPath($"//h1[contains(text(),'{actualProductName}')]")).Text;
            Assert.AreEqual(productTitle, actualProductName);
        }

        [When(@"I click on the Add to cart button")]
        public void WhenClickAddToCartBtn()
        {
            WElement.Element(By.XPath("//p[@id='add_to_cart']/button")).EClick();
        }

        [Then("I expect for the element with the text is \"(.*?)\"")]
        public void ThenExpectElementWithText(string successTitle)
        {
            WElement.Element(By.XPath($"//h2[normalize-space()='{successTitle}']")).ExpectedConditionsElement();
            driver.FindElement(By.XPath($"//h2[normalize-space()='{successTitle}']")).Text.Equals(successTitle);
        }
    }
}
