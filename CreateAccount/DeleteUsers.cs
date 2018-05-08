using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using RepoClass;
using System.Collections.Generic;

namespace RepoClass
{

    public class DeleteTestUser
    {
        
        static Login.Menu_before_login mbl = new Login.Menu_before_login();

        public static void Delete(IWebDriver driver,string userName)
        {
            bool deleteUser=false;

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
            while (!IsTestElementPresent(driver,REPO.BT_users_nextPageDisabled))
            {
                driver.FindElement(REPO.BT_users_nextPage).Click();
                if (IsTestElementPresent(driver,REPO.LB_users_TestowyUserDelete))
                {
                    driver.FindElement(REPO.LB_users_TestowyUserDelete).Click();
                    Thread.Sleep(500);
                    driver.FindElement(REPO.BT_yourProfile_delete).Click();
                    deleteUser = true;
                    break;
                }
            }
            if (!deleteUser)
            {
                Assert.Fail("Nie udało się skasować 'TestowyUserToDelete'");
            }
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
