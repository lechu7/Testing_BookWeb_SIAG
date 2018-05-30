using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using RepoClass;

namespace AllControls
{

    public class ObjectBeforeLogin
    {
        public List<By> homePageList = new List<By>();
        public List<By> createAccountList = new List<By>();
        public List<By> loginList = new List<By>();
        public List<By> booksList = new List<By>();
        public List<By> usersList = new List<By>();
        public List<By> authorsList = new List<By>();
        public void addToLists()
        {
            //homepage
            homePageList.Add(REPO.TB_UpMain_register);
            homePageList.Add(REPO.TB_UpMain_login);
            homePageList.Add(REPO.TB_UpMain_mainsite);
            homePageList.Add(REPO.TB_UpMain_books);
            homePageList.Add(REPO.TB_UpMain_users);
            homePageList.Add(REPO.TB_UpMain_authors);

            homePageList.Add(REPO.TB_all_search);
            homePageList.Add(REPO.SE_all_orders);
            homePageList.Add(REPO.SE_all_sort);
            homePageList.Add(REPO.BT_all_search);

            homePageList.Add(REPO.LB_homeBeforeLogin_BookWeb);
            homePageList.Add(REPO.LB_homeBeforeLogin_LB1);
            homePageList.Add(REPO.LB_homeBeforeLogin_LB2);
            homePageList.Add(REPO.LB_homeBeforeLogin_LB3);
            homePageList.Add(REPO.IM_homeBeforeLogin_IM1);
            homePageList.Add(REPO.IM_homeBeforeLogin_IM2);
            homePageList.Add(REPO.IM_homeBeforeLogin_IM3);


            homePageList.Add(REPO.LB_homeBeforeLogin_add);
            homePageList.Add(REPO.LB_homeBeforeLogin_share);
            homePageList.Add(REPO.LB_homeBeforeLogin_discover);
            homePageList.Add(REPO.HL_all_github);
            homePageList.Add(REPO.LB_all_wzim);


            //createAccount
            createAccountList.Add(REPO.TB_UpMain_register);
            createAccountList.Add(REPO.TB_UpMain_login);
            createAccountList.Add(REPO.TB_UpMain_mainsite);
            createAccountList.Add(REPO.TB_UpMain_books);
            createAccountList.Add(REPO.TB_UpMain_users);
            createAccountList.Add(REPO.TB_UpMain_authors);

            createAccountList.Add(REPO.TB_all_search);
            createAccountList.Add(REPO.SE_all_orders);
            createAccountList.Add(REPO.SE_all_sort);
            createAccountList.Add(REPO.BT_all_search);


            createAccountList.Add(REPO.LB_register_registerIn);
            createAccountList.Add(REPO.ET_register_username);
            createAccountList.Add(REPO.ET_register_email);
            createAccountList.Add(REPO.ET_register_password);
            createAccountList.Add(REPO.LB_register_usernameLB);
            createAccountList.Add(REPO.LB_register_emailLB);
            createAccountList.Add(REPO.LB_register_passwordLB);
            createAccountList.Add(REPO.BT_register_register);

            createAccountList.Add(REPO.HL_all_github);
            createAccountList.Add(REPO.LB_all_wzim);
            createAccountList.Add(REPO.HL_almostAll_toHome);

            //login
            loginList.Add(REPO.TB_UpMain_register);
            loginList.Add(REPO.TB_UpMain_login);
            loginList.Add(REPO.TB_UpMain_mainsite);
            loginList.Add(REPO.TB_UpMain_books);
            loginList.Add(REPO.TB_UpMain_users);
            loginList.Add(REPO.TB_UpMain_authors);

            loginList.Add(REPO.TB_all_search);
            loginList.Add(REPO.SE_all_orders);
            loginList.Add(REPO.SE_all_sort);
            loginList.Add(REPO.BT_all_search);

            loginList.Add(REPO.LB_login_login);
            loginList.Add(REPO.ET_login_mail);
            loginList.Add(REPO.ET_login_password);
            loginList.Add(REPO.BT_login_logIn);
            loginList.Add(REPO.LB_login_mailLB);
            loginList.Add(REPO.LB_login_passLB);

            loginList.Add(REPO.HL_all_github);
            loginList.Add(REPO.LB_all_wzim);
            loginList.Add(REPO.HL_almostAll_return);

            //books
            booksList.Add(REPO.TB_UpMain_register);
            booksList.Add(REPO.TB_UpMain_login);
            booksList.Add(REPO.TB_UpMain_mainsite);
            booksList.Add(REPO.TB_UpMain_books);
            booksList.Add(REPO.TB_UpMain_users);
            booksList.Add(REPO.TB_UpMain_authors);

            booksList.Add(REPO.TB_all_search);
            booksList.Add(REPO.SE_all_orders);
            booksList.Add(REPO.SE_all_sort);
            booksList.Add(REPO.BT_all_search);

            booksList.Add(REPO.SE_book_pagination);
            booksList.Add(REPO.TR_book_bookid10);

            booksList.Add(REPO.HL_all_github);
            booksList.Add(REPO.LB_all_wzim);

            //users
            usersList.Add(REPO.TB_UpMain_register);
            usersList.Add(REPO.TB_UpMain_login);
            usersList.Add(REPO.TB_UpMain_mainsite);
            usersList.Add(REPO.TB_UpMain_books);
            usersList.Add(REPO.TB_UpMain_users);
            usersList.Add(REPO.TB_UpMain_authors);

            usersList.Add(REPO.TB_all_search);
            usersList.Add(REPO.SE_all_orders);
            usersList.Add(REPO.SE_all_sort);
            usersList.Add(REPO.BT_all_search);

            usersList.Add(REPO.SE_users_pagination);
            usersList.Add(REPO.TR_users_userid10);

            usersList.Add(REPO.HL_all_github);
            usersList.Add(REPO.LB_all_wzim);

            //authors
            authorsList.Add(REPO.TB_UpMain_register);
            authorsList.Add(REPO.TB_UpMain_login);
            authorsList.Add(REPO.TB_UpMain_mainsite);
            authorsList.Add(REPO.TB_UpMain_books);
            authorsList.Add(REPO.TB_UpMain_users);
            authorsList.Add(REPO.TB_UpMain_authors);

            authorsList.Add(REPO.TB_all_search);
            authorsList.Add(REPO.SE_all_orders);
            authorsList.Add(REPO.SE_all_sort);
            authorsList.Add(REPO.BT_all_search);

            authorsList.Add(REPO.HL_authors_AlbertCamus);
            authorsList.Add(REPO.HL_authors_Dzuma);

            authorsList.Add(REPO.HL_all_github);
            authorsList.Add(REPO.LB_all_wzim);

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
