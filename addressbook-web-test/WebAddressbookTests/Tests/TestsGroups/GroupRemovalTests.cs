using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [TestCase(TestName = "Firefox Удаление группы 1")]      
        public void RemoveGroupFirefox()
        {            
            app.Groups.Delete(1,driver);
        }
        [TestCase(TestName = "Chrome Удаление группы 1")]       
        public void RemoveGroupChrome()
        {
            app.Groups.Delete(1, driver2);
        }
    }
}
