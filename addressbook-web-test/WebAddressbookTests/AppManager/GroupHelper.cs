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
      
        public GroupHelper(ApplicationManager manager)
            :base(manager)
        {            
            
        }
        public GroupHelper DeleteGroup(IWebDriver webDriver)
        {
            webDriver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
            return this;
        }

        internal GroupHelper Modify(int index, GroupData groupData, IWebDriver webDriver)
        {
            SelectGroup(index, webDriver);
            InitGroupModification(webDriver);
            FillGroupForm(groupData, webDriver);
            SubmitGroupModification(webDriver);
            return this;
        }

        private GroupHelper SubmitGroupModification(IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("update")).Click();
            return this;
        }

        private GroupHelper InitGroupModification(IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index, IWebDriver webDriver)
        {
            webDriver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public GroupHelper InitGroupCreation(IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper SubmitGroupCreation(IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData groupInfo, IWebDriver webDriver)
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
            return this;
        }
        
        public GroupHelper GoToGropPageFromSubmit(IWebDriver webDriver)
        {
            webDriver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper Create(GroupData groupInfo, IWebDriver webDriver)
        {                       
            InitGroupCreation(webDriver);
            FillGroupForm(groupInfo, webDriver);
            SubmitGroupCreation(webDriver);
            GoToGropPageFromSubmit(webDriver);
            return this;
        }
        public GroupHelper Delete(int index, IWebDriver webDriver)
        {
            SelectGroup(index, webDriver);
            DeleteGroup(webDriver);
            GoToGropPageFromSubmit(webDriver);
            return this;
        }
    }
}
