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
            //ToDo Czy wyskakuje error
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
