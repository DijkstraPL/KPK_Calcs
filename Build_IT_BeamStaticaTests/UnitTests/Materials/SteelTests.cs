using Build_IT_BeamStatica.Materials;
using NUnit.Framework;

namespace Build_IT_BeamStaticaTests.UnitTests.Materials
{
    [TestFixture]
    public class SteelTests
    {
        [Test]
        public void SteelCreationTest_Success()
        {
            var steel = new Steel();

            Assert.That(steel.Density, Is.EqualTo(7850));
            Assert.That(steel.ThermalExpansionCoefficient, Is.EqualTo(0.000012));
            Assert.That(steel.YoungModulus, Is.EqualTo(210));
        }
    }
}
