using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Pages;
using Test.Helpers;

namespace Test.Tests.Client
{
    [TestFixture]
    class CheckMakingAppointment
    {
        public IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            var authPage = new AuthPage(_driver);

            _driver.Navigate().GoToUrl("http://localhost:4200/auth");
            authPage.UserNameInput.SendKeys(Constants.ClientCredentials.Login);
            authPage.PasswordInput.SendKeys(Constants.ClientCredentials.Password);
            authPage.LoginButton.Click();
            _driver.WaitUntilNavBarLoad();
        }

        [Test]
        public void ShouldToastDateNotSelected()
        {
            //Given
            var clientPage = new ClientPage(_driver);
            var makeAppointmentDialog = new MakeAppointmentDialog(_driver);
            var expectedToastDetail = "Date not selected.";
            var toastDetail = "";

            //When
            clientPage.FirstSalonListElement.Click();
            clientPage.MakeAppointmentButton.Click();
            _driver.WaitUntilMakeAppointmentDialogAppear();
            makeAppointmentDialog.FirstWorkerListElement.Click();
            makeAppointmentDialog.FirstServiceListElement.Click();
            _driver.WaitUntilMakeAppointmentSummaryRegionAppear();
            makeAppointmentDialog.SelectDateButton.Click();
            _driver.WaitUntilMakeAppointmentSelectDateRegionAppear();
            makeAppointmentDialog.ConfirmButton.Click();
            _driver.WaitUntilToastAppear();
            toastDetail = makeAppointmentDialog.LastToastDetail.Text;

            //Then
            Assert.AreEqual(toastDetail, expectedToastDetail);
        }

        [TearDown]
        public void Close()
        {
            _driver.Dispose();
        }
    }
}
