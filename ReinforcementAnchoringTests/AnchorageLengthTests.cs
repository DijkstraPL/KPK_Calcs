using NUnit.Framework;
using ReinforcementAnchoring;
using ReinforcementAnchoring.Coefficients;
using ReinforcementAnchoring.Interfaces;
using ReinforcementAnchoringTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementAnchoring.Tests
{
    [TestFixture()]
    public class AnchorageLengthTests
    {
        [Test()]
        [Description("Check constructor for the AnchorageLength.")]
        public void AnchorageLengthTest_Constructor_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();
            var reinforcement = new Reinforcement(12, 500, false);

            var anchorageLength = new AnchorageLength(reinforcement, reinforcementPosition,
                ConcreteClassEnum.C25_30, TypeEnum.Beam, BondConditionEnum.Good, null);

            Assert.IsNotNull(anchorageLength, "AnchorageLength should be created.");
            Assert.IsNotNull(anchorageLength.ReinforcementPosition,
                "ReinforcementPosition should be set at construction time.");
            Assert.IsNotNull(anchorageLength.Reinforcement,
                "Reinforcement should be set at construction time.");
            Assert.AreEqual(ConcreteClassEnum.C25_30, anchorageLength.ConcreteClassName,
                "ConcreteClassName should be set at construction time.");
            Assert.AreEqual(TypeEnum.Beam, anchorageLength.Type,
                "Type should be set at construction time.");
            Assert.AreEqual(BondConditionEnum.Good, anchorageLength.BondCondition,
                "BondCondition should be set at construction time.");
        }

        [Test()]
        [Description("Check ConcreteClass base on ConcreteClassName.")]
        public void AnchorageLengthTest_ConcreteClassProperty_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();
            var reinforcement = new Reinforcement(12, 500, false);

            var anchorageLength = new AnchorageLength(reinforcement, reinforcementPosition,
                ConcreteClassEnum.C25_30, TypeEnum.Beam, BondConditionEnum.Good, null);

            Assert.IsNotNull(anchorageLength.ConcreteClass, "ConcreteClass should be created.");
            Assert.AreEqual(ConcreteClassEnum.C25_30, anchorageLength.ConcreteClass.ClassOfConcrete,
                "ClassOfConcrete should be set at construction time.");
        }

        [Test()]
        [Description("Check calculation for the AnchorageLength without coefficients.")]
        public void AnchorageLengthTest_CalculateWithoutCoefficients_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();
            var reinforcement = new Reinforcement(12, 500, false);

            var anchorageLength = new AnchorageLength(reinforcement, reinforcementPosition,
                ConcreteClassEnum.C25_30, TypeEnum.Beam, BondConditionEnum.Good, null);

            anchorageLength.CalculateAnchorageLengths();

            Assert.AreEqual(450.886, Math.Round(anchorageLength.BasicRequiredAnchorageLength, 3),
                "BasicRequiredAnchorageLength not calculated properly.");
            Assert.AreEqual(135.266, Math.Round(anchorageLength.MinimumAnchorageLength, 3),
                "MinimumAnchorageLength not calculated properly.");
            Assert.AreEqual(450.886, Math.Round(anchorageLength.DesignAnchorageLength, 3),
                "DesignAnchorageLength not calculated properly.");
        }

        [Test()]
        [Description("Check calculation for the AnchorageLength with BarFormCoefficient.")]
        public void AnchorageLengthTest_CalculateWithBarFormCoefficient_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();
            var reinforcement = new Reinforcement(10, 500, false);

            var barFormCoefficient = new BarFormCoefficient(reinforcementPosition, reinforcement);

            var coefficients = new List<ICoefficient>();
            coefficients.Add(barFormCoefficient);

            var anchorageLength = new AnchorageLength(reinforcement, reinforcementPosition,
                ConcreteClassEnum.C25_30, TypeEnum.Beam, BondConditionEnum.Good, coefficients);

            anchorageLength.CalculateAnchorageLengths();

            Assert.AreEqual(375.738, Math.Round(anchorageLength.BasicRequiredAnchorageLength, 3),
                "BasicRequiredAnchorageLength not calculated properly.");
            Assert.AreEqual(112.721, Math.Round(anchorageLength.MinimumAnchorageLength, 3),
                "MinimumAnchorageLength not calculated properly.");
            Assert.AreEqual(263.017, Math.Round(anchorageLength.DesignAnchorageLength, 3),
                "DesignAnchorageLength not calculated properly.");
        }

        [Test()]
        [Description("Check calculation for the AnchorageLength with CoverCoefficient.")]
        public void AnchorageLengthTest_CalculateWithCoverCoefficient_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();
            var reinforcement = new Reinforcement(10, 500, false);

            var coverCoefficient = new CoverCoefficient(reinforcementPosition, reinforcement);

            var coefficients = new List<ICoefficient>();
            coefficients.Add(coverCoefficient);

            var anchorageLength = new AnchorageLength(reinforcement, reinforcementPosition,
                ConcreteClassEnum.C25_30, TypeEnum.Beam, BondConditionEnum.Good, coefficients);

            anchorageLength.CalculateAnchorageLengths();

            Assert.AreEqual(375.738, Math.Round(anchorageLength.BasicRequiredAnchorageLength, 3),
                "BasicRequiredAnchorageLength not calculated properly.");
            Assert.AreEqual(112.721, Math.Round(anchorageLength.MinimumAnchorageLength, 3),
                "MinimumAnchorageLength not calculated properly.");
            Assert.AreEqual(347.558, Math.Round(anchorageLength.DesignAnchorageLength, 3),
                "DesignAnchorageLength not calculated properly.");
        }

        [Test()]
        [Description("Check calculation for the AnchorageLength with TransversePressureCoefficient.")]
        public void AnchorageLengthTest_CalculateWithTransversePressureCoefficient_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();
            var reinforcement = new Reinforcement(10, 500, false);

            var transversePressureCoefficient = new TransversePressureCoefficient(reinforcementPosition, 5);

            var coefficients = new List<ICoefficient>();
            coefficients.Add(transversePressureCoefficient);

            var anchorageLength = new AnchorageLength(reinforcement, reinforcementPosition,
                ConcreteClassEnum.C25_30, TypeEnum.Beam, BondConditionEnum.Good, coefficients);

            anchorageLength.CalculateAnchorageLengths();

            Assert.AreEqual(375.738, Math.Round(anchorageLength.BasicRequiredAnchorageLength, 3),
                "BasicRequiredAnchorageLength not calculated properly.");
            Assert.AreEqual(112.721, Math.Round(anchorageLength.MinimumAnchorageLength, 3),
                "MinimumAnchorageLength not calculated properly.");
            Assert.AreEqual(300.590, Math.Round(anchorageLength.DesignAnchorageLength, 3),
                "DesignAnchorageLength not calculated properly.");
        }

        [Test()]
        [Description("Check calculation for the AnchorageLength with TransverseReinforcementCoefficient.")]
        public void AnchorageLengthTest_CalculateWithTransverseReinforcementCoefficient_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();
            var reinforcement = new Reinforcement(10, 500, false);

            var transverseReinforcementCoefficient =
                new TransverseReinforcementCoefficient(reinforcementPosition, reinforcement, TypeEnum.Beam, 5);

            var coefficients = new List<ICoefficient>();
            coefficients.Add(transverseReinforcementCoefficient);

            var anchorageLength = new AnchorageLength(reinforcement, reinforcementPosition,
                ConcreteClassEnum.C25_30, TypeEnum.Beam, BondConditionEnum.Good, coefficients);

            anchorageLength.CalculateAnchorageLengths();

            Assert.AreEqual(375.738, Math.Round(anchorageLength.BasicRequiredAnchorageLength, 3),
                "BasicRequiredAnchorageLength not calculated properly.");
            Assert.AreEqual(112.721, Math.Round(anchorageLength.MinimumAnchorageLength, 3),
                "MinimumAnchorageLength not calculated properly.");
            Assert.AreEqual(263.017, Math.Round(anchorageLength.DesignAnchorageLength, 3),
                "DesignAnchorageLength not calculated properly.");
        }

        [Test()]
        [Description("Check calculation for the AnchorageLength with WeldedTransverseBarCoefficient.")]
        public void AnchorageLengthTest_CalculateWithWeldedTransverseBarCoefficient_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();
            var reinforcement = new Reinforcement(10, 500, false);

            var weldedTransverseBarCoefficient = new WeldedTransverseBarCoefficient();

            var coefficients = new List<ICoefficient>();
            coefficients.Add(weldedTransverseBarCoefficient);

            var anchorageLength = new AnchorageLength(reinforcement, reinforcementPosition,
                ConcreteClassEnum.C25_30, TypeEnum.Beam, BondConditionEnum.Good, coefficients);

            anchorageLength.CalculateAnchorageLengths();

            Assert.AreEqual(375.738, Math.Round(anchorageLength.BasicRequiredAnchorageLength, 3),
                "BasicRequiredAnchorageLength not calculated properly.");
            Assert.AreEqual(112.721, Math.Round(anchorageLength.MinimumAnchorageLength, 3),
                "MinimumAnchorageLength not calculated properly.");
            Assert.AreEqual(263.017, Math.Round(anchorageLength.DesignAnchorageLength, 3),
                "DesignAnchorageLength not calculated properly.");
        }

        [Test()]
        [Description("Check calculation for the AnchorageLength with MultipleCoefficients.")]
        public void AnchorageLengthTest_CalculateWithMultipleCoefficients_Success()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();
            var reinforcement = new Reinforcement(10, 500, false);

            var barFormCoefficient = new BarFormCoefficient(reinforcementPosition, reinforcement);
            var coverCoefficient = new CoverCoefficient(reinforcementPosition, reinforcement);
            var transversePressureCoefficient = new TransversePressureCoefficient(reinforcementPosition, 5);
            var transverseReinforcementCoefficient =
                new TransverseReinforcementCoefficient(reinforcementPosition, reinforcement, TypeEnum.Beam, 5);
            var weldedTransverseBarCoefficient = new WeldedTransverseBarCoefficient();

            var coefficients = new List<ICoefficient>();
            coefficients.Add(barFormCoefficient);
            coefficients.Add(coverCoefficient);
            coefficients.Add(transversePressureCoefficient);
            coefficients.Add(transverseReinforcementCoefficient);
            coefficients.Add(weldedTransverseBarCoefficient);

            var anchorageLength = new AnchorageLength(reinforcement, reinforcementPosition,
                ConcreteClassEnum.C25_30, TypeEnum.Beam, BondConditionEnum.Good, coefficients);

            anchorageLength.CalculateAnchorageLengths();

            Assert.AreEqual(375.738, Math.Round(anchorageLength.BasicRequiredAnchorageLength, 3),
                "BasicRequiredAnchorageLength not calculated properly.");
            Assert.AreEqual(112.721, Math.Round(anchorageLength.MinimumAnchorageLength, 3),
                "MinimumAnchorageLength not calculated properly.");
            Assert.AreEqual(128.878, Math.Round(anchorageLength.DesignAnchorageLength, 3),
                "DesignAnchorageLength not calculated properly.");
        }

        [Test()]
        [Description("Check calculation for the AnchorageLength with SameCoefficients.")]
        public void AnchorageLengthTest_CalculateWithSameoefficients_Exception()
        {
            var reinforcementPosition = AnchoringHelper.CreateReinforcementPosition();
            var reinforcement = new Reinforcement(10, 500, false);

            var barFormCoefficient = new BarFormCoefficient(reinforcementPosition, reinforcement);

            var coefficients = new List<ICoefficient>();
            coefficients.Add(barFormCoefficient);
            coefficients.Add(barFormCoefficient);

            var anchorageLength = new AnchorageLength(reinforcement, reinforcementPosition,
                ConcreteClassEnum.C25_30, TypeEnum.Beam, BondConditionEnum.Good, coefficients);

            Assert.Throws<ArgumentException>(() => anchorageLength.CalculateAnchorageLengths(),
                "More than one coefficient type should throw ArgumentException.");
        }
    }
}