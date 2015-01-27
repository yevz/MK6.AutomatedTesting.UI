using Microsoft.VisualStudio.TestTools.UnitTesting;
using MK6.AutomatedTesting.UI.Configuration;
using OpenQA.Selenium.Remote;

namespace MK6.AutomatedTesting.UI.Tests
{
    [TestClass]
    public class DriverFactoryTests
    {
        [TestMethod]
        public void BuildRemoteCapabilities_ReturnsCapabilitiesWithBrowserNameFirefox_WhenRemoteBrowserIsFirefox()
        {
            var config = BuildFirefoxBrowserConfig();
            var capabilities = BuildRemoteCapabilities(config);

            Assert.AreEqual(
                "firefox",
                capabilities.BrowserName);
        }

        [TestMethod]
        public void BuildRemoteCapabilities_ReturnsCapabilitiesWithJavascriptEnabled_WhenRemoteBrowserIsFirefox()
        {
            var config = BuildFirefoxBrowserConfig();
            var capabilities = BuildRemoteCapabilities(config);

            Assert.IsTrue(capabilities.IsJavaScriptEnabled);
        }

        [TestMethod]
        public void BuildRemoteCapabilities_ReturnsCapabilitiesWithEmptyVersion_WhenRemoteBrowserIsFirefox()
        {
            var config = BuildFirefoxBrowserConfig();
            var capabilities = BuildRemoteCapabilities(config);

            Assert.AreEqual(string.Empty, capabilities.Version);
        }

        [TestMethod]
        public void BuildRemoteCapabilities_ReturnsCapabilitiesWithBrowserNameChrome_WhenRemoteBrowserIsChrome()
        {
            var config = BuildChromeBrowserConfig();
            var capabilities = BuildRemoteCapabilities(config);

            Assert.AreEqual(
                "chrome",
                capabilities.BrowserName);
        }

        [TestMethod]
        public void BuildRemoteCapabilities_ReturnsCapabilitiesWithJavascriptEnabled_WhenRemoteBrowserIsChrome()
        {
            var config = BuildChromeBrowserConfig();
            var capabilities = BuildRemoteCapabilities(config);

            Assert.IsTrue(capabilities.IsJavaScriptEnabled);
        }

        [TestMethod]
        public void BuildRemoteCapabilities_ReturnsCapabilitiesWithEmptyVersion_WhenRemoteBrowserIsChrome()
        {
            var config = BuildChromeBrowserConfig();
            var capabilities = BuildRemoteCapabilities(config);

            Assert.AreEqual(string.Empty, capabilities.Version);
        }

        [TestMethod]
        public void BuildRemoteCapabilities_ReturnsCapabilitiesWithBrowserNameInternetExplorer_WhenRemoteBrowserIsInternetExplorer()
        {
            var config = BuildIE9BrowserConfig();
            var capabilities = BuildRemoteCapabilities(config);

            Assert.AreEqual(
                "internet explorer",
                capabilities.BrowserName);
        }

        [TestMethod]
        public void BuildRemoteCapabilities_ReturnsCapabilitiesWithJavascriptEnabled_WhenRemoteBrowserIsInternetExplorer()
        {
            var config = BuildIE9BrowserConfig();
            var capabilities = BuildRemoteCapabilities(config);

            Assert.IsTrue(capabilities.IsJavaScriptEnabled);
        }

        [TestMethod]
        public void BuildRemoteCapabilities_ReturnsCapabilitiesWithVersion9_WhenRemoteBrowserIsInternetExplorer9()
        {
            var config = BuildIE9BrowserConfig();
            var capabilities = BuildRemoteCapabilities(config);

            Assert.AreEqual("9", capabilities.Version);
        }

        [TestMethod]
        public void BuildRemoteCapabilities_ReturnsCapabilitiesWithVersion10_WhenRemoteBrowserIsInternetExplorer10()
        {
            var config = BuildIE10BrowserConfig();
            var capabilities = BuildRemoteCapabilities(config);

            Assert.AreEqual("10", capabilities.Version);
        }

        [TestMethod]
        public void BuildRemoteCapabilities_ReturnsCapabilitiesWithVersion11_WhenRemoteBrowserIsInternetExplorer11()
        {
            var config = BuildIE11BrowserConfig();
            var capabilities = BuildRemoteCapabilities(config);

            Assert.AreEqual("11", capabilities.Version);
        }

        private static DesiredCapabilities BuildRemoteCapabilities(
            DriverConfigurationSection config)
        {
            return DriverFactory.BuildRemoteCapabilities(config);
        }

        private static DriverConfigurationSection BuildFirefoxBrowserConfig()
        {
            return new DriverConfigurationSection { RemoteBrowser = "firefox" };
        }

        private static DriverConfigurationSection BuildChromeBrowserConfig()
        {
            return new DriverConfigurationSection { RemoteBrowser = "chrome" };
        }

        private static DriverConfigurationSection BuildIE9BrowserConfig()
        {
            return new DriverConfigurationSection
            {
                RemoteBrowser = "internet explorer",
                RemoteBrowserVersion = "9"
            };
        }

        private static DriverConfigurationSection BuildIE10BrowserConfig()
        {
            return new DriverConfigurationSection
            {
                RemoteBrowser = "internet explorer",
                RemoteBrowserVersion = "10"
            };
        }

        private static DriverConfigurationSection BuildIE11BrowserConfig()
        {
            return new DriverConfigurationSection
            {
                RemoteBrowser = "internet explorer",
                RemoteBrowserVersion = "11"
            };
        }
    }
}
