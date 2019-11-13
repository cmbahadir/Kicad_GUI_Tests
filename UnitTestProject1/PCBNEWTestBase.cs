using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Appium;

namespace PCBNEWTest
{
    public class PCBNEWTestBase
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string pcbnewAppId = @"D:\Mete\kicad-source\build\debug\pcbnew\pcbnew.exe";

        protected static WindowsDriver<WindowsElement> session;
        

        public static void Setup()
        {
            if (session == null)
            {
                // Create a new session to launch PCBNEW application
                AppiumOptions appCapabilities = new AppiumOptions();
                appCapabilities.AddAdditionalCapability("app", pcbnewAppId);
                Uri ApplicationDriverURL = new Uri("http://127.0.0.1:4723");
                session = new WindowsDriver<WindowsElement>(ApplicationDriverURL, appCapabilities);
                Assert.IsNotNull(session);
                Assert.IsNotNull(session.SessionId);

                // Verify that Pcbnew is started with Pcbnew window title
                Assert.AreEqual("Pcbnew", session.Title);

                // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
                session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
            }
        }

        public static void BaseTearDown()
        {
            if (session != null)
            {
                session.Close();

                try
                {
                    session.FindElementByName("Don't Save").Click();
                }
                catch { }

                session.Quit();
                session = null;
            }
        }

        //Workaround incorrect characters problem : https://github.com/microsoft/WinAppDriver/issues/699
        protected static string SanitizeBackslashes(string input) => input.Replace("\\", Keys.Alt + Keys.NumberPad9 + Keys.NumberPad2 + Keys.Alt);
        protected static string SanitizeFileExtension(string input) => input.Replace("ç", Keys.Alt + Keys.NumberPad9 + Keys.NumberPad2 + Keys.Alt);
    }
}