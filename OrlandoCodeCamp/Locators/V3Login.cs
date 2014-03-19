using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;

namespace OCC.Locators
{
    [TestFixture]
    public class V3Login
    {
        const string Local = "http://localhost:8080/login.html";
        // const string local = "http://sv-ui.herokuapp.com/login.html";
        IWebDriver browser;

        private Dictionary<string, By> InputFields = new Dictionary<string, By>() 
        {
            {"username", By.XPath(".//*[@id='username']")},
            {"password", By.XPath(".//*[@id='password']")},
        };

        private Dictionary<string, By> Buttons = new Dictionary<string, By>() 
        {
            {"login", By.XPath(".//*[@id='login']")},
        };

        private string USERNAME = "label[for='username']+input";
        private string PASSWORD = "label[for='password']+input";
        private string LOGINBUTTON = "button[value='login']";


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
        public void Can_log_on_to_system_using_Better_XPATH()
        {
            browser.Navigate().GoToUrl(Local);
            browser.FindElement(InputFields["username"]).SendKeys("Username");
            browser.FindElement(InputFields["password"]).SendKeys("abc123");
            browser.FindElement(Buttons["login"]).Click();

            Assert.IsTrue(browser.Title.Equals("User Interface Samples"),
                "Page title should be 'User Interface Samples' but is '" + browser.Title + "' instead.");
        }

        [Test]
        public void Can_log_on_to_system_using_CSS()
        {
            browser.Navigate().GoToUrl(Local);

            browser.FindElement(
                By.CssSelector(this.USERNAME))
                .SendKeys("Username");
            browser.FindElement(
                By.CssSelector(this.PASSWORD))
                .SendKeys("abc123");
            browser.FindElement(
                By.CssSelector(this.LOGINBUTTON))
                .Click();


            Assert.IsTrue(browser.Title.Equals("User Interface Samples"),
                "Page title should be 'User Interface Samples' but is '" + browser.Title + "' instead.");
        }


    }
}
