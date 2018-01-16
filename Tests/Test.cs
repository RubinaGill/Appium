using NUnit.Framework;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.iOS;
using System.IO;
using System.Configuration;
using TestAppium.Pages;

namespace TestAppium
{
    [TestFixture()]
    public class Test
    {
        //Creating instance for Appium Driver
        AppiumDriver<IWebElement> driver;
    
        [SetUp()]
        public void startDriver()
        {
            String dirPath = ConfigurationManager.AppSettings["DirectoryPath"];
            string fileName = string.Format("{0}{1}",Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../")),dirPath);
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("deviceName", "iPad Air");
            caps.SetCapability("automationName", "XCUITest");
            caps.SetCapability("platformName", "iOS");
            caps.SetCapability("app", fileName);

            //Launch the IOS Driver
            driver = new IOSDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), caps);
        }

        [Test()]
        public void TestCase()
        {
            //click on Add icon
            driver.FindElement(AppLocators.addButton).Click();

            //enter text in alert box
            IWebElement textbox = driver.FindElement(AppLocators.textBox);
            textbox.SendKeys("First Element");

            //click on save button
            driver.FindElement(AppLocators.saveButton).Click();

            //if the element is added into list 
            Assert.AreEqual("First Element", driver.FindElement(AppLocators.listElement).Text);

        }

        [TearDown()]
        public void closeDriver()
        {
            driver.Quit();
        }
    }
}
