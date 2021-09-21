using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;



namespace SeleniumIntro
{
    public class Tests
    {




        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickTheSigninLink_ThenIGoToTheSigninPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Maximise the browser so it's full screen
                driver.Manage().Window.FullScreen();
                //Navigate to the AP site
                driver.Navigate().GoToUrl("http://automationpractice.com/");
                //Grab the Sign In link so we can interact with it
                IWebElement signinLink = driver.FindElement(By.LinkText("Sign in"));
                //Act - click sign in link
                signinLink.Click();
                //Wait to ensure a response
                Thread.Sleep(5000);
                //Assert - that we are now on the sign in age
                Assert.That(driver.Title, Is.EqualTo("Login - My Store"));
            }
        }



        [Test]
        public void GivenIAmOnTheSignPage_AndIEnterA4DigitPassword_WhenIClickTheSignInButton_ThenIGetAnErrorMessage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Maximise the browser so it's full screen
                driver.Manage().Window.FullScreen();
                //Navigate to the AP site
                driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication");
                // grab the email input field
                IWebElement emailField = driver.FindElement(By.Id("email"));
                //Enter a valid email
                emailField.SendKeys("testing@snailmail.ccm");
                //Find password field
                var passwordField = driver.FindElement(By.Id("passwd"));
                //Enter a password of less than 5 char
                passwordField.SendKeys("four");
                //Get sign in button
                var signinButton = driver.FindElement(By.Id("SubmitLogin"));
                //Click the log in button
                signinButton.Click();
                //Find the alter elment
                var alert = driver.FindElement(By.ClassName("alert"));
                //Assert - correct error message is displayed
                Assert.That(alert.Text.Contains("Invalid password"));
            }
        }



        [Test]
        public void UsingMouseHoverAction_OnJohnLewis()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Maximise the browser so it's full screen
                //Navigate to the John Lewis site
                driver.Navigate().GoToUrl("https://www.johnlewis.com/");
                driver.Manage().Window.FullScreen();
                Thread.Sleep(2000);
                //Final 'accept all cookie's button
                var acceptAllCooiesButton = driver.FindElement(By.ClassName("c-button-yMKB7"));
                acceptAllCooiesButton.Click();
                Thread.Sleep(2000);
                //Find the home and garden element
                var homeAndGardenElement = driver.FindElement(By.LinkText("Home & Garden"));
                Thread.Sleep(2000);
                //Instantiate an action which we can use for more complex website interactions
                Actions action = new Actions(driver);
                //Get mouse to hover over the Home & garden element
                action.MoveToElement(homeAndGardenElement).Perform();
                Thread.Sleep(5000);
                //Grab bedding link
                var beddingsLink = driver.FindElement(By.LinkText("Bedding"));
                //Click beddings link
                beddingsLink.Click();
                //Check the title of the page is correct
                Assert.That(driver.Title.Contains("Bedding | Bed Sets and Bed Linen"));
            }
        }



        [Test]
        public void HandlingMulitpleWindows()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Maximise the browser so it's full screen
                driver.Manage().Window.FullScreen();
                driver.Navigate().GoToUrl("https://www.computerhope.com/");
                var twitterLink = driver.FindElement(By.LinkText("Twitter"));
                twitterLink.Click();
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                Thread.Sleep(5000);
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles[0]);
                Assert.That(driver.Title, Is.EqualTo("Computer Hope's Free Computer Help"));



                var helpLink = driver.FindElement(By.LinkText("Help"));
                helpLink.Click();
                Assert.That(driver.Title, Is.EqualTo("Computer Online Help"));
                driver.Navigate().Back();
                Assert.That(driver.Title, Is.EqualTo("Computer Hope's Free Computer Help"));

            }
        }

        [Test]
        public void UsingMouseHoverAction_OnJohnLewis_Electricals()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Maximise the browser so it's full screen
                //Navigate to the John Lewis site
                driver.Navigate().GoToUrl("https://www.johnlewis.com/");
                driver.Manage().Window.FullScreen();
                Thread.Sleep(2000);
                //Final 'accept all cookie's button
                var acceptAllCooiesButton = driver.FindElement(By.ClassName("c-button-yMKB7"));
                acceptAllCooiesButton.Click();
                Thread.Sleep(2000);
                //Find the home and garden element
                var electricals = driver.FindElement(By.LinkText("Electricals"));
                Thread.Sleep(2000);
                //Instantiate an action which we can use for more complex website interactions
                Actions action = new Actions(driver);
                //Get mouse to hover over the Home & garden element
                action.MoveToElement(electricals).Perform();
                Thread.Sleep(5000);
                //Grab bedding link
                var beddingsLink = driver.FindElement(By.LinkText("Televisions"));
                //Click beddings link
                beddingsLink.Click();
                //Check the title of the page is correct
                Assert.That(driver.Title.Contains("Television"));
            }
        }

        [Test]
        public void UsingIncorrectLogin_NoEntryFieldsEntered_OnJohnLewis()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Maximise the browser so it's full screen
                //Navigate to the John Lewis site
                driver.Navigate().GoToUrl("https://www.johnlewis.com/");
                driver.Manage().Window.FullScreen();
                Thread.Sleep(2000);
                //Final 'accept all cookie's button
                var acceptAllCooiesButton = driver.FindElement(By.ClassName("c-button-yMKB7"));
                acceptAllCooiesButton.Click();
                Thread.Sleep(2000);
                //Find the home and garden element
                var signIn = driver.FindElement(By.LinkText("Sign in"));
                Thread.Sleep(1000);
                signIn.Click();
                Thread.Sleep(2000);
                var login = driver.FindElement(By.Id("loginForm"));
                login.Click();
                Thread.Sleep(2000);
                var message = driver.FindElement(By.ClassName("_1rtCJ"));
                //Thread.Sleep(2000);
                Assert.That(message.Text.Contains("There are 2 errors below, " +
                    "please correct them and try again"));
            }
        }
    }
}

