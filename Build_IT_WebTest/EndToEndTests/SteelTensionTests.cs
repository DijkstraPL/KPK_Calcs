using Build_IT_Web_TestHelper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Build_IT_WebTest.EndToEndTests
{
    [TestFixture]
    [EndToEndCategory]
    public class SteelTensionTests
    {
        private const string _chromeDriver = @"C:\KPK_Calcs\Build_IT_WebTest\bin\Debug\netcoreapp2.2";
        private const string _url = "http://building-it.net/scripts/calculator/1";
        private IWebDriver _driver;

        private IWebElement NEd;
        private IWebElement A;
        private IWebElement fy;

        private IWebElement _calculateButton;

        private string NplRd_Selector;
        private string resistance_Selector;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(_chromeDriver);
            _driver.Navigate().GoToUrl(_url);
            
            NEd = _driver.FindElement(By.ClassName("N_Ed_"));
            A = _driver.FindElement(By.ClassName("A"));
            fy = _driver.FindElement(By.ClassName("f_y_"));

            _calculateButton = _driver.FindElement(By.ClassName("calculate"));
            
            NplRd_Selector = @"N_pl\,Rd_";
            resistance_Selector = "Resistance";
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
                 
        [Test]
        public void CalculateTest_Success()
        {
            NEd.SendKeys("250");
            A.SendKeys("12");
            fy.SendKeys("235");

            _calculateButton.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.ClassName(NplRd_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(resistance_Selector)));

            var NplRd = _driver.FindElement(By.ClassName(NplRd_Selector));
            var resistance = _driver.FindElement(By.ClassName(resistance_Selector));

            Assert.That(NplRd.Text.Contains("282"));
            Assert.That(resistance.Text.Contains("88.652"));
        }
    }
}
