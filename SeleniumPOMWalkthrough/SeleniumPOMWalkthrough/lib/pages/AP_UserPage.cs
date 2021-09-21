using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOMWalkthrough.lib.pages
{
    public class AP_UserPage
    {
        private IWebDriver _seleniumDriver;
        private string _userPageURL = AppConfigReader.UserPageURL;
        private IWebElement _shoppingCartButton => _seleniumDriver.FindElement(By.Id("shopping_cart_container"));
        private IWebElement _header => _seleniumDriver.FindElement(By.Id("header_container"));
        private IWebElement _shoppingCartBadge => _seleniumDriver.FindElement(By.ClassName("shopping_cart_badge"));
        private IWebElement _addToCartBackpack => _seleniumDriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));

        private IWebElement _inventoryListName => _seleniumDriver.FindElement(By.ClassName("inventory_item_name"));
        private IWebElement _continuShoppingButton => _seleniumDriver.FindElement(By.Id("continue-shopping"));
        


        public AP_UserPage(IWebDriver seleniumDriver)
        {
            this._seleniumDriver = seleniumDriver;
        }

        public void GoToUserPage() => _seleniumDriver.Navigate().GoToUrl(_userPageURL);
        public void ClickShoppingCartButton() => _shoppingCartButton.Click();
        public string GetHeaderText() => _header.Text;
        public void ClickAddToCartBackPack() => _addToCartBackpack.Click();
        public string GetShoppingCartBadge() => _shoppingCartBadge.Text;
        public string GetInventoryListName() => _inventoryListName.Text;
        public void ClickContinueShoppingButton() => _continuShoppingButton.Click();
        public string GetPageTitle() => _seleniumDriver.Title;
    }

}
