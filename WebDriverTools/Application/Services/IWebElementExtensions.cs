using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.WaitHelpers;

namespace WebDriverTools.Application.Services
{
    public static class IWebElementExtensions
    {
        /// <summary>
        /// Checks if the <paramref name="element"/> can be clicked on.
        /// </summary>
        /// <param name="element">Element to validate for clickability.</param>
        /// <returns>Returns true if the <paramref name="element"/> is clickable, else false.</returns>
        /// <remarks>WARNING !!!
        /// This wrongly returns true, when the element is hidden by an overlay.
        /// Causing exceptions when trying to click on an <paramref name="element"/>.
        /// NB: Tested on the ChromeDriver.
        /// </remarks>
        public static bool IsClickable(this IWebElement element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            RemoteWebElement remoteElement = element as RemoteWebElement;

            if (remoteElement == null)
                throw new ArgumentException("Must be of type " + typeof(RemoteWebElement).FullName, nameof(element));

            return ExpectedConditions.ElementToBeClickable(element)
                                     .Invoke(remoteElement.WrappedDriver) != null;
        }

        public static IWebElement GetParent(this IWebElement element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            RemoteWebElement remoteElement = element as RemoteWebElement;

            if (remoteElement == null)
                throw new ArgumentException("Must be of type " + typeof(RemoteWebElement).FullName, nameof(element));

            IJavaScriptExecutor js = (IJavaScriptExecutor)remoteElement.WrappedDriver;
            return (IWebElement)js.ExecuteScript("return arguments[0].parentNode;", element);
        }

        public static ReadOnlyCollection<string> GetStyleClasses(this IWebElement element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            RemoteWebElement remoteElement = element as RemoteWebElement;

            if (remoteElement == null)
                throw new ArgumentException("Must be of type " + typeof(RemoteWebElement).FullName, nameof(element));

            return new ReadOnlyCollection<string>(element.GetAttribute("class").Split(' '));
        }

        // TODO Tale med ALP hvorfor denne ikke var så fed.
        //public static object SetValue(this IWebElement element, string value, bool triggerBlur = false, bool triggerInput = true)
        //{
        //    if (element == null)
        //        throw new ArgumentNullException(nameof(element));

        //    RemoteWebElement remoteElement = element as RemoteWebElement;

        //    if (remoteElement == null)
        //        throw new ArgumentException("Must be of type " + typeof(RemoteWebElement).FullName, nameof(element));

        //    IJavaScriptExecutor js = (IJavaScriptExecutor)remoteElement.WrappedDriver;
        //    object result = js.ExecuteScript(
        //        FormattableString.Invariant($"return arguments[0].value = '{value}';"), element);

        //    if (triggerBlur)
        //    {
        //        js.ExecuteScript(
        //            FormattableString.Invariant($"return arguments[0].blur();"), element);
        //    }

        //    if (triggerInput)
        //    {
        //        js.ExecuteScript(
        //            FormattableString.Invariant($"arguments[0].dispatchEvent(new Event('input'));"), element);
        //    }

        //    return result;
        //}

        public static void SetValue(this IWebElement inputElement, string newInputBoxString)
        {
            inputElement.SendKeys(Keys.Control + "a");
            inputElement.SendKeys(newInputBoxString.ToString(CultureInfo.InvariantCulture));
        }
    }
}
