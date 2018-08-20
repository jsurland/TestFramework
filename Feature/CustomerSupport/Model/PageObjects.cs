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

        [FindsBy(How = How.CssSelector, Using = ".search-input input")]
        [CacheLookup]
        protected IWebElement SearchBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".searchresult h2")]
        [CacheLookup]
        protected IWebElement ResultHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".contact-box a")]
        [CacheLookup]
        protected IWebElement ContactButton { get; set; }

        protected By SearchResultList = By.CssSelector(".searchresult .link-list li"); 
    }
}
