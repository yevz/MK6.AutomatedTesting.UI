using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MK6.AutomatedTesting.UI.Extensions
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindUntilVisible(this IWebDriver browser, By by, TimeSpan timeout)
        {
            var wait = new WebDriverWait(browser, timeout);
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static bool TryFindUntilVisible(this IWebDriver browser, By by, TimeSpan timeout, out IWebElement element)
        {
            try
            {
                element = FindUntilVisible(browser, by, timeout);
                return true;
            }
            catch (NoSuchElementException)
            {
                element = null;
                return false;
            }
        }

        public static void WaitForElementLoad(this IWebDriver browser, By selector, int waitMilliseconds)
        {
            new WebDriverWait(browser, TimeSpan.FromSeconds(15)).Until(d =>
            {
                try
                {
                    browser.FindElement(selector);
                    return true;
                }
                catch (Exception)
                {
                    Thread.Sleep(waitMilliseconds);
                    return false;
                }
            });
        }

        public static void WaitForAjaxToFinish(this IWebDriver browser, int waitMilliseconds)
        {
            var start = Environment.TickCount;
            bool ajaxStatus = false;
            var js = browser as IJavaScriptExecutor;
            do
            {
                ajaxStatus = (bool)js.ExecuteScript("return jQuery.active==0");
                Thread.Sleep(waitMilliseconds);

            } while (ajaxStatus.Equals(false) && Environment.TickCount - start <= 5000);



        }
    }
}
