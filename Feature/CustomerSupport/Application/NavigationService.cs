using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using UserInterfaceSupport.Model;
using SeleniumExtras.WaitHelpers;

namespace CustomerSupport.Application
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
