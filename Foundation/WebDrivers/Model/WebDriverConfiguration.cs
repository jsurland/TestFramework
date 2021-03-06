﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace WebDrivers.Model
{
    public class WebDriverConfiguration : IDisposable
    {
        public IWebDriver WebDriver { get; set; }
        public FirefoxDriverService FireFoxService { get; set; }
        public SessionId SessionId { get; set; }

        public void Dispose()
        {
            WebDriver?.Dispose();
            FireFoxService?.Dispose();
        }
    }
}