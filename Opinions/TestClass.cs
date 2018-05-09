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

        [SetUp]
        public void SetUp()
        {
            service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(service);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//PRĘDKOŚć SKRYPTU
            driver.Navigate().GoToUrl(REPO.side);
        }

        [Test]
        public void Opinion2()//dodanie opinii z opisem - strona książki
        {
            //logowanie
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.loginUserTest, REPO.ET_login_mail);
            mbl.EnterPassword(driver,REPO.passUserTest, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            //przejście do listy książek
            driver.FindElement(REPO.TB_UpMain_books).Click();

            //wybranie Autobiografia
            bl.Click_on_book_Autobiografia(driver, REPO.BT_book_Autobiografia);

            //dodanie opinii
            bp.Add_description(driver, REPO.TA_books_page_description, "nie polecam");
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 0);
            bp.Submit_opinion(driver, REPO.BT_books_page_submit);

            //sprawdzenie, czy opinia jest na stronie książki
            driver.FindElement(REPO.DIV_books_page_opinionTest);
            Assert.Pass();

        }
        [Test]
        public void Opinion1()//dodanie opinii bez opisu - strona książki
        {
            //logowanie
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.loginUserTest, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUserTest, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            //przejście do listy książek
            driver.FindElement(REPO.TB_UpMain_books).Click();

            //wybranie Autobiografia
            bl.Click_on_book_Autobiografia(driver, REPO.BT_book_Autobiografia);

            //dodanie opinii
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 0);
            bp.Submit_opinion(driver, REPO.BT_books_page_submit);

            //sprawdzenie, czy opinia jest na stronie książki
            driver.FindElement(REPO.DIV_books_page_rateTest);
            Assert.Pass();

        }

        [Test]
        public void Opinion3()//dodanie opinii z opisem - profil uzytkownika
        {
            //logowanie
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.loginUserTest, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUserTest, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            //przejście do listy książek
            driver.FindElement(REPO.TB_UpMain_books).Click();

            //wybranie Autobiografia
            bl.Click_on_book_Autobiografia(driver, REPO.BT_book_Autobiografia);

            //dodanie opinii
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 0);
            bp.Add_description(driver, REPO.TA_books_page_description, "nie polecam");
            bp.Submit_opinion(driver, REPO.BT_books_page_submit);


            //przejście do profilu użytkownika
            driver.FindElement(REPO.TB_UpMain_profile).Click();

            //zaimplementować jak Daniel wprowadzi zmiany do profilu!!!!
            throw new NotImplementedException("test nie zaimplementowany!");

        }

        [Test]
        public void Opinion4()//dodanie opinii bez opisu - profil uzytkownika
        {
            //logowanie
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.loginUserTest, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUserTest, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            //przejście do listy książek
            driver.FindElement(REPO.TB_UpMain_books).Click();

            //wybranie Autobiografia
            bl.Click_on_book_Autobiografia(driver, REPO.BT_book_Autobiografia);

            //dodanie opinii
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 0);
            bp.Submit_opinion(driver, REPO.BT_books_page_submit);

            //przejście do profilu użytkownika
            driver.FindElement(REPO.TB_UpMain_profile).Click();
            

            //zaimplementować jak Daniel wprowadzi zmiany do profilu!!!!
            throw new NotImplementedException("test nie zaimplementowany!");

        }

        [Test]
        public void Opinion5()//sprawdzenie opinii innego użytkownika jako administrator - są opinie
        {
            //logowanie
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            mbl.EnterMail(driver, REPO.loginUserTest, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUserTest, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);


            //przejście do listy książek
            driver.FindElement(REPO.TB_UpMain_books).Click();

            //wybranie Autobiografia
            bl.Click_on_book_Autobiografia(driver, REPO.BT_book_Autobiografia);

            //dodanie opinii
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 0);
            bp.Submit_opinion(driver, REPO.BT_books_page_submit);

            //wylogowanie
            driver.Navigate().GoToUrl(REPO.side);
            driver.FindElement(REPO.TB_UpMain_logOut).Click();

            //logowanie jako admin
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            mbl.EnterMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);


            //przejście do listy użytkowników
            driver.FindElement(REPO.TB_UpMain_users).Click();

            //przejście do użytkownika test
            List_of_users.FindTestUser();

            //zaimplementować jak Daniel wprowadzi zmiany do profilu!!!!
            throw new NotImplementedException("test nie zaimplementowany!");
        }

        [Test]
        public void Opinion6()//sprawdzenie opinii innego użytkownika jako administrator - brak opinii
        {
            //logowanie jako admin
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            mbl.EnterMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);


            //przejście do listy użytkowników
            driver.FindElement(REPO.TB_UpMain_users).Click();

            //przejście do użytkownika test
            List_of_users.FindTestUser();
            //zaimplementować jak Daniel wprowadzi zmiany do profilu!!!!
            throw new NotImplementedException("test nie zaimplementowany!");
        }


        [TearDown]
        public void TearDown()
        {
            //wylogowanie
            driver.Navigate().GoToUrl(REPO.side);
            driver.FindElement(REPO.TB_UpMain_logOut).Click();
            //logowanie jako admin
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            //przejście do listy książek
            driver.FindElement(REPO.TB_UpMain_books).Click();

            //wybranie Autobiografia
            bl.Click_on_book_Autobiografia(driver, REPO.BT_book_Autobiografia);

            //usuwanie opinii użytkownika test
            try
            {
                while (true)
                {
                    driver.FindElement(By.XPath("//div[contains(.,'test')]/a[contains(.,'Usuń')]")).Click();
                }

            }
            catch (Exception) { }


            driver.Quit();


        }
    }
}
