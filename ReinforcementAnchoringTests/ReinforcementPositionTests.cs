using NUnit.Framework;
using ReinforcementAnchoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementAnchoring.Tests
{
    [TestFixture()]
    public class ReinforcementPositionTests
    {
        [Test()]
        [Description("Check constructor for the ReinforcementPosition.")]
        public void ReinforcementPositionTest_Constructor_Success()
        {
            var reinforcementPosition = new ReinforcementPosition(
                false, AnchorageTypeEnum.Loop, 25, 20, 50, TransverseBarPositionEnum.InsideBend);

            Assert.IsNotNull(reinforcementPosition, "ReinforcementPosition should be created.");
            Assert.IsFalse(reinforcementPosition.AreAnchoragesInTension,
                "AreAnchoragesInTension property should be set at construction time.");
            Assert.AreEqual(AnchorageTypeEnum.Loop, reinforcementPosition.AnchorageType,
                "AnchorageType should be set at construction time.");
            Assert.AreEqual(25, reinforcementPosition.SideCoverDistance,
                "SideCoverDistance should be set at construction time.");
            Assert.AreEqual(20, reinforcementPosition.BottomCoverDistance,
                "BottomCoverDistance should be set at construction time.");
            Assert.AreEqual(50, reinforcementPosition.DistanceBetweenBars,
                "DistanceBetweenBars should be set at construction time.");
            Assert.AreEqual(TransverseBarPositionEnum.InsideBend, reinforcementPosition.TransverseBarPosition,
                "TransverseBarPosition should be set at construction time.");
        }
    }
}