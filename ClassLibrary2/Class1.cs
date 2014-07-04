using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace zadanie_moe_delo
{
    [TestFixture]
    public class zadanie_moe_delo
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://www.yandex.ru/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.CssSelector("div.b-weather > div.b-content-item__title > a.b-link")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=7358 | ]]
            driver.FindElement(By.LinkText("Регион")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=7358 | ]]
            driver.FindElement(By.Id("id1167775361710")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=7358 | ]]
            driver.FindElement(By.Id("id1167775361710")).Clear();
            driver.FindElement(By.Id("id1167775361710")).SendKeys("Пенза");
            driver.Close();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}