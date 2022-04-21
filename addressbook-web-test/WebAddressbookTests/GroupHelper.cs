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
    public class GroupHelper : HelperBase
    {
        protected object _baseURL;
        public GroupHelper(IWebDriver webDriver, string baseURL)
            :base(webDriver)
        {            
            _baseURL = baseURL;
        }
        public void DeleteGroup(IWebDriver webDriver)
        {
            webDriver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
        }
        public void SelectGroup(int index, IWebDriver webDriver)
        {
            webDriver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }
        public void InitGroupCreation(IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("new")).Click();
        }
        public void SubmitGroupCreation(IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("submit")).Click();
        }
        public void FillGroupForm(GroupData groupInfo, IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("group_name")).Click();
            webDriver.FindElement(By.Name("group_name")).Clear();
            webDriver.FindElement(By.Name("group_name")).SendKeys(groupInfo.GroupName);
            webDriver.FindElement(By.Name("group_header")).Click();
            webDriver.FindElement(By.Name("group_header")).Clear();
            webDriver.FindElement(By.Name("group_header")).SendKeys(groupInfo.GroupHeader);
            webDriver.FindElement(By.Name("group_footer")).Click();
            webDriver.FindElement(By.Name("group_footer")).Clear();
            webDriver.FindElement(By.Name("group_footer")).SendKeys(groupInfo.GroupFooter);
        }                
    }
}
