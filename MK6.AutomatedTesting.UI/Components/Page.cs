using OpenQA.Selenium;
using System;

namespace MK6.AutomatedTesting.UI.Components
{
    public abstract class Page
    {
        private readonly IWebDriver _browser;

        public readonly Uri Uri;

        protected Page(IWebDriver browser, Uri uri)
        {
            this._browser = browser;
            this.Uri = uri;
        }

        public bool IsCurrentPage()
        {
            return this._browser.Url.Equals(
                this.Uri.ToString(),
                StringComparison.InvariantCultureIgnoreCase);
        }

        public IWebDriver Browser { get { return _browser; } }

        public void Load()
        {
            this._browser.Url = this.Uri.ToString();
        }

        public bool IsCurrentRelativePage()
        {
            return new Uri(_browser.Url).PathAndQuery.Equals(Uri.PathAndQuery,
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
