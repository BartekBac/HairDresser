using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Pages;

namespace Test.Helpers
{
    public static class WaitService
    {
        public static void WaitUntilNavBarLoad(this IWebDriver driver)
        {
            var delay = TimeSpan.FromSeconds(20);
            var navigationBar = new NavigationBar(driver);
            var wait = new WebDriverWait(driver, delay);
            wait.Until(x => x.FindElement(By.Id(navigationBar.LogoutButton.GetAttribute("id"))));
        }
        public static void WaitUntilToastAppear(this IWebDriver driver)
        {
            var delay = TimeSpan.FromSeconds(10);
            var authPage = new AuthPage(driver);
            var wait = new WebDriverWait(driver, delay);
            wait.Until(x => x.FindElement(By.ClassName(authPage.LastToastSummary.GetAttribute("class"))));
        }
        public static void WaitUntilMakeAppointmentDialogAppear(this IWebDriver driver)
        {
            var delay = TimeSpan.FromSeconds(10);
            var makeAppointmentDialog = new MakeAppointmentDialog(driver);
            var wait = new WebDriverWait(driver, delay);
            wait.Until(x => x.FindElement(By.Id(makeAppointmentDialog.MakeAppointmentDialogDiv.GetAttribute("id"))));
        }
        public static void WaitUntilMakeAppointmentSummaryRegionAppear(this IWebDriver driver)
        {
            var delay = TimeSpan.FromSeconds(10);
            var makeAppointmentDialog = new MakeAppointmentDialog(driver);
            var wait = new WebDriverWait(driver, delay);
            wait.Until(x => x.FindElement(By.Id(makeAppointmentDialog.SelectDateButton.GetAttribute("id"))));
        }
        public static void WaitUntilMakeAppointmentSelectDateRegionAppear(this IWebDriver driver)
        {
            var delay = TimeSpan.FromSeconds(10);
            var makeAppointmentDialog = new MakeAppointmentDialog(driver);
            var wait = new WebDriverWait(driver, delay);
            wait.Until(x => x.FindElement(By.Id(makeAppointmentDialog.ConfirmButton.GetAttribute("id"))));
        }
    }
}
