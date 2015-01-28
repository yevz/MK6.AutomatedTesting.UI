using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;
using System;
using System.Globalization;
using TechTalk.SpecFlow;

namespace MK6.AutomatedTesting.UI.SpecFlow.Tests
{
    [TestClass]
    public class FeatureContextExtensionTests
    {
        [TestMethod]
        public void SetBrowser_PutsBrowserInFeatureContext_WhenOneIsNotAlreadyThere()
        {
            var featureContext = CreateFeatureContext();

            var browser = new Mock<IWebDriver>().Object;
            featureContext.SetBrowser(browser);

            Assert.AreSame(
                browser,
                featureContext[FeatureContextExtensions.BrowserKey]);
        }

        [TestMethod]
        public void SetBrowser_ThrowsApplicationException_WhenBrowserIsAlreadyStored()
        {
            var featureContext = CreateFeatureContext();
            var browser = new Mock<IWebDriver>().Object;
            featureContext.Add(FeatureContextExtensions.BrowserKey, browser);

            try
            {
                featureContext.SetBrowser(new Mock<IWebDriver>().Object);
                Assert.Fail("Did not throw expected exception");
            }
            catch (ApplicationException)
            {
                // Test passes; threw exception
            }
        }

        [TestMethod]
        public void GetBrowser_ReturnsStoredBrowser_WhenOneIsStored()
        {
            var featureContext = CreateFeatureContext();
            var browser = new Mock<IWebDriver>().Object;
            featureContext.Add(FeatureContextExtensions.BrowserKey, browser);

            Assert.AreSame(browser, featureContext.GetBrowser());
        }

        [TestMethod]
        public void GetBrowser_ThrowsApplicationException_WhenOneHasNotBeenStored()
        {
            var featureContext = CreateFeatureContext();

            try
            {
                featureContext.GetBrowser();
                Assert.Fail("Did not throw expected exception");
            }
            catch (ApplicationException)
            {
                // Test passes; threw exception
            }
        }

        [TestMethod]
        public void SetApplication_StoresApplication_WhenOneHasNotAlreadyBeenStored()
        {
            var featureContext = CreateFeatureContext();
            var app = new Mock<Application>().Object;
            featureContext.SetApplication(app);

            Assert.AreSame(
                app, 
                featureContext[FeatureContextExtensions.ApplicationKey]);
        }

        [TestMethod]
        public void SetApplication_ThrowsApplicationException_WhenOneHasAlreadyBeenStored()
        {
            var featureContext = CreateFeatureContext();
            var app = new Mock<Application>().Object;
            featureContext.Add(FeatureContextExtensions.ApplicationKey, app);

            try
            {
                featureContext.SetApplication(new Mock<Application>().Object);
                Assert.Fail("Did not throw expected exception");
            }
            catch (ApplicationException)
            {
                // Test passes; threw exception
            }
        }

        [TestMethod]
        public void GetApplication_ReturnsApplication_ThatHasBeenStoredInIt()
        {
            var featureContext = CreateFeatureContext();
            var app = new Mock<Application>().Object;
            featureContext.Add(FeatureContextExtensions.ApplicationKey, app);

            Assert.AreSame(app, featureContext.GetApplication<Application>());
        }

        [TestMethod]
        public void GetApplication_ThrowsApplication_WhenOneHasNotBeenStored()
        {
            var featureContext = CreateFeatureContext();

            try
            {
                featureContext.GetApplication<Application>();
                Assert.Fail("Did not throw expected exception");
            }
            catch (ApplicationException)
            {
                // Test passes; threw exception
            }
        }

        [TestMethod]
        public void GetApplication_ThrowsApplication_WhenOneStoredIsNotOfTypeRequested()
        {
            var featureContext = CreateFeatureContext();

            try
            {
                featureContext.GetApplication<TestApplication>();
                Assert.Fail("Did not throw expected exception");
            }
            catch (ApplicationException)
            {
                // Test passes; threw exception
            }
        }

        private static FeatureContext CreateFeatureContext()
        {
            return new FeatureContext(
                new FeatureInfo(
                    CultureInfo.CurrentCulture,
                    string.Empty,
                    string.Empty),
                CultureInfo.CurrentCulture);
        }

        private class TestApplication : Application
        {
            public override void Logout()
            {
                throw new NotImplementedException();
            }
        }

    }
}
