using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using Feature.CustomerSupport.Model;
using Foundation.TestPages;
using Foundation.TestPages.Infrastructure;
using Foundation.UserInterfaceSupport.Model;

namespace Foundation.SimpleNavigation.Application
{
    public class PageNavigationService : PageObjects
    {
        private readonly UserInterfaceBase _userInterface;
        private readonly GoToUrlService _simplePageNavigation;

        public PageNavigationService(UserInterfaceBase userInterface) : base(userInterface.WebDriver)
        {
            _userInterface = userInterface;
            _simplePageNavigation = new GoToUrlService(_userInterface);
        }

        public void GotoFrontPage()
        {
            _simplePageNavigation.GoToUrlAndWaitUntilReady(Constants.Urls.FrontPageUrl, FrontPage);
        }

        public void GotoLottoPage()
        {
            _simplePageNavigation.GoToUrlAndWaitUntilReady(Constants.Urls.LottoFrontPageUrl, LottoFrontPage);
        }
    }
}
