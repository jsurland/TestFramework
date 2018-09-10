using Foundation.WebDriverTools.Application.Services;
using NUnit.Framework;

namespace Foundation.UserInterfaceSupport.Model
{
    [TestFixture(Constants.BrowserType.FireFox, Constants.OperatingSystem.Windows, Description = "FireFox", Category = "Windows10")]
    //[TestFixture(Constants.BrowserType.Chrome, Constants.OperatingSystem.Windows, Description = "Chrome", Category = "Windows")]

    //    [TestFixture(BrowserType.Edge, OsType.Windows10, Description = "Edge", Category = "Windows")]
    // Internet Explorer requires special configuration.
    //    [TestFixture(Constants.BrowserType.InternetExplorer, Constants.OperatingSystem.Windows, Description = "InternetExplorer",Category = "Windows")]
    //    [TestFixture(BrowserType.Safari, OsType.IPhone, Description = "Safari", Category = "IPhone")]
    //    [TestFixture(BrowserType.Safari, OsType.IPad, Description = "Safari", Category = "IPad")]
    //    [TestFixture(BrowserType.Android, OsType.GalaxyS7, Description = "Android", Category = "GalaxyS7")]
    //    [TestFixture(BrowserType.Android, OsType.GalaxyTab, Description = "Android", Category = "GalaxyTab")]

    public class UserInterfaceBase : BrowserTestBase
    {
        protected UserInterfaceBase(Constants.BrowserType browser, Constants.OperatingSystem operatingSystem) : base(browser, operatingSystem)
        {
        }

        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
            base.OneTimeSetUp();

            if (OperatingSystem == Constants.OperatingSystem.Windows)
                WebDriver.Manage().Window.Maximize();

            HtmlViewportService = new HtmlViewportService(WebDriver);
            WaitForUiStatesService = new WaitForUiStatesService(WebDriver);
        }
         
        public HtmlViewportService HtmlViewportService { get; set; }
        public WaitForUiStatesService WaitForUiStatesService { get; set; }
    }
}
