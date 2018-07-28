using NUnit.Framework;
using SnowLoads.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.API.Tests
{
    [TestFixture]
    public class ConditionCheckerTests
    {
        #region ForDesignSituationTest

        [Test]
        [Description("Check if conditions are proper for design situation to be use.")]
        public void ForDesignSituationTest_SituationA_NotExceptional_NotAnnexB_Success()
        {
            bool result = ConditionChecker.ForDesignSituation(false, DesignSituation.A, false);
            Assert.IsTrue(result, "Conditions checking is wrong");
        }

        [Test]
        [Description("Check if conditions are proper for design situation to be use.")]
        public void ForDesignSituationTest_SituationB1_Exceptional_NotAnnexB_Success()
        {
            bool result = ConditionChecker.ForDesignSituation(true, DesignSituation.B1, false);
            Assert.IsTrue(result, "Conditions checking is wrong");
        }

        [Test]
        [Description("Check if conditions are proper for design situation to be use.")]
        public void ForDesignSituationTest_SituationB1_Exceptional_Success()
        {
            bool result = ConditionChecker.ForDesignSituation(false, DesignSituation.B3, true);
            Assert.IsFalse(result, "Conditions checking is wrong");
        }

        #endregion // ForDesignSituationTest
    }
}