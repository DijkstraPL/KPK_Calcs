using BeamStatica.Loads.ContinousLoads.NormalLoadResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using BeamStatica.Materials.Intefaces;
using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;

namespace BeamStaticaTests.UnitTests.Loads.ContinousLoads.NormalLoadResults
{
    [TestFixture()]
    public class NormalForceResultTests
    {
        private NormalForceResult _normalForceResult;

        [SetUp]
        public void SetUpData()
        {
            var continousLoad = new Mock<IContinousLoad>();
            continousLoad.Setup(cl => cl.StartPosition.Value).Returns(1);
            continousLoad.Setup(cl => cl.StartPosition.Position).Returns(1);
            continousLoad.Setup(cl => cl.EndPosition.Value).Returns(3);
            continousLoad.Setup(cl => cl.EndPosition.Position).Returns(7);
            continousLoad.Setup(cl => cl.Length)
                .Returns(continousLoad.Object.EndPosition.Position - continousLoad.Object.StartPosition.Position);

            _normalForceResult = new NormalForceResult(continousLoad.Object);
        }

        [Test()]
        public void NormalLoadResults_GetValueForNormalForceTest_InsideLoadLength_Success()
        {
            var result = _normalForceResult.GetValue(distanceFromLoadStartPosition: 2);

            Assert.That(result, Is.EqualTo(2.666667).Within(0.000001));
        }

        [Test()]
        public void NormalLoadResults_GetValueForNormalForceTest_OutsideLoadLength_Success()
        {
            var result = _normalForceResult.GetValue(distanceFromLoadStartPosition: 8);

            Assert.That(result, Is.EqualTo(12).Within(0.000001));
        }
    }
}