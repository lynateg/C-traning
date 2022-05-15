using OpenQA.Selenium;
namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected ApplicationManager _manager;
        protected string _baseURL;
        private IWebDriver _webDriver;
        public HelperBase(ApplicationManager manager, IWebDriver webDriver)
        {
            _manager = manager;
            _baseURL = manager.BaseURL;
            _webDriver = webDriver;
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                _webDriver.FindElement(locator).Click();
                _webDriver.FindElement(locator).Clear();
                _webDriver.FindElement(locator).SendKeys(text);
            }
        }
    }
}