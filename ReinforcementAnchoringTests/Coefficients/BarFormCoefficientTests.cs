using NUnit.Framework;
using ReinforcementAnchoring.Coefficients;
using ReinforcementAnchoringTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementAnchoring.Coefficients.Tests
{
    [TestFixture()]
    public class BarFormCoefficientTests
    {
        [Test()]
        [Description("Check constructor for the BarFormCoefficient.")]
        public void BarFormCoefficientTest_Constructor_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();
            var bar = new Bar(12);

            var barFormCoefficient = new BarFormCoefficient(reinforcementPosition, bar);

            Assert.IsNotNull(barFormCoefficient, "BarFormCoefficient should be created.");
            Assert.IsNotNull(barFormCoefficient.ReinforcementPosition,
                "ReinforcementPosition should be set at construction time.");
            Assert.IsNotNull(barFormCoefficient.Bar,
                "Bar should be set at construction time.");
        }

        [Test()]
        [Description("Check calculation for the BarFormCoefficient.")]
        public void BarFormCoefficientTest_Calculate_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();
            var bar = new Bar(10);

            var barFormCoefficient = new BarFormCoefficient(reinforcementPosition, bar);

            barFormCoefficient.Calculate();

            Assert.AreEqual(0.7, Math.Round(barFormCoefficient.Coefficient, 3), "Coefficient not calculated properly.");
        }
    }
}