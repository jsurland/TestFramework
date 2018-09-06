using Feature.CookieWarning.Application;
using Foundation.UserInterfaceSupport.Model;
using OpenQA.Selenium;
using Project.UserInterfaceTests.Model;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Project.UserInterfaceTests.Application
{
    class PreparePageService : PageObjects
    {
        private readonly UserInterfaceBase _userInterface;

        public PreparePageService(UserInterfaceBase userInterface) : base(userInterface.WebDriver)
        {
            _userInterface = userInterface;
        }

        public void PreparePage()
        {
            _userInterface.WebDriver.Navigate().GoToUrl(_userInterface.SiteUri + Constants.ClickTestPages.FrontPageUrl);
            _userInterface.DefaultWait.Until(e => FrontPage.Displayed);
            var test = new CookieWarningService(_userInterface);
            test.AcceptCookiesWithoutFail();
        }
    }
}
