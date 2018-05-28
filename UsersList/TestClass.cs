using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using RepoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersList
{
    [TestFixture]
    public class TestClass
    {
        public int whatShouldBeDeleted = 0;
        public static IWebDriver driver;
        FirefoxDriverService service;


        public UsersAPI UA = new UsersAPI();


        [Test]
        public void UserListTest()
        {
            //stworzenie listy uzytkownikow na podstawie otrzymanych danych
            List<string> usersList = UA.userList();

            //przejście do stronki
            service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(service);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//PRĘDKOŚć SKRYPTU
            driver.Navigate().GoToUrl(REPO.side);

            //przejście do listy uzytkownikow
            driver.FindElement(REPO.TB_UpMain_users).Click();

            //przejscie po elementach uzytkownikow i sprawdzenie czy kazdy element(uzytkownik) istnieje na stronie
            for (int i = 0, j = 0; i < usersList.Count; i++, j++)
            {
                //sprawdzenie, czy uzytkownik się wyświetla
                if (usersList[i] != "admin")
                {
                    string xPath1 = "//a[contains(.,'" + usersList[i] + "')]";
                    driver.FindElement(By.XPath(xPath1));

                    //przejście do następnej strony listy
                    if (j == 9)
                    {
                        j = -1;//-1 bo po zakonczeniu pętli będzie podniesione o 1, a ma startować od 0
                        driver.FindElement(REPO.BT_book_nextPage).Click();
                    }
                }
            }

            driver.Quit();

        }
    }
}
