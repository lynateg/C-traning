using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private IWebDriver _webDriver;
        public ContactHelper(ApplicationManager manager, IWebDriver webDriver)
            : base(manager, webDriver) 
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
            Type(By.Name("firstname"), userData.Firstname);
            Type(By.Name("middlename"), userData.Middlename);
            Type(By.Name("lastname"), userData.Lastname);
            Type(By.Name("nickname"), userData.Nickname);
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
