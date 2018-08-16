using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestPages.Infrastructure
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
