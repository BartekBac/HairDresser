using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Pages
{
    public class NavigationBar
    {
        private readonly IWebDriver _driver;

        public NavigationBar(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement LogoutButton
        {
            get
            {
                return _driver.FindElement(By.Id("logout-button"));
            }
        }
    }
}
