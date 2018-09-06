using Foundation.UserInterfaceSupport.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using SimpleClickPagesTest.Model;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Project.UserInterfaceTests.Tests
{
    public class SimplePagesClickService : PageObjects
    {
        private UserInterfaceBase _userInterface;

        public SimplePagesClickService(UserInterfaceBase userInterface) : base(userInterface.WebDriver)
        {
            _userInterface = userInterface;
        }

        public void ClickTestFrontPage()
        {
            //WebDriver.Navigate().GoToUrl(SiteUri + Constants.ClickTestPages.FrontPageUrl);
            //this.DefaultWait.Until(e => FrontPage.Displayed);

            //DefaultWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("region-frontpage")));
        }

        public void ClickTestLottoFrontPage()
        {
            //WebDriver.Navigate().GoToUrl(SiteUri + Constants.ClickTestPages.LottoFrontPageUrl);
            //DefaultWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("region-lotto")));
        }
    }
}