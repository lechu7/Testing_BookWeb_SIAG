using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;


namespace RepoClass
{

    public static class REPO
    {
        
        //GŁóWNY ADRES NASZEGO PROJEKTU
        public static string side = "https://siag-bookweb.herokuapp.com/";

        //URL API
        public static string URLUsers = "http://siag-bookweb.herokuapp.com/api/users/json";
        public static string URLBooks = "http://siag-bookweb.herokuapp.com/api/books/json";

        //ZMIENNE GLOBALNE
        public static string mailAdmin = "admin@example.com";
        public static string loginAdmin = "admin";
        public static string passAdmin = "Admos384";

        public static string mailUser1 = "dariuszjaros@email.com";
        public static string loginUser1 = "djaros";
        public static string passUser1 = "Jaros95";
        public static string passUserToRegistration1 = "Jaroszewski95";

        public static string mailUser2 = "jankwitek@email.com";
        public static string loginUser2 = "jkwitek";
        public static string passUser2 = "Kwitek93";

        public static string mailUserTest = "totalnie.testowy.test@gmail.com";
        public static string loginUserTest = "test";
        public static string passUserTest = "EQ0GI3A0a";

        public static string RegistartionTestUserName = "TestowyUserToDelete";
        public static string RegistartionTestUserEmail = "TestowyUserToDelete@testowy.com";
        public static string RegistartionTestUserPass = "Pa$$w0rd";




        //OBIEKTY
        //NA KAŻDEJ ZAKŁADCE
        public static By HL_all_github = By.XPath("//a[contains(.,'github')]");
        public static By HL_all_home = By.XPath("//a[contains(.,'Powrót do strony głównej')]");
        public static By LB_all_wzim = By.XPath("//small[contains(.,'Wydział Zastosowań Informatyki i Informatyki')]");

        //Przyciski górnego menu 
        public static By TB_UpMain_register = By.Id("register");
        public static By TB_UpMain_login = By.Id("login");
        public static By TB_UpMain_mainsite = By.Id("mainsite");
        public static By TB_UpMain_books = By.Id("books");
        public static By TB_UpMain_users = By.Id("users");
        public static By TB_UpMain_addBook = By.Id("addbook");
        public static By TB_UpMain_logOut = By.Id("logout");
        public static By TB_UpMain_profile = By.Id("profile");

        //Strona Rejestracji
        public static By ET_register_username = By.Id("username");
        public static By ET_register_email = By.Id("email");
        public static By ET_register_password = By.Id("password");
        public static By BT_register_register= By.Id("submit");
        public static By LB_register_registerIn = By.XPath("//div[contains(.,'Zarejestruj się w BookWeb!')]");
        public static By PUWin_register_6errors_emptyInputs = By.XPath("//div[contains(.,'6 errors')]");
        public static By PUWin_register_5errors_UserNameTo3 = By.XPath("//div[contains(.,'5 errors')]");
        public static By PUWin_register_4errors_OnlyUserName = By.XPath("//div[contains(.,'4 errors')]");
        public static By PUWin_register_2errors_ExistUserNameAndExistEmail = By.XPath("//div[contains(.,'2 errors')]");
        public static By PUWin_register_1error = By.XPath("//div[contains(.,'1 error')]");
        public static By PUWin_register_registerTestowyUserToDelete= By.XPath("//div[contains(.,'Witamy TestowyUserToDelete!')]");


        //Strona logowania
        public static By ET_login_mail = By.Id("email");
        public static By ET_login_password = By.Id("password");
        public static By BT_login_logIn = By.Id("submit");
        public static By PUWin_login_incorrectLoginDetails = By.XPath("//div[contains(.,'Podałeś błędne dane logowania')]");
        public static By LB_login_login = By.XPath("//div[contains(.,'Logowanie')]");

        //Twój Profil
        public static By BT_yourProfile_delete = By.Id("delete");
        

        //Strona główna przed zalogowaniem

        //Strona główna po zalogowaniu
        public static By PUWin_home_correctLogin = By.XPath("//div[contains(.,'Zostałeś prawidłowo zalogowany')]");

        //Lista książek
        public static By TB_book_search = By.Id("search");
        public static By SE_book_orders = By.Id("orders");
        public static By SE_book_sort = By.Id("sort");
        public static By BT_book_Autobiografia = By.XPath("//a[contains(.,'Autobiografia')]");

        //Użytkownicy
        public static By SE_users_pagination = By.XPath("//ul[@class='pagination']");
        public static By BT_users_nextPage = By.XPath("//a[contains(.,'Next →')]");
        public static By BT_users_nextPageDisabled = By.XPath("//li[@class='next next_page disabled']");
        public static By LB_users_TestowyUserDelete = By.XPath("//div/a[contains(.,'Użytkownik TestowyUserToDelete')]");

        //Strona książki autobiografia
        public static By TA_books_page_description = By.Id("description");
        public static By SE_books_page_opinionRate = By.Id("opinion_rate");
        public static By BT_books_page_submit = By.Id("submit");
        public static By DIV_books_page_rateTest = By.XPath("//div[contains(.,'test ocenił 1/10: \n')]");
        public static By DIV_books_page_opinionTest = By.XPath("//div[contains(.,'test ocenił 1/10: nie polecam')]");
        public static By BT_books_page_return = By.XPath("//a[contains(.,'Powrót')]");
    }
}
