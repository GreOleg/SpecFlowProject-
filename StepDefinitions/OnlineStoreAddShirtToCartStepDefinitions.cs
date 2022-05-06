using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject.Helpers;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    [Parallelizable(ParallelScope.All)]
    class OnlineStoreAddShirtToCartStepDefinitions
    {
        private readonly IWebDriver driver;
        public OnlineStoreAddShirtToCartStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I open the App")]
        public void GivenOpenApp()
        {
            driver.Navigate().GoToUrl(@"http://automationpractice.com/index.php");
        }

        [When("I enter the \"(.*?)\" in the Search field")]
        public void WhenEnterSearchItem(string searchItem)
        {
            WElement.Find(By.XPath("//input[@id='search_query_top']"), driver).InputText(searchItem);
        }

        [Then("I expect for the element search tooltip \"(.*?)\" to appear")]
        public void ThenExpectElementIntoTooltip(string searchItem)
        {
            WElement.Find(By.XPath($"//li[contains(text(),'{searchItem}')]"), driver).WaitElement();
        }

        [When("I click on the element search tooltip \"(.*?)\"")]
        public void WhenClickElementIntoTooltip(string searchItem)
        {
            WElement.Find(By.XPath($"//li[contains(text(),'{searchItem}')]"), driver).EClick();
        }

        [Then(@"I expect for the product page to appear")]
        public void ThenExpectProductPageToAppear()
        {
            WElement.Find(By.XPath("//body[@id='product']"), driver).WaitElement();
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
            WElement.Find(By.XPath("//p[@id='add_to_cart']/button"), driver).EClick();
        }

        [Then("I expect for the element with the text is \"(.*?)\"")]
        public void ThenExpectElementWithText(string successTitle)
        {
            WElement.Find(By.XPath($"//h2[normalize-space()='{successTitle}']"), driver).ExpectedConditionsElementVisibleAndClickable();
            driver.FindElement(By.XPath($"//h2[normalize-space()='{successTitle}']")).Text.Equals(successTitle);
        }
    }
}
