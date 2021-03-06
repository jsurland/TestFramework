﻿using System;
using System.IO;
using Foundation.UserInterfaceSupport.Infrastructure;
using Foundation.UserInterfaceSupport.Model.Repositories;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Foundation.UserInterfaceSupport.Model
{
    public abstract class BrowserTestBase : IDisposable
    {
        private bool _disposedStatus = false;
        public WebDriverWait DefaultWait { get; private set; }
        public WebDriverWait PageLoadWait { get; private set; }
        private WebDriverConfiguration WebDriverConfiguration { get; set; } 
        public Constants.BrowserType Browser { get; }
        public Constants.OperatingSystem OperatingSystem { get; }

        public IWebDriver WebDriver
        {
            get { return WebDriverConfiguration?.WebDriver; }
        }
        
        public SessionId SessionId
        {
            get { return WebDriverConfiguration?.SessionId; }
        }

        public Uri SiteUri { get; }
        public Uri SitecoreUri { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected BrowserTestBase(Constants.BrowserType browser, Constants.OperatingSystem operatingSystem)
        {
            Browser = browser;
            OperatingSystem = operatingSystem;
            SiteUri = EnvironmentSettingsRepository.SiteUrl;
            SitecoreUri = EnvironmentSettingsRepository.SitecoreUrl;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedStatus)
            {
                if (disposing)
                {
                    WebDriverConfiguration?.Dispose();
                }
            }

            _disposedStatus = true;
        }

        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            if (UseBrowserStack())
            {
                WebDriverConfiguration = new BrowserStackRepository().GetBrowser(Browser, OperatingSystem);

                SetBrowserStackSettings();
            }
            else
            {
                string browserPath = Path.Combine(EnvironmentSettingsRepository.WebDriversPath);

                WebDriverConfiguration = new BrowserRepository().GetBrowser(Browser, browserPath);
 
                SetBrowserTimeouts();
            }
        }

        private bool UseBrowserStack()
        {
            return false;
        }

        private void SetBrowserStackSettings()
        {
            if (OperatingSystem == Constants.OperatingSystem.Windows)
                WebDriver.Manage().Window.Maximize();

            if (OperatingSystem != Constants.OperatingSystem.Windows)
                WebDriver.Manage().Timeouts().PageLoad =
                    TimeSpan.FromSeconds(Constants.Timeouts.BrowserStackCommandTimeout);

            DefaultWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(Constants.Timeouts.BrowserStackDefaultPollingTimeout));

            // Polling between 1-5 sec.
            int interval = (int) Math.Round((decimal) Constants.Timeouts.BrowserStackDefaultPollingTimeout / 4);
            interval = Math.Max(interval, 1);

            if (interval > 5)
                interval = 5;

            DefaultWait.PollingInterval = TimeSpan.FromSeconds(interval);

            PageLoadWait = new WebDriverWait(WebDriver,
                TimeSpan.FromSeconds(Constants.Timeouts.BrowserStackPageLoadTimeout));
        }

        private void SetBrowserTimeouts()
        {
            DefaultWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(Constants.Timeouts.DefaultPollingTimeout));
            DefaultWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            PageLoadWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(Constants.Timeouts.PageLoadTimeout));
        }
    }
}