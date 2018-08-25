using NUnit.Framework;
using ReinforcementAnchoringTests;
using System;

namespace ReinforcementAnchoring.Coefficients.Tests
{
    [TestFixture()]
    public class TransverseReinforcementCoefficientTests
    {
        [Test()]
        [Description("Check constructor for the TransverseReinforcementCoefficient.")]
        public void TransverseReinforcementCoefficientTest_Constructor_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();
            var bar =  new Bar(12);

            var transverseReinforcementCoefficient = new TransverseReinforcementCoefficient(
                reinforcementPosition, bar, TypeEnum.Beam, 10);

            Assert.IsNotNull(transverseReinforcementCoefficient, "TransverseReinforcementCoefficient should be created.");
            Assert.IsNotNull(transverseReinforcementCoefficient.ReinforcementPosition,
                "ReinforcementPosition should be set at construction time.");
            Assert.IsNotNull(transverseReinforcementCoefficient.Bar,
                "Bar should be set at construction time.");
            Assert.AreEqual(TypeEnum.Beam, transverseReinforcementCoefficient.Type,
                "Type should be set at construction time.");
            Assert.AreEqual(10, transverseReinforcementCoefficient.TransverseReinforcementArea,
                "TransverseReinforcementArea should be set at construction time.");
        }

        [Test()]
        [Description("Check calculation for the TransverseReinforcementCoefficient.")]
        public void TransverseReinforcementCoefficientTest_Calculate_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();
            var bar = new Bar(12);

            var transverseReinforcementCoefficient = new TransverseReinforcementCoefficient(
                reinforcementPosition, bar, TypeEnum.Beam, 5);

            transverseReinforcementCoefficient.Calculate();

            Assert.AreEqual(0.791, Math.Round(transverseReinforcementCoefficient.Coefficient, 3),
                "Coefficient not calculated properly.");
        }
    }
}