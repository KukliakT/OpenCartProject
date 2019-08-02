﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test.Pages
{
    public class HomePage : TopPart
    {
        public const string IPHONE6 = "iPhone6";
        //
        public IWebElement Slideshow0
        { get { return driver.FindElement(By.Id("slideshow0")); } }

        private ProductsContainerComponent productsContainerComponent;

        public HomePage(IWebDriver driver) : base(driver)
        {
            productsContainerComponent = new ProductsContainerComponent(driver);
        }

        // Page Object

        // Slideshow0
        public IWebElement GetSlideshow0FirstImage()
        {
            //return Slideshow0.FindElement(By.CssSelector("a > img"));
            return Slideshow0.FindElement(By.XPath(".//a/img"));
            //return Slideshow0.FindElement(By.XPath("//a/img")); // ERROR
            //return driver.FindElement(By.XPath("//div[@id='slideshow0']//a/img"));
        }

        public string GetSlideshow0FirstImageAttributeText(string attribute)
        {
            return GetSlideshow0FirstImage().GetAttribute(attribute).Trim();
        }

        public string GetSlideshow0FirstImageAttributeSrcText()
        {
            return GetSlideshow0FirstImageAttributeText(TAG_ATTRIBUTE_SRC);
        }

        // productComponentsContainer
        public ProductsContainerComponent getProductComponentsContainer()
        {
            return productsContainerComponent;
        }

        // Functional

        // Business Logic
        //public HomePage chooseCurrency(Currencies currency)
        //{
        //    ClickCurrencyByPartialName(currency);
        //    return new HomePage(driver);
        //}

    }
}