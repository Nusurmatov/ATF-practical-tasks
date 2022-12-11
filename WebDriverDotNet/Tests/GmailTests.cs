using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverDotNet.Pages;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverDotNet.Helpers;

namespace WebDriverDotNet.Tests
{
    [TestFixture]
    public sealed class GmailTests
    {
        IWebDriver? browser;
        GmailMainPage? gmail;

        [SetUp]
        public void Setup()
        {
            browser = new ChromeDriver();
            gmail = new GmailMainPage(browser);
        }

        [Test]
        public void LoginTest()
        {
            // Wrong Email
            gmail?.LoginPage.Navigate();
            gmail?.LoginPage.SignInIcon.Click();
            gmail?.LoginPage.EnterEmail("wrong");
            Assert.IsTrue(gmail?.LoginPage.ErrorEmailText.Displayed);

            // Empty Email
            gmail?.LoginPage.EnterEmail(string.Empty);
            Assert.IsTrue(gmail?.LoginPage.ErrorEmailText.Displayed);

            // Wrong Password
            gmail?.LoginPage.EnterEmail(gmail.LoginPage.Email);
            gmail?.LoginPage.EnterPassword("WrongPassword");
            Assert.IsTrue(gmail?.LoginPage.ErrorPasswordText.Text.Contains("Wrong password"));

            // Empty Password
            gmail?.LoginPage.EnterPassword(string.Empty);
            Assert.IsTrue(gmail?.LoginPage.ErrorPasswordText.Text.Contains("Enter a password"));

            // Correct password
            gmail?.LoginPage.EnterPassword(gmail.LoginPage.Password);
            Assert.IsTrue(gmail?.IsDisplayed(gmail.ComposeIcon));
        }

        [Test]
        public void VerifyMessageTest()
        {
            var outlook = new OutlookMainPage(new ChromeDriver());
            var mail = new Mail(outlook.OtherEmail);
            gmail.NewMail = mail;
            outlook.LoginPage.EnterEmail(outlook.LoginPage.Email);
            outlook.LoginPage.EnterPassword(outlook.LoginPage.Password);
            outlook.LoginPage.NoIcon.Click();
            outlook.SendMessage(mail);
            outlook.Driver.Close();

            gmail?.LoginPage.Navigate();
            gmail?.LoginPage.SignInIcon.Click();
            gmail?.LoginPage.EnterEmail(gmail.LoginPage.Email);
            gmail?.LoginPage.EnterPassword(gmail.LoginPage.Password);

            gmail?.Wait.Until(ExpectedConditions.StalenessOf(gmail?.UnreadMails[0]));
            gmail?.UnreadMails[0].Click();
            Assert.IsTrue(gmail?.MessageBox.Text.Contains(mail.SecretPassword));
        }

        [Test]
        public void ChangeNickNameTest()
        {
            GoogleAccountPage gmailAccount = new GoogleAccountPage(browser);
            gmailAccount?.GoToGoogleAccount.Click();
            gmailAccount?.LoginPage.EnterEmail(gmailAccount.LoginPage.Email);
            gmailAccount?.LoginPage.EnterPassword(gmailAccount.LoginPage.Password);
            gmailAccount?.PersonalInfo.Click();
            gmailAccount?.AccountName.Click();
            gmailAccount?.EditNickNameIcon.Click();
            
            string? preNickName = gmailAccount?.NickNameTextBox.GetAttribute("value");
            string newNickName;
            if (preNickName?.ToUpperInvariant() == "NUSURMATOV")
            {
                newNickName = "NXR";
            }
            else
            {
                newNickName = "Nusurmatov";
            }

            gmailAccount?.NickNameTextBox.Click();
            gmailAccount?.NickNameTextBox.Clear();
            gmailAccount?.NickNameTextBox.SendKeys(newNickName);
            gmailAccount?.SaveNickName.Click();

            Assert.AreEqual(newNickName, gmailAccount?.NickNameText.Text);
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