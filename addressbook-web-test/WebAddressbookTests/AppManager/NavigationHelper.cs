using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager)
            : base(manager)
        { }
        public void OpenHomePage(IWebDriver webDriver)
        {
            webDriver.Navigate().GoToUrl(this._baseURL);
        }
        public void GoToGroupsPage(IWebDriver webDriver)
        {
            webDriver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
