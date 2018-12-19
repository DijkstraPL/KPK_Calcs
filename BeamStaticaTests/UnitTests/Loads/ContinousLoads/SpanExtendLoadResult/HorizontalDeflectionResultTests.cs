using BeamStatica.Loads.ContinousLoads.SpanExtendLoadResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using BeamStatica.Materials.Intefaces;
using BeamStatica.Loads.Interfaces;

namespace BeamStaticaTests.UnitTests.Loads.ContinousLoads.SpanExtendLoadResult
{
    [TestFixture()]
    public class HorizontalDeflectionResultTests
    {
        [Test()]
        public void SpanExtendLoadResult_GetValueForHorizontalDeflectionTest_Success()
        {
            var continousLoad = new Mock<IContinousLoad>();
            continousLoad.Setup(cl => cl.StartPosition.Value).Returns(0);
            continousLoad.Setup(cl => cl.EndPosition.Value).Returns(3);

            var horizontalDeflectionResult = new HorizontalDeflectionResult(continousLoad.Object);

           var result =  horizontalDeflectionResult.GetValue(null, distanceFromLeftSide: 4, currentLength: 1);

            Assert.That(result, Is.EqualTo(-0.09));
        }
    }
}