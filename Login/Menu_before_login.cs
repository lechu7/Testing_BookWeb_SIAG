using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace Login
{
    public class Menu_before_login
    {

        public void ClickLoginTab(IWebDriver driver, By loginTabBy)
        {
            driver.FindElement(loginTabBy).Click();
        }

        public void EnterMail(IWebDriver driver,string mail,By mailBy)
        {
            driver.FindElement(mailBy).SendKeys(mail);
            //Assert.AreEqual(driver.FindElement(mailObj), mail);
        }
        public void EnterPassword(IWebDriver driver, string password, By passBy)
        {
            driver.FindElement(passBy).SendKeys(password);
            //   Assert.AreEqual(ET_password.Text, password);
        }
        


    }
}
