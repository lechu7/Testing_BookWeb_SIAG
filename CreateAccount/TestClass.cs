using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using RepoClass;


namespace Registration
{
    [TestFixture]
    public class TestClass
    {
        public static IWebDriver driver;
        FirefoxDriverService service;
        MenuRegister mr = new MenuRegister();

        [SetUp]
        public void SetUp()
        {
            service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(service);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//PRĘDKOŚć SKRYPTU
            driver.Navigate().GoToUrl(REPO.side);
        }

        //KROK 1 "Rejestracja z pustymi polami"
        [Test]
        public void Registration1()
        {
            mr.ClickRegistrationTab(driver, REPO.TB_UpMain_register);
            Thread.Sleep(1500);
            mr.ClickRegistrationButton(driver, REPO.BT_register_register);
            mr.CheckShowError(driver, REPO.PUWin_register_6errors_emptyInputs);
        }

        //KROK 2 Rejestracja jedynie z Nazwa Użytkownika (Lenght< 3)
        [Test]
        public void Registration2()
        {
            mr.ClickRegistrationTab(driver, REPO.TB_UpMain_register);
            Thread.Sleep(1500);
            mr.EnterUserName(driver, "12", REPO.ET_register_username);
            mr.ClickRegistrationButton(driver, REPO.BT_register_register);
            mr.CheckShowError(driver, REPO.PUWin_register_5errors_UserNameTo3);
        }

        //KROK 3 Rejestracja jedynie z Nazwa Użytkownika 
        [Test]
        public void Registration3()
        {
            mr.ClickRegistrationTab(driver, REPO.TB_UpMain_register);
            Thread.Sleep(1500);
            mr.EnterUserName(driver, REPO.RegistartionTestUserName, REPO.ET_register_username);
            mr.ClickRegistrationButton(driver, REPO.BT_register_register);
            mr.CheckShowError(driver, REPO.PUWin_register_4errors_OnlyUserName);
        }

        //KROK 4 Rejestracja jedynie z mailem 
        [Test]
        public void Registration4()
        {
            mr.ClickRegistrationTab(driver, REPO.TB_UpMain_register);
            Thread.Sleep(1500);
            mr.EnterMail(driver,REPO.mailUserTest,REPO.ET_register_email);
            mr.ClickRegistrationButton(driver, REPO.BT_register_register);
            mr.CheckShowError(driver, REPO.PUWin_register_5errors_UserNameTo3);
        }

        //KROK 5 Rejestracja istniejący użytkownik + istniejący mail + hasło
        [Test]
        public void Registration5()
        {
            mr.ClickRegistrationTab(driver, REPO.TB_UpMain_register);
            Thread.Sleep(1500);
            mr.EnterUserName(driver, REPO.loginUser1, REPO.ET_register_username);
            mr.EnterMail(driver, REPO.mailUser1, REPO.ET_register_email);
            mr.EnterPassword(driver, REPO.passUserToRegistration1, REPO.ET_register_password);
            mr.ClickRegistrationButton(driver, REPO.BT_register_register);
            mr.CheckShowError(driver,REPO.PUWin_register_2errors_ExistUserNameAndExistEmail);
        }

        //KROK 6 Rejestracja istniejący użytkownik + mail + hasło
        [Test]
        public void Registration6()
        {
            mr.ClickRegistrationTab(driver, REPO.TB_UpMain_register);
            Thread.Sleep(1500);
            mr.EnterUserName(driver, REPO.loginUser1, REPO.ET_register_username);
            mr.EnterMail(driver, REPO.RegistartionTestUserEmail, REPO.ET_register_email);
            mr.EnterPassword(driver, REPO.passUserToRegistration1, REPO.ET_register_password);
            mr.ClickRegistrationButton(driver, REPO.BT_register_register);
            mr.CheckShowError(driver, REPO.PUWin_register_1error);
        }

        //KROK 7 Rejestracja użytkownik + istniejący mail + hasło
        [Test]
        public void Registration7()
        {
            mr.ClickRegistrationTab(driver, REPO.TB_UpMain_register);
            Thread.Sleep(1500);
            mr.EnterUserName(driver, REPO.RegistartionTestUserName, REPO.ET_register_username);
            mr.EnterMail(driver, REPO.mailUser1, REPO.ET_register_email);
            mr.EnterPassword(driver, REPO.passUserToRegistration1, REPO.ET_register_password);
            mr.ClickRegistrationButton(driver, REPO.BT_register_register);
            mr.CheckShowError(driver, REPO.PUWin_register_1error);
        }

        //KROK 8 Rejestracja poprawna użytkownik+ mail+hasło
        [Test]
        public void Registration8()
        {
            mr.ClickRegistrationTab(driver, REPO.TB_UpMain_register);
            Thread.Sleep(1500);
            mr.EnterUserName(driver, REPO.RegistartionTestUserName, REPO.ET_register_username);
            mr.EnterMail(driver, REPO.RegistartionTestUserEmail, REPO.ET_register_email);
            mr.EnterPassword(driver, REPO.passUserToRegistration1, REPO.ET_register_password);
            mr.ClickRegistrationButton(driver, REPO.BT_register_register);
            Thread.Sleep(1500);
            mr.CheckRegister(driver, REPO.PUWin_register_registerTestowyUserToDelete);

            //Usuwanie naszego Testowego Użytkownika "TestowyUserToDelete"
            DeleteUser.Delete(driver,REPO.RegistartionTestUserName);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
