using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using RepoClass;
using Login;

namespace OpinionsList
{
    [TestFixture]
    public class TestClass
    {
        public static IWebDriver driver;
        FirefoxDriverService service;

        Menu_before_login mbl = new Menu_before_login();
        OpinionsAPI oa = new OpinionsAPI();
        BooksAPI ba = new BooksAPI();
        TargetList tl = new TargetList();

        [SetUp]
        public void SetUp()
        {
            service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(service);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//PRĘDKOŚć SKRYPTU
            driver.Navigate().GoToUrl(REPO.side);
            driver.Manage().Window.Maximize();

        }

        //KROK 1 "Sprawdzenie wszystkich opinii"
        [Test]
            public void OpinionsList1()
        {
            //Listy opinii i książek(do zczytania tytułu)
            List<OpinionsObject> listOpinions = new List<OpinionsObject>();
            List<BooksObject> listBook = new List<BooksObject>();
            listOpinions =oa.opinionsList();
            listBook = ba.BookList();
           
            //Przygotowanie listy z odpowiednimi polami
            List<ObjectTargetList> targetList = new List<ObjectTargetList>();
            targetList = tl.ReturnTargetList(listOpinions, listBook);

            //ToDo
            //Sprawdzenie wszystkich tych opinii na stronie
            if (true)
            {

            }
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
