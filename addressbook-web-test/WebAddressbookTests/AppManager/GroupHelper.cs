using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        private IWebDriver _webDriver;
        public GroupHelper(ApplicationManager manager, IWebDriver webDriver)
            : base(manager)
        {
            _webDriver = webDriver;
        }
        public GroupHelper DeleteGroup()
        {
            _webDriver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
            return this;
        }

        internal GroupHelper Modify(int index, GroupData groupData)
        {
            _manager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            InitGroupModification();
            FillGroupForm(groupData);
            SubmitGroupModification();
            return this;
        }

        private GroupHelper SubmitGroupModification()
        {
            _webDriver.FindElement(By.Name("update")).Click();
            return this;
        }

        private GroupHelper InitGroupModification()
        {
            _webDriver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            _webDriver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public GroupHelper InitGroupCreation()
        {
            _webDriver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {
            _webDriver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData groupInfo)
        {
            _webDriver.FindElement(By.Name("group_name")).Click();
            _webDriver.FindElement(By.Name("group_name")).Clear();
            _webDriver.FindElement(By.Name("group_name")).SendKeys(groupInfo.GroupName);
            _webDriver.FindElement(By.Name("group_header")).Click();
            _webDriver.FindElement(By.Name("group_header")).Clear();
            _webDriver.FindElement(By.Name("group_header")).SendKeys(groupInfo.GroupHeader);
            _webDriver.FindElement(By.Name("group_footer")).Click();
            _webDriver.FindElement(By.Name("group_footer")).Clear();
            _webDriver.FindElement(By.Name("group_footer")).SendKeys(groupInfo.GroupFooter);
            return this;
        }

        public GroupHelper GoToGropPageFromSubmit()
        {
            _webDriver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper Create(GroupData groupInfo)
        {
            _manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(groupInfo);
            SubmitGroupCreation();
            GoToGropPageFromSubmit();
            return this;
        }
        public GroupHelper Delete(int index)
        {
            _manager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            DeleteGroup();
            GoToGropPageFromSubmit();
            return this;
        }
    }
}
