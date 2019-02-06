using Build_IT_BeamStatica.Sections;
using NUnit.Framework;

namespace Build_IT_BeamStaticaTests.UnitTests.Sections
{
    [TestFixture()]
    public class RectangleSectionTests
    {
        private Section _rectangleSection;

        [SetUp()]
        public void SetUpIBeamSection()
        {
            _rectangleSection = new RectangleSection(
                width: 100, height: 250);
        }

        [Test()]
        public void RectangleSection_CalculatedCircumferenceTest_Success()
        {
            Assert.That(_rectangleSection.Circumference, Is.EqualTo(70).Within(0.001));
        }

        [Test()]
        public void RectangleSection_CalculatedAreaTest_Success()
        {
            Assert.That(_rectangleSection.Area, Is.EqualTo(250).Within(0.001));
        }

        [Test()]
        public void RectangleSection_CalculatedCentroidTest_Success()
        {
            Assert.That(_rectangleSection.Centroid.X, Is.EqualTo(50));
            Assert.That(_rectangleSection.Centroid.Y, Is.EqualTo(125));
        }

        [Test()]
        public void RectangleSection_AdjustedPointsTest_Success()
        {
            Assert.That(_rectangleSection.AdjustedPoints[0].X, Is.EqualTo(-50), message: "0X");
            Assert.That(_rectangleSection.AdjustedPoints[0].Y, Is.EqualTo(-125), message: "0Y");
            Assert.That(_rectangleSection.AdjustedPoints[1].X, Is.EqualTo(50), message: "1X");
            Assert.That(_rectangleSection.AdjustedPoints[1].Y, Is.EqualTo(-125), message: "1Y");
            Assert.That(_rectangleSection.AdjustedPoints[2].X, Is.EqualTo(50), message: "2X");
            Assert.That(_rectangleSection.AdjustedPoints[2].Y, Is.EqualTo(125), message: "2Y");
            Assert.That(_rectangleSection.AdjustedPoints[3].X, Is.EqualTo(-50).Within(0.0001), message: "3X");
            Assert.That(_rectangleSection.AdjustedPoints[3].Y, Is.EqualTo(125), message: "3Y");
           }

        [Test()]
        public void RectangleSection_CalculatedMomentOfInteriaTest_Success()
        {
            Assert.That(_rectangleSection.MomentOfInteria, Is.EqualTo(13020.833).Within(0.001));
        }

        [Test()]
        public void RectangleSection_CalculatedSolidHeightTest_Success()
        {
            Assert.That(_rectangleSection.SolidHeight, Is.EqualTo(250));
        }
    }
}
