using Build_IT_Data.Materials;
using NUnit.Framework;

namespace Build_IT_DataTests.UnitTests.Materials
{
    [TestFixture]
    public class ConcreteTests
    {
        [Test]
        public void ConcreteCreationTest_WithReinforcement_Success()
        {
            var concrete = new Concrete(youngModulus: 30, withReinforcement: true);

            Assert.That(concrete.Density, Is.EqualTo(2500));
            Assert.That(concrete.ThermalExpansionCoefficient, Is.EqualTo(0.000010));
            Assert.That(concrete.YoungModulus, Is.EqualTo(30));
        }

        [Test]
        public void ConcreteCreationTest_WithoutReinforcement_Success()
        {
            var concrete = new Concrete(youngModulus: 25, withReinforcement: false);

            Assert.That(concrete.Density, Is.EqualTo(2400));
            Assert.That(concrete.ThermalExpansionCoefficient, Is.EqualTo(0.000010));
            Assert.That(concrete.YoungModulus, Is.EqualTo(25));
        }
    }
}
