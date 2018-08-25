using NUnit.Framework;
using ReinforcementAnchoringTests;
using System;

namespace ReinforcementAnchoring.Coefficients.Tests
{
    [TestFixture()]
    public class CoverCoefficientTests
    {
        [Test()]
        [Description("Check constructor for the CoverCoefficient.")]
        public void CoverCoefficientTest_Constructor_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();
            var bar = new Bar(12);

            var coverCoefficient = new CoverCoefficient(reinforcementPosition, bar);

            Assert.IsNotNull(coverCoefficient, "CoverCoefficient should be created.");
            Assert.IsNotNull(coverCoefficient.ReinforcementPosition,
                "ReinforcementPosition should be set at construction time.");
            Assert.IsNotNull(coverCoefficient.Bar,
                "Bar should be set at construction time.");
        }

        [Test()]
        [Description("Check calculation for the CoverCoefficient.")]
        public void CoverCoefficientTest_Calculate_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();
            var bar = new Bar(10);

            var coverCoefficient = new CoverCoefficient(reinforcementPosition, bar);

            coverCoefficient.Calculate();

            Assert.AreEqual(0.925, Math.Round(coverCoefficient.Coefficient, 3), "Coefficient not calculated properly.");
        }
    }
}