using Foundation.UserInterfaceSupport.Model;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Feature.CustomerSupport.Application
{
    public class NavigationService
    {
        private readonly UserInterfaceBase _userInterface;

        public NavigationService(UserInterfaceBase userInterfaceBase)
        {
            _userInterface = userInterfaceBase;
        }

        public void NavigateToCustomerSupportPage()
        {
            var contactButton = _userInterface.DefaultWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".contact-box a")));
            _userInterface.HtmlViewportService.ScrollIntoView(contactButton);
            contactButton.Click();
        }

    }
}
