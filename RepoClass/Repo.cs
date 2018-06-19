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
        public static By LB_all_wzim = By.XPath("//small[contains(.,'Wydział Zastosowań Informatyki i Informatyki')]");
        public static By TB_all_search = By.Id("search");
        public static By SE_all_orders = By.Id("orders");
        public static By SE_all_sort = By.Id("sort");
        public static By BT_all_search = By.Name("commit");
        //na prawie każdej
        public static By HL_almostAll_toHome = By.XPath("//a[contains(.,'Powrót do strony głównej')]");
        public static By HL_almostAll_return = By.XPath("//a[contains(.,'Powrót')]");

        //Przyciski górnego menu 
        public static By TB_UpMain_register = By.Id("register");
        public static By TB_UpMain_login = By.Id("login");
        public static By TB_UpMain_mainsite = By.Id("mainsite");
        public static By TB_UpMain_books = By.Id("books");
        public static By TB_UpMain_users = By.Id("users");
        public static By TB_UpMain_addBook = By.Id("addbook");
        public static By TB_UpMain_logOut = By.Id("logout");
        public static By TB_UpMain_profile = By.Id("profile");
        public static By TB_UpMain_authors = By.Id("authors");

        //Strona Rejestracji
        public static By LB_register_usernameLB = By.XPath("//div[contains(.,'Nazwa użytkownika')]");
        public static By LB_register_emailLB = By.XPath("//div[contains(.,'Email')]");
        public static By LB_register_passwordLB = By.XPath("//div[contains(.,'Hasło')]");
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
        public static By LB_login_mailLB = By.XPath("//div[contains(.,'Email/Login')]");
        public static By LB_login_passLB = By.XPath("//div[contains(.,'Hasło')]");

        //Twój Profil
        public static By BT_yourProfile_delete = By.Id("delete");
        public static By PUWin_yourProfile_deleteAdmin = By.XPath("//div[contains(.,'Nie możesz usunąć administratora')]");
        public static By LB_yourProfile_yourOpinions = By.XPath("//div[contains(.,'Opinie użytkownika')]");
        public static By DIV_yourProfile_opinion_book = By.XPath("//div/a[contains(.,'Wyspa')]");//\n    <div>1/10</div>\n    <div>nie polecam</div>')]");
        public static By DIV_yourProfile_opinion_rate = By.XPath("//div[contains(.,'1/5')]");
        public static By DIV_yourProfile_opinion_description = By.XPath("//div[contains(.,'nie polecam')]");

        //Strona główna przed zalogowaniem
        public static By LB_homeBeforeLogin_add = By.XPath("//p[contains(.,'Dodawaj')]");
        public static By LB_homeBeforeLogin_share = By.XPath("//p[contains(.,'Dziel sie!')]");
        public static By LB_homeBeforeLogin_discover = By.XPath("//p[contains(.,'Odkrywaj')]");
        //Kropko ze zmianą slajdu
        public static By POINT_homeBeforeLogin_point1 = By.XPath("//p[@class='carousel-indicators']/li[0]");
        public static By POINT_homeBeforeLogin_point2 = By.XPath("//p[@class='carousel-indicators']/li[1]");
        public static By POINT_homeBeforeLogin_point3 = By.XPath("//p[@class='carousel-indicators']/li[2]");

        public static By LB_homeBeforeLogin_BookWeb= By.XPath("//div[contains(.,'BookWeb')]");
        public static By LB_homeBeforeLogin_LB1 = By.XPath("//p[contains(.,'Miejsce na wyrażanie Twoich opinii')]");
        public static By LB_homeBeforeLogin_LB2 = By.XPath("//p[contains(.,'Zaloguj się, aby mieć dostęp do bazy wielu książek. ')]");
        public static By LB_homeBeforeLogin_LB3 = By.XPath("//p[contains(.,'Co sądzą inni użytkownicy? Sprawdź bazę komentarzy i zdecyduj się na nową książkę!')]");

        public static By IM_homeBeforeLogin_IM1 = By.XPath("//img[contains(@alt, 'Los Angeles')]");
        public static By IM_homeBeforeLogin_IM2 = By.XPath("//img[contains(@alt, 'Chicago')]");
        public static By IM_homeBeforeLogin_IM3 = By.XPath("//img[contains(@alt, 'New York')]");

        //Strona główna po zalogowaniu
        public static By PUWin_home_correctLogin = By.XPath("//div[contains(.,'Zostałeś prawidłowo zalogowany')]");

        //Strona Lista książek
        public static By BT_book_Autobiografia = By.XPath("//a[contains(.,'Wyspa')]");
        public static By SE_book_pagination = By.ClassName("pagination");
        public static By TR_book_bookid10 = By.Id("book-10");
        public static By BT_book_nextPage = By.XPath("//li[@class='next next_page ']/a[1]");
        public static By BT_book_nextPage_disabled = By.XPath("//li[@class='next next_page disabled']/a[1]");

        //Strona Użytkownicy
        public static By SE_users_pagination = By.XPath("//ul[@class='pagination']");
        public static By BT_users_nextPage = By.XPath("//a[contains(.,'Następna')]");
        public static By BT_users_nextPageDisabled = By.XPath("//li[@class='next next_page disabled']");
        public static By LB_users_TestowyUserDelete = By.XPath("//a[contains(.,'Użytkownik TestowyUserToDelete')]");
        public static By TR_users_userid10 = By.PartialLinkText("Użytkownik");

        //Strona Autorzy
        public static By HL_authors_AlbertCamus = By.XPath("//a[contains(.,'Książki autora: Albert Camus')]");
        public static By HL_authors_Dzuma = By.XPath("//a[contains(.,'Wyspa')]");

        //Strona Dodaj ksiazke
        public static By LB_addBook_addBook = By.XPath("//a[contains(.,'Dodaj książkę')]");
        public static By LB_addBook_title = By.XPath("//a[contains(.,'Tytuł')]");
        public static By LB_addBook_author = By.XPath("//a[contains(.,'Autor')]");
        public static By LB_addBook_genre = By.XPath("//a[contains(.,'Gatunek')]");
        public static By ET_addBook_title = By.Id("title");
        public static By ET_addBook_author = By.Id("author");
        public static By ET_addBook_genre = By.Id("genre");
        public static By BT_addBook_add = By.Id("submit");

        //Strona książki autobiografia
        public static By TA_books_page_description = By.Id("description");
        public static By SE_books_page_opinionRate = By.Id("opinion_rate");
        public static By BT_books_page_submit = By.Id("submit");
        public static By DIV_books_page_rateTest = By.XPath("//div[contains(.,'test ocenił 1/5: \n')]");
        public static By DIV_books_page_opinionTest = By.XPath("//div[contains(.,'test ocenił 1/5: nie polecam')]");
        public static By BT_books_page_return = By.XPath("//a[contains(.,'Powrót')]");


        //Dominik Gołdyn Testy Elementy Nowe
        public static By NoBookError = By.XPath("//h2[contains(.,'Brak obiektów dla frazy')]");

        public static By SearchingTitleASC = By.XPath("//div[contains(.,'title,ASC')]");
        public static By SearchingAuthorASC = By.XPath("//div[contains(.,'author,ASC')]");
        public static By SearchingGenreASC = By.XPath("//div[contains(.,'genre,ASC')]");

        public static By SearchingTitleDESC = By.XPath("//div[contains(.,'title,DESC')]");
        public static By SearchingAuthorDESC = By.XPath("//div[contains(.,'author,DESC')]");
        public static By SearchingGenreDESC = By.XPath("//div[contains(.,'genre,DESC')]");
    }
}
