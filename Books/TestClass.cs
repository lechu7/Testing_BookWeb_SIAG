using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using RepoClass;
using System.Collections.Generic;

namespace Books
{
    [TestFixture]
    public class TestClass
    {
        public int whatShouldBeDeleted = 0;
        public static IWebDriver driver;
        FirefoxDriverService service;

        Login.Menu_before_login mbl = new Login.Menu_before_login();

        

        [SetUp]
        public void SetUp()
        {
            
            service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(service);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//PRĘDKOŚć SKRYPTU
            driver.Navigate().GoToUrl(REPO.side);
            driver.Manage().Window.Maximize();

            

        }
        [Test]
        public void Books1()//dodawanie nowej książki nowego autora
        {

            
            //logowanie jako admin
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            mbl.EnterMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            //przejście do dodawania książek
            driver.FindElement(REPO.TB_UpMain_addBook).Click();

            //wypełnienie pól nowej książki
            driver.FindElement(REPO.ET_addBook_author).SendKeys("Jan Niezbędny");
            driver.FindElement(REPO.ET_addBook_genre).SendKeys("dramat");
            driver.FindElement(REPO.ET_addBook_title).SendKeys("Suszarka na pranie STANDARD 18m");

            //dodanie książki
            driver.FindElement(REPO.BT_addBook_add).Click(); driver.FindElement(By.XPath("//div[contains(.,'Książka została prawidłowo dodana')]"));

            //wyszukanie książki
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("javascript:window.scrollBy(0,700)");
            driver.FindElement(REPO.TB_all_search).SendKeys("Suszarka na pranie STANDARD 18m");
            driver.FindElement(REPO.BT_all_search).Click();

            //sprawdza, czy jest dodana książka na liście
            driver.FindElement(By.XPath("//div/div[contains(.,'Jan Niezbędny')]/parent::div/div[contains(.,'Suszarka na pranie STANDARD 18m')]/parent::div[contains(.,'dramat')]"));

            //driver.FindElement(By.XPath("//td[contains(.,'Jan Niezbędny')]/parent::tr/td[contains(.,'dramat')]/parent::tr/*/a[contains(.,'Suszarka na pranie STANDARD 18m')]"));

            //przygotowanie do usunięcia dodanej książki:
            whatShouldBeDeleted = 1;
            Assert.Pass();


            

        }

        [Test]
        public void Books2()//dodanie nowej książki autora, który już jest w bazie
        {
           
            //logowanie jako admin
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            mbl.EnterMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);

            //przejście do dodawania książek
            driver.FindElement(REPO.TB_UpMain_addBook).Click();

            //wypełnienie pól nowej książki
            driver.FindElement(REPO.ET_addBook_author).SendKeys("Andrzej Iwan");
            driver.FindElement(REPO.ET_addBook_genre).SendKeys("dramat");
            driver.FindElement(REPO.ET_addBook_title).SendKeys("Suszarka na pranie STANDARD 18m");

            //dodanie książki
            driver.FindElement(REPO.BT_addBook_add).Click(); driver.FindElement(By.XPath("//div[contains(.,'Książka została prawidłowo dodana')]"));

            //odnalezienie książki
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("javascript:window.scrollBy(0,700)");
            driver.FindElement(REPO.TB_all_search).SendKeys("Suszarka na pranie STANDARD 18m");
            driver.FindElement(REPO.BT_all_search).Click();

            //sprawdza, czy jest dodana książka na liście
            driver.FindElement(By.XPath("//div/div[contains(.,'Andrzej Iwan')]/parent::div/div[contains(.,'Suszarka na pranie STANDARD 18m')]/parent::div[contains(.,'dramat')]"));


            //przygotowanie do usunięcia dodanej książki:
            whatShouldBeDeleted = 2;
            Assert.Pass();

        }

