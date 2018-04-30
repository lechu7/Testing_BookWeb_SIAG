using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Threading;

namespace Login
{
    public class Menu_before_login
    {

        public void ClickLoginTab(IWebDriver driver, By loginTabBy)
        {
            driver.FindElement(loginTabBy).Click();
        }
        public void EnterMail(IWebDriver driver, string mail, By mailBy)
        {
           driver.FindElement(mailBy).SendKeys(mail);
        }
        public void CheckMail(IWebDriver driver, string mail, By mailBy)
        {
            Assert.AreEqual(driver.FindElement(mailBy).GetAttribute("value"), mail);
        }
        public void EnterPassword(IWebDriver driver, string password, By passBy)
        {
            driver.FindElement(passBy).SendKeys(password);
        }
        public void ClickLogIn(IWebDriver driver, By logInBy)
        {
            driver.FindElement(logInBy).Click();
        }
        public void CheckShowError(IWebDriver driver, By errorBy)
        {
            Assert.IsTrue(driver.FindElement(errorBy).Displayed);
        }
        public void CheckLoginAsAdmin(IWebDriver driver, By addBookTabBy)
        {
            Assert.IsTrue(IsTestElementPresent(driver, addBookTabBy));
        }
        public void CheckLoginAsUser(IWebDriver driver, By addBookTabBy)
        {
            Assert.IsFalse(IsTestElementPresent(driver, addBookTabBy));
        }
        public void CheckLogin(IWebDriver driver, By logBy)
        {
            Assert.IsTrue(IsTestElementPresent(driver, logBy));
        }




        public bool IsTestElementPresent(IWebDriver driver, By byOBJ)
        {
            try
            {
                driver.FindElement(byOBJ);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
