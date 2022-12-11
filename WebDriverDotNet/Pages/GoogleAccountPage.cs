using OpenQA.Selenium;

namespace WebDriverDotNet.Pages
{
    public class GoogleAccountPage
    {
        public readonly IWebDriver Driver;

        public readonly GmailLoginPage LoginPage; 

        public GoogleAccountPage(IWebDriver browser)
        {
            Driver = browser;
            Driver.Navigate().GoToUrl("https://account.google.com/");
            LoginPage = new GmailLoginPage(browser);
        }

        private readonly By GoToGoogleAccountIconLoc = By.XPath("/html/body/header/div[1]/div[5]/ul/li[2]");

        private readonly By PersonalInfoLoc = By.XPath("//li[@class='BBRNg'][2]");

        private readonly By AccountNameLoc = By.XPath("//a[contains(@aria-label,'Name')]");

        private readonly By EditNicknameIconLoc = By.XPath("//button[@aria-label='Edit Nickname']");
        
        private readonly By SaveNickNameIconLoc = By.XPath("//span[text()='Save']");

        public readonly By NickNameTextBoxLoc = By.XPath("//span[text()='Nickname']/following::input[@type='text']");

        public readonly By NickNameTextLoc = By.XPath("//div[contains(text(),'Nickname')]/following-sibling::div");

        public IWebElement GoToGoogleAccount => Driver.FindElement(GoToGoogleAccountIconLoc);

        public IWebElement PersonalInfo => Driver.FindElement(PersonalInfoLoc);

        public IWebElement AccountName => Driver.FindElement(AccountNameLoc);

        public IWebElement EditNickNameIcon => Driver.FindElement(EditNicknameIconLoc);

        public IWebElement NickNameTextBox => Driver.FindElement(NickNameTextBoxLoc);

        public IWebElement SaveNickName => Driver.FindElement(SaveNickNameIconLoc);

        public IWebElement NickNameText => Driver.FindElement(NickNameTextLoc);
    }
}
