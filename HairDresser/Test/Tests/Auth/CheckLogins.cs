using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Helpers;
using Test.Pages;

namespace Test.Auth
{
    [TestFixture]
    public class CheckLogins
    {
        public IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://localhost:4200/auth");
        }

        [Test]
        public void LoginClient()
        {
            //Given
            var authPage = new AuthPage(_driver);

            //When
            authPage.UserNameInput.SendKeys(Constants.ClientCredentials.Login);
            authPage.PasswordInput.SendKeys(Constants.ClientCredentials.Password);
            authPage.LoginButton.Click();
            _driver.WaitUntilNavBarLoad();

            //Then
            Assert.AreEqual(_driver.Url, Urls.ClientPage);
        }
        [Test]
        public void LoginSalon()
        {
            //Given
            var authPage = new AuthPage(_driver);

            //When
            authPage.UserNameInput.SendKeys(Constants.SalonCredentials.Login);
            authPage.PasswordInput.SendKeys(Constants.SalonCredentials.Password);
            authPage.LoginButton.Click();
            _driver.WaitUntilNavBarLoad();

            //Then
            Assert.AreEqual(_driver.Url, Urls.SalonPage);
        }
        [Test]
        public void LoginWorker()
        {
            //Given
            var authPage = new AuthPage(_driver);

            //When
            authPage.UserNameInput.SendKeys(Constants.WorkerCredentials.Login);
            authPage.PasswordInput.SendKeys(Constants.WorkerCredentials.Password);
            authPage.LoginButton.Click();
            _driver.WaitUntilNavBarLoad();

            //Then
            Assert.AreEqual(_driver.Url, Urls.WorkerPage);
        }
        [Test]
        public void FailedLogin()
        {
            //Given
            var authPage = new AuthPage(_driver);
            var wrongPassowrd = "xyz";
            var expectedSummaryTitle = "Login failed";
            var summaryTitle = "";

            //When
            authPage.UserNameInput.SendKeys(Constants.WorkerCredentials.Login);
            authPage.PasswordInput.SendKeys(wrongPassowrd);
            authPage.LoginButton.Click();
            _driver.WaitUntilToastAppear();
            summaryTitle = authPage.LastToastSummary.Text;

            //Then
            Assert.AreEqual(expectedSummaryTitle, summaryTitle);
        }

        [TearDown]
        public void Close()
        {
            _driver.Dispose();
        }
    }
}
