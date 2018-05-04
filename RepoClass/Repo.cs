using OpenQA.Selenium;


namespace RepoClass
{
    public static class REPO
    {
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

        //Strona Rejestracji
        public static By ET_register_username = By.Id("username");
        public static By ET_register_email = By.Id("email");
        public static By ET_register_password = By.Id("password");
        public static By BT_register_register= By.Id("submit");
        public static By LB_register_registerIn = By.XPath("//div[contains(.,'Zarejestruj się w BookWeb!')]");

        //Strona logowania
        public static By ET_login_mail = By.Id("email");
        public static By ET_login_password = By.Id("password");
        public static By BT_login_logIn = By.Id("submit");
        public static By PUWin_login_incorrectLoginDetails = By.XPath("//div[contains(.,'Podałeś błędne dane logowania')]");
        public static By LB_login_login = By.XPath("//div[contains(.,'Logowanie')]");

        //Strona główna przed zalogowaniem

        //Strona główna po zalogowaniu
        public static By PUWin_home_correctLogin = By.XPath("//div[contains(.,'Zostałeś prawidłowo zalogowany')]");
    }
}
