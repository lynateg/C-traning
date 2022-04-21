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
    public class HelperBase
    {
        protected ApplicationManager _manager;
        public IWebDriver _driver;
        public IWebDriver _driver2;
        private string _baseURL;

        public HelperBase(ApplicationManager manager) 
        {
            _manager = manager;
            _driver = manager.Driver;
            _driver2 = manager.Driver2;
            
        }

        public HelperBase(IWebDriver webDriver, string baseURL)
        {
            _baseURL = baseURL;
        }
    }
}