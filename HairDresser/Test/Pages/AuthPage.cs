using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Pages
{
    public class AuthPage
    {
        private readonly IWebDriver _driver;

        public AuthPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement UserNameInput
        {
            get
            {
                return _driver.FindElement(By.Id("username-input"));
            }
        }
        public IWebElement PasswordInput
        {
            get
            {
                return _driver.FindElement(By.Id("password-input"));
            }
        }
        public IWebElement LoginButton
        {
            get
            {
                return _driver.FindElement(By.Id("login-button"));
            }
        }
        public IWebElement SignUpButton
        {
            get
            {
                return _driver.FindElement(By.Id("sign-up-button"));
            }
        }
        public IWebElement AddSalonLink
        {
            get
            {
                return _driver.FindElement(By.Id("add-salon-a"));
            }
        }
        public IWebElement LastToastSummary
        {
            get
            {
                return _driver.FindElement(By.ClassName("ui-toast-summary"));
            }
        }

    }
}
