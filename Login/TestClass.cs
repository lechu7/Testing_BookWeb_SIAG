using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace Login
{
    [TestFixture]
    public class TestClass
    {
        public static IWebDriver driver;
        FirefoxDriverService service;


        Menu_before_login mbl = new Menu_before_login();


        string mailAdmin = "admin@example.com";
        string loginAdmin = "admin";
        string passAdmin = "admos384";

        string mailUser = "dariuszjaros@email.com";
        string loginUser= "djaros";
        string passUser = "Jaros95";

        [SetUp]
        public void SetUp()
        {
         service = FirefoxDriverService.CreateDefaultService();
         service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
         driver = new FirefoxDriver(service);
         driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//PRĘDKOŚć SKRYPTU
         driver.Navigate().GoToUrl("http://cryptic-oasis-70750.herokuapp.com");
        }

        //KROK 1 "Wpisanie  "nie maila" w pole maila."
        [Test]
        public void Login1()
        {
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver,"random", REPO.ET_login_mail);
            mbl.CheckMail(driver, "random", REPO.ET_login_mail);
            mbl.EnterPassword(driver, passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            mbl.CheckShowError(driver, REPO.PUWin_login_incorrectLoginDetails);
        }

        //KROK 2 "Wpisanie samego maila."
        [Test]
        public void Login2()
        {
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, mailAdmin, REPO.ET_login_mail);
            mbl.CheckMail(driver, mailAdmin, REPO.ET_login_mail);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            mbl.CheckShowError(driver, REPO.PUWin_login_incorrectLoginDetails);
        }

        //KROK 3 "Wpisanie złego maila i złego hasła."
        [Test]
        public void Login3()
        {
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, "random", REPO.ET_login_mail);
            mbl.EnterPassword(driver, "random", REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            mbl.CheckShowError(driver, REPO.PUWin_login_incorrectLoginDetails);
        }

        //KROK 4 "Poprawne logowanie na ADMINA za pomocą Loginu."
        [Test]
        public void Login4()
        {
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, loginAdmin, REPO.ET_login_mail);
            mbl.CheckMail(driver, loginAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);
            mbl.CheckLogin(driver, REPO.PUWin_home_correctLogin);
            mbl.CheckLoginAsAdmin(driver, REPO.TB_UpMain_addBook);
        }

        //KROK 5 "Poprawne logowanie na ADMINA za pomocą Maila."
        [Test]
        public void Login5()
        {
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, mailAdmin, REPO.ET_login_mail);
            mbl.CheckMail(driver, mailAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);
            mbl.CheckLogin(driver, REPO.PUWin_home_correctLogin);
            mbl.CheckLoginAsAdmin(driver, REPO.TB_UpMain_addBook);
        }
        //KROK 6 "Poprawne logowanie na USER  za pomocą Loginu."
        [Test]
        public void Login6()
        {
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, loginUser, REPO.ET_login_mail);
            mbl.CheckMail(driver, loginUser, REPO.ET_login_mail);
            mbl.EnterPassword(driver, passUser, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);
            mbl.CheckLogin(driver, REPO.PUWin_home_correctLogin);
            mbl.CheckLoginAsUser(driver, REPO.TB_UpMain_addBook);
        }
        //KROK 7 "Poprawne logowanie na USER  za pomocą Maila."
        [Test]
        public void Login7()
        {
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, mailUser, REPO.ET_login_mail);
            mbl.CheckMail(driver, mailUser, REPO.ET_login_mail);
            mbl.EnterPassword(driver, passUser, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            Thread.Sleep(500);
            mbl.CheckLogin(driver, REPO.PUWin_home_correctLogin);
            mbl.CheckLoginAsUser(driver, REPO.TB_UpMain_addBook);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
}
}
