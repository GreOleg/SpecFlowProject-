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

        [Given(@"Start the browser with Online Store")]
        public void GivenStartTheBrowserWithOnlineStore()
        {
            driver.Navigate().GoToUrl(@"http://automationpractice.com/index.php");
        }

        [When(@"In the Search field, enter the value is (.*)")]
        public void WhenInTheSearchFieldEnterTheValue(string searchItem)
        {
            WElement.Element(By.XPath("//input[@id='search_query_top']")).InputText(searchItem);
        }

        [Then("Wait for the element under Search with the text is (.*) to appear")]
        public void WaitTheElementToAppear(string searchItem)
        {
            WElement.Element(By.XPath($"//li[contains(text(),'{searchItem}')]")).WaitElement();
        }

        [When(@"Click on the element under Search with the text is (.*)")]
        public void ClickTheElementWithText(string searchItem)
        {
            WElement.Element(By.XPath($"//li[contains(text(),'{searchItem}')]")).EClick();
        }

        [When("Wait for the product page to appear")]
        public void WaitForProductPageToAppear()
        {
            WElement.Element(By.XPath("//body[@id='product']")).WaitElement();
        }

        [Then("Assert that the product name is (.*)")]
        public void AssertProductName(string actualProductName)
        {
            string productTitle = driver.FindElement(By.XPath($"//h1[contains(text(),'{actualProductName}')]")).Text;
            Assert.AreEqual(productTitle, actualProductName);
        }

        [When("Click on the Add to cart button")]
        public void ClickAddToCartBtn()
        {
            WElement.Element(By.XPath("//p[@id='add_to_cart']/button")).EClick();
        }

        [When("Wait for the element with the text is (.*) to appear on page")]
        public void WaitForElementWithText(string successTitle)
        {
            WElement.Element(By.XPath($"//h2[normalize-space()='{successTitle}']")).ExpectedConditionsElement();
        }

        [Then("Assert for the element with the text is (.*)")]
        public void AssertForElementWithText(string successTitle)
        {
            driver.FindElement(By.XPath($"//h2[normalize-space()='{successTitle}']")).Text.Equals(successTitle);
        }
    }
}
