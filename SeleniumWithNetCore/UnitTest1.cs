using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumWithNetCore
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            IWebDriver driver = new ChromeDriver(driverDir);

            driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");

            driver.FindElement(By.Name("UserName")).SendKeys("admin");
            driver.FindElement(By.Name("Password")).SendKeys("admin");

            driver.FindElement(By.Name("Login")).Submit();

        }
    }




    public class LoginPage
    {

        public LoginPage(IWebDriver driver)
        {
            //Note: Not working with Selenium 3.6.0 in .Net Core 2.0
            //PageFactory
        }

        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement Password { get; set; }


    }
}
