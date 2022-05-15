using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        private IWebDriver _webDriver;
        public LoginHelper(ApplicationManager manager, IWebDriver webDriver)
            : base(manager) 
        {
            _webDriver = webDriver;
        }
        public void Login(AccountData account)
        {
            _webDriver.FindElement(By.Name("user")).Click();
            _webDriver.FindElement(By.Name("user")).Clear();
            _webDriver.FindElement(By.Name("user")).SendKeys(account.Username);
            _webDriver.FindElement(By.Name("pass")).Clear();
            _webDriver.FindElement(By.Name("pass")).SendKeys(account.Password);
            _webDriver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        public void Logout()
        {
            _webDriver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}