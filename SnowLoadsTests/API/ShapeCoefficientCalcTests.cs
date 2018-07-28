using NUnit.Framework;
using SnowLoads.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowLoads.API.Tests
{
    [TestFixture()]
    public class ShapeCoefficientCalcTests
    {
        #region CalculateSnowLoadShapeCoefficient1

        [Test()]
        [Description("Ensure that calculation for shape coefficient is proper.")]
        public void CalculateSnowLoadShapeCoefficient1Test_LessThan30DegreeWithoutFences_Success()
        {
            double slope = 25;
            double result = ShapeCoefficientCalc.CalculateSnowLoadShapeCoefficient1(slope);

            Assert.AreEqual(0.8, result, $"Something go wrong with shape coefficient calculation. Slope {slope}degree.");
        }

        [Test()]
        [Description("Ensure that calculation for shape coefficient is proper.")]
        public void CalculateSnowLoadShapeCoefficient1Test_LessThan60DegreeWithoutFences_Success()
        {
            double slope = 50;
            double result = ShapeCoefficientCalc.CalculateSnowLoadShapeCoefficient1(slope);

            Assert.AreEqual(0.266667, result, 0.001, $"Something go wrong with shape coefficient calculation. Slope {slope}degree.");
        }

        [Test()]
        [Description("Ensure that calculation for shape coefficient is proper.")]
        public void CalculateSnowLoadShapeCoefficient1Test_MoreThan60DegreeWithoutFences_Success()
        {
            double slope = 80;
            double result = ShapeCoefficientCalc.CalculateSnowLoadShapeCoefficient1(slope);

            Assert.AreEqual(0, result, $"Something go wrong with shape coefficient calculation. Slope {slope}degree.");
        }

        [Test()]
        [Description("Ensure that calculation for shape coefficient is proper.")]
        public void CalculateSnowLoadShapeCoefficient1Test_MoreThan60DegreeWithFences_Success()
        {
            double slope = 80;
            bool snowFences = true;
            double result = ShapeCoefficientCalc.CalculateSnowLoadShapeCoefficient1(slope, snowFences);

            Assert.AreEqual(0.8, result, $"Something go wrong with shape coefficient calculation. Slope {slope}degree. Fences: {snowFences}.");
        }

        [Test()]
        [Description("Ensure that calculation for shape coefficient is proper.")]
        public void CalculateSnowLoadShapeCoefficient1Test_LessThan0DegreeWithoutFences_Exception()
        {
            double slope = -50;

            Assert.Throws<ArgumentOutOfRangeException>(() => ShapeCoefficientCalc.CalculateSnowLoadShapeCoefficient1(slope), "Method shouldn't work for this specific example.");
        }

        [Test()]
        [Description("Ensure that calculation for shape coefficient is proper.")]
        public void CalculateSnowLoadShapeCoefficient1Test_LessThan0DegreeWithFences_Exception()
        {
            double slope = -50;
            bool snowFences = true;

            Assert.Throws<ArgumentOutOfRangeException>(() => ShapeCoefficientCalc.CalculateSnowLoadShapeCoefficient1(slope, snowFences), "Method shouldn't work for this specific example.");
        }

        #endregion // CalculateSnowLoadShapeCoefficient1

        #region CalculateSnowLoadShapeCoefficient2

        [Test]
        [Description("Ensure that calculation for shape coefficient is proper.")]
        public void CalculateSnowLoadShapeCoefficient2Test_LessThan30Degree_Success()
        {
            double slope = 20;

            double result = ShapeCoefficientCalc.CalculateSnowLoadShapeCoefficient2(slope);

            Assert.AreEqual(1.33334, result, 0.001, "Something go wrong with shape coefficient calculation. Slope {slope}degree.");
        }

        [Test]
        [Description("Ensure that calculation for shape coefficient is proper.")]
        public void CalculateSnowLoadShapeCoefficient2Test_LessThan60Degree_Success()
        {
            double slope = 50;

            double result = ShapeCoefficientCalc.CalculateSnowLoadShapeCoefficient2(slope);

            Assert.AreEqual(1.6, result, "Something go wrong with shape coefficient calculation. Slope {slope}degree.");
        }

        [Test]
        [Description("Ensure that calculation for shape coefficient is proper.")]
        public void CalculateSnowLoadShapeCoefficient2Test_MoreThan60Degree_Success()
        {
            double slope = 70;

            double result = ShapeCoefficientCalc.CalculateSnowLoadShapeCoefficient2(slope);

            Assert.AreEqual(1.6, result, "Something go wrong with shape coefficient calculation. Slope {slope}degree.");
        }

        [Test]
        [Description("Ensure that calculation for shape coefficient is proper.")]
        public void CalculateSnowLoadShapeCoefficient2Test_LessThan0Degree_Success()
        {
            double slope = -20;

            Assert.Throws<ArgumentOutOfRangeException>(() => ShapeCoefficientCalc.CalculateSnowLoadShapeCoefficient2(slope), "Method shouldn't work for this specific example.");
        }

        #endregion // CalculateSnowLoadShapeCoefficient2
    }
}