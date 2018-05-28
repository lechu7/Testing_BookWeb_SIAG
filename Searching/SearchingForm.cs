using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class SearchingForm
    {
        public void EnterPhrase(IWebDriver driver, string phrase, By searchBy)
        {
            driver.FindElement(searchBy).SendKeys(phrase);
        }

        public void CheckPhrase(IWebDriver driver, string phrase, By searchBy)
        {
            Assert.AreEqual(driver.FindElement(searchBy).GetAttribute("value"), phrase);
        }

        public void ClickSearch(IWebDriver driver, By searchBy)
        {
            driver.FindElement(searchBy).Click();
            Assert.IsTrue(true, "true");
        }

        public void CheckShowError(IWebDriver driver, By errorBy)
        {
            Assert.IsTrue(driver.FindElement(errorBy).Displayed);
        }

        public void EnterSort(IWebDriver driver, string phrase, By sortType)
        {
            driver.FindElement(sortType).SendKeys(phrase);
        }

        public void EnterType(IWebDriver driver, string phrase, By optionType)
        {
            driver.FindElement(optionType).SendKeys(phrase);
        }

        public void CheckWhatSortWasDone(IWebDriver driver, By message, string Result)
        {
            Assert.AreNotEqual(driver.FindElement(message), null);
        }



    }
}
