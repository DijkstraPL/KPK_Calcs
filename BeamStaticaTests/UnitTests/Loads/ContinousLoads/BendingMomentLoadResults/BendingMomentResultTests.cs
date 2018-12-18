using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeamStatica.Loads.ContinousLoads.BendingMomentLoadResults;
using BeamStatica.Loads.Interfaces;

namespace BeamStaticaTests.UnitTests.Loads.ContinousLoads.BendingMomentLoadResults
{
    [TestFixture()]
    public class BendingMomentResultTests
    {
        [Test()]
        public void BendingMomentLoadResults_GetValueForBendingMomentTest_Success()
        {
            var continousLoad = new Mock<IContinousLoad>();
            continousLoad.Setup(cl => cl.StartPosition.Value).Returns(5);

            var bendingMomentResult = new BendingMomentResult(continousLoad.Object);

            var result = bendingMomentResult.GetValue(4);

            Assert.That(result, Is.EqualTo(20));
        }
    }
}
