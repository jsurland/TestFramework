using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feature.CookieWarning.Application;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimplePageTest;
using UserInterfaceSupport.Model;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UserInterfaceTests.Application
{
    class PreparePageService
    {
        private readonly UserInterfaceBase _userInterface;

        public PreparePageService(UserInterfaceBase userInterface)
        {
            _userInterface = userInterface;
        }

        public void PreparePage()
        {
            _userInterface.WebDriver.Navigate().GoToUrl(_userInterface.SiteUri + Constants.ClickTestPages.FrontPageUrl);
            _userInterface.DefaultWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("region-frontpage")));
            new CookieWarningService(_userInterface).AcceptCookiesWithoutFail();
        }
    }
}
