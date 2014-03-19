using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;

namespace OCC.Locators
{
    [TestFixture]
    public class WorkingWithTables
    {
        const string Local = "http://localhost:8080/grid.html";
        // const string local = "http://sv-ui.herokuapp.com/login.html";
        IWebDriver browser;

        private By tableLocator = By.XPath(".//*[@id='carGrid']/table/tbody");


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
        public void Table_Contains_Two_BMW()
        {
            browser.Navigate().GoToUrl(Local);

            int numHits = 0;
            IWebElement table = browser.FindElement(tableLocator);
            IList<IWebElement> rows =
                table.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                if (row.Text.Contains("BMW"))
                {
                    numHits++;
                }
            }

            Assert.AreEqual(2, numHits);
        }


    }
}
