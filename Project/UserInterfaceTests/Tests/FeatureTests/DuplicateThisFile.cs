using Feature.CustomerSupport.Application;
using Feature.CustomerSupport.Test;
using Foundation.UserInterfaceSupport.Model;
using NUnit.Framework;
using Project.UserInterfaceTests.Application;

namespace Project.UserInterfaceTests.Tests.FeatureTests
{
    [Parallelizable]
    [Category("FeatureTest")]
    class DuplicateThisFile : UserInterfaceBase
    {
        private CustomerSupportService _customerSupportService;

        protected DuplicateThisFile(Foundation.UserInterfaceSupport.Constants.BrowserType browser, 
            Foundation.UserInterfaceSupport.Constants.OperatingSystem operatingSystem) : base(browser, operatingSystem)
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
            _customerSupportService = new CustomerSupportService(this);
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
        public void DummyTest(string searchString, bool reverseExpectations)
        {
            _customerSupportService.NavigateToCustomerSupportPage();
            var faqSearchTest = new FaqSearchTest(this);
            faqSearchTest.SearchForAndFind(searchString, reverseExpectations);
        }
    }
}
