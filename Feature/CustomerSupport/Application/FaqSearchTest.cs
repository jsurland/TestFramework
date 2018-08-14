using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using UserInterfaceSupport.Model;

namespace CustomerSupport.Application
{
    public class FaqSearchTest
    {
        private readonly UserInterfaceBase _userInterface;

        public FaqSearchTest(UserInterfaceBase userInterface)
        {
            _userInterface = userInterface;
        }

        public void SearchForAndFind(string searchString, bool reverseExpectations)
        {
            var searchBox = _userInterface.DefaultWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".search-input input")));
            searchBox.Click();
            Assert.IsNotNull(searchBox, "The search box not found.");

            searchBox.SendKeys(Keys.Control + "a");
            searchBox.SendKeys(searchString.ToString(CultureInfo.InvariantCulture));
            var resultHeader = _userInterface.DefaultWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".searchresult h2")));
            Assert.IsTrue(resultHeader.Text.Contains(searchString));
            _userInterface.WaitForUiStatesService.WaitForElementCountGreaterThanZero(By.CssSelector(".searchresult .link-list li"), 30);
            var resultList = _userInterface.WebDriver.FindElements(By.CssSelector(".searchresult .link-list li"));
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
