﻿using Feature.CustomerSupport.Model;
using Foundation.UserInterfaceSupport.Model;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Feature.CustomerSupport.Application
{
    public class CustomerSupportService : PageObjects
    {
        private readonly UserInterfaceBase _userInterface;

        public CustomerSupportService(UserInterfaceBase userInterface) : base(userInterface.WebDriver)
        {
            _userInterface = userInterface;
        }

        public void NavigateToCustomerSupportPage()
        {
            _userInterface.DefaultWait.Until(e => ContactButton.Enabled && ContactButton.Displayed);
            _userInterface.HtmlViewportService.ScrollIntoView(ContactButton);
            ContactButton.Click();
        }

    }
}
