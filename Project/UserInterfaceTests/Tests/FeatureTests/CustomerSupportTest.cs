using Feature.CustomerSupport.Application;
using Feature.CustomerSupport.Test;
using Foundation.UserInterfaceSupport.Model;
using NUnit.Framework;
using Project.UserInterfaceTests.Application;

namespace Project.UserInterfaceTests.Tests.FeatureTests
{
    [Parallelizable]
    [Category("FeatureTest")]
    class CustomerSupportTest : UserInterfaceBase
    {
        private NavigationService _navigationService;

        public CustomerSupportTest(Foundation.UserInterfaceSupport.Constants.BrowserType browserType, 
            Foundation.UserInterfaceSupport.Constants.OperatingSystem operatingSystem) : base(browserType, operatingSystem)
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
            _navigationService = new NavigationService(this);
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
        [TestCase("Lotto", false)]
        [TestCase("DoNotFindThisAdsasfsdf", true)]
        public void SearchAndFindFaqTopicOnCustomerSupportTest(string searchString, bool reverseExpectations)
        {
            _navigationService.NavigateToCustomerSupportPage();
            var faqSearchTest = new FaqSearchTest(this);
            faqSearchTest.SearchForAndFind(searchString, reverseExpectations);
        }
    }
}
