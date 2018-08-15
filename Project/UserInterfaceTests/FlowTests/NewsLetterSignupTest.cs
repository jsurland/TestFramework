using Foundation.UserInterfaceSupport.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using Project.UserInterfaceTests.Application;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Project.UserInterfaceTests.FlowTests
{
    [Parallelizable]
    [Category("FeatureTest")]
    public class NewsLetterSignupTest : UserInterfaceBase
    {
        public NewsLetterSignupTest(Foundation.UserInterfaceSupport.Constants.BrowserType browserType, 
            Foundation.UserInterfaceSupport.Constants.OperatingSystem operatingSystem) : base(
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
        public void NewsLetterSignup()
        {
            WebDriver.Navigate().GoToUrl(SiteUri + Constants.NewsletterSignup.SignupUrl);
            DefaultWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("region-frontpage")));
        }
    }
}