using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebDrivers.Infrastructure
{
    public class InternetExplorerService
    {
        public void HandleInternetExplorerCertificateError(Constants.BrowserType browser, IWebDriver webDriver)
        {
            try
            {
                if (browser == Constants.BrowserType.InternetExplorer
                    && webDriver != null
                    && !string.IsNullOrEmpty(webDriver.Title)
                    && (webDriver.Title.Contains("Certificate Error") || webDriver.Title.Contains("Certifikatfejl")))
                {
                    webDriver.Navigate().GoToUrl("javascript:document.getElementById('overridelink').click()");
                }
            }
            catch (Exception e)
            {
                Assert.Inconclusive($"A setup step did not complete. Possible reason given was Internet Explorer check step failed, error was {e}");
            }
        }

    }
}
