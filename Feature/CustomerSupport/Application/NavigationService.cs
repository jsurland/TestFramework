using Feature.CustomerSupport.Model;
using Foundation.UserInterfaceSupport.Model;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Feature.CustomerSupport.Application
{
    public class NavigationService : PageObjects
    {
        private readonly UserInterfaceBase _userInterface;

        public NavigationService(UserInterfaceBase userInterface) : base(userInterface.WebDriver)
        {
            _userInterface = userInterface;
        }

        public void NavigateToCustomerSupportPage()
        {
            var contactButton = _userInterface.DefaultWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".contact-box a")));
            _userInterface.HtmlViewportService.ScrollIntoView(contactButton);
            contactButton.Click();
        }

    }
}
