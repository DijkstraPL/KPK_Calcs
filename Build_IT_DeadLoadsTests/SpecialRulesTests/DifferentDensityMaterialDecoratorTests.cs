using Build_IT_DeadLoads.Interfaces;
using Build_IT_DeadLoads.SpecialRules;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DeadLoadsTests.SpecialRules
{
    [TestFixture]
    public class NormalPercentageOfReinforcingAndPrestressingSteelForConcreteTests
    {
        [Test]
        public void MaximumDensityTest_Success()
        {
            var material = Mock.Of<IMaterial>(m => m.MaximumDensity == 1);
            
            var oneKiloNewtonHeavierMaterial =
                new DifferentDensityMaterialDecorator(material,1);

            Assert.That(oneKiloNewtonHeavierMaterial.MaximumDensity, Is.EqualTo(2));
        }

        [Test]
        public void MinimumDensityTest_Success()
        {
            var material = Mock.Of<IMaterial>(m => m.MinimumDensity == 3);

            var oneKiloNewtonHeavierMaterial =
                new DifferentDensityMaterialDecorator(material,1);

            Assert.That(oneKiloNewtonHeavierMaterial.MinimumDensity, Is.EqualTo(4));
        }

        [Test]
        public void TwoDecoratorsTest_Success()
        {
            var material = Mock.Of<IMaterial>(m => m.MaximumDensity == 2);

            var threeKiloNewtonsHeavierMaterial =
                new DifferentDensityMaterialDecorator(
                new DifferentDensityMaterialDecorator(material,1) , 2);

            Assert.That(threeKiloNewtonsHeavierMaterial.MaximumDensity, Is.EqualTo(5));
        }
    }
}
