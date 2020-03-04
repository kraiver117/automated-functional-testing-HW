using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatedFunctionalTestingHW
{
    class AddOneAddress
    {
        IWebDriver driver;
        int seconds = 3000;

        [SetUp]
        public void startBrowser()
        {
            driver = new FirefoxDriver("C:/Users/jagutierrez/source/repos/AutomatedFunctionalTestingHW");
        }

        [Test]
        public void LoginTest()
        {
            driver.Url = "http://automationpractice.com/index.php?controller=authentication&back=my-account";

            Thread.Sleep(seconds);
            IWebElement loginForm = driver.FindElement(By.Id("email"));

            Actions loginActions = new Actions(driver);
            loginActions.Click(loginForm)
                .SendKeys("jagutierrez@gmail.com"+Keys.Tab)
                .SendKeys("origen117"+Keys.Tab+Keys.Tab)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();

            AdddingAddress();


        }

        private void AdddingAddress()
        {
            Thread.Sleep(seconds);
            driver.FindElement(By.XPath("//li[4]/a/span")).Click();

            driver.FindElement(By.XPath("//div[@id='center_column']/div/a/span")).Click();

            //Filling the form
            Thread.Sleep(seconds);
            driver.FindElement(By.Id("firstname")).SendKeys("Angel");
            driver.FindElement(By.Id("lastname")).SendKeys("Gutierrez");
            driver.FindElement(By.Id("company")).SendKeys("Scio");
            driver.FindElement(By.Id("address1")).SendKeys("Corregidora 48");
            driver.FindElement(By.Id("address2")).SendKeys("Brisa del mar 54");
            driver.FindElement(By.Id("city")).SendKeys("Morelia");
            driver.FindElement(By.XPath("//option[5]")).Click();
            driver.FindElement(By.Id("postcode")).SendKeys("58500");
            driver.FindElement(By.Id("phone")).SendKeys("434342432");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("1232143");
            driver.FindElement(By.Id("other")).SendKeys("Selenium is awesome dude!");
            driver.FindElement(By.Id("alias")).SendKeys("CJ & BDM");
            driver.FindElement(By.XPath("//p[2]/button/span")).Click();
        }

        [TearDown]
        public void closeBrowser()
        {
            Thread.Sleep(seconds);
            driver.Close();
        }

    }
}
