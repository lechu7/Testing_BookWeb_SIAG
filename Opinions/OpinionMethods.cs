using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using RepoClass;
using System.Collections.Generic;

namespace Opinions
{
    public static class OpinionMethods
    {
        public static void GoingToBooksPage(IWebDriver driver, string BooksName)
        {
            //wyszukanie książki
            IJavaScriptExecutor js = (IJavaScriptExecutor)TestClass.driver;
            js.ExecuteScript("javascript:window.scrollBy(0,700)");
            driver.FindElement(REPO.TB_all_search).SendKeys(BooksName);
            driver.FindElement(REPO.BT_all_search).Click();

           driver.FindElement(By.XPath("//h4[@class='title']/a[contains(text(),'" + BooksName + "')]")).Click();


        }
    }
}
