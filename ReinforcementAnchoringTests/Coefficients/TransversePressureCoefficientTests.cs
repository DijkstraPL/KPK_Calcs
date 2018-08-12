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
    public class TransversePressureCoefficientTests
    {
        [Test()]
        [Description("Check constructor for the TransversePressureCoefficient.")]
        public void TransversePressureCoefficientTest_Constructor_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();

            var transversePressureCoefficient = new TransversePressureCoefficient(reinforcementPosition, 250);

            Assert.IsNotNull(transversePressureCoefficient, "TransversePressureCoefficient should be created.");
            Assert.IsNotNull(transversePressureCoefficient.ReinforcementPosition,
                "ReinforcementPosition should be set at construction time.");
            Assert.AreEqual(250, transversePressureCoefficient.TransversePressure,
                "TransversePressure should be set at construction time.");
        }

        [Test()]
        [Description("Check calculation for the TransversePressureCoefficient.")]
        public void CoverCoefficientTest_Calculate_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();

            var transversePressureCoefficient = new TransversePressureCoefficient(reinforcementPosition, 5);

            transversePressureCoefficient.Calculate();

            Assert.AreEqual(0.8, Math.Round(transversePressureCoefficient.Coefficient, 3),
                "Coefficient not calculated properly.");
        }
    }
}