using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Login
{
    public static class REPO
    {
        public static By ET_mail = By.Id("email");
        public static By ET_password = By.Id("password");
        public static By P_U_Win_incorrectLoginDetails = By.Id("flash_danger");
        public static By TB_mail = By.Id("email");
    }
}
