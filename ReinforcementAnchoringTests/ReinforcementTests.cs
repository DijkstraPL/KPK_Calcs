using NUnit.Framework;
using System;

namespace ReinforcementAnchoring.Tests
{
    [TestFixture()]
    public class ReinforcementTests
    {
        [Test()]
        [Description("Check constructor for the Reinforcement.")]
        public void ReinforcementTest_Constructor_Success()
        {
            var reinforcement = new Reinforcement(12, 500, false);

            Assert.IsNotNull(reinforcement, "Reinforcement should be created.");
            Assert.AreEqual(12, reinforcement.Diameter, 
                "Diameter should be set at construction time.");
            Assert.AreEqual(500, reinforcement.PressInReinforcement,
                "Press in reinforcement should be set at construction time.");
            Assert.IsFalse( reinforcement.IsPairOfBars,
                "Bars in pair boolean should be set at construction time.");
        }

        [Test()]
        [Description("Check calculation for the DesignPressInReinforcement.")]
        public void DesignPressInReinforcementTest_Property_Success()
        {
            var reinforcement = new Reinforcement(12, 500, false);

            Assert.AreEqual(434.783, Math.Round(reinforcement.DesignPressInReinforcement,3),
                "DesignPressInReinforcement not calculated properly.");
        }

        [Test()]
        [Description("Check calculation for the DesignPressInReinforcement.")]
        public void AreaTest_Property_Success()
        {
            var reinforcement = new Reinforcement(12, 500, false);

            Assert.AreEqual(1.131, Math.Round(reinforcement.Area, 3),
                "DesignPressInReinforcement not calculated properly.");
        }
    }
}