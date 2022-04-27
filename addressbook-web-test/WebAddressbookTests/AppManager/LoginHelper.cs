using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager)
            : base(manager) { }
        public void Login(AccountData account, IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("user")).Click();
            webDriver.FindElement(By.Name("user")).Clear();
            webDriver.FindElement(By.Name("user")).SendKeys(account.Username);
            webDriver.FindElement(By.Name("pass")).Clear();
            webDriver.FindElement(By.Name("pass")).SendKeys(account.Password);
            webDriver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        public void Logout(IWebDriver webDriver)
        {
            webDriver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}