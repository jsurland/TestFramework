using OpenQA.Selenium;

namespace WebDriverTools.Application.Services
{
    public class AnimationService
    {
        private readonly IJavaScriptExecutor _javaScriptExecutor;
        private readonly IWebElement _element;
        private string _originalDuration;

        public AnimationService(IJavaScriptExecutor javaScriptExecutor, IWebElement element)
        {
            this._javaScriptExecutor = javaScriptExecutor;
            this._element = element;
        }

        public bool EnableAnimations(int time = 3000)
        {
            var animationDuration = _element.GetCssValue("animation-duration");
            this._originalDuration = animationDuration;
            return (bool)_javaScriptExecutor.ExecuteScript($@"
                    (
                        arguments[0].style.animationDuration = '{time}ms';
                        return true;
                    )();
                ", _element);
        }

        public bool DisableAnimations()
        {
            return (bool)_javaScriptExecutor.ExecuteScript($@"
                    (
                        arguments[0].style.animationDuration = '{_originalDuration}';
                        return true;
                    )();
                ");
        }
    }
}
