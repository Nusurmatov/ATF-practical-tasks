using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverDotNet.Pages;
using System;
using WebDriverDotNet.Helpers;

namespace WebDriverDotNet.Tests
{
    [TestFixture]
    public sealed class OutlookTests
    {
        IWebDriver? browser;
        OutlookMainPage? outlook;

        [SetUp]
        public void Setup()
        {
            browser = new ChromeDriver();
            outlook = new OutlookMainPage(browser);
        }

        [Test]
        public void LoginTest()
        {
            // Wrong Email
            outlook?.LoginPage.EnterEmail("wrong");
            Assert.IsTrue(outlook?.LoginPage.ErrorEmailText.Displayed);

            // Empty Email
            outlook?.LoginPage.EnterEmail(string.Empty);
            Assert.IsTrue(outlook?.LoginPage.ErrorEmailText.Displayed);

            // Wrong Password
            outlook?.LoginPage.EnterEmail(outlook.LoginPage.Email);
            outlook?.LoginPage.EnterPassword("WrongPassword");
            Assert.IsTrue(outlook?.LoginPage.ErrorPasswordText.Displayed);

            // Empty Password
            outlook?.LoginPage.EnterPassword(string.Empty);
            Assert.IsTrue(outlook?.LoginPage.ErrorPasswordText.Displayed);

            // Correct password
            outlook?.LoginPage.EnterPassword(outlook.LoginPage.Password);
            outlook?.LoginPage.NoIcon.Click();
            Assert.IsTrue(outlook?.IsDisplayed(outlook.NewMailIcon));
        }

        [Test]
        public void SendMessageTest()
        {
            outlook?.LoginPage.EnterEmail(outlook.LoginPage.Email);
            outlook?.LoginPage.EnterPassword(outlook.LoginPage.Password);
            outlook?.LoginPage.NoIcon.Click();
            outlook?.SendMessage(new Mail(outlook.OtherEmail));

            Assert.IsTrue(outlook?.NewMailIcon.Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            if (browser != null)
            {
                browser.Quit();
            }
        }
    }
}
