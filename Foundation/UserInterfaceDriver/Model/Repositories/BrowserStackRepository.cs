using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using UserInterfaceSupport;
using UserInterfaceSupport.Model;
using UserInterfaceSupport.Model.Factories;

namespace WebDrivers.Model.Repositories
{
    public class BrowserStackRepository
    {
        private static readonly Regex NameRegex = new Regex(@"\(.*\)", RegexOptions.CultureInvariant | RegexOptions.Singleline);

        public WebDriverConfiguration GetBrowser(Constants.BrowserType browser, Constants.OperatingSystem operatingSystem)
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();

            capabilities.SetCapability("browserstack.user", BrowserStackUser());
            capabilities.SetCapability("browserstack.key", BrowserStackKey());
            capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
            capabilities.SetCapability("browserstack.debug", BrowserstackDebug());
            capabilities.SetCapability("browserstack.local", BrowserstackLocal());
            capabilities.SetCapability("browserstack.video", BrowserstackVideo());

            //Set selenium version to latest (default is 2.53.0) to avoid error in reading cookies in Edge
            capabilities.SetCapability("browserstack.selenium_version", "3.11.0");
            capabilities.SetCapability("project", Assembly.GetCallingAssembly().GetName().Name);

            string name = TestContext.CurrentContext.Test.Name;
            name = NameRegex.Replace(name, string.Empty);

            capabilities.SetCapability("name", name);

            string browserStackIndentifier = BrowserStackIndentifier();

            if (string.IsNullOrEmpty(browserStackIndentifier))
                browserStackIndentifier = Environment.MachineName;

            capabilities.SetCapability("browserstack.localIdentifier", browserStackIndentifier);

            capabilities.SetCapability("resolution", BrowserStackResolution());

            switch (operatingSystem)
            {
                case Constants.OperatingSystem.Windows:
                    capabilities.SetCapability("os", "WINDOWS");
                    capabilities.SetCapability("os_version", 10);
                    break;

                case Constants.OperatingSystem.IPad:
                    capabilities.SetCapability("platform", "MAC");
                    capabilities.SetCapability("device", "iPad Pro");
                    capabilities.SetCapability("deviceOrientation", "landscape");
                    capabilities.SetCapability("realMobile",
                        false); // Currently (2017-08-31) no real devices of this type.
                    break;

                case Constants.OperatingSystem.IPhone:
                    capabilities.SetCapability("platform", "MAC");
                    capabilities.SetCapability("device", "iPhone 7");
                    capabilities.SetCapability("realMobile", !BrowserStackUseEmulator());
                    break;

                case Constants.OperatingSystem.GalaxyS7:
                    capabilities.SetCapability("platform", "ANDROID");
                    capabilities.SetCapability("device", "Samsung Galaxy S7");
                    capabilities.SetCapability("realMobile", !BrowserStackUseEmulator());
                    break;

                case Constants.OperatingSystem.GalaxyTab:
                    capabilities.SetCapability("platform", "ANDROID");
                    capabilities.SetCapability("device",
                        BrowserStackUseEmulator()
                            ? "Samsung Galaxy Tab 4 10.1"
                            : "Samsung Galaxy Tab 4");
                    capabilities.SetCapability("deviceOrientation", "landscape");
                    capabilities.SetCapability("realMobile", !BrowserStackUseEmulator());
                    break;
            }

            switch (browser)
            {
                case Constants.BrowserType.Chrome:
                    capabilities.SetCapability("browserName", "Chrome");

                    // This does not seem to have any effect on BrowserStack but it does locally.
                    capabilities.SetCapability("browser.profile.managed_default_content_settings.images", 2);
                    capabilities.SetCapability("browser.profile.default_content_settings.state.flash", 0);
                    break;

                case Constants.BrowserType.Android:
                    capabilities.SetCapability("browserName", "android");
                    break;

                case Constants.BrowserType.FireFox:
                    capabilities.SetCapability("browserName", "Firefox");
                    break;

                case Constants.BrowserType.InternetExplorer:
                    capabilities.SetCapability("browserName", "IE");
                    capabilities.SetCapability("browser_version", 11);
                    capabilities.SetCapability("browserstack.ie.noFlash", true);
                    // Use for IE 11 and older.
                    capabilities.SetCapability("ie.usePerProcessProxy", true);
                    break;

                case Constants.BrowserType.Edge:
                    capabilities.SetCapability("browserName", "Edge");
                    break;

                case Constants.BrowserType.Safari:
                    capabilities.SetCapability("browserName", "Safari");
                    capabilities.SetCapability("browser_version", 10);
                    break;
            }

            WebDriverConfiguration webDriverConfiguration = new WebDriverConfigurationFactory().Create();
            try
            {
                webDriverConfiguration.WebDriver = new RemoteWebDriver(
                    BrowserStackUrl(),
                    capabilities,
                    TimeSpan.FromSeconds(Constants.Timeouts.BrowserStackCommandTimeout));

                webDriverConfiguration.SessionId = ((RemoteWebDriver) webDriverConfiguration.WebDriver).SessionId;
            }
            catch (Exception ex)
            {
                throw new ServerException(
                    FormattableString.Invariant(
                        $"Failed estabilishing a connection to browserstack, browserstack.localIdentifier: {capabilities.GetCapability("browserstack.localIdentifier").ToString()}"),
                    ex);
            }

            return webDriverConfiguration;
        }

        private Uri BrowserStackUrl()
        {
            throw new NotImplementedException();
        }

        private bool BrowserStackUseEmulator()
        {
            throw new NotImplementedException();
        }

        private string BrowserStackResolution()
        {
            throw new NotImplementedException();
        }

        private string BrowserStackIndentifier()
        {
            throw new NotImplementedException();
        }

        private string BrowserstackVideo()
        {
            throw new NotImplementedException();
        }

        private string BrowserstackLocal()
        {
            throw new NotImplementedException();
        }

        private string BrowserstackDebug()
        {
            throw new NotImplementedException();
        }

        private string BrowserStackKey()
        {
            throw new NotImplementedException();
        }

        private string BrowserStackUser()
        {
            throw new NotImplementedException();
        }
    }
}