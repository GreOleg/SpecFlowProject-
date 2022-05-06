using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject.Helpers;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    //[Parallelizable(ParallelScope.All)]
    internal class CalculatorStepDefinitions
    {
        private readonly IWebDriver driver;

        public CalculatorStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I open the Calculator")]
        public void GivenOpenApp()
        {
            driver.Navigate().GoToUrl(@"https://web2.0calc.ru/");
        }

        [Given("I have entered first value is (.*) into the calculator")]
        public void GivenEnterFirstNum(string num)
        {
            WElement.Find(By.XPath("//input[@id='input']"), driver).InputText(num);
        }

        [Given("I press (.*)")]
        public void GivenPressActionBtn(string action)
        {
            WElement.Find(By.XPath($"//button[@id='{"Btn" + action}']"), driver).EClick();
        }

        [Given("I have entered second value is (.*) into the calculator")]
        public void GivenEnterSecondNum(string num)
        {
            WElement.Find(By.XPath("//input[@id='input']"), driver).InputText(num);
        }

        [When(@"I press the equals button")]
        public void WhenPressEqualsBtn()
        {
            WElement.Find(By.XPath("//button[@id='BtnCalc']"), driver).EClick();
            Thread.Sleep(1000);
        }

        [Then("the (.*) should be on the screen")]
        public void ThenExpectResult(string expectedResult)
        {
            var actualResult = driver.FindElement(By.XPath("//input[@id='input']")).GetAttribute("value");
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
