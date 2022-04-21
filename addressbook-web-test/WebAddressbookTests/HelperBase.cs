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
        protected IWebDriver _webDriver;
        public HelperBase(IWebDriver webDriver) 
        {
            _webDriver = webDriver;
        }
    }
}