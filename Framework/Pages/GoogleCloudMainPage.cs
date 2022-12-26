using OpenQA.Selenium;

namespace Framework.Pages
{
    public class GoogleCloudMainPage : AbstractPage
    {
        private readonly By SignInIconLocator = By.CssSelector("[track-name=signIn]");

        private readonly By SearchBoxLocator = By.CssSelector("[aria-label=Search]");

        private readonly By GoogleCloudPricingCalculatorLinkLocator 
            = By.XPath("//div[@class='gsc-thumbnail-inside']/descendant::b[contains(text(), 'Google Cloud Pricing Calculator')]");

        public IWebElement SignInIcon => base.WaitAndFindElement(SignInIconLocator);

        public IWebElement SearchBox => base.WaitAndFindElement(SearchBoxLocator);

        public IWebElement GoogleCloudPricingCalculatorLink => base.WaitAndFindElement(GoogleCloudPricingCalculatorLinkLocator);

        public GoogleCloudMainPage(IWebDriver driver) : base(driver) { }  

        public void GoToPricingCalculatorPage()
        {
            this.SearchBox.Click();
            this.SearchBox.SendKeys("Google Cloud Pricing Calculator" + Keys.Enter);
            this.GoogleCloudPricingCalculatorLink.Click();
        }

        public void GoToSignInPage() => this.SignInIcon.Click();
    }
}
