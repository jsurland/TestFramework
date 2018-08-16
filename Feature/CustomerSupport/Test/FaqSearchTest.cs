using System.Globalization;
using Feature.CustomerSupport.Model;
using Foundation.UserInterfaceSupport.Model;
using Foundation.WebDriverTools.Application.Services;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Feature.CustomerSupport.Test
{
    public class FaqSearchTest : PageObjects
    {
        private readonly UserInterfaceBase _userInterface;

        public FaqSearchTest(UserInterfaceBase userInterface) : base(userInterface.WebDriver)
        {
            _userInterface = userInterface;
        }

        public void SearchForAndFind(string searchString, bool reverseExpectations)
        {
            _userInterface.DefaultWait.Until(e => SearchBox.Enabled && SearchBox.Displayed);
            SearchBox.Click();
            SearchBox.SendKeys(searchString, true);

            _userInterface.DefaultWait.Until(w => ResultHeader.Displayed);
            Assert.IsTrue(ResultHeader.Text.Contains(searchString));

            _userInterface.WaitForUiStatesService.WaitForElementCountGreaterThanZero(SearchResultList, 30);
            var resultList = _userInterface.WebDriver.FindElements(SearchResultList);
            if (reverseExpectations)
            {
                Assert.IsTrue(resultList.Count == 1, $"FAQ List found too many results. Searchstring was: '{searchString}', Search results was: {resultList.Count}.");
                Assert.IsTrue(resultList[0].Text.ToUpper().Contains("INGEN RESULTATER"), $"FAQ List found did not find 'Ingen resultater'. Searchstring was: '{searchString}'.");
                return;
            }

            Assert.IsTrue(resultList.Count > 0, $"FAQ List did not find any results. Searchstring was: '{searchString}'.");
            Assert.IsTrue(!resultList[0].Text.ToUpper().Contains("INGEN RESULTATER"), $"FAQ List did not find any results. Searchstring was: '{searchString}'.");
        }
    }
}
