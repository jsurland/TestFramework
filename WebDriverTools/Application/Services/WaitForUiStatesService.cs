using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebDriverTools.Application.Services
{
    public class WaitForUiStatesService
    {
        private readonly IWebDriver _webDriver;
        public WaitForUiStatesService(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void WaitForElementCountGreaterThanZero(By selector, int patienceInSeconds)
        {
            int waitTimeLeft = patienceInSeconds;
            do
            {
                var resultList = _webDriver.FindElements(selector);
                if (resultList.Count > 0)
                    break;

                System.Threading.Thread.Sleep(1000);
            } while (waitTimeLeft-- > 0);
        }
    }
}
