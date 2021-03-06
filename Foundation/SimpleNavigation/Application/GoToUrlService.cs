﻿using System;
using Foundation.TestPages.Infrastructure;
using Foundation.UserInterfaceSupport.Model;
using OpenQA.Selenium;

namespace Foundation.SimpleNavigation.Application
{
    internal class GoToUrlService: BaseTestPageObjects
    {
        private readonly UserInterfaceBase _userInterface;

        internal GoToUrlService(UserInterfaceBase userInterface) : base(userInterface.WebDriver)
        {
            _userInterface = userInterface;
        }

        internal void GoToUrlAndWaitUntilReady(string url, IWebElement waitForElement)
        {
            _userInterface.WebDriver.Navigate().GoToUrl(_userInterface.SiteUri + url);
            _userInterface.DefaultWait.Until(e => waitForElement.Enabled && waitForElement.Displayed);
        }

        internal void GoToUrlAndWaitUntilDisplayed(string url, IWebElement waitForElement)
        {
            _userInterface.WebDriver.Navigate().GoToUrl(url);
            _userInterface.DefaultWait.Until(e => waitForElement.Displayed);
        }

        internal void GoToUrlAndWaitUntilEnabled(string url, IWebElement waitForElement)
        {
            _userInterface.WebDriver.Navigate().GoToUrl(url);
            _userInterface.DefaultWait.Until(e => waitForElement.Enabled);
        }
    }
}
