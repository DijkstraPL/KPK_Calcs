using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeamStatica.Loads.ContinousLoads.UpDownTemperatureDifferenceResults;
using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;

namespace BeamStaticaTests.UnitTests.Loads.ContinousLoads.UpDownTemperatureDifferenceResults
{
    [TestFixture()]
    public class VerticalDeflectionResultTests
    {
        [Test()]
        public void UpDownTemperatureDifferenceResults_GetValueForVerticalDeflectionTest_Success()
        {
            var span = new Mock<ISpan>();
            span.Setup(s => s.Section.SolidHeight).Returns(4);

            var continousLoad = new Mock<IContinousLoad>();
            continousLoad.Setup(cl => cl.StartPosition.Value).Returns(5);
            continousLoad.Setup(cl => cl.EndPosition.Value).Returns(1);

            var verticalDeflectionResult = new VerticalDeflectionResult(continousLoad.Object);

            var result = verticalDeflectionResult.GetValue(span.Object, distanceFromLeftSide: 7, currentLength:  1);

            Assert.That(result, Is.EqualTo(0.0018));
        }
    }
}
