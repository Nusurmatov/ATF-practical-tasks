using NUnit.Framework;
using OpenQA.Selenium;
using Framework.Driver;
using Framework.Pages;
using System;
using Framework.Utils;
using NUnit.Framework.Interfaces;

namespace Framework
{
    public class BaseTest
    {
        protected IWebDriver Driver;

        protected LoginPage LoginPage;

        protected GoogleCloudMainPage GoogleCloudMainPage;

        protected GoogleCloudPricingCalculatorPage PricingCalculatorPage;

        protected YopMailPage YopMailPage;

        protected UserCreatorUtil User;

        [SetUp]
        public void SetUp()
        {
            BrowserDrivers browserType;
            var environment = Environment.GetEnvironmentVariable("Environment") ?? "Dev";
            User = new UserCreatorUtil(environment);
            Enum.TryParse(User.Browser, ignoreCase: true, out browserType);
            Console.WriteLine(User.Name);
            Console.WriteLine(User.Browser);

            this.Driver = DriverSingleton.GetInstance(browserType);
            this.LoginPage = new LoginPage(this.Driver);
            this.GoogleCloudMainPage = new GoogleCloudMainPage(this.Driver);
            this.PricingCalculatorPage = new GoogleCloudPricingCalculatorPage(this.Driver);
            this.YopMailPage = new YopMailPage(this.Driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                ScreenshotUtil.TakeAndSaveScreenshot(Driver);
            }

            DriverSingleton.CloseBrowser();
        }
    }
}