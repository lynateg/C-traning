using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        protected IWebDriver driver;
        protected string baseURL;

        public ApplicationManager(IWebDriver webDriver)
        {
            baseURL = "http://localhost/addressbook/";
            loginHelper = new LoginHelper(this, webDriver);
            navigator = new NavigationHelper(this, webDriver);
            groupHelper = new GroupHelper(this, webDriver);
            contactHelper = new ContactHelper(this, webDriver);
            driver = webDriver;
        }

        public string BaseURL
        {
            get
            {
                return baseURL;
            }
        }
        public void Stop()
        {
            driver.Quit();
        }
        public LoginHelper Auth
        {
            get { return loginHelper; }
        }
        public NavigationHelper Navigator
        {
            get { return navigator; }
        }
        public GroupHelper Groups
        {
            get { return groupHelper; }
        }
        public ContactHelper Contacts
        {
            get { return contactHelper; }
        }
    }
}
