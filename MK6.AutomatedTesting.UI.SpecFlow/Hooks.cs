using MK6.AutomatedTesting.UI.Configuration;
using OpenQA.Selenium;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace MK6.AutomatedTesting.UI.SpecFlow
{
    [Binding]
    public static class Hooks
    {
        [BeforeFeature]
        public static void OpenBrowser()
        {
            FeatureContext.Current
                .SetBrowser(GetBrowserFromConfig());
        }

        [AfterScenario]
        public static void LogoutFromApplication()
        {
            try
            {
                FeatureContext.Current
                    .GetApplication<Application>()
                    .Logout();
            }
            catch (NoSuchElementException)
            {
                // This will occur if we're not on a page with a logout
                // form, such as on a failed login scenario
            }
        }

        [AfterFeature]
        public static void LogoutAndCloseBrowserAfterScenario()
        {
            var browser = FeatureContext.Current.GetBrowser();
            browser.Close();
            browser.Dispose();
        }

        private static IWebDriver GetBrowserFromConfig()
        {
            var configSection = ConfigurationManager.GetSection("driver")
                as DriverConfigurationSection;
            return DriverFactory.Build(configSection);
        }

        private static Uri GetBaseUrl()
        {
            return new Uri(ConfigurationManager.AppSettings["BaseUrl"]);
        }
    }
}
