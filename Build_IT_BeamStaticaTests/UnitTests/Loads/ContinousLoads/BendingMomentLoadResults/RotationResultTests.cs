using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Build_IT_BeamStatica.Loads.ContinousLoads.BendingMomentLoadResults;
using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;

namespace Build_IT_BeamStaticaTests.UnitTests.Loads.ContinousLoads.BendingMomentLoadResults
{
    [TestFixture()]
    public class RotationResultTests
    {
        [Test()]
        public void BendingMomentLoadResults_GetValueForRotationTest_Success()
        {
            var span = new Mock<ISpan>();
            span.Setup(s => s.Material.YoungModulus).Returns(2);
            span.Setup(s => s.Section.MomentOfInteria).Returns(4);

            var continousLoad = new Mock<IContinousLoad>();
            continousLoad.Setup(cl => cl.StartPosition.Value).Returns(5);

            var rotationResult = new RotationResult(continousLoad.Object);

            var result = rotationResult.GetValue(span.Object, distanceFromLeftSide: 4, currentLength:  1);

            Assert.That(result, Is.EqualTo(2.8125));
        }
    }
}
