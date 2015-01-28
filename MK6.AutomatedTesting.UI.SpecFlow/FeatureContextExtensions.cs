using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MK6.AutomatedTesting.UI.SpecFlow
{
    public static class FeatureContextExtensions
    {
        internal const string BrowserKey = "Browser";

        internal const string ApplicationKey = "Application";

        public static IWebDriver GetBrowser(this FeatureContext featureContext)
        {
            var browser = default(object);

            if (featureContext.TryGetValue(BrowserKey, out browser) && browser is IWebDriver)
            {
                return browser as IWebDriver;
            }

            throw new ApplicationException("Browser is not stored in context as expcected");
        }

        public static void SetBrowser(this FeatureContext featureContext, IWebDriver browser)
        {
            if (featureContext.ContainsKey(BrowserKey))
            {
                throw new ApplicationException("Browser has already been set for this scenario");
            }

            featureContext.Add(BrowserKey, browser);
        }

        public static T GetApplication<T>(this FeatureContext featureContext) where T : Application
        {
            var browser = default(object);

            if (featureContext.TryGetValue(ApplicationKey, out browser) && browser is T)
            {
                return browser as T;
            }

            throw new ApplicationException("Application is not stored in context as expected");
        }

        public static void SetApplication<T>(this FeatureContext featureContext, T application)
        {
            if (featureContext.ContainsKey(ApplicationKey))
            {
                throw new ApplicationException("Application has already been set for this scenario");
            }

            featureContext.Add(ApplicationKey, application);
        }
    }
}
