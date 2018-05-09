using NUnit.Framework;
using OpenQA.Selenium;
using RepoClass;
using System;

namespace Opinions
{
    static class List_of_users
    {
        public static void ClickNext()
        {
            TestClass.driver.FindElement(REPO.BT_users_nextPage).Click();
        }

        public static bool CheckIfNextIsDisabled()
        {
            try
            {
                TestClass.driver.FindElement(REPO.BT_users_nextPageDisabled);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static void ClickOnUserTest()
        {
            TestClass.driver.FindElement(By.XPath("//a[contains(.,'Użytkownik test')]")).Click();
        }

        public static void FindTestUser()
        {
            while(true)
            {
                try
                {
                    ClickOnUserTest();
                    break;
                }
                catch (Exception e)
                {
                    if (CheckIfNextIsDisabled())
                        throw e;

                    ClickNext();
                    
                }
            }
        }
    }
}
