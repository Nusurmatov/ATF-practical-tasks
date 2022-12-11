using OpenQA.Selenium;
using WebDriverDotNet.Helpers;
using SeleniumExtras;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace WebDriverDotNet.Pages
{
    public sealed class GmailLoginPage
    {
        public readonly string Email = "KhusniddinFake2@gmail.com";

        public readonly string Password = "FakePassword2";

        private readonly IWebDriver Driver;

        private readonly string Url = "https://www.google.com/intl/en/gmail/about/";

        private readonly By SignInIconLoc = By.XPath("//a[@data-action='sign in']");

        private readonly By EmailTextBoxLoc = By.Id("identifierId");

        private readonly By EmailSubmitIconLoc = By.Id("identifierNext");

        private readonly By ErrorEmailTextLoc = By.XPath("//div[contains((text()),'Enter a') or contains(text(), 'find your')]");

        public readonly By PasswordTextBoxLoc = By.XPath("//input[contains(@aria-label,'Enter')]");

        private readonly By PasswordSubmitIconLoc = By.Id("passwordNext");

        private readonly By ErrorPasswordTextLoc = By.XPath("//span[contains(text(),'Wrong password') or contains(text(),'Enter a password')]");

        public IWebElement SignInIcon => Driver.FindElement(SignInIconLoc);

        public IWebElement EmailTextBox => Driver.FindElement(EmailTextBoxLoc);

        public IWebElement EmailSubmitIcon => Driver.FindElement(EmailSubmitIconLoc);

        public IWebElement ErrorEmailText => Driver.FindElement(ErrorEmailTextLoc);

        public IWebElement PasswordTextBox => Driver.FindElement(PasswordTextBoxLoc);

        public IWebElement PasswordSubmitIcon => Driver.FindElement(PasswordSubmitIconLoc);

        public IWebElement ErrorPasswordText => Driver.FindElement(ErrorPasswordTextLoc);

        public GmailLoginPage(IWebDriver browser)
        {
            this.Driver = browser;
            Waits.ImplicitWait(this.Driver, seconds: 30);
        }

        public void EnterEmail(string email)
        {
            Waits.ImplicitWait(this.Driver, seconds: 20);
            EmailTextBox.Clear();
            EmailTextBox.SendKeys(email);
            EmailSubmitIcon.Click();
        }

        public void EnterPassword(string password)
        {
            PasswordTextBox.SendKeys(password);
            PasswordSubmitIcon.Click();
            Waits.ImplicitWait(this.Driver, seconds: 10);
        }

        public void Navigate() => this.Driver.Navigate().GoToUrl(this.Url);
    }
}