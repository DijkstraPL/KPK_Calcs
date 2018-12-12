using BeamStatica.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BeamStatica.Sections.Additional;
using BeamStatica.Sections.Additional.Interfaces;

namespace BeamStatica.Sections.Tests
{
    [TestFixture()]
    public class PolygonSection1Tests
    {
        private Section _polygonSection;

        [SetUp()]
        public void SetUpPolygonSection()
        {
            var points = new List<IPoint>();
            points.Add(new Point(0, 0));
            points.Add(new Point(200, 0));
            points.Add(new Point(200, 300));
            points.Add(new Point(0, 300));
            _polygonSection = new Section(points);
        }

        [Test()]
        public void PolygonSection_CalculatedCircumferenceTest_Success()
        {
            Assert.That(_polygonSection.Circumference, Is.EqualTo(100));
        }

        [Test()]
        public void PolygonSection_CalculatedAreaTest_Success()
        {
            Assert.That(_polygonSection.Area, Is.EqualTo(600));
        }

        [Test()]
        public void PolygonSection_CalculatedCentroidTest_Success()
        {
            Assert.That(_polygonSection.Centroid.X, Is.EqualTo(100));
            Assert.That(_polygonSection.Centroid.Y, Is.EqualTo(150));
        }

        [Test()]
        public void PolygonSection_AdjustedPointsTest_Success()
        {
            Assert.That(_polygonSection.AdjustedPoints[0].X, Is.EqualTo(-100));
            Assert.That(_polygonSection.AdjustedPoints[0].Y, Is.EqualTo(-150));
            Assert.That(_polygonSection.AdjustedPoints[1].X, Is.EqualTo(100));
            Assert.That(_polygonSection.AdjustedPoints[1].Y, Is.EqualTo(-150));
            Assert.That(_polygonSection.AdjustedPoints[2].X, Is.EqualTo(100));
            Assert.That(_polygonSection.AdjustedPoints[2].Y, Is.EqualTo(150));
            Assert.That(_polygonSection.AdjustedPoints[3].X, Is.EqualTo(-100));
            Assert.That(_polygonSection.AdjustedPoints[3].Y, Is.EqualTo(150));
        }

        [Test()]
        public void PolygonSection_CalculatedMomentOfInteriaTest_Success()
        {
            Assert.That(_polygonSection.MomentOfInteria, Is.EqualTo(45000));
        }

    }
}