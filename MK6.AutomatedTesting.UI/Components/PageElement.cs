using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MK6.AutomatedTesting.UI.Components
{
    public abstract class PageElement
    {
        protected readonly Func<IWebElement> _elementRetriever;

        private readonly IWebDriver _browser;

        public PageElement(IWebDriver browser, By findBy)
        {
            this._browser = browser;
            this._elementRetriever = () => browser.FindElement(findBy);
        }

        protected IWebElement Element
        {
            get
            {
                return this._elementRetriever.Invoke();
            }
        }

        public bool IsVisible
        {
            get
            {
                return this.Element.Displayed;
            }
        }

        public void WaitUntilIsVisible(TimeSpan timeout)
        {
            new WebDriverWait(this._browser, timeout).Until(e => this.IsVisible);
        }
    }
}
