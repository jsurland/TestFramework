using Feature.CookieWarning.Model;
using Foundation.UserInterfaceSupport.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Feature.CookieWarning.Application
{
    public class CookieWarningService : PageObjects
    {
        private readonly UserInterfaceBase _userInterface;

        public CookieWarningService(UserInterfaceBase userInterface) : base(userInterface.WebDriver)
        {
            _userInterface = userInterface;
        }

        public void AcceptCookiesWithoutFail()
        {
            _userInterface.DefaultWait.Until(e => CookieButton.Displayed);
            CookieButton.Click();
        }
    }
}
