using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using RepoClass;
using System.Collections.Generic;

namespace RepoClass
{

    public class DeleteUsers
    {
        
        static Login.Menu_before_login mbl = new Login.Menu_before_login();

        public static void Delete(IWebDriver driver,string userName)
        {
            //Wylogowanie się z Testowego
            if (IsTestElementPresent(driver,REPO.TB_UpMain_logOut))
            {
                driver.FindElement(REPO.TB_UpMain_logOut).Click();
            }
            else
            {
                Assert.Fail();
            }
            //logowanie na ADMIN
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.loginAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            //Wyszukiwanie Usera
            driver.FindElement(REPO.TB_UpMain_users).Click();
            Thread.Sleep(500);

            //IWebElement pagingInfo = webDriver.FindElement(REPO.SE_users_pagination);
            //string[] stringArray = pagingInfo.Text.Split(' ');
            //int countPage= 
            //int sizePagination=REPO.SE_users_pagination.

        }

        public static bool IsTestElementPresent(IWebDriver driver, By byOBJ)
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
