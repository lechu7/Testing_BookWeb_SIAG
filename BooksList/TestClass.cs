using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using RepoClass;
using Opinions;
using System.Collections.Generic;

namespace BooksList
{
    [TestFixture]
    public class TestClass
    {
        public int whatShouldBeDeleted = 0;
        public static IWebDriver driver;
        FirefoxDriverService service;

        Login.Menu_before_login mbl = new Login.Menu_before_login();

        BooksAPI BA = new BooksAPI();

        [Test]
        public void BooksList1()
        {
            //stworzenie listy książek na podstawie otrzymanych danych
            List<BooksObject> booksList = BA.BookList();

            //przejście do stronki
            service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(service);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//PRĘDKOŚć SKRYPTU
            driver.Navigate().GoToUrl(REPO.side);
            driver.Manage().Window.Maximize();
            //przejście do listy książek
            driver.FindElement(REPO.TB_UpMain_books).Click();

            //porównywaie listy z tym co jest wyświetlane przez książkę
            for (int i = 0, j = 0; i < booksList.Count; i++, j++)
            {

                //wszystkie stringi opisujące książkę
                string bookTitle = booksList[i].title;
                string bookAuthor = booksList[i].author;
                string bookGenre = booksList[i].genre;
                string bookID = "book-" + (i + 1).ToString();

                //sprawdzenie, czy książka się wyświetla
                
                string xPath1 = "//td[contains(.,'" + bookAuthor + "')]/parent::tr/td[contains(.,'" + bookGenre + "')]/parent::tr/*/a[contains(.,'" + bookTitle + "')]";
                driver.FindElement(By.XPath(xPath1));
                
                
                    
                //przejście do następnej strony listy
                if (j == 9)
                {
                    j = -1;//-1 bo po zakonczeniu pętli będzie podniesione o 1, a ma startować od 0
                    driver.FindElement(REPO.BT_book_nextPage).Click();
                }
            }



            driver.Quit();


        }

          
        
    }
}
