using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace KicadAutomatedGUITests
{
    public class BasicOperations
    {
        public void Open_PCB_File(WindowsDriver<WindowsElement> testSession, string filePath, string fileName)
        {
            //Get the File Menu Element
            WindowsElement element;
            element = testSession.FindElementByName("File");

            //Thread.Sleeps look ugly
            Thread.Sleep(TimeSpan.FromSeconds(2));
            element.SendKeys(Keys.ArrowDown);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            element.SendKeys(Keys.Enter);

            //Browse Files Dialog
            WindowsElement browseFilesElement = testSession.FindElementByName("Open Board File");
            browseFilesElement.SendKeys(Keys.Alt + "n");
            browseFilesElement.SendKeys(filePath + fileName);

            //Press the Open button
            WindowsElement OpenButton = testSession.FindElementByName("Open");
            OpenButton.Click();
        }
    }
}
