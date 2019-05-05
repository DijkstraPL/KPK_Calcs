using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using BeamStatica.Materials.Intefaces;
using BeamStatica.Loads.Interfaces;
using BeamStatica.Loads.ContinousLoads.UpDownTemperatureDifferenceResults;
using BeamStatica.Spans.Interfaces;

namespace BeamStaticaTests.UnitTests.Loads.ContinousLoads.UpDownTemperatureDifferenceResults
{
    [TestFixture()]
    public class RotationResultTests
    {
        [Test()]
        public void SpanExtendLoadResult_GetValueForRotationTest_Success()
        {
            var continousLoad = new Mock<IContinousLoad>();
            continousLoad.Setup(cl => cl.StartPosition.Value).Returns(0);
            continousLoad.Setup(cl => cl.EndPosition.Value).Returns(3);

            var span = new Mock<ISpan>();
            span.Setup(s => s.Section.SolidHeight).Returns(3);

            var rotationResult = new RotationResult(continousLoad.Object);

           var result = rotationResult.GetValue(span.Object, distanceFromLeftSide: 4, currentLength: 1);

            Assert.That(result, Is.EqualTo(-0.0003));
        }
    }
}