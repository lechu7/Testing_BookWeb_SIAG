using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using RepoClass;
using System.Threading;

namespace AllControls
{
    [TestFixture]
    public class TestClass
    {
        public static IWebDriver driver;
        FirefoxDriverService service;

        public List<By> lista = new List<By>();
        Login.Menu_before_login mbl = new Login.Menu_before_login();
        ObjectBeforeLogin obl = new ObjectBeforeLogin();
        ObjectUserLogin oul = new ObjectUserLogin();
        ObjectAdminLogin oal = new ObjectAdminLogin();

        [SetUp]
        public void SetUp()
        {
            service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(service);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//PRĘDKOŚć SKRYPTU
            driver.Navigate().GoToUrl(REPO.side);

            obl.addToLists();//DODANIE WSZYSTKICH ELEMENTOW DO LIST (ObjectBeforeLogin)
            oul.addToLists();//DODANIE WSZYSTKICH ELEMENTOW DO LIST (ObjectUserLogin)
            oal.addToLists();//DODANIE WSZYSTKICH ELEMENTOW DO LIST (ObjectUserLogin)
        }

        //KROK 1 "Sprawdzenie wszystkich kontolek (input, label, button) na wszystkich zakładkach przed zalogowaniem."
        [Test]
        public void AllControls1()
        {
            //1-home, 2 createAccount, 3 login, 4 books, 5 users, 6 author
            lista = obl.homePageList;
            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    Assert.True(obl.IsTestElementPresent(driver, lista[i]));
                }
                switch (j)
                {
                    case 0:
                        lista = obl.createAccountList;
                        obl.ClickLoginTab(driver, REPO.TB_UpMain_register);
                        break;
                    case 1:
                        lista = obl.loginList;
                        obl.ClickLoginTab(driver, REPO.TB_UpMain_login);
                        break;
                    case 2:
                        lista = obl.booksList;
                        obl.ClickLoginTab(driver, REPO.TB_UpMain_books);
                        break;
                    case 3:
                        lista = obl.usersList;
                        obl.ClickLoginTab(driver, REPO.TB_UpMain_users);
                        break;
                    case 4:
                        lista = obl.authorsList;
                        obl.ClickLoginTab(driver, REPO.TB_UpMain_authors);
                        break;
                    default:
                        lista = null;
                        break;
                }

            }

        }

        //KROK 2 "Sprawdzenie wszystkich kontolek (input, label, button) na wszystkich zakładkach jako User."
        [Test]
        public void AllControls2()
        {
            //0- log out 1-profile , 2 home, 3 books, 4 users, 6 author

            //logowanie user
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.loginUser2, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUser2, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            lista = oul.homePageList;
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    Assert.True(oul.IsTestElementPresent(driver, lista[i]));
                    
                }
                switch (j)
                {
                    case 0:
                        lista = oul.profileList;
                        oul.ClickLoginTab(driver, REPO.TB_UpMain_profile);
                        break;
                    case 1:
                        lista = oul.homePageList;
                        oul.ClickLoginTab(driver, REPO.TB_UpMain_mainsite);
                        break;
                    case 2:
                        lista = oul.booksList;
                        oul.ClickLoginTab(driver, REPO.TB_UpMain_books);
                        break;
                    case 3:
                        lista = oul.usersList;
                        oul.ClickLoginTab(driver, REPO.TB_UpMain_users);
                        break;
                    case 4:
                        lista = oul.authorsList;
                        oul.ClickLoginTab(driver, REPO.TB_UpMain_authors);
                        break;
                    default:
                        lista = null;
                        break;
                }

            }

        }

        //KROK 3 "Sprawdzenie wszystkich kontolek (input, label, button) na wszystkich zakładkach jako Admin."
        [Test]
        public void AllControls3()
        {
            //0- log out 1-profile , 2 home, 3 books, 4 users, 6 author, 7 addBook

            //logowanie admin
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.loginAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            lista = oal.homePageList;
            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    Assert.True(oal.IsTestElementPresent(driver, lista[i]));

                }
                switch (j)
                {
                    case 0:
                        lista = oal.profileList;
                        oal.ClickLoginTab(driver, REPO.TB_UpMain_profile);
                        break;
                    case 1:
                        lista = oal.homePageList;
                        oal.ClickLoginTab(driver, REPO.TB_UpMain_mainsite);
                        break;
                    case 2:
                        lista = oal.booksList;
                        oal.ClickLoginTab(driver, REPO.TB_UpMain_books);
                        break;
                    case 3:
                        lista = oal.usersList;
                        oal.ClickLoginTab(driver, REPO.TB_UpMain_users);
                        break;
                    case 4:
                        lista = oal.authorsList;
                        oal.ClickLoginTab(driver, REPO.TB_UpMain_authors);
                        break;
                    case 5:
                        lista = oal.addBookList;
                        oal.ClickLoginTab(driver, REPO.TB_UpMain_addBook);
                        break;
                    default:
                        lista = null;
                        break;
                }

            }

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}




 
