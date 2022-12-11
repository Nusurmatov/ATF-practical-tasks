using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverDotNet.Helpers
{
    public static class Waits
    {
        public static void ImplicitWait(IWebDriver? driver, int seconds)
        {
            if (driver != null)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
            }
        }

        public static bool ExplicitWait(IWebDriver driver, int seconds, Func<IWebDriver, bool> condition)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            return wait.Until(condition);
        }
    }
}