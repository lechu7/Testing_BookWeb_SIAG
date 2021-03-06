﻿using NUnit.Framework;
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
        string BooksName = "Narrenturm";

        [SetUp]
        public void SetUp()
        {
            service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(service);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//PRĘDKOŚć SKRYPTU
            driver.Navigate().GoToUrl(REPO.side);
            driver.Manage().Window.Maximize();

            //usuwanie wszystkim opinii//logowanie jako admin
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            OpinionMethods.GoingToBooksPage(driver, BooksName);
            
            //usuwanie opinii użytkowników
            try
            {
                while (true)
                {
                    driver.FindElement(By.XPath("//p[contains(.,'/5')]/a[contains(.,'Usuń')]")).Click();
                }

            }
            catch (Exception) { }

            //wylogowanie
            driver.FindElement(REPO.TB_UpMain_logOut).Click();
        }

        [Test]
        public void Opinion2()//dodanie opinii z opisem - strona książki
        {
            //logowanie
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.loginUserTest, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUserTest, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);
            //przejscie do książki
            OpinionMethods.GoingToBooksPage(driver, BooksName);


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

            OpinionMethods.GoingToBooksPage(driver, BooksName);


            //dodanie opinii
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 0);
            bp.Submit_opinion(driver, REPO.BT_books_page_submit);

            //sprawdzenie komunikatu
            driver.FindElement(By.XPath("//div[contains(.,'Opinia została dodana')]"));

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
            //przejscie do książki
            OpinionMethods.GoingToBooksPage(driver, BooksName);


            //dodanie opinii
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 0);
            bp.Add_description(driver, REPO.TA_books_page_description, "nie polecam");
            bp.Submit_opinion(driver, REPO.BT_books_page_submit);

            //sprawdzenie komunikatu
            driver.FindElement(By.XPath("//div[contains(.,'Opinia została dodana')]"));

            //przejście do profilu użytkownika
            driver.FindElement(REPO.TB_UpMain_profile).Click();

            //sprawdzenie, czy opinia jest na profilu usera
            driver.FindElement(By.XPath("//a[contains(.,'"+BooksName+"')]"));
            driver.FindElement(By.XPath("//div[contains(.,'1/5')]"));
            driver.FindElement(By.XPath("//div[contains(.,'nie polecam')]"));


            Assert.Pass();
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

            //przejscie do książki
            OpinionMethods.GoingToBooksPage(driver, BooksName);


            //dodanie opinii
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 0);
            bp.Submit_opinion(driver, REPO.BT_books_page_submit);

            //przejście do profilu użytkownika
            driver.FindElement(REPO.TB_UpMain_profile).Click();



            driver.FindElement(By.XPath("//div[@class='media-body']/div/a[contains(text(),'" + BooksName + "')]/parent::div/parent::div[@class='media-body']/div[contains(text(),'1/5')]/parent::div[@class='media-body']/div[contains(text(),'')]"));
               // "/parent::div/parent::p/div[contains(text(),'1/5')]/parent::p/div[contains(text(),'')]"));


            Assert.Pass();

        }

        [Test]
        public void Opinion5()//sprawdzenie opinii innego użytkownika jako administrator - są opinie
        {
            //logowanie
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            mbl.EnterMail(driver, REPO.loginUserTest, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUserTest, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);


            //przejscie do książki
            OpinionMethods.GoingToBooksPage(driver, BooksName);

            //dodanie opinii
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 0);
            bp.Add_description(driver, REPO.TA_books_page_description, "nie polecam");
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

            driver.FindElement(By.XPath("//div[@class='media-body']/div/a[contains(text(),'" + BooksName + "')]/parent::div/parent::div[@class='media-body']/div[contains(text(),'1/5')]/parent::div[@class='media-body']/div[contains(text(),'')]"));

            Assert.Pass();
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


            try
            {
                driver.FindElement(By.XPath("//div[@class='media-body']/div[contains(.,'/5')]"));
            }
            catch (NoSuchElementException)
            {

                Assert.Pass();
            }
            Assert.Fail();
        }
        [Test]
        public void Opinion7()//sprawdzenie czy można dać opis opinii o długości powyżej 1000 znaków
        {
            //logowanie
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.loginUserTest, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUserTest, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            //przejscie do książki
            OpinionMethods.GoingToBooksPage(driver, BooksName);

            //dodanie opinii
            bp.Add_description(driver, REPO.TA_books_page_description, LoremIpsum.lo);
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 0);
            bp.Submit_opinion(driver, REPO.BT_books_page_submit);

            //sprawdzenie, czy wyskakuje odpowiedni komentarz
            driver.FindElement(By.XPath("//div[contains(.,'Wymagane jest podanie wszystkich opcji. Opis może mieć max 1000 znaków. Wartość oceny od 1 do 5.')]"));
            //sprawdzenie, czy opinia jest na stronie książki
            try
            {
                driver.FindElement(By.XPath("//div[contains(.,'test')]"));
            }
            catch (NoSuchElementException)
            {

                Assert.Pass();
            }
            Assert.Fail();

        }

        [Test]
        public void Opinion8()//usunięcie swojej opinii
        {
            //logowanie
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.loginUserTest, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUserTest, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            //przejscie do książki
            OpinionMethods.GoingToBooksPage(driver, BooksName);

            //dodanie opinii
            bp.Add_description(driver, REPO.TA_books_page_description, "nie polecam");
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 0);
            bp.Submit_opinion(driver, REPO.BT_books_page_submit);


            //usunięcie opinii
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("javascript:window.scrollBy(0,350)");
            driver.FindElement(By.XPath("//p[contains(.,'/5')]/a[contains(.,'Usuń')]")).Click();
            driver.FindElement(By.XPath("//div[contains(.,'Usunięto opinię')]"));

            //sprawdzenie
            try
            {
                driver.FindElement(By.XPath("//div[contains(.,'test ocenił 1/5: nie polecam')]"));
            }
            catch (NoSuchElementException)
            {

                Assert.Pass();
            }

        }

        [Test]
        public void Opinion9()//usuwanie opinii jako admin  
        {
            //logowanie jako test
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.loginUserTest, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUserTest, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            //przejscie do książki
            OpinionMethods.GoingToBooksPage(driver, BooksName);

            //dodanie opinii
            bp.Add_description(driver, REPO.TA_books_page_description, "nie polecam");
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

            //przejscie do książki
            OpinionMethods.GoingToBooksPage(driver, BooksName);

            //usuwanie opinii użytkownika test
         
                    driver.FindElement(By.XPath("//p[contains(.,'test ocenił 1/5: nie polecam')]/a[contains(.,'Usuń')]")).Click();
               
            
            //sprawdzenie
            try
            {
                driver.FindElement(By.XPath("//p[contains(.,'test ocenił 1/5: nie polecam')]"));
            }
            catch (NoSuchElementException)
            {

                Assert.Pass();
            }
            Assert.Fail();

        }

        [Test]
        public void Opinion10()//sprawdzenie poprawności średniej ocen
        {
            //logowanie jako admin
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            mbl.EnterMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);

            //przejscie do książki
            OpinionMethods.GoingToBooksPage(driver, BooksName);

            //usuwanie opinii użytkowników
            try
            {
                while (true)
                {
                    driver.FindElement(By.XPath("//p[contains(.,'/5')]/a[contains(.,'Usuń')]")).Click();

                }

            }
            catch (NoSuchElementException) { }

            //wylogowanie
            driver.Navigate().GoToUrl(REPO.side);
            driver.FindElement(REPO.TB_UpMain_logOut).Click();



            //UŻYTKOWNIK TEST
            //logowanie
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.loginUserTest, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUserTest, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            //przejscie do książki
            OpinionMethods.GoingToBooksPage(driver, BooksName);

            //dodanie opinii
            bp.Add_description(driver, REPO.TA_books_page_description, "nie polecam");
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 0);
            bp.Submit_opinion(driver, REPO.BT_books_page_submit);

            //wylogowanie
            driver.Navigate().GoToUrl(REPO.side);
            driver.FindElement(REPO.TB_UpMain_logOut).Click();


            //UŻYTKOWNIK Test2
            //logowanie
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, "test2", REPO.ET_login_mail);
            mbl.EnterPassword(driver, "EQ0GI3A0a", REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            //przejscie do książki
            OpinionMethods.GoingToBooksPage(driver, BooksName);

            //dodanie opinii
            bp.Add_description(driver, REPO.TA_books_page_description, "nie polecam, test2");
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 3);
            bp.Submit_opinion(driver, REPO.BT_books_page_submit);

            //wylogowanie
            driver.Navigate().GoToUrl(REPO.side);
            driver.FindElement(REPO.TB_UpMain_logOut).Click();



            //UŻYTKOWNIK JKWITEK
            //logowanie
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.loginUser2, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUser2, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            //przejscie do książki
            OpinionMethods.GoingToBooksPage(driver, BooksName);

            //dodanie opinii
            bp.Add_description(driver, REPO.TA_books_page_description, "nie polecam");
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 4);
            bp.Submit_opinion(driver, REPO.BT_books_page_submit);

            //wylogowanie
            driver.Navigate().GoToUrl(REPO.side);
            driver.FindElement(REPO.TB_UpMain_logOut).Click();

            //sprawdzenie
            //logowanie
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.loginUser2, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUser2, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            //przejscie do książki
            OpinionMethods.GoingToBooksPage(driver, BooksName);

            //sprawdzenie średniej
            driver.FindElement(By.XPath("//div[contains(.,'Średnia 3.33')]"));
            Assert.Pass();
        }

        [Test]
        public void Opinion11()//sprawdzenie komunikatu przy dodawaniu opinii
        {
            //logowanie
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.loginUserTest, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUserTest, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            //przejscie do książki
            OpinionMethods.GoingToBooksPage(driver, BooksName);

            //dodanie opinii
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 0);
            bp.Submit_opinion(driver, REPO.BT_books_page_submit);

            driver.FindElement(By.XPath("//div[contains(.,'Opinia została dodana')]"));
            Assert.Pass();

        }
        [Test]
        public void Opinion12()//dodanie dwoch opinii
        {
            //logowanie
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.loginUserTest, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUserTest, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);

            //przejscie do książki
            OpinionMethods.GoingToBooksPage(driver, BooksName);

            //dodanie opinii
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 0);
            bp.Submit_opinion(driver, REPO.BT_books_page_submit);

            //dodanie drugiej opinii
            bp.Add_rate(driver, REPO.SE_books_page_opinionRate, 4);
            bp.Submit_opinion(driver, REPO.BT_books_page_submit);

            //sprawdzenie
            driver.FindElement(By.XPath("//div[contains(.,'Dodałeś już opinię do tej książki')]"));
            try
            {
                driver.FindElement(By.XPath("//div[contains(.,'test ocenił 5/5:')"));
            }
            catch (Exception)
            {

                Assert.Pass();
            }
            Assert.Fail();

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

            //przejscie do strony książki
            OpinionMethods.GoingToBooksPage(driver, BooksName);


            //usuwanie opinii użytkownika test
            try
            {
                while (true)
                {
                    driver.FindElement(By.XPath("//p[contains(.,'test')]/a[contains(.,'Usuń')]")).Click();
                }

            }
            catch (Exception) { }




            driver.Quit();


        }
    }
}
