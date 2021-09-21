using OpenQA.Selenium.Chrome;
using SeleniumPOMWalkthrough.lib.pages;
using NUnit.Framework;

namespace SeleniumPOMWalkthrough.tests
{
    public class AP_Signin_Tests
    {
        /*
        Instantiate our pages in oure tests
        these classes will inlcude the functions for the page
         Notice - No USING STATEMENTS
         */

        public AP_Website<ChromeDriver> AP_Website = new AP_Website<ChromeDriver>();

        //Login, correct credentials
        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickTheSigninButton_WithCorrectCredetials_ThenIShouldLandOnTheInventoryPage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.InputUserName("standard_user");
            AP_Website.AP_HomePage.InputPassword("secret_sauce");
            AP_Website.AP_HomePage.VisitSignInPage();
            Assert.That(AP_Website.SeleniumDriver.Title, 
                Does.Contain("Swag Labs"));

        }


        //Login, no credentials given
        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickTheSigninButton_WithNoCredentials_ThenIShouldGetTheExpectedErrorMessage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.InputUserName("");
            AP_Website.AP_HomePage.InputPassword("");
            AP_Website.AP_HomePage.VisitSignInPage();
            Assert.That(AP_Website.AP_HomePage.GetErrorMessage(),
                Does.Contain("Epic sadface: Username is required"));
        }

        //Login, valid username not password
        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickTheSigninButton_WithValidUserName_ButNoPassword_ThenIShouldGetTheExpectedErrorMessage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.InputUserName("standard_user");
            //AP_Website.AP_HomePage.InputPassword("");
            AP_Website.AP_HomePage.VisitSignInPage();
            Assert.That(AP_Website.AP_HomePage.GetErrorMessage(),
                Does.Contain("Epic sadface: Password is required"));
        }

        //Login, valid username in incorrect password
        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickTheSigninButton_WithValidUserName_ButIncorretPassword_ThenIShouldGetTheExpectedErrorMessage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.InputUserName("standard_user");
            AP_Website.AP_HomePage.InputPassword("12345");
            AP_Website.AP_HomePage.VisitSignInPage();
            Assert.That(AP_Website.AP_HomePage.GetErrorMessage(),
                Does.Contain("Epic sadface: Username and password do not match any user in this service"));
        }

        //Login, no Username, some password
        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickTheSigninButton_WithNoUserName_WithSomePasswordEntered_ThenIShouldGetTheExpectedErrorMessage()
        {
            AP_Website.AP_HomePage.VisitHomePage();  
            AP_Website.AP_HomePage.InputPassword("secret_sauce");
            AP_Website.AP_HomePage.VisitSignInPage();
            Assert.That(AP_Website.AP_HomePage.GetErrorMessage(),
                Does.Contain("Epic sadface: Username is required"));
        }

        [TearDown]
        public void CleanUp()
        {
            AP_Website.SeleniumDriver.Quit();
            AP_Website.SeleniumDriver.Dispose();
        }
    }
}
