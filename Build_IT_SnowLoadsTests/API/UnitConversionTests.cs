using Build_IT_SnowLoads.API;
using NUnit.Framework;

namespace Build_IT_SnowLoadsTests.API
{
    [TestFixture()]
    public class UnitConversionTests
    {
        [Test()]
        [Description("Ensure that conversion from percentage to degrees is proper.")]
        public void ConvertPercentageToDegreeTest_40Percent_Success()
        {
            double percent = 40;
            double result = UnitConversion.ConvertToDegrees(percent);
            Assert.AreEqual(21.801, result, 0.001, $"There is something wrong with conversion of {percent}% into degrees.");
        }

        [Test()]
        [Description("Ensure that conversion to radians is proper.")]
        public void ConvertToRadiansTest_90Degrees_Success()
        {
            double degrees = 90;
            double result = UnitConversion.ConvertToRadians(degrees);

            Assert.AreEqual(90 * 3.1415 / 180, result, 0.001, $"There is something wrong with conversion of {degrees}degree into radians.");
        }
    }
}