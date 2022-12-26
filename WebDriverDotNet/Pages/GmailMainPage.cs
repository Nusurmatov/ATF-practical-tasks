using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using WebDriverDotNet.Helpers;

namespace WebDriverDotNet.Pages
{
    public class GmailMainPage
    {
        public readonly IWebDriver Driver;

        public readonly GmailLoginPage LoginPage;

        public readonly WebDriverWait Wait;

        public Mail? NewMail { get; set; } 

        public readonly string OtherEmail = "KhusniddinFake1@outlook.com";

        private readonly By ComposeIconLoc = By.XPath("//div[text()='Compose']");

        public readonly By UnreadMailsLoc = By.XPath("//colgroup/following::tr");

        public readonly By MessageBoxLoc = By.XPath("//div[@style='display:']/descendant::*/span");

        public ReadOnlyCollection<IWebElement> UnreadMails => Driver.FindElements(UnreadMailsLoc); 

        public IWebElement MessageBox => Driver.FindElement(By.XPath($"//span[contains(@style, 'font-family')]")); 

        public IWebElement ComposeIcon => Driver.FindElement(ComposeIconLoc);

        public GmailMainPage(IWebDriver browser)
        {
            this.Driver = browser;
            this.LoginPage = new GmailLoginPage(browser);
            Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(15));
        }
    
        public bool IsDisplayed(IWebElement element)
        {
            try
            {
                Waits.ImplicitWait(this.Driver, seconds: 10);
                bool result = element.Displayed;
                return result;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
