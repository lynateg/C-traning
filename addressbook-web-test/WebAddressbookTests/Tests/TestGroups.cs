using NUnit.Framework;
using OpenQA.Selenium;


namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupTests : TestBase
    {
        [TestCase(TestName = "Добавление группы контактов")]
        //[Test]
        public void GroupCreationTest()
        {
            GroupCreationTest(driver);
        }
        [TestCase(TestName = "Добавление пустой группы контактов")]
        public void EmptyGroupCreationTest()
        {
            GroupCreationTest(driver);
        }
        [TestCase(TestName = "Модификация группы контактов")]
        public void GroupModificationTest()
        {
            app.Groups.Modify(1, new GroupData("ooo", "ppp", "jjj"), driver);
        }
        [TestCase(TestName = "Удаление группы 1")]
        public void RemoveGroup()
        {
            app.Groups.Delete(1, driver);
        }
        private void GroupCreationTest(IWebDriver driver)
        {
            app.Groups.Create(new GroupData("", "", ""), driver);
            app.Groups.Create(new GroupData("xxx", "zzz", "yyy"), driver);
        }
    }
}