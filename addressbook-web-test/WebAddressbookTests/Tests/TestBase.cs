using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace WebAddressbookTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            //driver = new ChromeDriver();
            app = new ApplicationManager(driver);
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
        [TearDown]
        public void TeardownTest()
        {
            {
                app.Navigator.OpenHomePage();
                app.Auth.Logout();
                app.Stop();
            }
        }
    }
}
