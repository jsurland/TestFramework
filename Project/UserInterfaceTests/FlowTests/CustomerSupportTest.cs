using CustomerSupport.Application;
using NUnit.Framework;
using OpenQA.Selenium;
using SimplePageTest;
using UserInterfaceSupport.Model;
using UserInterfaceTests.Application;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UserInterfaceTests.FlowTests
{
    [Parallelizable]
    [Category("FeatureTest")]
    class CustomerSupportTest : UserInterfaceBase
    {
        private NavigationService _navigationService;

        public CustomerSupportTest(UserInterfaceSupport.Constants.BrowserType browserType, UserInterfaceSupport.Constants.OperatingSystem operatingSystem) : base(
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
