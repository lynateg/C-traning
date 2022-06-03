﻿using OpenQA.Selenium;
using System;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public string baseURL;
        public LoginHelper(ApplicationManager manager, string baseURL)
            : base(manager) 
        {
            this.baseURL = baseURL;
        }
        public LoginHelper OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
            return this;
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if(IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
                driver.FindElement(By.Name("user"));
            }
        }
        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text 
                == "(" + account.Username + ")";
            
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }


    }
}