using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace Testy
{
    class Program
    {

        static void Main(string[] args)
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"d:\tmp");
            service.FirefoxBinaryPath= @"C:\Programy\Mozilla Firefox\firefox.exe";
            IWebDriver driver = new FirefoxDriver(service);
            driver.Navigate().GoToUrl("http://www.google.pl");


            //Deklaracja obiktów
            IWebElement input = driver.FindElement(By.Id("lst-ib"));
            IWebElement button = driver.FindElement(By.Name("btnK"));


            //Metody
            input.SendKeys("BookWeb_SIAG");
            button.Click();

            Console.ReadKey();
        }
    }
}
