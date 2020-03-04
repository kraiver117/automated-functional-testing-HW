using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace AutomatedFunctionalTestingHW
{
    class RegistrationTesting
    {
        IWebDriver driver;

        
        int seconds = 4000;


        [SetUp]
        public void startBrowser(){
            
            driver = new FirefoxDriver("C:/Users/jagutierrez/source/repos/automated-functional-testing-HW");
            //driver = new ChromeDriver("C:/Users/Angel/Desktop/AutomatedFunctionalTesting/automated-functional-testing-HW");
        }

        [Test]
        public void AutoLogin()
        {
            driver.Url = "http://automationpractice.com/index.php";

            //navigating to login page
            Thread.Sleep(seconds);

            IWebElement loginBtn = driver.FindElement(By.ClassName("login"));
            loginBtn.Click();

            //fill email register
            Thread.Sleep(seconds);
            IWebElement emailAdd = driver.FindElement(By.Id("email_create"));
            Actions emailActions = new Actions(driver);
            emailActions.Click(emailAdd)
                .SendKeys("guti1996@gmail.com" + Keys.Tab)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();

            //fill inputs
            Thread.Sleep(seconds);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Jose");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Angel");
            driver.FindElement(By.Id("passwd")).SendKeys("origen117");
            driver.FindElement(By.Id("company")).SendKeys("Scio");
            driver.FindElement(By.Id("address1")).SendKeys("Corregidora #405");
            driver.FindElement(By.Id("address2")).SendKeys("Colonia Centro");
            driver.FindElement(By.Id("city")).SendKeys("Puruandiro");
            driver.FindElement(By.Id("postcode")).SendKeys("58500");
            driver.FindElement(By.Id("other")).SendKeys("GG Izi");
            driver.FindElement(By.Id("phone")).SendKeys("234523423");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("1231231233");
            driver.FindElement(By.Id("alias")).SendKeys("Kraiver");


            //fill selects
            // Bday
            Thread.Sleep(3000);
            IWebElement Bday = driver.FindElement(By.XPath("//option[27]"));
            Bday.Click();
            IWebElement Bmonth = driver.FindElement(By.XPath("(//option[@value='4'])[2]"));
            Bmonth.Click();
            IWebElement Byear = driver.FindElement(By.XPath("//option[@value='1997']"));
            Byear.Click();

            //state
            Thread.Sleep(3000);
            IWebElement state = driver.FindElement(By.XPath("(//option[@value='3'])[3]"));
            state.Click();


            Thread.Sleep(seconds);
            IWebElement sendButton = driver.FindElement(By.Id("submitAccount"));
            sendButton.Click();


        }

        [TearDown]
        public void closeBrowser()
        {
            Thread.Sleep(seconds);
            driver.Close();
        }


    }
}
