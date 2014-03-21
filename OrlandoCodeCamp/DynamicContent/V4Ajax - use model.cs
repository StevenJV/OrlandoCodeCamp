using NUnit.Framework;
using OCCPageModel;

namespace OCC.DynamicContent
{
    [TestFixture]
    public class V4Ajax
    {
        [Test]
        public void Dropdown_Selections_Are_Displayed_WaitForData()
        {
            var thisPage = new DropdownsPage();

            thisPage.SelectFromDropdown("make", "Ferrari");
            thisPage.SelectFromDropdown("model", "California");
            thisPage.SelectFromDropdown("color", "Red");
            StringAssert.AreEqualIgnoringCase("Red", thisPage.SelectedColor(), "Color not displaed correctly.");
        }


    }
}
