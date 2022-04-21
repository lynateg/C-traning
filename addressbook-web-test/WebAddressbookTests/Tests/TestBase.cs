using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;


namespace WebAddressbookTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected IWebDriver driver2;
        protected ApplicationManager app;

        [SetUp]       
        public void SetupTest()
        {
            app = new ApplicationManager();
            driver = new FirefoxDriver();
            driver2 = new ChromeDriver();
            app.Navigator.OpenHomePage(driver);
            app.Auth.Login(new AccountData("admin", "secret"), driver); 
            app.Navigator.OpenHomePage(driver2);
            app.Auth.Login(new AccountData("admin", "secret"), driver2);
        }
        [TearDown]
        public void TeardownTest()
        {
            {
                app.Navigator.OpenHomePage(driver);
                app.Navigator.OpenHomePage(driver2);
                app.Auth.Logout(driver);
                app.Auth.Logout(driver2);
                app.Stop(driver);
                app.Stop(driver2);
            }
        }
    }
}
