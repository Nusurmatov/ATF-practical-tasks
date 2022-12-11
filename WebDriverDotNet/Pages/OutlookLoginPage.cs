using OpenQA.Selenium;
using WebDriverDotNet.Helpers;

namespace WebDriverDotNet.Pages
{
    public sealed class OutlookLoginPage
    {
        public readonly string Email = "KhusniddinFake1@outlook.com";

        public readonly string Password = "FakePassword1";

        private readonly IWebDriver Driver;
        
        private readonly string Url = "https://outlook.live.com/owa/";

        private readonly By SignInIconLoc = By.XPath("//a[@data-task='signin']");

        private readonly By EmailTextBoxLoc = By.XPath("//input[@type='email']");

        private readonly By EmailSubmitIconLoc = By.XPath("//input[@type='submit']");

        private readonly By ErrorEmailTextLoc = By.Id("usernameError");

        private readonly By PasswordTextBoxLoc = By.XPath("//input[@type='password']");

        private readonly By PasswordSubmitIconLoc = By.XPath("//input[@value='Sign in']");

        private readonly By ErrorPasswordTextLoc = By.Id("passwordError");

        private readonly By NoIconLoc = By.XPath("//input[@type='button']");

        public IWebElement SignInIcon => Driver.FindElement(SignInIconLoc); 

        public IWebElement EmailTextBox => Driver.FindElement(EmailTextBoxLoc); 

        public IWebElement EmailSubmitIcon => Driver.FindElement(EmailSubmitIconLoc);

        public IWebElement ErrorEmailText => Driver.FindElement(ErrorEmailTextLoc);

        public IWebElement PasswordTextBox => Driver.FindElement(PasswordTextBoxLoc); 

        public IWebElement PasswordSubmitIcon => Driver.FindElement(PasswordSubmitIconLoc); 

        public IWebElement ErrorPasswordText => Driver.FindElement(ErrorPasswordTextLoc);

        public IWebElement NoIcon => Driver.FindElement(NoIconLoc);  
        
        public OutlookLoginPage(IWebDriver browser)
        {
            this.Driver = browser;
            Driver.Navigate().GoToUrl(this.Url);
            Waits.ImplicitWait(this.Driver, seconds: 30);
            SignInIcon.Click();
        }    
    
        public void EnterEmail(string email)
        {
            EmailTextBox.Clear();
            EmailTextBox.SendKeys(email);
            EmailSubmitIcon.Click();
            Waits.ImplicitWait(this.Driver, seconds: 10);
        }

        public void EnterPassword(string password)
        {
            PasswordTextBox.Clear();
            PasswordTextBox.SendKeys(password);
            PasswordSubmitIcon.Click();
            Waits.ImplicitWait(this.Driver, seconds: 10);
        }
    }
}
