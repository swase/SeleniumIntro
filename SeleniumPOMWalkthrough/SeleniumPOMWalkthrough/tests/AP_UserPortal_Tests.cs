using OpenQA.Selenium.Chrome;
using SeleniumPOMWalkthrough.lib.pages;
using NUnit.Framework;

namespace SeleniumPOMWalkthrough.tests
{
    class AP_UserPortal_Tests
    {
        public AP_Website<ChromeDriver> AP_Website = new AP_Website<ChromeDriver>();

        [SetUp]
        public void SetUp()
        {
            //get Access to user Site
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.InputUserName("standard_user");
            AP_Website.AP_HomePage.InputPassword("secret_sauce");
            AP_Website.AP_HomePage.VisitSignInPage();
        }

        [Test]
        public void WhenImOnTHeInventoryPage_WhenIClickTheBasketPage_ThenShouldBeAbleToViewMyCart()
        {
            //Test inventoryPage
            AP_Website.AP_UserPage.GoToUserPage();
            AP_Website.AP_UserPage.ClickShoppingCartButton();
            var result = AP_Website.AP_UserPage.GetPageTitle();
            Assert.That(result, Does.Contain("Swag Labs"));
        }

        [Test]
        public void WhenImOnTHeInventoryPage_WhenIClickAddToCar_ForBackPack_ThenCartBagShouldBe1()
        {

            //Test inventoryPage
            AP_Website.AP_UserPage.ClickAddToCartBackPack();
            string result = AP_Website.AP_UserPage.GetShoppingCartBadge();
            Assert.That(result, Is.EqualTo("1"));
        }

        [Test]
        public void GivenIAddedItemToCar_WhenIClickTheShoppingCart_IShouldLandOnTheCheckoutPage_WithItemListedCorrectly()
        {

            //Add item to cart and click shopping cart
            AP_Website.AP_UserPage.ClickAddToCartBackPack();
            AP_Website.AP_UserPage.ClickShoppingCartButton();

            //Test if added to inventory
            string result = AP_Website.AP_UserPage.GetInventoryListName();
            Assert.That(result, Is.EqualTo("Sauce Labs Backpack"));
        }

        [Test]
        public void GivenImnCheckoutPage_WhenIClickContinueShoppingButton_IReturnToInventoryPage()
        {

            //Add item to cart and click shopping cart
            AP_Website.AP_UserPage.ClickAddToCartBackPack();
            AP_Website.AP_UserPage.ClickShoppingCartButton();

            //Test if added to inventory
            AP_Website.AP_UserPage.ClickContinueShoppingButton();
            var result = AP_Website.AP_UserPage.GetPageTitle();
            Assert.That(result, Does.Contain("Swag Labs"));
        }

        [TearDown]
        public void CleanUp()
        {
            AP_Website.SeleniumDriver.Quit();
            AP_Website.SeleniumDriver.Dispose();
        }
    }
}
