using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace SeleniumPOMWalkthrough.lib.driver_config
{
    public class SeleniumDriverConfig<T> where T : IWebDriver, new()
    {
        public IWebDriver Driver { get; set; }

        public SeleniumDriverConfig(int pageLoadInSecs, int implicitWaitInSec)
        {
            Driver = new T();
            DriverSetup(pageLoadInSecs, implicitWaitInSec);
        }

        private void DriverSetup(int pageLoadInSecs, int implicitWaitInSec)
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSecs);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSec);


        }

        public void SetHeadlessBrowser() 
        {
            Driver = new T();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
        }
    }
}
