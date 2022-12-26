using OpenQA.Selenium;
using System;
using System.IO;

namespace Framework.Utils
{
    public static class ScreenshotUtil
    {
        private static string _parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        public static void TakeAndSaveScreenshot(IWebDriver driver)
        {
            ITakesScreenshot? ts = driver as ITakesScreenshot;
            Screenshot screenshot = ts.GetScreenshot();
                
            SaveScreenShotWithTimeStamp(screenshot);
        }

        private static void SaveScreenShotWithTimeStamp(Screenshot screenshot)
        {
            DateTime dateTime = DateTime.Now;
            screenshot.SaveAsFile(Path.Combine(_parentPath, "Screenshots", $"screenshot_{GetTimeStamp(dateTime)}.jpeg"));
        }

        private static string GetTimeStamp(DateTime dateTime) => dateTime.ToString("yyyy-MM-dd_HH-mm-ss");
    }
}
