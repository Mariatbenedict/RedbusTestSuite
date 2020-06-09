using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Red_Bus_Unit_Test_Project_V1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NavigateRedBus()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),options);
            driver.Navigate().GoToUrl("http://www.redbus.in");




        } //signin-block

     //   [TestMethod]
        // Login is not implemented because the website has a multifactor authentication setup.
        //public void Login()
        //{
        //    ChromeOptions options = new ChromeOptions();
        //    options.AddArgument("--start-maximized");
        //    var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        //    driver.Navigate().GoToUrl("http://www.redbus.in");
        //    IWebElement signIn = wait.Until(drv => drv.FindElement(By.Id("signin-block")));
        //    signIn.Click(); //signInLink
        //    IWebElement signInLink = wait.Until(drv => drv.FindElement(By.Id("signInLink")));
        //    signInLink.Click();//mobileNoInp
        //    driver.SwitchTo().Frame(0);
        //    IWebElement mobileNoInp = wait.Until(drv => drv.FindElement(By.Id("mobileNoInp")));
        //    mobileNoInp.SendKeys("123456789");//otpContainer

        //    IWebElement otpContainer = wait.Until(drv => drv.FindElement(By.ClassName("otpContainer")));
        //    otpContainer.Click();



        //}

        [TestMethod]
        public void SearchBus()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            driver.Navigate().GoToUrl("http://www.redbus.in");
            IWebElement src = wait.Until(drv => drv.FindElement(By.Id(PageHelper.sourceTextElementId)));
            src.SendKeys(TestDataHelper.sourceLocation);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait.Until(drv => drv.FindElement(By.ClassName(PageHelper.autoFillElementClass)));
            src.SendKeys(Keys.Enter);
            IWebElement dest = wait.Until(drv => drv.FindElement(By.Id(PageHelper.destinationTextElementId)));
            dest.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            dest.SendKeys(TestDataHelper.destinationLocation);
            IWebElement destDropDown = wait.Until(drv => drv.FindElement(By.ClassName(PageHelper.autoFillElementClass)));
            dest.SendKeys(Keys.Enter);
            IWebElement onwardCalender = driver.FindElement(By.ClassName(PageHelper.onwardCalenderClass));
            onwardCalender.Click();

            var current = wait.Until(drv => drv.FindElements(By.ClassName(PageHelper.currentElementClass)));
            current[1].Click();
            var searchBtn = wait.Until(drv => drv.FindElement(By.Id(PageHelper.searchButtonElementId)));
            searchBtn.Click();
        }
    }
}
