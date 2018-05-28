using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using RepoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    [TestFixture]
    public class TestClass
    {
        public static IWebDriver driver;
        FirefoxDriverService service;

        SearchingForm sf = new SearchingForm();

        [SetUp]
        public void SetUp()
        {
            service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(service);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//PRĘDKOŚć SKRYPTU
            driver.Navigate().GoToUrl(REPO.side);
        }


        ////KROK 1 "Wyszukiwanie z frazą sortując rosnąco po tytule."
        [Test]
        public void Search1()
        {
            sf.EnterPhrase(driver, "", REPO.TB_all_search);
            sf.CheckPhrase(driver, "", REPO.TB_all_search);
            sf.EnterSort(driver, "title", REPO.SE_all_orders);
            sf.EnterType(driver, "Rosnąco", REPO.SE_all_sort);
            sf.ClickSearch(driver, REPO.BT_all_search);
            sf.CheckWhatSortWasDone(driver, REPO.SearchingTitleASC, "title,ASC");
        }
        ////KROK 2 "Wyszukiwanie z frazą sortując rosnąco po autorze."
        [Test]
        public void Search2()
        {
            sf.EnterPhrase(driver, "", REPO.TB_all_search);
            sf.CheckPhrase(driver, "", REPO.TB_all_search);
            sf.EnterSort(driver, "author", REPO.SE_all_orders);
            sf.EnterType(driver, "Rosnąco", REPO.SE_all_sort);
            sf.ClickSearch(driver, REPO.BT_all_search);
            sf.CheckWhatSortWasDone(driver, REPO.SearchingAuthorASC, "author,ASC");
        }
        ////KROK 3 "Wyszukiwanie z frazą sortując rosnąco po gatunku."
        [Test]
        public void Search3()
        {
            sf.EnterPhrase(driver, "", REPO.TB_all_search);
            sf.CheckPhrase(driver, "", REPO.TB_all_search);
            sf.EnterSort(driver, "genre", REPO.SE_all_orders);
            sf.EnterType(driver, "Rosnąco", REPO.SE_all_sort);
            sf.ClickSearch(driver, REPO.BT_all_search);
            sf.CheckWhatSortWasDone(driver, REPO.SearchingGenreASC, "genre,ASC");
        }
        ////KROK 4 "Wyszukiwanie z frazą sortując malejąco po tytule."
        [Test]
        public void Search4()
        {
            sf.EnterPhrase(driver, "", REPO.TB_all_search);
            sf.CheckPhrase(driver, "", REPO.TB_all_search);
            sf.EnterSort(driver, "title", REPO.SE_all_orders);
            sf.EnterType(driver, "Malejąco", REPO.SE_all_sort);
            sf.ClickSearch(driver, REPO.BT_all_search);
            sf.CheckWhatSortWasDone(driver, REPO.SearchingTitleDESC, "title,DESC");
        }
        ////KROK 5 "Wyszukiwanie z frazą sortując malejąco po autorze."
        [Test]
        public void Search5()
        {
            sf.EnterPhrase(driver, "", REPO.TB_all_search);
            sf.CheckPhrase(driver, "", REPO.TB_all_search);
            sf.EnterSort(driver, "author", REPO.SE_all_orders);
            sf.EnterType(driver, "Malejąco", REPO.SE_all_sort);
            sf.ClickSearch(driver, REPO.BT_all_search);
            sf.CheckWhatSortWasDone(driver, REPO.SearchingAuthorDESC, "author,DESC");
        }
        ////KROK 6 "Wyszukiwanie z frazą sortując malejąco po gatunku."
        [Test]
        public void Search6()
        {
            sf.EnterPhrase(driver, "", REPO.TB_all_search);
            sf.CheckPhrase(driver, "", REPO.TB_all_search);
            sf.EnterSort(driver, "genre", REPO.SE_all_orders);
            sf.EnterType(driver, "Malejąco", REPO.SE_all_sort);
            sf.ClickSearch(driver, REPO.BT_all_search);
            sf.CheckWhatSortWasDone(driver, REPO.SearchingGenreDESC, "genre,DESC");
        }

        //KROK 7 "Sprawdzenie czy będzie komunikat Brak ksiazki o podanych parametrach."
        [Test]
        public void Search7()
        {
            sf.EnterPhrase(driver, "123a", REPO.TB_all_search);
            sf.CheckPhrase(driver, "123a", REPO.TB_all_search);
            sf.ClickSearch(driver, REPO.BT_all_search);
            sf.CheckShowError(driver, REPO.NoBookError);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
