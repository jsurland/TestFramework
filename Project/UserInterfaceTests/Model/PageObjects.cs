using Foundation.TestPages.Infrastructure;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Project.UserInterfaceTests.Model
{
    public class PageObjects : BaseTestPageObjects
    {
        public PageObjects(IWebDriver webDriver) : base(webDriver)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "region-frontpage")]
        [CacheLookup]
        public IWebElement FrontPage { get; set; }
    }
}
