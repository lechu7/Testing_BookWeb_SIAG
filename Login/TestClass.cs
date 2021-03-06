﻿using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using RepoClass;


namespace Login
{
    [TestFixture]
    public class TestClass
    {
        public static IWebDriver driver;
        FirefoxDriverService service;
       
        Menu_before_login mbl = new Menu_before_login();

        [SetUp]
        public void SetUp()
        {
         service = FirefoxDriverService.CreateDefaultService();
         service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
         driver = new FirefoxDriver(service);
         driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//PRĘDKOŚć SKRYPTU
         driver.Navigate().GoToUrl(REPO.side);
        }

        //KROK 1 "Wpisanie  "nie maila" w pole maila."
        [Test]
        public void Login1()
        {
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver,"random", REPO.ET_login_mail);
            mbl.CheckMail(driver, "random", REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            mbl.CheckShowError(driver, REPO.PUWin_login_incorrectLoginDetails);
        }

        //KROK 2 "Wpisanie samego maila."
        [Test]
        public void Login2()
        {
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            Thread.Sleep(1500);
            mbl.EnterMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.CheckMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
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
            mbl.EnterMail(driver, REPO.loginAdmin, REPO.ET_login_mail);
            mbl.CheckMail(driver, REPO.loginAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
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
            mbl.EnterMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.CheckMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
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
            mbl.EnterMail(driver, REPO.loginUser2, REPO.ET_login_mail);
            mbl.CheckMail(driver, REPO.loginUser2, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUser2, REPO.ET_login_password);
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
            mbl.EnterMail(driver, REPO.mailUser2, REPO.ET_login_mail);
            mbl.CheckMail(driver, REPO.mailUser2, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passUser2, REPO.ET_login_password);
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
