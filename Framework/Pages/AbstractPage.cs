using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Framework.Pages
{
    public abstract class AbstractPage
    {
        private const int WaitTimeOut = 15;

        public virtual string Url => "https://cloud.google.com/";

        public readonly IWebDriver Driver;

        public readonly WebDriverWait Wait;
        
        protected AbstractPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WaitTimeOut));
            this.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WaitTimeOut);
        }

        public void GoTo() => this.Driver.Navigate().GoToUrl(this.Url);

        public IWebElement WaitAndFindElement(By locator) => this.Wait.Until(ExpectedConditions.ElementExists(locator));
    }
}
