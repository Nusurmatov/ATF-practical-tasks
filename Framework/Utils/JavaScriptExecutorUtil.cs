using OpenQA.Selenium;

namespace Framework.Utils
{
    public static class JavaScriptExecutorUtil
    {
        public static void ClickElement(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click()", element);
        }

        public static void OpenNewTab(IWebDriver driver)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("window.open();");
        }
    }
}
