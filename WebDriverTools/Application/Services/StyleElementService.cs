using System;
using OpenQA.Selenium;

namespace Foundation.WebDriverTools.Application.Services
{
    public class StyleElementService
    {
        private readonly IJavaScriptExecutor _javaScriptExecutor;
        private readonly string _styleId;
        private readonly IWebDriver _webDriver;
        private readonly IWebElement _styleElement;

        public StyleElementService(IWebDriver driver, string content, bool addToDOM = true)
        {
            _styleId = Guid.NewGuid().ToString("N");
            _javaScriptExecutor = (IJavaScriptExecutor)driver;
            _styleElement = (IWebElement)_javaScriptExecutor.ExecuteScript(@"
                var styleTag = document.createElement('style');
                styleTag.innerHTML = arguments[0];
                styleTag.id = arguments[1];
                document.querySelector('head').appendChild(styleTag);
                return styleTag;
            ", content, _styleId);
        }

        public StyleElementService(IWebDriver driver, By selector, string content, bool addToDOM = true)
        {
            var actualSelector = selector.ToString().Split(new[] { ": " }, StringSplitOptions.None)[1];
            var selectorContent = $"{actualSelector} {{ {content} }};";
            new StyleElementService(driver, selectorContent, addToDOM);
        }

        public void RemoveFromDom()
        {
            _javaScriptExecutor.ExecuteScript($@"
                var element = document.querySelector('style[id=\'{_styleId}\']');
                element.parentNode.removeChild(element);
            ");
        }

        public void AddToDom()
        {
            _javaScriptExecutor.ExecuteScript(@"
                document.querySelector('head').appendChild(arguments[0]);
            ", _styleElement);
        }
    }
}