        [Test]
        public void Books3() //dodanie książki nowego autora, która ma tytuł taki jak książka kogoś innego
        {
            
            //logowanie jako admin
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            mbl.EnterMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            //przejście do dodawania książek
            driver.FindElement(REPO.TB_UpMain_addBook).Click();

            //wypełnienie pól nowej książki
            driver.FindElement(REPO.ET_addBook_author).SendKeys("Jan Niezbędny");
            driver.FindElement(REPO.ET_addBook_genre).SendKeys("autobiografia/pamiętnik");
            driver.FindElement(REPO.ET_addBook_title).SendKeys("Spalony");

            //dodanie książki
            driver.FindElement(REPO.BT_addBook_add).Click(); driver.FindElement(By.XPath("//div[contains(.,'Książka została prawidłowo dodana')]"));

            //odnalezienie książki
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("javascript:window.scrollBy(0,700)");
            driver.FindElement(REPO.TB_all_search).SendKeys("Spalony");
            driver.FindElement(REPO.BT_all_search).Click();

            //sprawdza, czy jest dodana książka na liście
            driver.FindElement(By.XPath("//div/div[contains(.,'Jan Niezbędny')]/parent::div/div[contains(.,'Spalony')]/parent::div[contains(.,'autobiografia/pamiętnik')]"));



            //przygotowanie do usunięcia dodanej książki:
            whatShouldBeDeleted = 1;
            Assert.Pass();
        }
        [Test]
        public void Books4() //dodanie książki, która już widnieje w bazie
        {
            
            //logowanie jako admin
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            mbl.EnterMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            //przejście do dodawania książek
            driver.FindElement(REPO.TB_UpMain_addBook).Click();

            //wypełnienie pól nowej książki
            driver.FindElement(REPO.ET_addBook_author).SendKeys("Andrzej Iwan");
            driver.FindElement(REPO.ET_addBook_genre).SendKeys("autobiografia/pamiętnik");
            driver.FindElement(REPO.ET_addBook_title).SendKeys("Spalony");

            //dodanie książki
            driver.FindElement(REPO.BT_addBook_add).Click();
            

          
            //sprawdzenie, czy wyświetla się komunikat o tym, że taka książka jest już w bazie
            driver.FindElement(By.XPath("//div[contains(.,'Taka książka już istnieje')]"));

            whatShouldBeDeleted = -1;

           

            Assert.Pass();

        }
        [Test]
        public void Books5() //dodanie książki bez tytułu
        {
            
            //logowanie jako admin
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            mbl.EnterMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            //przejście do dodawania książek
            driver.FindElement(REPO.TB_UpMain_addBook).Click();

            //wypełnienie pól nowej książki
            driver.FindElement(REPO.ET_addBook_author).SendKeys("Albert Camus");
            driver.FindElement(REPO.ET_addBook_genre).SendKeys("literatura piękna/klasyka");


            //dodanie książki
            driver.FindElement(REPO.BT_addBook_add).Click();
            

            //sprawdzenie, czy wyświetla się komunikat o tym, że nie można jej dodać
            driver.FindElement(By.XPath("//li[contains(.,'Musisz podać tytuł')]"));

            //odnalezienie książki
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("javascript:window.scrollBy(0,700)");
            driver.FindElement(REPO.TB_all_search).SendKeys("Albert Camus");
            driver.FindElement(REPO.BT_all_search).Click();

            //sprawdza, czy jest dodana książka na liście
            


            //sprawdza, czy książki nie ma na końcu listy
            try
            {
                driver.FindElement(By.XPath("//div/div[contains(.,'Albert Camus')]/parent::div/div[contains(.,'')]/parent::div[contains(.,'literatura piękna/klasyka')]"));
                //driver.FindElement(By.XPath("//td[contains(.,'Albert Camus')]/parent::tr/td[contains(.,'literatura piękna/klasyka')]"));
            }
            catch (NoSuchElementException)
            {
                whatShouldBeDeleted = -1;
                Assert.Pass();
            }

            Assert.Fail();

        }
        [Test]
        public void Books6() //dodanie książki bez autora
        {
            
            //logowanie jako admin
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            mbl.EnterMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            //przejście do dodawania książek
            driver.FindElement(REPO.TB_UpMain_addBook).Click();

            //wypełnienie pól nowej książki
            //driver.FindElement(REPO.ET_addBook_author).SendKeys("Albert Camus");
            driver.FindElement(REPO.ET_addBook_genre).SendKeys("literatura piękna/klasyka");
            driver.FindElement(REPO.ET_addBook_title).SendKeys("Dżuma");

            //dodanie książki
            driver.FindElement(REPO.BT_addBook_add).Click();
            

            //sprawdzenie, czy wyświetla się komunikat o tym, że nie można jej dodać
            driver.FindElement(By.XPath("//li[contains(.,'Musisz podać autora')]"));

            //odnalezienie książki
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("javascript:window.scrollBy(0,700)");
            driver.FindElement(REPO.TB_all_search).SendKeys("Dżuma");
            driver.FindElement(REPO.BT_all_search).Click();

            //sprawdza, czy jest dodana książka na liście



            //sprawdza, czy książki nie ma na końcu listy
            try
            {
                driver.FindElement(By.XPath("//div/div[contains(.,'')]/parent::div/div[contains(.,'Dżuma')]/parent::div[contains(.,'literatura piękna/klasyka')]"));
                //driver.FindElement(By.XPath("//td[contains(.,'Albert Camus')]/parent::tr/td[contains(.,'literatura piękna/klasyka')]"));
            }
            catch (NoSuchElementException)
            {
                whatShouldBeDeleted = -1;
                Assert.Pass();
            }

            Assert.Fail();

        }
        [Test]
        public void Books7() //dodanie książki bez gatunku
        {
            
            //logowanie jako admin
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            mbl.EnterMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            //przejście do dodawania książek
            driver.FindElement(REPO.TB_UpMain_addBook).Click();

            //wypełnienie pól nowej książki
            driver.FindElement(REPO.ET_addBook_author).SendKeys("Gringo Tomasz");
            //driver.FindElement(REPO.ET_addBook_genre).SendKeys("literatura piękna/klasyka");
            driver.FindElement(REPO.ET_addBook_title).SendKeys("Dżuma");

            //dodanie książki
            driver.FindElement(REPO.BT_addBook_add).Click();
            

            //sprawdzenie, czy wyświetla się komunikat o tym, że nie można jej dodać
            driver.FindElement(By.XPath("//li[contains(.,'Musisz podać kategorię')]"));

            //odnalezienie książki
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("javascript:window.scrollBy(0,700)");
            driver.FindElement(REPO.TB_all_search).SendKeys("Albert Camus");
            driver.FindElement(REPO.BT_all_search).Click();

            //sprawdza, czy jest dodana książka na liście



            //sprawdza, czy książki nie ma na końcu listy
            try
            {
                driver.FindElement(By.XPath("//div/div[contains(.,'Albert Camus')]/parent::div/div[contains(.,'Dżuma')]/parent::div[contains(.,'')]"));
                //driver.FindElement(By.XPath("//td[contains(.,'Albert Camus')]/parent::tr/td[contains(.,'literatura piękna/klasyka')]"));
            }
            catch (NoSuchElementException)
            {
                whatShouldBeDeleted = -1;
                Assert.Pass();
            }

            Assert.Fail();

        }
        [Test]
        public void Books8() //czy można usunąć książkę z listy książek
        {
            //okreslenie numeru ostatniej strony
            BooksAPI BA = new BooksAPI();
            List<BooksObject> booksList = BA.BookList();
            int lastPage = ((booksList.Count+1) / 10) + 1;
            string lastPageXPath = "//a[contains(.,'" + lastPage + "')]";
            //logowanie jako admin
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            mbl.EnterMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            //przejście do dodawania książek
            driver.FindElement(REPO.TB_UpMain_addBook).Click();

            //wypełnienie pól nowej książki
            driver.FindElement(REPO.ET_addBook_author).SendKeys("Jan Niezbędny");
            driver.FindElement(REPO.ET_addBook_genre).SendKeys("dramat");
            driver.FindElement(REPO.ET_addBook_title).SendKeys("Suszarka na pranie STANDARD 18m");

            //dodanie książki
            driver.FindElement(REPO.BT_addBook_add).Click(); driver.FindElement(By.XPath("//div[contains(.,'Książka została prawidłowo dodana')]"));



            //przejście do ostatniej strony listy
            driver.FindElement(REPO.TB_UpMain_books).Click();
            driver.FindElement(By.XPath(lastPageXPath)).Click();

            //usunięcie książki
            try
            {
                driver.FindElement(By.XPath("//td[contains(.,'Jan Niezbędny')]/parent::tr/*/a[contains(.,'Usuń')]")).Click();
            }
            catch(NoSuchElementException)
            {
                
                    //przejście na początek
                    driver.FindElement(By.XPath("//a[contains(text(), '1')]")).Click();
                    try
                    {
                        driver.FindElement(By.XPath("//td[contains(.,'Jan Niezbędny')]/parent::tr/*/a[contains(.,'Usuń')]")).Click();
                        //driver.FindElement(By.XPath("//td[contains(.,'Jan Niezbędny')]/parent::tr/td[contains(.,'dramat')]/parent::tr/*/a[contains(.,'Suszarka na pranie STANDARD 18m')]"));
                    }
                    catch (NoSuchElementException)
                    {
                        Assert.Fail();
                    }
                
             
            }
            //sprawdzenie komunikatu o usunięciu książki
            driver.FindElement(By.XPath("//div[contains(.,'Pozycja została usunięta')]"));


            //odnalezienie książki
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("javascript:window.scrollBy(0,700)");
            driver.FindElement(REPO.TB_all_search).SendKeys("Albert Camus");
            driver.FindElement(REPO.BT_all_search).Click();

            //sprawdza, czy jest dodana książka na liście



            //sprawdza, czy książki nie ma na końcu listy
            try
            {
                driver.FindElement(By.XPath("//div/div[contains(.,'Jan Niezbędny')]/parent::div/div[contains(.,'Suszarka na pranie STANDARD 18m')]/parent::div[contains(.,'dramat')]"));
                //driver.FindElement(By.XPath("//div/div[contains(.,'Jan Niezbędny')]/parent::div/div[contains(.,'Suszarka Na ')]/parent::div[contains(.,'')]"));
                //driver.FindElement(By.XPath("//td[contains(.,'Albert Camus')]/parent::tr/td[contains(.,'literatura piękna/klasyka')]"));
            }
            catch (NoSuchElementException)
            {
                whatShouldBeDeleted = -1;
                Assert.Pass();
            }

            Assert.Fail();
        }
        [Test]
        public void Books9() //czy można usunąć książkę po wyszukaniu
        {
            
            //logowanie jako admin
            mbl.ClickLoginTab(driver, REPO.TB_UpMain_login);
            mbl.EnterMail(driver, REPO.mailAdmin, REPO.ET_login_mail);
            mbl.EnterPassword(driver, REPO.passAdmin, REPO.ET_login_password);
            mbl.ClickLogIn(driver, REPO.BT_login_logIn);
            //przejście do dodawania książek
            driver.FindElement(REPO.TB_UpMain_addBook).Click();

            //wypełnienie pól nowej książki
            driver.FindElement(REPO.ET_addBook_author).SendKeys("Jan Niezbędny");
            driver.FindElement(REPO.ET_addBook_genre).SendKeys("dramat");
            driver.FindElement(REPO.ET_addBook_title).SendKeys("Suszarka na pranie STANDARD 18m");

            //dodanie książki
            driver.FindElement(REPO.BT_addBook_add).Click(); driver.FindElement(By.XPath("//div[contains(.,'Książka została prawidłowo dodana')]"));



            //wyszukanie książki
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("javascript:window.scrollBy(0,700)");
            driver.FindElement(REPO.TB_all_search).SendKeys("Suszarka na pranie STANDARD 18m");
            driver.FindElement(REPO.BT_all_search).Click();

            //usunięcie książki
            driver.FindElement(By.XPath("//a[contains(.,'Usuń')]")).Click();

            //sprawdzenie komunikatu o usunięciu książki
            driver.FindElement(By.XPath("//div[contains(.,'Pozycja została usunięta')]"));

            

            //sprawdzenie, czy książki tam nie ma

            //wyszukanie książki
            driver.FindElement(REPO.TB_all_search).SendKeys("Suszarka na pranie STANDARD 18m");
            
            js.ExecuteScript("javascript:window.scrollBy(0,700)");
            driver.FindElement(REPO.BT_all_search).Click();
            js.ExecuteScript("javascript:window.scrollBy(0,-700)");
            //sprawdzenie

            driver.FindElement(By.XPath("//h2[contains(.,'Brak obiektów dla frazy Suszarka na pranie STANDARD 18m')]"));
            whatShouldBeDeleted = -1;
        }

        [TearDown]
        public void TearDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            switch (whatShouldBeDeleted)
            {
                case 1:

                    driver.FindElement(By.XPath("//div/div[contains(.,'Jan Niezbędny')]/parent::div/*/a[contains(.,'Usuń')]")).Click();
                    //driver.FindElement(By.XPath("//td[contains(.,'Jan Niezbędny')]/parent::tr/*/a[contains(.,'Usuń')]")).Click();
                    break;
                case 2:

                    driver.FindElement(By.XPath("//div/div[contains(.,'Andrzej Iwan')]/parent::div/*/a[contains(.,'Usuń')]")).Click();
                    //driver.FindElement(By.XPath("//td[contains(.,'Jan Niezbędny')]/parent::tr/*/a[contains(.,'Usuń')]")).Click();
                    break;
                case 3:
                    
                    js.ExecuteScript("javascript:window.scrollBy(0,350)");
                    driver.FindElement(By.XPath("//td[contains(.,'Jan Niezbędny')]/parent::tr/*/a[contains(.,'Usuń')]")).Click();
                    break;
                case 4:
                   

                    break;
                default:
                    break;
            }
            //
            driver.Quit();

        }
    }
}
