using OpenQA.Selenium;

namespace Framework.Pages
{
    public class LoginPage : AbstractPage
    {
        private readonly By EmailTextBoxLoc = By.Id("identifierId");

        private readonly By EmailSubmitIconLoc = By.Id("identifierNext");

        private readonly By PasswordSubmitIconLoc = By.Id("passwordNext");

        public readonly By PasswordTextBoxLoc = By.XPath("//input[contains(@aria-label,'Enter')]");

        private readonly By ErrorEmailTextLoc = By.XPath("//div[contains((text()),'Enter a') or contains(text(), 'find your')]");

        private readonly By ErrorPasswordTextLoc = By.XPath("//span[contains(text(),'Wrong password') or contains(text(),'Enter a password')]");

        public IWebElement EmailTextBox => base.WaitAndFindElement(EmailTextBoxLoc);

        public IWebElement EmailSubmitIcon => base.WaitAndFindElement(EmailSubmitIconLoc);

        public IWebElement ErrorEmailText => base.WaitAndFindElement(ErrorEmailTextLoc);

        public IWebElement PasswordTextBox => base.WaitAndFindElement(PasswordTextBoxLoc);

        public IWebElement PasswordSubmitIcon => base.WaitAndFindElement(PasswordSubmitIconLoc);

        public IWebElement ErrorPasswordText => base.WaitAndFindElement(ErrorPasswordTextLoc);

        public LoginPage(IWebDriver browser) : base(browser) { }

        public void Login(string email, string password)
        {
            EmailTextBox.Clear();
            EmailTextBox.SendKeys(email);
            EmailSubmitIcon.Click();

            EmailTextBox.Clear();
            PasswordTextBox.SendKeys(password);
            PasswordSubmitIcon.Click();
        }
    }
}