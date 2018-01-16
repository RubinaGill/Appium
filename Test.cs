using NUnit.Framework;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.iOS;
using System.IO;

namespace TestAppium
{
    [TestFixture()]
    public class Test
    {
        //Creating instance for Appium Driver
        AppiumDriver<IWebElement> driver;

        string FileName = string.Format("{0}Resources/HitList.app", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../")));
        String textBoxXPath = "//XCUIElementTypeAlert[@name='New Name']/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeOther[1]/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeCollectionView/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeTextField";
        String elementXPath = "//XCUIElementTypeApplication[@name='HitList']/XCUIElementTypeWindow[1]/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeTable/XCUIElementTypeCell/XCUIElementTypeStaticText";


        [SetUp()]
        public void startDriver()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("deviceName", "iPad Air");
            caps.SetCapability("automationName", "XCUITest");
            caps.SetCapability("platformName", "iOS");
            caps.SetCapability("app", FileName);

            //Launch the IOS Driver
            driver = new IOSDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), caps);
        }


        [Test()]
        public void TestCase()
        {
            //click on Add icon
            driver.FindElementByAccessibilityId("Add").Click();

            //enter text in alert box
            IWebElement textbox = driver.FindElementByXPath(textBoxXPath);
            textbox.SendKeys("First Element");

            //click on save button
            driver.FindElementByName("Save").Click();

            //if the element is added into list 
            Assert.AreEqual("First Element", driver.FindElementByXPath(elementXPath).Text);

        }

        [TearDown()]
        public void closeDriver()
        {
            driver.Quit();
        }
    }
}
