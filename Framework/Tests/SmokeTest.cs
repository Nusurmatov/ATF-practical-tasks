using NUnit.Framework;
using Framework.Pages;
using System;

namespace Framework.Tests
{
    [TestFixture]
    public class SmokeTest : BaseTest
    {
        [Test]
        [Category("Smoke")]
        [Category("Regression")]
        public void GoToPricingCalculaterPageTest()
        {
            GoogleCloudMainPage.GoTo();
            GoogleCloudMainPage.GoToPricingCalculatorPage();
            Console.WriteLine(Driver.Title);

            Assert.IsTrue(Driver.Title.Contains("Google Cloud Pricing Calculator"));
        }

        [Test]
        [Category("Smoke")]
        [Category("Regression")]
        public void LoginTest()
        {
            GoogleCloudMainPage.GoTo();
            GoogleCloudMainPage.SignInIcon.Click();
            LoginPage.Login(email: YopMailPage.GenerateRandomEmail(Driver), password: "passwordToBeFailed");
                
            Assert.IsTrue(GoogleCloudMainPage.SearchBox.Displayed);
        }
    }
}