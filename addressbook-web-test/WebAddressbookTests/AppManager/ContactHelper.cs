using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private IWebDriver _webDriver;
        public ContactHelper(ApplicationManager manager, IWebDriver webDriver)
            : base(manager) 
        {
            _webDriver = webDriver;
        }

        public ContactHelper Delete()
        {
            SelectContact();
            InitDeleteContact();
            CloseAlertWindow();
            return this;
        }
        public ContactHelper New(UserData userData)
        {
            _webDriver.FindElement(By.LinkText("add new")).Click();
            _webDriver.FindElement(By.Name("firstname")).Click();
            _webDriver.FindElement(By.Name("firstname")).Clear();
            _webDriver.FindElement(By.Name("firstname")).SendKeys(userData.Firstname);
            _webDriver.FindElement(By.Name("middlename")).Click();
            _webDriver.FindElement(By.Name("middlename")).Clear();
            _webDriver.FindElement(By.Name("middlename")).SendKeys(userData.Middlename);
            _webDriver.FindElement(By.Name("lastname")).Click();
            _webDriver.FindElement(By.Name("lastname")).Clear();
            _webDriver.FindElement(By.Name("lastname")).SendKeys(userData.Lastname);
            _webDriver.FindElement(By.Name("nickname")).Click();
            _webDriver.FindElement(By.Name("nickname")).Clear();
            _webDriver.FindElement(By.Name("nickname")).SendKeys(userData.Nickname);
            ConfirmCreationNewContact();
            return this;
        }
        public ContactHelper UpdateModification()
        {
            _webDriver.FindElement(By.XPath("/html/body/div/div[4]/form[1]/input[1]")).Click();
            return this;
        }
        public ContactHelper InitModification()
        {
            _webDriver.FindElement(By.XPath("/html/body/div[1]/div[4]/form[2]/table/tbody/tr[4]/td[8]/a/img")).Click();
            return this;
        }
        public ContactHelper GoToHomePage()
        {
            _webDriver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper InitDeleteContact()
        {
            _webDriver.FindElement(By.XPath("//*[@id='content']/form[2]/div[2]/input")).Click();
            return this;
        }
        public ContactHelper SelectContact()
        {
            _webDriver.FindElement(By.XPath("/html/body/div[1]/div[4]/form[2]/table/tbody/tr[3]/td[1]/input")).Click();
            return this;
        }
        public ContactHelper CloseAlertWindow()
        {
            _webDriver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper ConfirmCreationNewContact()
        {
            _webDriver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }
        public ContactHelper Modify(UserData userData)
        {
            _manager.Navigator.OpenHomePage();
            InitModification();
            New(userData);
            GoToHomePage();
            return this;
        }
    }
}
