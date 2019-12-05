﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Pages
{
    public class MakeAppointmentDialog
    {
        private readonly IWebDriver _driver;

        public MakeAppointmentDialog(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement MakeAppointmentDialogDiv
        {
            get
            {
                return _driver.FindElement(By.Id("make-appointment-div"));
            }
        }
        public IWebElement FirstWorkerListElement
        {
            get
            {
                var workerDivs = _driver.FindElements(By.ClassName("my-list-element-wrapper"));
                return workerDivs[0].FindElement(By.TagName("label"));
            }
        }
        public IWebElement FirstServiceListElement
        {
            get
            {
                var serviceDivs = _driver.FindElements(By.ClassName("my-list-element-wrapper"));
                return serviceDivs[0].FindElement(By.TagName("label"));
            }
        }
        public IWebElement SelectDateButton
        {
            get
            {
                return _driver.FindElement(By.Id("select-date-button"));
            }
        }
        public IWebElement ChangeVisitDetailButton
        {
            get
            {
                return _driver.FindElement(By.Id("change-visit-details-button"));
            }
        }
        public IWebElement ConfirmButton
        {
            get
            {
                return _driver.FindElement(By.Id("confirm-button"));
            }
        }
        public IWebElement RejectButton
        {
            get
            {
                return _driver.FindElement(By.Id("reject-button"));
            }
        }
        public IWebElement LastToastDetail
        {
            get
            {
                return _driver.FindElement(By.ClassName("ui-toast-detail"));
            }
        }
    }
}
