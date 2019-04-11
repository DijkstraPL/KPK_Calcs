using Build_IT_SnowLoads.API;
using NUnit.Framework;

namespace Build_IT_SnowLoadsTests.API
{
    [TestFixture()]
    public class SnowLoadCalcTests
    {
        #region CalculateSnowLoad

        [Test]
        [Description("Ensure that calculation for snow load is proper.")]
        public void CalculateSnowLoadTest_Success()
        {
            double shapeCoefficient = 1.5;
            double exposureCoefficient = 1.2;
            double thermalCoefficient = 0.8;
            double snowLoad = 0.9;

            double result = SnowLoadCalc.CalculateSnowLoad(shapeCoefficient, exposureCoefficient, thermalCoefficient, snowLoad);

            Assert.AreEqual(1.296, result, "Something go wrong with calculation for snow load.");
        }

        #endregion // CalculateSnowLoad
    }
}