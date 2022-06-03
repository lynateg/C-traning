using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {        
        public ContactHelper(ApplicationManager manager)
            : base(manager) 
        {}
        
        public ContactHelper Delete(int i)
        {
            app.Auth.OpenHomePage();
            SelectContact(i);
            InitDeleteContact();
            CloseAlertWindow();
            return this;
        }
        public ContactHelper New(UserData userData)
        {
            driver.FindElement(By.LinkText("add new")).Click();
            Type(By.Name("firstname"), userData.Firstname);
            Type(By.Name("middlename"), userData.Middlename);
            Type(By.Name("lastname"), userData.Lastname);
            Type(By.Name("nickname"), userData.Nickname);
            ConfirmCreationNewContact();
            return this;
        }
        public ContactHelper UpdateModification()
        {
            driver.FindElement(By.XPath("//*[@id='content']/form[2]/div[2]/input")).Click();
            return this;
        }
        public ContactHelper InitModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@title='Edit'])[" + (index) + "]")).Click();
            return this;
        }
        public ContactHelper GoToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper InitDeleteContact()
        {
            driver.FindElement(By.XPath("//*[@id='content']/form[2]/div[2]/input")).Click();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//tr[@name='entry'][" + (index+1) + "]/ td/input")).Click();
            return this;
        }
        public ContactHelper CloseAlertWindow()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper ConfirmCreationNewContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }
        public ContactHelper Modify(UserData userData)
        {
            app.Auth.OpenHomePage();
            InitModification(1);
            New(userData);
            GoToHomePage();
            return this;
        }
        public bool IsContactExist(int index)
        {
            return IsElementPresent(By.XPath("//tr[@name='entry'][" + (index) + "]//img[@title='Edit']"));
        }
    }
}
