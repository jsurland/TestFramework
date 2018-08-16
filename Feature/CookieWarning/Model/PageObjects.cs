using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestPages.Infrastructure;

namespace Feature.CookieWarning.Model
{
    public class PageObjects : BaseTestPageObjects 
    {
        public PageObjects(IWebDriver webDriver) : base(webDriver)
        {
        }

        [FindsBy(How = How.CssSelector, Using = ".cookie-info__content .seen_button")]
        [CacheLookup]
        protected IWebElement CookieButton { get; set; }
    }
}
