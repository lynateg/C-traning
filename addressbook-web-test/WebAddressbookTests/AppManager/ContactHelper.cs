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
            app.Auth.OpenHomePage();
            return this;
        }
        public ContactHelper New(UserData userData)
        {
            driver.FindElement(By.LinkText("add new")).Click();
            Type(By.Name("firstname"), userData.Firstname);
            //Type(By.Name("middlename"), userData.Middlename);
            Type(By.Name("lastname"), userData.Lastname);
            //Type(By.Name("nickname"), userData.Nickname);
            ConfirmCreationNewContact();
            //GoToHomePage();
            return this;
        }
        public ContactHelper UpdateModification()
        {
            driver.FindElement(By.XPath("//*[@id='content']/form[2]/div[2]/input")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper InitModification(int index)
        {
            //driver.FindElement(By.XPath("(//img[@title='Edit'])[" + (index) + "]")).Click();
            driver.FindElement(By.XPath("(.//input[@name= 'selected[]'])[" + (index + 1) + "]/following::img[2]")).Click();
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
            contactCache = null;
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
            contactCache = null;
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
        private List<UserData> contactCache = null;
        public List<UserData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<UserData>();
                app.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new UserData(element.FindElement(By.XPath("./td[3]")).Text,
                        element.FindElement(By.XPath("./td[2]")).Text));
                }
            }
            return new List<UserData>(contactCache);
        }

        public UserData GetContactInformationFromTable(int index)
        {
            app.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new UserData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }
        public UserData GetContactInformationFromEditForm(int index)
        {
            app.Navigator.OpenHomePage();
            InitModification(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            var x = new UserData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
            return x;       
        }
        public int GetNumberOfSearchResults()
        {
            app.Navigator.OpenHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
        public UserData GetContactInformationFromDetails(int index)
        {
            app.Navigator.OpenHomePage();
            Thread.Sleep(300);
            GoToContactDetails(0);

            string AllContactData = driver.FindElement(By.XPath("//div[@id='content']")).Text;

            return new UserData()
            {
                AllContactData = AllContactData
            };

        }
        public ContactHelper GoToContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }
    }

}
