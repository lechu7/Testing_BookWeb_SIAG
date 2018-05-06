using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Opinions
{
    class Books_page
    {
        public void Add_description(IWebDriver driver, By descriptionBy, string opinion)
        {
            driver.FindElement(descriptionBy).SendKeys(opinion);
        }

        public void Add_rate(IWebDriver driver, By rateBy, int index)
        {
            var rate = driver.FindElement(rateBy);
            var selectElement = new SelectElement(rate);
            selectElement.SelectByIndex(index);
        }
        public void Submit_opinion(IWebDriver driver, By submitBy)
        {
            driver.FindElement(submitBy).Click();
        }


    }
    class Books_list
    {
        public void Click_on_book_Autobiografia(IWebDriver driver, By AutobiografiaButtonBy)
        {
            driver.FindElement(AutobiografiaButtonBy).Click();
        }
    }
}
