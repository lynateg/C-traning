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
            app.Groups.Create(new GroupData("xxx", "zzz", "yyy"));
        }
        [TestCase(TestName = "Добавление пустой группы контактов")]
        public void EmptyGroupCreationTest()
        {
            app.Groups.Create(new GroupData("", "", ""));
        }
        [TestCase(TestName = "Модификация группы контактов")]
        public void GroupModificationTest()
        {
            app.Groups.Modify(1, new GroupData("ooo", "ppp", "jjj"));
        }
        [TestCase(TestName = "Удаление группы 1")]
        public void RemoveGroup()
        {
            app.Groups.Delete(1);
        }
       
    }
}