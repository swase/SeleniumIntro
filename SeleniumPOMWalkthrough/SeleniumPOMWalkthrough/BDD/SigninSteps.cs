using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumPOMWalkthrough.lib.pages;
using SeleniumPOMWalkthrough.utils;
using TechTalk.SpecFlow.Assist;

namespace SeleniumPOMWalkthrough.BDD
{
    [Binding]
    public sealed class SigninSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        public AP_Website<ChromeDriver> AP_Website { get; } = new AP_Website<ChromeDriver>();
        Credentials _credentials;


        [Given(@"I am on the signin page")]
        public void GivenIAmOnTheSigninPage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
        }

        [Given(@"I have not entered any credentials")]
        public void GivenIHaveNotEnteredAnyCredentials()
        {
            AP_Website.AP_HomePage.InputUserName("");
            AP_Website.AP_HomePage.InputPassword("");
        }

        [Given(@"I enter ""(.*)""")]
        public void GivenIHaveEnter(string email)
        {
            AP_Website.AP_HomePage.InputUserName(email);
        }

        [Given(@"I don't enter a password")]
        public void GivenIDonTEnterAPassword()
        {
        }

        [Given(@"I enter an invalid password ""(.*)""")]
        public void GivenIEnterAnInvalidPassword(string password)
        {
            AP_Website.AP_HomePage.InputPassword(password);
        }

        [Given(@"I have the following credentials")]
        public void GivenIHaveTheFollowingCredentials(Table table)
        {
            _credentials = table.CreateInstance<Credentials>();
        }

        [When(@"I click the sign in button")]
        public void WhenIClickTheSignInButton()
        {
            AP_Website.AP_HomePage.VisitSignInPage();
        }

        [When(@"I enter these credentials")]
        public void WhenIEnterTheseCredentials()
        {
            AP_Website.AP_HomePage.InputSigninCredentials(_credentials);
        }

        [Then(@"I should see an alert containing the error message ""(.*)""")]
        public void ThenIShouldSeeAnAlertContainingTheErrorMessage(string expected)
        {
            Assert.That(AP_Website.AP_HomePage.GetErrorMessage(), Does.Contain(expected));
        }

        [Then(@"the resulting page navigated to should have title ""(.*)""")]
        public void ThenTheResultingPageNavigatedToShouldHaveTitle(string expectedTitle)
        {
            Assert.That(AP_Website.SeleniumDriver.Title, Is.EqualTo(expectedTitle));
        }


        [AfterScenario]
        public void DisposeWebDriver()
        {
            AP_Website.SeleniumDriver.Quit();
            AP_Website.SeleniumDriver.Dispose();
        }

    }
}
