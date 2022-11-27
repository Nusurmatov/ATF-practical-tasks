using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Locators
{
    [TestFixture]
    public sealed class LocatorTests
    {
        IWebDriver? driver;
        IWebElement? element;

        [SetUp]
        public void Setup()
        {
            var driverDir = System.IO.Path.GetDirectoryName(typeof(LocatorTests).Assembly.Location);
            driver = new ChromeDriver(driverDir);
            driver?.Navigate().GoToUrl("https://www.bbc.com/sport");
        }

        [Test]
        public void LinkTextLocatorTest()
        {
            // Search Box
            this.Wait(seconds: 30);
            element = driver?.FindElement(By.LinkText("Search BBC"));
            element?.Click();
            driver?.FindElement(By.Id("search-input")).SendKeys("Qatar 2022");

            Assert.Pass();
        }

        [Test]
        public void CssSelectorLocatorTest()
        {
            // All Sports Button
            this.Wait(seconds: 10);
            driver?.FindElement(By.CssSelector("div.ssrcss-1kl7qyq-StyledToggle ekfn8591"));

            Assert.Pass();
        }
        
        [Test]
        public void XPathLocatorTest()
        {
            // BBC Icon
            this.Wait(seconds: 30);
            driver?.FindElement(By.XPath("//div[@class='ssrcss-g08l83-GlobalNavigationItem e1gviwgp23']")).Click();

            Assert.Pass();
        }

        [Test]
        public void XPathAxesTest()
        {
            // All Sports Button
            this.Wait(seconds: 30);
            element = driver?.FindElement(By.XPath("//div[@class='ssrcss-cvutxg-ToggleContainer enbola60']/child::a"));
            element?.Click();

            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        private void Wait(int seconds)
        {
            if (driver != null)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
            }
        }
    }
}