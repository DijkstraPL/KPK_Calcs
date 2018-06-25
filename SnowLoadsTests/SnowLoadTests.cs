//using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnowLoads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SnowLoads.Tests
{
    [TestFixture()]
    public class SnowLoadTests
    {
        #region SnowDensity 

        [Test()]
        [Description("Ensure that user can only use proper values of the snwow load.")]
        public void SnowDensityTest_Value1_Success()
        {
            var snowLoad = new SnowLoad(new BuildingSite());
            snowLoad.SnowDensity = 1;

            Assert.AreEqual(1, snowLoad.SnowDensity, "Value is not equal to the entered one.");
        }

        [Test()]
        [Description("Ensure that user can only use proper values of the snwow load.")]
        public void SnowDensityTest_Value2_Success()
        {
            var snowLoad = new SnowLoad(new BuildingSite());
            snowLoad.SnowDensity = 2;

            Assert.AreEqual(2, snowLoad.SnowDensity, "Value is not equal to the entered one.");
        }

        [Test()]
        [Description("Ensure that user can only use proper values of the snwow load.")]
        public void SnowDensityTest_Value3_Success()
        {
            var snowLoad = new SnowLoad(new BuildingSite());
            snowLoad.SnowDensity = 3;

            Assert.AreEqual(3, snowLoad.SnowDensity, "Value is not equal to the entered one.");
        }

        [Test()]
        [Description("Ensure that user can only use proper values of the snwow load.")]
        public void SnowDensityTest_Value5_Exception()
        {
            var snowLoad = new SnowLoad(new BuildingSite());

            Assert.Throws<ArgumentOutOfRangeException>(() => snowLoad.SnowDensity = 5, "Snow load shouldn't be that much.");
        }
        #endregion // SnowDensity

        [Test()]
        public void SnowLoadTest()
        {
            var snowLoad = new SnowLoad(new BuildingSite());
                        
            Assert.IsTrue(snowLoad.BuildingSite != null);
        }

        [Test()]
        public void SetCharacteristicSnowLoadTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void SetVariationCoefficientTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void SetCharacteristicSnowLoadForSpecificReturnPeriodTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void SetExceptionalSnowLoadCoefficientTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void SetDesignExceptionalSnowLoadForSpecificReturnPeriodTest()
        {
            Assert.Fail();
        }
    }
}