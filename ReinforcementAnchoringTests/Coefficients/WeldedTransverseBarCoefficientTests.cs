using NUnit.Framework;
using System;

namespace ReinforcementAnchoring.Coefficients.Tests
{
    [TestFixture()]
    public class WeldedTransverseBarCoefficientTests
    {
        [Test()]
        [Description("Check calculation for the WeldedTransverseBarCoefficient.")]
        public void WeldedTransverseBarCoefficientTest_Calculate_Success()
        {
            var weldedTransverseBarCoefficient = new WeldedTransverseBarCoefficient();

            weldedTransverseBarCoefficient.Calculate();

            Assert.AreEqual(0.7, Math.Round(weldedTransverseBarCoefficient.Coefficient, 3),
                "Coefficient not calculated properly.");
        }
    }
}