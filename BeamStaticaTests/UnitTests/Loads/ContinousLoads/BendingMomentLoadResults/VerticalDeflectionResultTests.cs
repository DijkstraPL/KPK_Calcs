﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeamStatica.Loads.ContinousLoads.BendingMomentLoadResults;
using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;

namespace BeamStaticaTests.UnitTests.Loads.ContinousLoads.BendingMomentLoadResults
{
    [TestFixture()]
    public class VerticalDeflectionResultTests
    {
        [Test()]
        public void BendingMomentLoadResults_GetValueForVerticalDeflectionTest_Success()
        {
            var span = new Mock<ISpan>();
            span.Setup(s => s.Material.YoungModulus).Returns(2);
            span.Setup(s => s.Section.MomentOfInteria).Returns(4);

            var continousLoad = new Mock<IContinousLoad>();
            continousLoad.Setup(cl => cl.StartPosition.Value).Returns(5);

            var verticalDeflectionResult = new VerticalDeflectionResult(continousLoad.Object);

            var result = verticalDeflectionResult.GetValue(span.Object, distanceFromLeftSide: 7, currentLength:  1);

            Assert.That(result, Is.EqualTo(22.5));
        }
    }
}
