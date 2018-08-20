using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Foundation.TestPages.Infrastructure
{
    public class BaseTestPageObjects
    {
        private readonly IWebDriver _webDriver;

        public BaseTestPageObjects(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }
    }
}
