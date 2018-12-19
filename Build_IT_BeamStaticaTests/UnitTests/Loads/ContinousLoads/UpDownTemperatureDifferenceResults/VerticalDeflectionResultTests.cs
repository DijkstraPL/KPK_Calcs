using Build_IT_BeamStatica.Loads.ContinousLoads.UpDownTemperatureDifferenceResults;
using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;
using Moq;
using NUnit.Framework;

namespace Build_IT_BeamStaticaTests.UnitTests.Loads.ContinousLoads.UpDownTemperatureDifferenceResults
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
