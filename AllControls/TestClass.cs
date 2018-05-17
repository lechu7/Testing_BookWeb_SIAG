using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using RepoClass;


namespace AllControls
{
    [TestFixture]
    public class TestClass
    {
        public static IWebDriver driver;
        FirefoxDriverService service;

        public List<By> lista = new List<By>();
        ObjectBeforeLogin obl = new ObjectBeforeLogin();

        [SetUp]
        public void SetUp()
        {
            service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(service);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//PRĘDKOŚć SKRYPTU
            driver.Navigate().GoToUrl(REPO.side);

            obl.addToLists();//DODANIE WSZYSTKICH ELEMENTOW DO LIST
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
                    obl.IsTestElementPresent(driver, lista[i]);
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

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}




 
