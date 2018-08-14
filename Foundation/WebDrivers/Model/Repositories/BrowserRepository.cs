using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using WebDrivers.Model.Factories;

namespace WebDrivers.Model.Repositories
{
    public class BrowserRepository
    {
        public WebDriverConfiguration GetBrowser(Constants.BrowserType browser, string browserPath)
        {
            WebDriverConfiguration webDriverConfiguration = new WebDriverConfigurationFactory().Create();
            
            switch (browser)
            {
                case Constants.BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
                    chromeOptions.AddArgument("--ignore-certificate-errors");
                    //chromeOptions.AddUserProfilePreference("profile.managed_default_content_settings.images", 2);
                    chromeOptions.AddUserProfilePreference("profile.default_content_settings.state.flash", 0);

                    webDriverConfiguration.WebDriver = new ChromeDriver(browserPath, chromeOptions);
                    break;

                case Constants.BrowserType.FireFox:
                    webDriverConfiguration.FireFoxService = FirefoxDriverService.CreateDefaultService(browserPath, "geckodriver.exe");

                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
                    firefoxOptions.AddAdditionalCapability("acceptInsecureCerts", true, true);

                    webDriverConfiguration.WebDriver = new FirefoxDriver(webDriverConfiguration.FireFoxService, firefoxOptions, TimeSpan.FromSeconds(180));
                    break;

                case Constants.BrowserType.InternetExplorer:
                    var internetExplorerOptions = new InternetExplorerOptions();

                    internetExplorerOptions.AddAdditionalCapability(CapabilityType.AcceptSslCertificates, true);
                    internetExplorerOptions.EnsureCleanSession = true;

                    webDriverConfiguration.WebDriver = new InternetExplorerDriver(browserPath, internetExplorerOptions);

                    break;

                default:
                {
                    string errorMsg = FormattableString.Invariant(
                        $"Browser type: {browser}. Try and use BrowserStack by setting UseBrowserStack to true in app.config and run the StartBrowserStackLocal.ps1 before running the test.");

                    throw new NotSupportedException(errorMsg);
                }
            }

            return webDriverConfiguration;
        }
    }
}