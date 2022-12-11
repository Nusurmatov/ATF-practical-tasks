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
            
	        if (driver != null)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
	    }

        [Test]
        public void LinkTextLocatorTest()
        {
            // Search Box
            /// element = driver?.FindElement(By.LinkText("Search BBC"));
            element = driver?.FindElement(By.XPath("//div[@aria-label='Search BBC']"));
            
            element?.Click();
            driver?.FindElement(By.Id("search-input")).SendKeys("Qatar 2022");

            Assert.Pass();
        }

        [Test]
        public void CssSelectorLocatorTest()
        {
            // All Sports Button
            /// driver?.FindElement(By.CssSelector("div.ssrcss-1kl7qyq-StyledToggle ekfn8591"));
            driver?.FindElement(By.XPath("//a[@aria-controls='product-navigation-menu']"));

            Assert.Pass();
        }
        
        [Test]
        public void XPathLocatorTest()
        {
            // BBC Icon
            /// driver?.FindElement(By.XPath("//div[@class='ssrcss-g08l83-GlobalNavigationItem e1gviwgp23']")).Click();
            driver?.FindElement(By.XPath("//*[@aria-label='BBC']//a"));

            Assert.Pass();
        }

        [Test]
        public void XPathAxesTest()
        {
            // All Sports Button
            /// element = driver?.FindElement(By.XPath("//div[@class='ssrcss-cvutxg-ToggleContainer enbola60']/child::a"));
            driver?.FindElement(By.XPath("//div[@id='product-navigation-menu']/descendant::a[1]"));
           
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
    }
}