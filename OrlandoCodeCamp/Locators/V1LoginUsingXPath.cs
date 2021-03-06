﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace OCC.Locators
{
    [TestFixture]
    public class V1LoginUsingXPath
    {
        private const string Local = "http://localhost:8080/login.html";
        // const string local = "http://sv-ui.herokuapp.com/login.html";
        IWebDriver browser;
        
        [TestFixtureSetUp]
        public void Run_once_before_any_other_tests()
        {
            browser = new FirefoxDriver();
        }

        [TestFixtureTearDown]
        public void Run_after_all_other_tests_are_done()
        {
            browser.Quit();
        }


        [Test]
        public void Can_log_on_to_system_using_XPATH()
        {
            browser.Navigate().GoToUrl(Local);
            browser.FindElement(
                        By.XPath("html/body/p[2]/input"))
                   .SendKeys("Username");
            browser.FindElement(
                        By.XPath("html/body/p[3]/input"))
                   .SendKeys("abc123");
            browser.FindElement(
                        By.XPath("html/body/p[4]/button"))
                   .Click();

            Assert.IsTrue(browser.Title.Equals("User Interface Samples"), 
                "Page title should be 'User Interface Samples' but is '" + browser.Title + "' instead.");
        }


    }
}
