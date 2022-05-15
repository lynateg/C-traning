using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private IWebDriver _webDriver;
        public NavigationHelper(ApplicationManager manager, IWebDriver webDriver)
            : base(manager, webDriver)
        {
            _webDriver = webDriver;
        }
        public void OpenHomePage()
        {
            _webDriver.Navigate().GoToUrl(this._baseURL);
        }
        public void GoToGroupsPage()
        {
            _webDriver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
