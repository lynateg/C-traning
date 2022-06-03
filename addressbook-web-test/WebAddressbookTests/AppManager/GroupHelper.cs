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
            return this;
        }
        internal GroupHelper Modify(int index, GroupData groupData)
        {
            app.Navigator.GoToGroupsPage();
            SelectGroup(index);
            InitGroupModification();
            FillGroupForm(groupData);
            SubmitGroupModification();
            return this;
        }
        private GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
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

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            app.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                if (!string.IsNullOrEmpty(element.Text) && !string.IsNullOrEmpty(element.TagName))
                {
                    groups.Add(new GroupData(element.Text, element.TagName));
                }
            
            }
            return groups;
        }
    }
}
