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
        protected string _baseURL;
        public HelperBase(ApplicationManager manager) 
        {
            _manager = manager;
            _baseURL = manager.BaseURL;
        }

    }
}