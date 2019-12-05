using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Pages
{
    public class ClientPage
    {
        private readonly IWebDriver _driver;

        public ClientPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement FirstSalonListElement
        {
            get
            {
                var salonDivs = _driver.FindElements(By.ClassName("my-list-element-wrapper"));
                return salonDivs[0];
            }
        }
        public IWebElement MakeAppointmentButton
        {
            get
            {
                return _driver.FindElement(By.ClassName("my-appoint-button"));
            }
        }
    }
}
