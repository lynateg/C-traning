using OpenQA.Selenium;
namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected ApplicationManager app;
        protected IWebDriver driver;
        public HelperBase(ApplicationManager manager)
        {
            this.app = manager;
            this.driver = app.Driver;
        }
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Click();
                driver.FindElement(locator).SendKeys(text);
            }            
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}