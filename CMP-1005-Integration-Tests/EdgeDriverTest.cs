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
                PageLoadStrategy = PageLoadStrategy.Normal,
                AcceptInsecureCertificates = true
            };

            _driver = new ChromeDriver(options);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("1", "1", "operation_add", "2")]
        [DataRow("5", "1", "operation_sub", "4")]
        [DataRow("5", "2", "operation_mul", "10")]
        [DataRow("6", "3", "operation_div", "2")]
        public void EnsureApplicaitonCanDoBasicMath(string leftNumber, string rightNumber, string operation, string expectedResult)
        {
            // Replace with your own test logic
            _driver.Url = testUrl;
            var leftNum = _driver.FindElementById("leftNumber");
            var rightNum = _driver.FindElementById("rightNumber");
            var operationBox = _driver.FindElementById(operation);
            var calcBtn = _driver.FindElementById("calculate");

            leftNum.SendKeys(leftNumber);
            rightNum.SendKeys(rightNumber);
            operationBox.Click();
            calcBtn.Click();

            var output = _driver.FindElementById("calculation_answer");
            var answer = output.Text;
            Assert.AreEqual(expectedResult, answer);
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
