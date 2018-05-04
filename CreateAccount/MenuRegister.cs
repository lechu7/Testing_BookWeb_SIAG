using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Registration
{
    public class MenuRegister
    {
        public void ClickRegistrationTab(IWebDriver driver, By registrationTabBy)
        {
            driver.FindElement(registrationTabBy).Click();
        }
        public void ClickRegistrationButton(IWebDriver driver, By registrationBy)
        {
            driver.FindElement(registrationBy).Click();
        }
    }
}
