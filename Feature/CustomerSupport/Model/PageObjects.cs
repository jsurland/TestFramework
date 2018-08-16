using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestPages.Infrastructure;

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

        protected By SearchResultList = By.CssSelector(".searchresult .link-list li"); 
    }
}
