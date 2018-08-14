using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebDriverTools.Application.Services
{
    public class HtmlViewportService
    {

        private readonly IWebDriver _webDriver;
        private readonly WebDriverWait _defaultWait;
        private readonly IJavaScriptExecutor _javaScriptExecutor;
        private StyleElementService _hideStyleElementService;

        public HtmlViewportService(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
            this._defaultWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            this._javaScriptExecutor = (IJavaScriptExecutor)webDriver;
        }

        public void ScrollIntoView(IWebElement element, bool top = true, int offset = 0)
        {
            _javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(" + (top ? "true" : "false") + "); return '';", element);
            if (offset != 0)
            {
                _javaScriptExecutor.ExecuteScript("window.scrollBy(0, arguments[0]); return '';", offset);
            }

            // Fix for IE scrolling sideways
            // TODO: Only do for IE and ideally dont use this at all, because
            // it can cause js to not work properly.
            // Instead scroll to a parent element that is the width of the screen.
            _javaScriptExecutor.ExecuteScript("document.querySelector('body > form').style.overflow = 'hidden'; return '';");
            _javaScriptExecutor.ExecuteScript("document.querySelector('body > form').style.overflow = 'visible'; return '';");
            System.Threading.Thread.Sleep(1000);
        }

        public void ScrollIntoView(By cssSelector, bool top = true, int offset = 0)
        {
            ScrollIntoView(_webDriver.FindElement(cssSelector), top, offset);
        }

        public void DisableAnimationsAndTransitions()
        {
            this._hideStyleElementService = new StyleElementService(_webDriver, "* { animation-duration: 0s !important; transition-duration: 0s !important; };");
        }

        public void EnableAnimationsAndTransitions()
        {
            _hideStyleElementService?.RemoveFromDom();
        }

        public AnimationService EnableAnimationsForElement(IWebElement element)
        {
            var animationHandle = new AnimationService(_javaScriptExecutor, element);
            animationHandle.EnableAnimations();
            return animationHandle;
        }

        //public void HideNav()
        //{
        //    IWebElement element = _webDriver.FindElement(By.CssSelector(".top-navigation"));

        //    if (element != null)
        //    {
        //        ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].style.display='none'; return '';", element);
        //    }
        //}

        //public void HideNotifications()
        //{
        //    IWebElement element = _webDriver.FindElement(By.CssSelector(".notification-bar-container"));

        //    ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].parentNode.removeChild(arguments[0])", element);
        //}

        //public void RemoveCookieMessage()
        //{
        //    By ensightenCookieButton = By.CssSelector("#ensCloseBanner");
        //    By ensightenCookieBannerSelector = By.CssSelector("#ensNotifyBanner");

        //    StyleElementService fixEnsighten = new StyleElementService(_webDriver, "#ensNotifyBanner { left: 0px !important; }");

        //    var ensightenElements = _webDriver.FindElements(ensightenCookieButton);

        //    if (ensightenElements.Count > 0 && ensightenElements[0].Displayed)
        //    {
        //        var jsDriver = (IJavaScriptExecutor)_webDriver;

        //        var ensightenCookieBanner = _webDriver.FindElement(ensightenCookieBannerSelector);

        //        ensightenElements[0].Click();
        //    }

        //    // TODO: Ensighten will be the new cookie consent handler. When fully implemented, we can disable div.seen_button functionality

        //    By btnAccept = By.CssSelector("div.seen_button");

        //    var cookieInfoElements = _webDriver.FindElements(By.CssSelector("div.seen_button"));

        //    if (cookieInfoElements.Count > 0 && cookieInfoElements[0].Displayed)
        //    {
        //        cookieInfoElements[0].Click();
        //    }
        //}

        //public void RemoveNotificationMessages()
        //{
        //    By closeButtonSelectors = By.CssSelector(".notifications .close-btn");

        //    var notifications = _webDriver.FindElements(closeButtonSelectors);

        //    while (notifications.Count > 0)
        //    {
        //        var element = _webDriver.FindElement(closeButtonSelectors);

        //        element.Click();

        //        _defaultWait.Until(ExpectedConditions.StalenessOf(element));

        //        notifications = _webDriver.FindElements(closeButtonSelectors);
        //    }
        //}
    }
}
