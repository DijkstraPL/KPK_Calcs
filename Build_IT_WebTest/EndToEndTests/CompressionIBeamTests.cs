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
    [Explicit("End To End")]
    public class CompressionIBeamTests
    {
        private const string _chromeDriver = @"C:\KPK_Calcs\Build_IT_WebTest\bin\Debug\netcoreapp3.0";
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

            fy = _driver.FindElement(By.ClassName("f_y_"));
            expansionPanel = _driver.FindElement(By.Id("mat-expansion-panel-header-0"));
            h = _driver.FindElement(By.ClassName("h"));
            b = _driver.FindElement(By.ClassName("b"));
            tf = _driver.FindElement(By.ClassName("t_f_"));
            tw = _driver.FindElement(By.ClassName("t_w_"));
            rolled = _driver.FindElement(By.ClassName("Rolled"));
            welded = _driver.FindElement(By.ClassName("Welded"));
            r = _driver.FindElement(By.ClassName("r"));

            _calculateButton = _driver.FindElement(By.ClassName("calculate"));

            A_Selector = "A";
            ε_Selector = "ε";
            webClass_Selector = "WebClass";
            cweb_Selector = "c_web_";
            cflange_Selector = "c_flange_";
            flangeClass_Selector = "FlangeClass";
            Aeff_Selector = "A_eff_";
            NcRd_Selector = @"N_c\,Rd_";
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void CalculateTest_Sample1_5_Success()
        {
            fy.SendKeys("275");
            if (expansionPanel.GetAttribute("aria-expanded") != "true")
                expansionPanel.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => h);

            h.SendKeys("300");
            b.SendKeys("150");
            tf.SendKeys("10,7");
            tw.SendKeys("7,1");
            rolled.Click();
            r.SendKeys("15");

            _calculateButton.Click();

            wait.Until(d => d.FindElement(By.ClassName(A_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(ε_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(cweb_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(cflange_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(webClass_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(flangeClass_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(Aeff_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(NcRd_Selector)));

            var A = _driver.FindElement(By.ClassName(A_Selector));
            var ε = _driver.FindElement(By.ClassName(ε_Selector));
            var cweb = _driver.FindElement(By.ClassName(cweb_Selector));
            var cflange = _driver.FindElement(By.ClassName(cflange_Selector));
            var webClass = _driver.FindElement(By.ClassName(webClass_Selector));
            var flangeClass = _driver.FindElement(By.ClassName(flangeClass_Selector));
            var Aeff = _driver.FindElement(By.ClassName(Aeff_Selector));
            var NcRd = _driver.FindElement(By.ClassName(NcRd_Selector));

            Assert.That(A.Text.Contains("53.8", StringComparison.InvariantCulture));
            Assert.That(ε.Text.Contains("0.92", StringComparison.InvariantCulture));
            Assert.That(webClass.Text.Contains("Class 2", StringComparison.InvariantCulture));
            Assert.That(flangeClass.Text.Contains("Class 1", StringComparison.InvariantCulture));
            Assert.That(Aeff.Text.Contains("53.8", StringComparison.InvariantCulture));
            Assert.That(NcRd.Text.Replace(",", string.Empty).Contains("1479", StringComparison.InvariantCulture));
        }

        [Test]
        public void CalculateTest_Sample1_7_Success()
        {
            var kσweb_Selector = @"k_σ\,web_";
            var λpweb_Selector = @"λ_p\,web_";
            var ρweb_Selector = @"ρ_web_";
            var beffweb_Selector = @"b_eff\,web_";

            fy.SendKeys("355");
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
            wait.Until(d => d.FindElement(By.ClassName(A_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(ε_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(cweb_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(cflange_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(webClass_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(flangeClass_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(kσweb_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(λpweb_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(ρweb_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(beffweb_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(Aeff_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(NcRd_Selector)));

            var A = _driver.FindElement(By.ClassName(A_Selector));
            var ε = _driver.FindElement(By.ClassName(ε_Selector));
            var cweb = _driver.FindElement(By.ClassName(cweb_Selector));
            var cflange = _driver.FindElement(By.ClassName(cflange_Selector));
            var webClass = _driver.FindElement(By.ClassName(webClass_Selector));
            var flangeClass = _driver.FindElement(By.ClassName(flangeClass_Selector));
            var kσweb = _driver.FindElement(By.ClassName(kσweb_Selector));
            var λpweb = _driver.FindElement(By.ClassName(λpweb_Selector));
            var ρweb = _driver.FindElement(By.ClassName(ρweb_Selector));
            var beffweb = _driver.FindElement(By.ClassName(beffweb_Selector));
            var Aeff = _driver.FindElement(By.ClassName(Aeff_Selector));
            var NcRd = _driver.FindElement(By.ClassName(NcRd_Selector));

            Assert.That(A.Text.Contains("53.8", StringComparison.InvariantCulture));
            Assert.That(ε.Text.Contains("0.81", StringComparison.InvariantCulture));
            Assert.That(webClass.Text.Contains("Class 4", StringComparison.InvariantCulture));
            Assert.That(flangeClass.Text.Contains("Class 1", StringComparison.InvariantCulture));
            Assert.That(Aeff.Text.Contains("52.6", StringComparison.InvariantCulture));
            Assert.That(kσweb.Text.Contains("4", StringComparison.InvariantCulture));
            Assert.That(λpweb.Text.Contains("0.758", StringComparison.InvariantCulture));
            Assert.That(ρweb.Text.Contains("0.937", StringComparison.InvariantCulture));
            Assert.That(beffweb.Text.Contains("232.8", StringComparison.InvariantCulture));
            Assert.That(NcRd.Text.Replace(",", string.Empty).Contains("1870", StringComparison.InvariantCulture));
        }
               
        [Test]
        public void CalculateTest_Sample1_8_Success()
        {
            var kσweb_Selector = @"k_σ\,web_";
            var λpweb_Selector = @"λ_p\,web_";
            var ρweb_Selector = @"ρ_web_";
            var beffweb_Selector = @"b_eff\,web_";

            fy.SendKeys("355");
            if (expansionPanel.GetAttribute("aria-expanded") != "true")
                expansionPanel.Click();
            h.SendKeys("424");
            b.SendKeys("300");
            tf.SendKeys("12");
            tw.SendKeys("8");
            welded.Click();
            var a = _driver.FindElement(By.ClassName("a"));
            a.SendKeys("5");

            _calculateButton.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.ClassName(A_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(ε_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(cweb_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(cflange_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(webClass_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(flangeClass_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(kσweb_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(λpweb_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(ρweb_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(beffweb_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(Aeff_Selector)));
            wait.Until(d => d.FindElement(By.ClassName(NcRd_Selector)));

            var A = _driver.FindElement(By.ClassName(A_Selector));
            var ε = _driver.FindElement(By.ClassName(ε_Selector));
            var cweb = _driver.FindElement(By.ClassName(cweb_Selector));
            var cflange = _driver.FindElement(By.ClassName(cflange_Selector));
            var webClass = _driver.FindElement(By.ClassName(webClass_Selector));
            var flangeClass = _driver.FindElement(By.ClassName(flangeClass_Selector));
            var kσweb = _driver.FindElement(By.ClassName(kσweb_Selector));
            var kσflange = _driver.FindElement(By.ClassName(@"k_σ\,flange_"));
            var λpweb = _driver.FindElement(By.ClassName(λpweb_Selector));
            var λpflange= _driver.FindElement(By.ClassName(@"λ_p\,flange_"));
            var ρweb = _driver.FindElement(By.ClassName(ρweb_Selector));
            var ρflange = _driver.FindElement(By.ClassName("ρ_flange_"));
            var beffweb = _driver.FindElement(By.ClassName(beffweb_Selector));
            var beffflange = _driver.FindElement(By.ClassName(@"b_eff\,flange_"));
            var Aeff = _driver.FindElement(By.ClassName(Aeff_Selector));
            var NcRd = _driver.FindElement(By.ClassName(NcRd_Selector));

            Assert.That(A.Text.Contains("104", StringComparison.InvariantCulture));
            Assert.That(ε.Text.Contains("0.81", StringComparison.InvariantCulture));
            Assert.That(webClass.Text.Contains("Class 4", StringComparison.InvariantCulture));
            Assert.That(flangeClass.Text.Contains("Class 4", StringComparison.InvariantCulture));
            Assert.That(kσweb.Text.Contains("4", StringComparison.InvariantCulture));
            Assert.That(λpweb.Text.Contains("1.04", StringComparison.InvariantCulture));
            Assert.That(ρweb.Text.Contains("0.756", StringComparison.InvariantCulture));
            Assert.That(beffweb.Text.Contains("291", StringComparison.InvariantCulture));
            Assert.That(kσflange.Text.Contains("0.43", StringComparison.InvariantCulture));
            Assert.That(λpflange.Text.Contains("0.76", StringComparison.InvariantCulture));
            Assert.That(ρflange.Text.Contains("0.98", StringComparison.InvariantCulture));
            Assert.That(beffflange.Text.Contains("137", StringComparison.InvariantCulture));
            Assert.That(Aeff.Text.Contains("96", StringComparison.InvariantCulture));
            Assert.That(NcRd.Text.Replace(",", string.Empty).Contains("3422", StringComparison.InvariantCulture));
        }
    }
}
