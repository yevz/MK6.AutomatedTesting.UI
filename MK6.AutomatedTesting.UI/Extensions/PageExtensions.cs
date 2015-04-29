using System;
using System.Threading;
using MK6.AutomatedTesting.UI.Components;
using OpenQA.Selenium.Support.UI;

namespace MK6.RetailPlatform.Budget.Tests.UI.Abstraction.Extensions
{
    public static class PageExtensions
    {
        public static bool WaitForPageToLoad(this Page page, int waitMilliseconds)
        {
            return new WebDriverWait(page.Browser, TimeSpan.FromSeconds(15)).Until(d =>
            {
                if (page.IsCurrentRelativePage()) { return true; }
                Thread.Sleep(waitMilliseconds);
                return false;
            });
        }
    }
}