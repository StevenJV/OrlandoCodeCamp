using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace OCC.DynamicContent
{
    [TestFixture]
    public class V1Ajax
    {
        const string Local = "http://localhost:8080/dropdown.html";
        // const string local = "http://sv-ui.herokuapp.com/dropdown.html"; 
        IWebDriver browser;

        private Dictionary<string, By> Dropdowns = new Dictionary<string, By>() 
        {
            {"make", By.Id("dropdown_1")},
            {"model", By.Id("dropdown_2")},
            {"color", By.Id("dropdown_3")},
        };
        private Dictionary<string, By> Answers = new Dictionary<string, By>() 
        {
            {"make", By.Id("YourMakeChoice")},
            {"model", By.Id("YourModelChoice")},
            {"color", By.Id("YourColorChoice")},
        };

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
        public void Dropdown_Selections_Are_Displayed()
        {
            browser.Navigate().GoToUrl(Local);

            IWebElement makeDropDown = browser.FindElement(Dropdowns["make"]);
            var makeSelect = new SelectElement(makeDropDown);
            makeSelect.SelectByText("Ferrari");

            IWebElement maodelDropDown = browser.FindElement(Dropdowns["model"]);
            var modelSelect = new SelectElement(maodelDropDown);
            modelSelect.SelectByText("California");

            IWebElement colorDropDown = browser.FindElement(Dropdowns["color"]);
            var colorSelect = new SelectElement(colorDropDown);
            colorSelect.SelectByText("Red");


            Assert.AreEqual("Red",browser.FindElement(Answers["color"]).Text, "wrong color");


        }
    }
}
