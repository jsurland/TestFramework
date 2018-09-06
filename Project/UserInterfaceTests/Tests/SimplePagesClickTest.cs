using Foundation.UserInterfaceSupport.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using Project.UserInterfaceTests.Application;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Project.UserInterfaceTests.Tests
{
    [Parallelizable]
    [Category("ClickTest")]
    public class SimplePagesClickTest : UserInterfaceBase
    {
        public SimplePagesClickTest(Foundation.UserInterfaceSupport.Constants.BrowserType browserType, Foundation.UserInterfaceSupport.Constants.OperatingSystem operatingSystem) : base(
            browserType, operatingSystem)
        {
            // The constructor is not a good place to do much.
            // Mostly becuase the WebDriver reference is null, at this time.
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
        }

        [SetUp]
        public void BeforeTests()
        {
            new PreparePageService(this).PreparePage();
        }

        [TearDown]
        public void AfterEachTest()
        {
            
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            
        }

        [Test]
        public void ClickTestFrontPage()
        {
            WebDriver.Navigate().GoToUrl(SiteUri + Constants.ClickTestPages.FrontPageUrl);

            DefaultWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("region-frontpage")));
        }

        [Test]
        public void ClickTestLottoFrontPage()
        {
            WebDriver.Navigate().GoToUrl(SiteUri + Constants.ClickTestPages.LottoFrontPageUrl);
            DefaultWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("region-lotto")));
        }
    }
}