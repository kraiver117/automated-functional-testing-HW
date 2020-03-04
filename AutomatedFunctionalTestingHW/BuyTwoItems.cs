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
    class BuyTwoItems
    {
        IWebDriver driver;
        int seconds = 2500;

        [SetUp]
        public void StartBrowser()
        {
            driver = new FirefoxDriver("C:/Users/jagutierrez/source/repos/automated-functional-testing-HW");
        }

        [Test]
        public void ShoppingTest()
        {
            driver.Url = "http://automationpractice.com/index.php?controller=authentication&back=my-account";

            //login
            Thread.Sleep(seconds);
            IWebElement loginForm = driver.FindElement(By.Id("email"));

            Actions loginActions = new Actions(driver);
            loginActions.Click(loginForm)
                .SendKeys("guti1996@gmail.com" + Keys.Tab)
                .SendKeys("origen117" + Keys.Tab + Keys.Tab)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();

            Purchase();

        }
        public void Purchase()
        {
            //Buying first Item
            Thread.Sleep(seconds);
             driver.FindElement(By.XPath("//input[@id='search_query_top']")).SendKeys("Blouse");
             driver.FindElement(By.XPath("//button[@name='submit_search']")).Click();
            Thread.Sleep(seconds);
            driver.FindElement(By.XPath("//div[@id='center_column']/ul/li/div/div/div/a/img")).Click();
            driver.FindElement(By.XPath("//a[@id='color_8']")).Click();
            driver.FindElement(By.XPath("//p[@id='quantity_wanted_p']/a[2]/span/i")).Click();
            driver.FindElement(By.XPath("//p[@id='add_to_cart']/button/span")).Click();
            Thread.Sleep(seconds);
            driver.FindElement(By.XPath("//div[@id='layer_cart']/div/div[2]/div[4]/span/span")).Click();
            
            //Buying second Item
            Thread.Sleep(seconds);
            driver.FindElement(By.XPath("//input[@id='search_query_top']")).Clear();
            driver.FindElement(By.XPath("//input[@id='search_query_top']")).SendKeys("Dress");
            driver.FindElement(By.XPath("//button[@name='submit_search']")).Click();
            Thread.Sleep(seconds);
            driver.FindElement(By.XPath("//img[@alt='Printed Summer Dress']")).Click();
            Thread.Sleep(seconds);
            driver.FindElement(By.XPath("//a[@id='color_13']")).Click();
            Thread.Sleep(seconds);
            driver.FindElement(By.XPath("//p[@id='quantity_wanted_p']/a[2]/span/i")).Click();
            Thread.Sleep(seconds);
            driver.FindElement(By.XPath("//p[@id='add_to_cart']/button/span")).Click();
            Thread.Sleep(seconds);

            //Payment
            driver.FindElement(By.XPath("//div[@id='layer_cart']/div/div[2]/div[4]/a/span")).Click();
            driver.FindElement(By.XPath("//div[3]/div/p[2]/a/span")).Click();
            Thread.Sleep(seconds);
            driver.FindElement(By.XPath("//div[@id='center_column']/form/p/button/span")).Click();
            Thread.Sleep(seconds);
            driver.FindElement(By.XPath("//input[@id='cgv']")).Click();
            Thread.Sleep(seconds);
            driver.FindElement(By.XPath("//form[@id='form']/p/button/span")).Click();
            Thread.Sleep(seconds);
            driver.FindElement(By.XPath("//div[@id='HOOK_PAYMENT']/div[2]/div/p/a")).Click();
            Thread.Sleep(seconds);
            driver.FindElement(By.XPath("//p[@id='cart_navigation']/button/span")).Click();
            Thread.Sleep(seconds);
        }

        [TearDown]
        public void closeBrowser()
        {
            Thread.Sleep(seconds);
            driver.Close();
        }



    }
}
