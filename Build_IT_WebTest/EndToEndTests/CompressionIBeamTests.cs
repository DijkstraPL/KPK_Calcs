using Build_IT_Web_TestHelper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WebTest.EndToEndTests
{
    [TestFixture]
    [EndToEndCategory]
    public class CompressionIBeamTests
    {
        private const string _chromeDriver = @"C:\KPK_Calcs\Build_IT_WebTest\bin\Debug\netcoreapp2.2";
        private const string _url = "http://building-it.net/scripts/calculator/6";
        private IWebDriver _driver;

        private IWebElement fy;

        private IWebElement expansionPanel;
        private IWebElement h;
        private IWebElement b;
        private IWebElement tf;
        private IWebElement tw;
        private IWebElement rolled;
        private IWebElement welded;
        private IWebElement r;

        private IWebElement _calculateButton;

        private string A_Selector;
        private string ε_Selector;
        private string cweb_Selector;
        private string cflange_Selector;
        private string webClass_Selector;
        private string flangeClass_Selector;
        private string Aeff_Selector;
        private string NcRd_Selector;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(_chromeDriver);
            _driver.Navigate().GoToUrl(_url);

            fy = _driver.FindElement(By.Id("mat-input-0"));
            expansionPanel = _driver.FindElement(By.Id("mat-expansion-panel-header-0"));
            h = _driver.FindElement(By.Id("mat-input-1"));
            b = _driver.FindElement(By.Id("mat-input-2"));
            tf = _driver.FindElement(By.Id("mat-input-3"));
            tw = _driver.FindElement(By.Id("mat-input-4"));
            rolled = _driver.FindElement(By.Id("mat-radio-2"));
            welded = _driver.FindElement(By.Id("mat-radio-3"));
            r = _driver.FindElement(By.Id("mat-input-5"));

            _calculateButton = _driver.FindElement(By.CssSelector("body > app-root > div > script-calculator > div > div.text-center.ng-star-inserted > button"));

            A_Selector = "body > app-root > div > script-calculator > div > div:nth-child(6) > mat-list > div:nth-child(1) > parameter-result > div > mat-list-item > div > div.d-inline-flex.m-2 > div > p.font-weight-bold.mb-0.parameter-result-value > span.ng-star-inserted";
            ε_Selector = "body > app-root > div > script-calculator > div > div:nth-child(6) > mat-list > div:nth-child(2) > parameter-result > div > mat-list-item > div > div.d-inline-flex.m-2 > div > p.font-weight-bold.mb-0.parameter-result-value > span.ng-star-inserted";
            cweb_Selector = "body > app-root > div > script-calculator > div > div:nth-child(6) > mat-list > div:nth-child(3) > parameter-result > div > mat-list-item > div > div.d-inline-flex.m-2 > div > p.font-weight-bold.mb-0.parameter-result-value > span.ng-star-inserted";
            cflange_Selector = "body > app-root > div > script-calculator > div > div:nth-child(6) > mat-list > div:nth-child(4) > parameter-result > div > mat-list-item > div > div.d-inline-flex.m-2 > div > p.font-weight-bold.mb-0.parameter-result-value > span.ng-star-inserted";
            webClass_Selector = "body > app-root > div > script-calculator > div > div:nth-child(6) > mat-list > div:nth-child(5) > parameter-result > div > mat-list-item > div > div.d-inline-flex.m-2 > div > p.font-weight-bold.mb-0.parameter-result-value > span.ng-star-inserted";
            flangeClass_Selector = "body > app-root > div > script-calculator > div > div:nth-child(6) > mat-list > div:nth-child(6) > parameter-result > div > mat-list-item > div > div.d-inline-flex.m-2 > div > p.font-weight-bold.mb-0.parameter-result-value > span.ng-star-inserted";
            Aeff_Selector = "body > app-root > div > script-calculator > div > div:nth-child(6) > mat-list > div:nth-child(7) > parameter-result > div > mat-list-item > div > div.d-inline-flex.m-2 > div > p.font-weight-bold.mb-0.parameter-result-value > span.ng-star-inserted";
            NcRd_Selector = "body > app-root > div > script-calculator > div > div:nth-child(6) > mat-list > div:nth-child(8) > parameter-result > div > mat-list-item > div > div.d-inline-flex.m-2 > div > p.font-weight-bold.mb-0.parameter-result-value > span.ng-star-inserted";
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void CalculateTest_Success()
        {
            fy.SendKeys("275");
            if (expansionPanel.GetAttribute("aria-expanded") != "true")
                expansionPanel.Click();
            h.SendKeys("300");
            b.SendKeys("150");
            tf.SendKeys("10,7");
            tw.SendKeys("7,1");
            rolled.Click();
            r.SendKeys("15");

            _calculateButton.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.CssSelector(A_Selector)));
            wait.Until(d => d.FindElement(By.CssSelector(ε_Selector)));
            wait.Until(d => d.FindElement(By.CssSelector(cweb_Selector)));
            wait.Until(d => d.FindElement(By.CssSelector(cflange_Selector)));
            wait.Until(d => d.FindElement(By.CssSelector(webClass_Selector)));
            wait.Until(d => d.FindElement(By.CssSelector(flangeClass_Selector)));
            wait.Until(d => d.FindElement(By.CssSelector(Aeff_Selector)));
            wait.Until(d => d.FindElement(By.CssSelector(NcRd_Selector)));

            var A = _driver.FindElement(By.CssSelector(A_Selector));
            var ε = _driver.FindElement(By.CssSelector(ε_Selector));
            var cweb = _driver.FindElement(By.CssSelector(cweb_Selector));
            var cflange = _driver.FindElement(By.CssSelector(cflange_Selector));
            var webClass = _driver.FindElement(By.CssSelector(webClass_Selector));
            var flangeClass = _driver.FindElement(By.CssSelector(flangeClass_Selector));
            var Aeff = _driver.FindElement(By.CssSelector(Aeff_Selector));
            var NcRd = _driver.FindElement(By.CssSelector(NcRd_Selector));

            Assert.That(A.Text.Contains("53.8", StringComparison.InvariantCulture));
            Assert.That(ε.Text.Contains("0.92", StringComparison.InvariantCulture));
            Assert.That(webClass.Text.Contains("Class 2", StringComparison.InvariantCulture));
            Assert.That(flangeClass.Text.Contains("Class 1", StringComparison.InvariantCulture));
            Assert.That(Aeff.Text.Contains("53.8", StringComparison.InvariantCulture));
            Assert.That(NcRd.Text.Replace(",", string.Empty).Contains("1479", StringComparison.InvariantCulture));
        }
    }
}
