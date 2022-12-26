using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using WebDriverDotNet.Helpers;

namespace WebDriverDotNet.Pages
{
    public sealed class OutlookMainPage
    {
        public readonly IWebDriver Driver;
        
        public readonly WebDriverWait Wait; 

        public readonly OutlookLoginPage LoginPage;

        public readonly string OtherEmail = "KhusniddinFake2@gmail.com";

        private readonly By NewMailIconLoc = By.XPath("//i[@data-icon-name='MailRegular']");

        private readonly By EmailToLoc = By.XPath("//div[@aria-label='To']");

        private readonly By SubjectBoxLoc = By.XPath("//input[@aria-label='Add a subject']");

        private readonly By MessageBoxLoc = By.CssSelector("div.elementToProof");

        private readonly By SendIconLoc = By.CssSelector("[title='Send (Ctrl+Enter)']");

        private readonly By ToggleLeftPaneLoc = By.XPath("//i[@data-icon-name='GlobalNavButton']");

        private readonly By SentItemsIconLoc = By.XPath("//i[@data-icon-name='SendRegular']");

        public readonly By TodaysSentmailsLoc = By.XPath("//div[@id='groupHeaderToday']/following-sibling::*/div");

        public IWebElement NewMailIcon => Driver.FindElement(NewMailIconLoc);

        public IWebElement EmailTo => Driver.FindElement(EmailToLoc); 

        public IWebElement SubjectBox => Driver.FindElement(SubjectBoxLoc); 

        public IWebElement MessageBox => Driver.FindElement(MessageBoxLoc);

        public IWebElement SendIcon => Driver.FindElement(SendIconLoc); 

        public IWebElement ToggleLeftPane => Driver.FindElement(ToggleLeftPaneLoc); 

        public IWebElement SentItemsIcon => Driver.FindElement(SentItemsIconLoc);

        public int TodaysSentMailsCount => Driver.FindElements(TodaysSentmailsLoc).Count;

        public OutlookMainPage(IWebDriver browser)
        {
            this.Driver = browser;
            this.LoginPage = new OutlookLoginPage(browser);
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(15));
        }


        public void SendMessage(Mail mail)
        {
            Wait.Until(ExpectedConditions.StalenessOf(NewMailIcon));
            NewMailIcon.Click();
            EmailTo.SendKeys(mail.Email);
            SubjectBox.SendKeys(mail.Subject);
            MessageBox.SendKeys(mail.Message);
            SendIcon.Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(NewMailIconLoc));
        }

        public bool IsDisplayed(IWebElement element)
        {
            try
            {
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
