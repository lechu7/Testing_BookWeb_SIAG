using NUnit.Framework;
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
        public void CheckShowError(IWebDriver driver, By errorBy)
        {
            Assert.IsTrue(driver.FindElement(errorBy).Displayed);
        }
        public void EnterUserName(IWebDriver driver, string name, By nameBy)
        {
            driver.FindElement(nameBy).SendKeys(name);
        }
        public void EnterMail(IWebDriver driver, string mail, By mailBy)
        {
            driver.FindElement(mailBy).SendKeys(mail);
        }
        public void EnterPassword(IWebDriver driver, string pass, By passBy)
        {
            driver.FindElement(passBy).SendKeys(pass);
        }
        public void CheckRegister(IWebDriver driver, By regBy)
        {
            Assert.IsTrue(IsTestElementPresent(driver, regBy));
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
