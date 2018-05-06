using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using RepoClass;

namespace Opinions
{
    [TestFixture]
    public class TestClass
    {
        public static IWebDriver driver;
        FirefoxDriverService service;


        Login.Menu_before_login mbl = new Login.Menu_before_login();
        Books_list bl = new Books_list();
        Books_page bp = new Books_page();

        string mailAdmin = "admin@example.com";
        string loginAdmin = "admin";
        string passAdmin = "admos384";

        string mailUser = "totalnie.testowy.test@gmail.com";
        string loginUser = "test";
        string passUser = "EQ0GI3A0a";





        [SetUp]
        public void SetUp()
        {
            service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(service);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//PRĘDKOŚć SKRYPTU
            driver.Navigate().GoToUrl("https://siag-bookweb.herokuapp.com");
        }

        [Test]
        public void Opinion1()//dodanie opinii jako zwykły user
        {
            //logowanie
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, loginUser, REPO.ET_login_mail);
            
            mbl.EnterPassword(driver, passUser, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            //przejście do listy książek
            driver.FindElement(REPO.TB_UpMain_books).Click();

            //wybranie Autobiografia
            bl.Click_on_book_Autobiografia(driver, REPO.AH_book_Autobiografia);

            //dodanie opinii
            bp.Add_description(driver, REPO.TA_description, "nie polecam");
            bp.Add_rate(driver, REPO.SE_opinion_rate, 0);
            bp.Submit_opinion(driver, REPO.BT_submit);

            //sprawdzenie, czy opinia jest na stronie książki
          
                driver.FindElement(REPO.DIV_opinion_test);
                Assert.Pass();
            

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
