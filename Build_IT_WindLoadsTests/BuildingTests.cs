using Build_IT_WindLoads;
using Moq;
using NUnit.Framework;

namespace Build_IT_WindLoadsTests
{
    [TestFixture]
    public class BuildingTests
    {
        [Test]
        public void ConstructorTest_Success()
        {
            var building = new Building(length: 10, width: 5, height: 3);

            Assert.That(building.Length, Is.EqualTo(10));
            Assert.That(building.Width, Is.EqualTo(5));
            Assert.That(building.Height, Is.EqualTo(3));
        }

        [Test]
        [TestCase(3, 5)]
        [TestCase(1, 2)]
        public void EdgeDistanceTest_WidthIsSmaller_Success(double height, double expectedResult)
        {
            var building = new Building(length: 10, width: 5, height: height);

            Assert.That(building.EdgeDistance, Is.EqualTo(expectedResult));
        }
    }
}
