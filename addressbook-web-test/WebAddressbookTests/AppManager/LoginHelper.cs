using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        private IWebDriver _webDriver;
        public LoginHelper(ApplicationManager manager, IWebDriver webDriver)
            : base(manager, webDriver) 
        {
            _webDriver = webDriver;
        }
        public void Login(AccountData account)
        {
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            _webDriver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        public void Logout()
        {
            _webDriver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}