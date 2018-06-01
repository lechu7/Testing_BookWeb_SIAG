using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using RepoClass;
using Login;
using System.Threading;

namespace OpinionsList
{
    [TestFixture]
    public class TestClass
    {
        public static IWebDriver driver;
        FirefoxDriverService service;

        Menu_before_login mbl = new Menu_before_login();
        OpinionsAPI oa = new OpinionsAPI();
        BooksAPI ba = new BooksAPI();
        TargetList tl = new TargetList();

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

        //KROK 1 "Sprawdzenie wszystkich opinii"
        [Test]
            public void OpinionsList1()
        {
            //Listy opinii i książek(do zczytania tytułu)
            List<OpinionsObject> listOpinions = new List<OpinionsObject>();
            List<BooksObject> listBook = new List<BooksObject>();
            listOpinions =oa.opinionsList();
            listBook = ba.BookList();
           
            //Przygotowanie listy z odpowiednimi polami
            List<ObjectTargetList> targetList = new List<ObjectTargetList>();
            targetList = tl.ReturnTargetList(listOpinions, listBook);

            driver.FindElement(REPO.TB_UpMain_users).Click();

            

            //TMP username
            string usernameTMP = "";
            //TMP xpath
            string xpathTMP = "";
            //TMP userID
            int userIDTMP = 0;
            //TMP wspolrzedna pionowa na liscie user
            int XTMPuser = 0;
            //TMP wspolrzedna pionowa na liscie opinii
            int XTMPopinion = 0;

            //Sprawdzenie wszystkich tych opinii na stronie
            for (int i = 0; i < targetList.Count; i++)
            {
                xpathTMP = "";
          

                //Sprawdza czy trzeba wybrać nowego użytkownika
                if (usernameTMP!=targetList[i].username)
                {
                    userIDTMP++;
                    //Scrool co dwóch userów
                    if (userIDTMP % 2 == 0)
                    {
                        XTMPuser += 275;
                        Thread.Sleep(1500);
                        ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0," + XTMPuser + ")");
                    }
                    driver.FindElement(By.PartialLinkText("Użytkownik " + targetList[i].username)).Click();
                    usernameTMP = targetList[i].username;
                }


                //Prubuje kliknąć w tytuł książki
                try
                {
                    driver.FindElement(By.PartialLinkText(targetList[i].title)).Click();
                }
                catch (Exception)
                {
                    try
                    {
                        XTMPopinion += 600;
                        Thread.Sleep(millisecondsTimeout: 800);
                        ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0," + XTMPopinion + ")");
                        driver.FindElement(By.PartialLinkText(targetList[i].title)).Click();
                    }
                    catch (Exception)
                    {
                        XTMPopinion += 600;
                        Thread.Sleep(millisecondsTimeout: 800);
                        ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0," + XTMPopinion + ")");
                        driver.FindElement(By.PartialLinkText(targetList[i].title)).Click();
                    }

                }

                //Sprawdza czy ocena jest
                xpathTMP = "//p[contains(.,'"+targetList[i].username+" ocenił "+targetList[i].rate+"/5: "+targetList[i].description+"')]";
                Assert.True(IsTestElementPresent(driver,By.XPath(xpathTMP)));
                driver.Navigate().Back();


                //Sprawdza czy jest kolejna opinia czy cofnac
                if (i+1<targetList.Count)
                {
                    //Sprawdza czy cofnac do listy użytkowników
                    if (usernameTMP != targetList[i + 1].username)
                    {
                        driver.Navigate().Back();
                        XTMPopinion = 0;
                        //Kolejna strona użytkowników
                        if (userIDTMP % 10 == 0 && userIDTMP != 0)
                        {
                            Thread.Sleep(1000);
                            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0,0)");
                            driver.FindElement(REPO.BT_users_nextPage).Click();
                            XTMPuser = 0;
                        }

                    }
                }



            }
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        public bool IsTestElementPresent(IWebDriver driver, By byOBJ)
        {
            try
            {
                driver.FindElement(byOBJ);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
