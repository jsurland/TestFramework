using Foundation.TestPages.Infrastructure;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Feature.TestFeatureProject.Model
{
    public class PageObjects : BaseTestPageObjects
    {
        public PageObjects(IWebDriver webDriver) : base(webDriver)
        {
        }

        // Use PageObjects whenever possible
        [FindsBy(How = How.CssSelector, Using = ".search-input input")]
        [CacheLookup]
        protected IWebElement SearchBox { get; set; }

        // Use 'By' when PageObjects are not possible - depends on how you need to write the test
        protected By SearchResultList = By.CssSelector(".searchresult .link-list li"); 
    }
}
