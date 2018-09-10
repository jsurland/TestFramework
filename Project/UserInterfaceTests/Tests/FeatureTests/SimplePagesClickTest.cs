using Foundation.SimpleNavigation.Application;
using Foundation.UserInterfaceSupport.Model;
using NUnit.Framework;
using Project.UserInterfaceTests.Application;

namespace Project.UserInterfaceTests.Tests.FeatureTests
{
    [Parallelizable]
    [Category("ClickTest")]
    class SimplePagesClickTest : UserInterfaceBase
    {
        private PageNavigationService _navigationService;

        public SimplePagesClickTest(Foundation.UserInterfaceSupport.Constants.BrowserType browserType, Foundation.UserInterfaceSupport.Constants.OperatingSystem operatingSystem, 
            SimplePagesClickTest simplePagesClickTest) : base(browserType, operatingSystem)
        {
            // The constructor is not a good place to do much.
            // Mostly becuase the WebDriver reference is null, at this time.
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _navigationService = new PageNavigationService(this);
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
        public void ClickTest()
        {
            _navigationService.GotoFrontPage();
            _navigationService.GotoLottoPage();
        }

    }
}