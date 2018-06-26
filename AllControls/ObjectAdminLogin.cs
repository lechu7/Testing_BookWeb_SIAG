using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoClass;
using OpenQA.Selenium;

namespace AllControls
{
    class ObjectAdminLogin
    {
        public List<By> profileList = new List<By>();
        public List<By> homePageList = new List<By>();
        public List<By> booksList = new List<By>();
        public List<By> usersList = new List<By>();
        public List<By> authorsList = new List<By>();
        public List<By> addBookList = new List<By>();
        public void addToLists()
        {
            //profile
            profileList.Add(REPO.TB_UpMain_logOut);
            profileList.Add(REPO.TB_UpMain_profile);
            profileList.Add(REPO.TB_UpMain_mainsite);
            profileList.Add(REPO.TB_UpMain_books);
            profileList.Add(REPO.TB_UpMain_users);
            profileList.Add(REPO.TB_UpMain_authors);
            profileList.Add(REPO.TB_UpMain_addBook);

            profileList.Add(REPO.TB_all_search);
            profileList.Add(REPO.SE_all_orders);
            profileList.Add(REPO.SE_all_sort);
            profileList.Add(REPO.BT_all_search);


            profileList.Add(REPO.LB_yourProfile_yourOpinions);
            profileList.Add(REPO.BT_yourProfile_delete);

            profileList.Add(REPO.HL_all_github);
            profileList.Add(REPO.LB_all_wzim);


            //homepage
            homePageList.Add(REPO.TB_UpMain_logOut);
            homePageList.Add(REPO.TB_UpMain_profile);
            homePageList.Add(REPO.TB_UpMain_mainsite);
            homePageList.Add(REPO.TB_UpMain_books);
            homePageList.Add(REPO.TB_UpMain_users);
            homePageList.Add(REPO.TB_UpMain_authors);
            homePageList.Add(REPO.TB_UpMain_addBook);

            homePageList.Add(REPO.TB_all_search);
            homePageList.Add(REPO.SE_all_orders);
            homePageList.Add(REPO.SE_all_sort);
            homePageList.Add(REPO.BT_all_search);


 
            homePageList.Add(REPO.HL_all_github);
            homePageList.Add(REPO.LB_all_wzim);


            //books
            booksList.Add(REPO.TB_UpMain_logOut);
            booksList.Add(REPO.TB_UpMain_profile);
            booksList.Add(REPO.TB_UpMain_mainsite);
            booksList.Add(REPO.TB_UpMain_books);
            booksList.Add(REPO.TB_UpMain_users);
            booksList.Add(REPO.TB_UpMain_authors);
            booksList.Add(REPO.TB_UpMain_addBook);

            booksList.Add(REPO.TB_all_search);
            booksList.Add(REPO.SE_all_orders);
            booksList.Add(REPO.SE_all_sort);
            booksList.Add(REPO.BT_all_search);

            booksList.Add(REPO.SE_book_pagination);
            //booksList.Add(REPO.TR_book_bookid10);

            booksList.Add(REPO.HL_all_github);
            booksList.Add(REPO.LB_all_wzim);

            //users
            usersList.Add(REPO.TB_UpMain_logOut);
            usersList.Add(REPO.TB_UpMain_profile);
            usersList.Add(REPO.TB_UpMain_mainsite);
            usersList.Add(REPO.TB_UpMain_books);
            usersList.Add(REPO.TB_UpMain_users);
            usersList.Add(REPO.TB_UpMain_authors);
            usersList.Add(REPO.TB_UpMain_addBook);

            usersList.Add(REPO.TB_all_search);
            usersList.Add(REPO.SE_all_orders);
            usersList.Add(REPO.SE_all_sort);
            usersList.Add(REPO.BT_all_search);

            usersList.Add(REPO.SE_users_pagination);
            usersList.Add(REPO.TR_users_userid10);

            usersList.Add(REPO.HL_all_github);
            usersList.Add(REPO.LB_all_wzim);

            //authors
            authorsList.Add(REPO.TB_UpMain_logOut);
            authorsList.Add(REPO.TB_UpMain_profile);
            authorsList.Add(REPO.TB_UpMain_mainsite);
            authorsList.Add(REPO.TB_UpMain_books);
            authorsList.Add(REPO.TB_UpMain_users);
            authorsList.Add(REPO.TB_UpMain_authors);
            authorsList.Add(REPO.TB_UpMain_addBook);

            authorsList.Add(REPO.TB_all_search);
            authorsList.Add(REPO.SE_all_orders);
            authorsList.Add(REPO.SE_all_sort);
            authorsList.Add(REPO.BT_all_search);

           // authorsList.Add(REPO.HL_authors_AlbertCamus);
           // authorsList.Add(REPO.HL_authors_Dzuma);

            authorsList.Add(REPO.HL_all_github);
            authorsList.Add(REPO.LB_all_wzim);

            //addBook
            addBookList.Add(REPO.TB_UpMain_logOut);
            addBookList.Add(REPO.TB_UpMain_profile);
            addBookList.Add(REPO.TB_UpMain_mainsite);
            addBookList.Add(REPO.TB_UpMain_books);
            addBookList.Add(REPO.TB_UpMain_users);
            addBookList.Add(REPO.TB_UpMain_authors);
            addBookList.Add(REPO.TB_UpMain_addBook);

            addBookList.Add(REPO.TB_all_search);
            addBookList.Add(REPO.SE_all_orders);
            addBookList.Add(REPO.SE_all_sort);
            addBookList.Add(REPO.BT_all_search);

            addBookList.Add(REPO.LB_addBook_addBook);
            addBookList.Add(REPO.LB_addBook_title);
            addBookList.Add(REPO.LB_addBook_author);
            addBookList.Add(REPO.LB_addBook_genre);
            addBookList.Add(REPO.ET_addBook_title);
            addBookList.Add(REPO.ET_addBook_author);
            addBookList.Add(REPO.ET_addBook_genre);
            addBookList.Add(REPO.BT_addBook_add);

            addBookList.Add(REPO.HL_all_github);
            addBookList.Add(REPO.LB_all_wzim);
        }
        public void ClickLoginTab(IWebDriver driver, By loginTabBy)
        {
            driver.FindElement(loginTabBy).Click();
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
