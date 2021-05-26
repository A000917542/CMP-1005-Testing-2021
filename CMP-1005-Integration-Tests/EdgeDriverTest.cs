using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CMP_1005_Integration_Tests
{
    [TestClass]
    public class EdgeDriverTest
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        private ChromeDriver _driver;
        private string testUrl = "https://localhost:5001/";

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            // Initialize edge driver 
            var options = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };

            _driver = new ChromeDriver(options);
        }

        [TestMethod]
        public void EnsureApplicaitonCanAddTwoNumbers()
        {
            // Replace with your own test logic
            _driver.Url = testUrl;
            var leftNum = _driver.FindElementById("leftNumber");
            var rightNum = _driver.FindElementById("rightNumber");
            var addBox = _driver.FindElementById("operation_add");
            var calcBtn = _driver.FindElementById("calculate");

            leftNum.SendKeys("1");
            rightNum.SendKeys("1");
            addBox.Click();
            calcBtn.Click();

            var output = _driver.FindElementById("calculation_answer");
            var answer = output.Text;
            Assert.AreEqual("2", answer);
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
