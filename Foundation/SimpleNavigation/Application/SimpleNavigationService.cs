using System;
using Foundation.TestPages.Infrastructure;
using Foundation.UserInterfaceSupport.Model;
using OpenQA.Selenium;

namespace Foundation.SimpleNavigation.Application
{
    internal class SimpleNavigationService: BaseTestPageObjects
    {
        private readonly UserInterfaceBase _userInterface;

        internal SimpleNavigationService(UserInterfaceBase userInterface) : base(userInterface.WebDriver)
        {
            _userInterface = userInterface;
        }

        internal void GoToUrlAndWaitUntilReady(Uri url, IWebElement waitForElement)
        {
            _userInterface.WebDriver.Navigate().GoToUrl(url);
            _userInterface.DefaultWait.Until(e => waitForElement.Enabled && waitForElement.Displayed);
        }

        internal void GoToUrlAndWaitUntilDisplayed(Uri url, IWebElement waitForElement)
        {
            _userInterface.WebDriver.Navigate().GoToUrl(url);
            _userInterface.DefaultWait.Until(e => waitForElement.Displayed);
        }

        internal void GoToUrlAndWaitUntilEnabled(Uri url, IWebElement waitForElement)
        {
            _userInterface.WebDriver.Navigate().GoToUrl(url);
            _userInterface.DefaultWait.Until(e => waitForElement.Enabled);
        }


    }
}
