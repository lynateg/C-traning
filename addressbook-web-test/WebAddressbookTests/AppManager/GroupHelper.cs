using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager)
            : base(manager)
        { }
        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
            groupCache = null;
            return this;
        }
        internal GroupHelper Modify(int index, GroupData groupData)
        {
            app.Navigator.GoToGroupsPage();
            SelectGroup(index);
            InitGroupModification();
            FillGroupForm(groupData);
            SubmitGroupModification();
            app.Navigator.GoToGroupsPage();
            return this;
        }
        private GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }
        private GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper FillGroupForm(GroupData groupInfo)
        {
            Type(By.Name("group_name"), groupInfo.GroupName);
            Type(By.Name("group_header"), groupInfo.GroupHeader);
            Type(By.Name("group_footer"), groupInfo.GroupFooter);
            return this;
        }
        public GroupHelper GoToGropPageFromSubmit()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper Create(GroupData groupInfo)
        {
            app.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(groupInfo);
            SubmitGroupCreation();
            GoToGropPageFromSubmit();
            return this;
        }
        public GroupHelper Delete(int index)
        {            
            app.Navigator.GoToGroupsPage();
            SelectGroup(index);
            DeleteGroup();
            GoToGropPageFromSubmit();
            return this;
        }
        public bool IsGroupExist(int index)
        {
            return IsElementPresent(By.XPath("//div[@id='content']/form/span[" + index + "]/input"));
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
        private List<GroupData> groupCache = null;
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null) 
            {
                groupCache = new List<GroupData>();
                app.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text));
                }
            }

            return new List<GroupData>(groupCache);
        }
    }
}
