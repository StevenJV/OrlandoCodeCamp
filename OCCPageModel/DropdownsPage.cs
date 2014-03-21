using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace OCCPageModel
{
    public class DropdownsPage
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
        private Dictionary<string, By> DropdownsReady = new Dictionary<string, By>()
        {
            {"make", By.XPath("id('dropdown_1')/option[text()='select']")},
            {"model", By.XPath("id('dropdown_2')/option[text()='select']")},
            {"color", By.XPath("id('dropdown_3')/option[text()='select']")}, 
        }; 
        private Dictionary<string, By> Answers = new Dictionary<string, By>() 
        {
            {"make", By.Id("YourMakeChoice")},
            {"model", By.Id("YourModelChoice")},
            {"color", By.Id("YourColorChoice")},
        };

        public DropdownsPage()
        {
            browser = new FirefoxDriver();
            browser.Navigate().GoToUrl(Local);
        }

        ~DropdownsPage()
        {
            browser.Quit();
        }


        private void WaitForDropdownListToAppear(string dropdownName)
        {             
            const int timeSpanInseconds = 10;
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(timeSpanInseconds));
            wait.Until(ExpectedConditions.ElementExists(DropdownsReady[dropdownName]));
        }

        public void SelectFromDropdown(string dropdownName, string itemToSelect)
        {
            WaitForDropdownListToAppear(dropdownName);
            IWebElement makeDropDown = browser.FindElement(Dropdowns[dropdownName]);
            var makeSelect = new SelectElement(makeDropDown);
            makeSelect.SelectByText(itemToSelect);
        }


        public string SelectedColor()
        {
            return browser.FindElement(Answers["color"]).Text;
        }
    }
}
