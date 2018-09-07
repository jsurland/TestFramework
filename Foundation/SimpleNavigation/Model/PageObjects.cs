using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation.TestPages.Infrastructure;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Feature.CustomerSupport.Model
{
    public class PageObjects : BaseTestPageObjects
    {
        public PageObjects(IWebDriver webDriver) : base(webDriver)
        {
        }

        // Use PageObjects whenever possible
        [FindsBy(How = How.CssSelector, Using = ".region-frontpage")]
        [CacheLookup]
        protected IWebElement FrontPage { get; set; }

        // Use 'By' when PageObjects are not possible - depends on how you need to write the test
        //protected By SearchResultList = By.CssSelector(".searchresult .link-list li");
    }
}
