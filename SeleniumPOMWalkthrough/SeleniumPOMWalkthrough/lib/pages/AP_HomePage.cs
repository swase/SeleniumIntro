using OpenQA.Selenium;
using SeleniumPOMWalkthrough.utils;
using System;

namespace SeleniumPOMWalkthrough.lib.pages
{
    public class AP_HomePage
    {
        #region
        private IWebDriver _seleniumDriver;
        private string _homePageUrl = AppConfigReader.BaseURL;

        private IWebElement _signInLink => _seleniumDriver.FindElement(By.Id("login-button"));
        private IWebElement _userName => _seleniumDriver.FindElement(By.Id("user-name"));
        private IWebElement _password => _seleniumDriver.FindElement(By.Id("password"));
        private IWebElement _errorField => _seleniumDriver.FindElement(By.Id("login_button_container"));



        #endregion

        //Same as below
        //private IWebElement _signInLink
        //{
        //    get { return _seleniumDriver.FindElement(By.LinkText("Sign In")); }
        //}

        public AP_HomePage(IWebDriver seleniumDriver)
        {
            this._seleniumDriver = seleniumDriver;
        }
        //Methods to interact with the web page
        public void VisitHomePage() => _seleniumDriver.Navigate().GoToUrl(_homePageUrl);
        public void VisitSignInPage() => _signInLink.Click();
        public void InputUserName(string username) => _userName.SendKeys(username);
        public void InputPassword(string password) => _password.SendKeys(password);
        public string GetErrorMessage() => _errorField.Text;
        private IWebElement _emailField => this._seleniumDriver.FindElement(By.Id("email"));
        private IWebElement _passwordField => this._seleniumDriver.FindElement(By.Id("passwd"));

        public void InputSigninCredentials(Credentials credentials)
        {
            _userName.SendKeys(credentials.Email);
            _password.SendKeys(credentials.Password);
        }

    }
}
