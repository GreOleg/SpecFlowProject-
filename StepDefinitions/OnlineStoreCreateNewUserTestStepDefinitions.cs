using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowProject.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class OnlineStoreCreateNewUserTestStepDefinitions
    {
        private readonly IWebDriver driver;
        public OnlineStoreCreateNewUserTestStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I open ""([^""]*)""")]
        public void GivenIOpenTheOnlineStore(string partOfTitle)
        {
            driver.Navigate().GoToUrl(@"http://automationpractice.com/index.php");
            WElement.AssertAndWaitPartOfTitle(partOfTitle, driver);
        }

        [When(@"I press ""([^""]*)"" button")]
        public void WhenIPressButton(string login)
        {
            WElement.Find(By.CssSelector($"a.{login}"), driver).EClick();
        }

        [Then("The \"(.*?)\" page should be on the screen")]
        public void ThenPageShouldBeOnTheScreen(string partOfTitle)
        {
            WElement.AssertAndWaitPartOfTitle(partOfTitle, driver);
        }

        [When(@"I submit ""([^\""]* email)"" in the create an account form")]
        public void WhenISubmitEmailInTheCreateAnAccountForm(string userEmail)
        {
            WElement.Find(By.CssSelector("form#create-account_form"), driver).ExpectedConditionsElementVisibleAndClickable();
            WElement.Find(By.CssSelector("input#email_create"), driver).InputText(userEmail);
            WElement.Find(By.CssSelector("button[name='SubmitCreate']"), driver).EClick();
        }

        [When(@"I submit regestration user form with ""([^\""]* data)""")]
        public void ThenISubmitRegestrationUsrForm(Dictionary<string, string> user)
        {
            WElement.Find(By.CssSelector("form#account-creation_form"), driver).WaitElement();
            WElement.Find(By.CssSelector("input#customer_firstname"), driver).InputText(user["firstNameUser"]);
            WElement.Find(By.CssSelector("input#customer_lastname"), driver).InputText(user["lastNameUser"]);
            WElement.Find(By.CssSelector("input#passwd"), driver).InputText(user["passwordUser"]);
            WElement.Find(By.CssSelector("input#address1"), driver).InputText(user["addressUser"]);
            WElement.Find(By.CssSelector("input#city"), driver).InputText(user["cityUser"]);
            WElement.Find(By.CssSelector("select#id_state"), driver).SelectValue(user["stateUser"]);
            WElement.Find(By.CssSelector("input#postcode"), driver).InputText(user["postCodeUser"]);
            WElement.Find(By.CssSelector("input#phone_mobile"), driver).InputText(user["mobilePhoneUser"]);
            WElement.Find(By.CssSelector("button#submitAccount"), driver).EClick();
        }
    }
}
