using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace TestAppium.Pages
{
    public class AppLocators
    {
        public static By textBox = MobileBy.XPath("//XCUIElementTypeAlert[@name='New Name']/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeOther[1]/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeCollectionView/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeTextField");
        public static By listElement = MobileBy.XPath("//XCUIElementTypeApplication[@name='HitList']/XCUIElementTypeWindow[1]/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeTable/XCUIElementTypeCell/XCUIElementTypeStaticText");
        public static By addButton = MobileBy.AccessibilityId("Add");
        public static By saveButton = MobileBy.Name("Save");

    }
}
