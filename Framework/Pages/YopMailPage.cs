using Framework.Utils;
using OpenQA.Selenium;
using System.Linq;

namespace Framework.Pages
{
    public class YopMailPage : AbstractPage
    {
        public override string Url => "https://yopmail.com/";

        private readonly By RandomEmailAddressIconLocator = By.XPath("//*[contains(@title, 'Disposable Email')]");

        private readonly By LoginTextBoxLocator = By.Id("login");

        private readonly By LoginButtonLocator = By.Id("refreshbut");

        private readonly By RandomEmailTextBoxLocator = By.Id("geny");

        private readonly By EstimatedMonthlyCostMessageLocator = By.XPath("//*[contains(text(),'Estimated Monthly Cost:')]");

        public IWebElement RandomEmailAddressIcon => base.WaitAndFindElement(RandomEmailAddressIconLocator);

        public IWebElement LoginTextBox => base.WaitAndFindElement(LoginTextBoxLocator);

        public IWebElement LoginButton => base.WaitAndFindElement(LoginButtonLocator);

        public IWebElement RandomEmailTextBox => base.WaitAndFindElement(RandomEmailTextBoxLocator);

        public IWebElement EstimatedMonthlyCostMessage => base.WaitAndFindElement(EstimatedMonthlyCostMessageLocator);

        public YopMailPage(IWebDriver driver) : base(driver) { }

        public string GenerateRandomEmail(IWebDriver driver)
        {
            string temporaryEmail;

            JavaScriptExecutorUtil.OpenNewTab(Driver);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            base.GoTo();
            this.RandomEmailAddressIcon.Click();
            temporaryEmail = RandomEmailTextBox.Text;
            driver.Close();

            driver.SwitchTo().Window(driver.WindowHandles.First());
            return temporaryEmail;
        }
    
        public string GetMessageFromInbox(string mailAddress)
        {
            string message;

            JavaScriptExecutorUtil.OpenNewTab(Driver);
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            base.GoTo();
            LoginTextBox.Clear();
            LoginTextBox.SendKeys(mailAddress);
            LoginButton.Click();

            Driver.SwitchTo().Frame("ifmail");
            message = EstimatedMonthlyCostMessage.Text;
            Driver.SwitchTo().DefaultContent();
            Driver.Close();

            Driver.SwitchTo().Window(Driver.WindowHandles.First());
            return message;
        }
    }
}
