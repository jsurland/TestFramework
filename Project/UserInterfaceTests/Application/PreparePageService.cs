using Feature.CookieWarning.Application;
using Foundation.UserInterfaceSupport.Model;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Project.UserInterfaceTests.Application
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
