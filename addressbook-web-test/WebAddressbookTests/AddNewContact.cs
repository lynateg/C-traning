using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddNewContact : TestBase
    {                      
        [TestCase(TestName = "Firefox Добавление контакта")]
        //[Test]
        public void AddNewContactFirefox()
        {
            OpenHomePage(driver);
            Login(new AccountData("admin", "secret"), driver);               
            FillNewContactData(new UserData("Nail", "Hummer", "Imagine", "Pegasus"),driver);
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            OpenHomePage(driver);
            Logout(driver);

        }
        [TestCase(TestName = "Chrome Добавление контакта")]
        //[Test]
        public void AddNewContactChrome()
        {
            OpenHomePage(driver2);
            Login(new AccountData("admin", "secret"), driver2);
            FillNewContactData(new UserData("Lans", "Won", "DIWon", "Wolwerine"), driver2);
            driver2.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            OpenHomePage(driver2);
            Logout(driver2);

        }
    }
}
