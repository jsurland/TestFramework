using Foundation.UserInterfaceSupport.Model;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Feature.CookieWarning.Application
{
    public class CookieWarningService
    {
        private readonly UserInterfaceBase _userInterface;

        public CookieWarningService(UserInterfaceBase userInterface)
        {
            _userInterface = userInterface;
        }

        public void AcceptCookiesWithoutFail()
        {
            var cookieButton = _userInterface.DefaultWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cookie-info__content .seen_button")));
            {
                cookieButton.Click();
            }
        }
    }
}
