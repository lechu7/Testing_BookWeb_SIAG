using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


    public static class REPO
    {
        //Przyciski górnego menu 
        public static By TB_UpMain_login = By.Id("login");
        public static By TB_UpMain_addBook = By.Id("addbook");

        //Strona główna po zalogowaniu
        public static By PUWin_home_correctLogin = By.XPath("//div[contains(.,'Zostałeś prawidłowo zalogowany')]");

        //Strona logowania
        public static By ET_login_mail = By.Id("email");
        public static By ET_login_password = By.Id("password");
        public static By PUWin_login_incorrectLoginDetails = By.Id("flash_danger");
        public static By BT_login_logIn = By.Id("submit");
       
    }

