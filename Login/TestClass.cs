using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;




namespace Login
{
    [TestFixture]
    public class ControlClass
    {
        public static IWebDriver driver;
        FirefoxDriverService service;

        Menu_before_login mbl = new Menu_before_login();


        string mailAdmin = "admin@example.com";
        string passAdmin = "admos384";

        string mailUser = "dariuszjaros@email.com";
        string passUser = "Jaros95";

        [SetUp]
        public void SetUp()
        {
         service = FirefoxDriverService.CreateDefaultService();
         service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
         driver = new FirefoxDriver(service);
         driver.Navigate().GoToUrl("http://cryptic-oasis-70750.herokuapp.com/login");
        }
        [Test]
        public void Login()
        {
            //KROK 1 "Wpisanie  "nie maila" w pole maila."
            mbl.ClickLoginTab(driver, REPO.TB_mail);
            mbl.EnterMail(driver,"random", REPO.ET_mail);
            mbl.EnterPassword(driver, passAdmin, REPO.ET_password);
            Assert.Pass("Działa");
            
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
}
}
