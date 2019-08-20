﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OpenCart414Test.Pages
{
    public class CartEmptyContainerComponent
    {
        private IWebDriver driver;

        public IWebElement InfoMessage
        { get { return driver.FindElement(By.CssSelector("li p.text-center")); } }

        public CartEmptyContainerComponent(IWebDriver driver)
        {
            this.driver = driver;
            CheckElements();
        }

        private void CheckElements()
        {
            // TODO Develop Custom Exception
            IWebElement temp = InfoMessage; // TODO All Web Elements
        }

        // Page Object

        // InfoMessage
        public string GetInfoMessageText()
        {
            return InfoMessage.Text;
        }

        // Functional

        // Business Logic
    }
}