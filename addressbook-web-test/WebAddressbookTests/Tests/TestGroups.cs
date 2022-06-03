using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupTests : AuthTestBase
    {
        private GroupData groupinfo;

        [TestCase(TestName = "Добавление группы контактов")]
        //[Test]
        public void GroupCreationTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            
            app.Groups.Create(new GroupData("xxx", "zzz", "yyy"));
            groupinfo = new GroupData("xxx", "zzz", "yyy");

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(groupinfo);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }
        [TestCase(TestName = "Добавление пустой группы контактов")]
        public void EmptyGroupCreationTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(new GroupData("", "", ""));

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
        [TestCase(TestName = "Добавление неправильной группы контактов")]
        public void BadNameGroupCreationTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(new GroupData("f'f", "q'q", ""));
            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreNotEqual(oldGroups.Count + 1, newGroups.Count);
        }
        [TestCase(TestName = "Модификация группы контактов")]
        public void GroupModificationTest()
        {
            app.Groups.Modify(1, new GroupData("ooo", "ppp", "jjj"));
        }
        [TestCase(TestName = "Удаление группы 1")]
        public void RemoveGroup()
        {
            if (!app.Groups.IsGroupExist(1))
            {
                app.Groups.Create(new GroupData("BBQ", "QQB", "eagle"));
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Delete(1);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);
        }
       
    }
}