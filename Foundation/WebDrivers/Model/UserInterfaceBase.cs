using NUnit.Framework;
using WebDriverTools.Application.Services;

namespace WebDrivers
{
    [TestFixture(Constants.BrowserType.FireFox, Constants.OperatingSystem.Windows, Description = "FireFox", Category = "Windows")]
    //    [TestFixture(BrowserType.Edge, OsType.Windows10, Description = "Edge", Category = "Windows")]
    //    [TestFixture(BrowserType.InternetExplorer, OsType.Windows10, Description = "InternetExplorer",Category = "Windows")]
    //    [TestFixture(BrowserType.Chrome, OsType.Windows10, Description = "Chrome", Category = "Windows")]
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

            htmlViewportService = new HtmlViewportService(WebDriver);
        }

        public HtmlViewportService htmlViewportService { get; set; }
    }
}
