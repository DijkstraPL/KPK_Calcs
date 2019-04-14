using Build_IT_WindLoads;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_WindLoadsTests
{
    [TestFixture]
    public class WindLoadTests
    {
        [Test]
        public void ReferenceHeightsTest_SmallBuilding_Success()
        {
            var buildingSite = new Mock<IBuildingSite>();
            var building = new Mock<IBuilding>();
            building.Setup(b => b.Height).Returns(5);
            building.Setup(b => b.Width).Returns(10);
            building.Setup(b => b.Length).Returns(15);
            var windLoad = new WindLoad(buildingSite.Object, building.Object, buildingRotated: false);

            Assert.That(windLoad.GetReferenceHeightAt(0), Is.EqualTo(5));
            Assert.That(windLoad.GetReferenceHeightAt(2), Is.EqualTo(5));
            Assert.That(windLoad.GetReferenceHeightAt(5), Is.EqualTo(5));
        }

        [Test]
        public void ReferenceHeightsTest_MediumBuilding_Success()
        {
            var buildingSite = new Mock<IBuildingSite>();
            var building = new Mock<IBuilding>();
            building.Setup(b => b.Height).Returns(16);
            building.Setup(b => b.Width).Returns(10);
            building.Setup(b => b.Length).Returns(15);
            var windLoad = new WindLoad(buildingSite.Object, building.Object, buildingRotated: false);

            Assert.That(windLoad.GetReferenceHeightAt(0), Is.EqualTo(10));
            Assert.That(windLoad.GetReferenceHeightAt(10), Is.EqualTo(10));
            Assert.That(windLoad.GetReferenceHeightAt(10.001), Is.EqualTo(16));
            Assert.That(windLoad.GetReferenceHeightAt(16), Is.EqualTo(16));
        }

        [Test]
        public void ReferenceHeightsTest_HeightBuilding_Success()
        {
            var buildingSite = new Mock<IBuildingSite>();
            var building = new Mock<IBuilding>();
            building.Setup(b => b.Height).Returns(30);
            building.Setup(b => b.Width).Returns(10);
            building.Setup(b => b.Length).Returns(15);
            var windLoad = new WindLoad(buildingSite.Object, building.Object, buildingRotated: false);

            Assert.That(windLoad.GetReferenceHeightAt(0), Is.EqualTo(10));
            Assert.That(windLoad.GetReferenceHeightAt(10), Is.EqualTo(10));
            Assert.That(windLoad.GetReferenceHeightAt(10.001), Is.EqualTo(11));
            Assert.That(windLoad.GetReferenceHeightAt(18), Is.EqualTo(18));
            Assert.That(windLoad.GetReferenceHeightAt(17.5), Is.EqualTo(18));
            Assert.That(windLoad.GetReferenceHeightAt(20), Is.EqualTo(20));
            Assert.That(windLoad.GetReferenceHeightAt(20.001), Is.EqualTo(30));
            Assert.That(windLoad.GetReferenceHeightAt(25), Is.EqualTo(30));
            Assert.That(windLoad.GetReferenceHeightAt(30), Is.EqualTo(30));
        }
    }
}
