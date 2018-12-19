﻿using Build_IT_BeamStatica.Loads.ContinousLoads.AlongTemperatureDifferenceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Build_IT_BeamStatica.Materials.Intefaces;
using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;

namespace Build_IT_BeamStaticaTests.UnitTests.Loads.ContinousLoads.AlongTemperatureDifferenceResult
{
    [TestFixture()]
    public class HorizontalDeflectionResultTests
    {
        [Test()]
        public void AlongTemperatureDifferenceResult_GetValueForHorizontalDeflectionTest_Success()
        {
            var span = new Mock<ISpan>();
            span.Setup(s => s.Material.ThermalExpansionCoefficient).Returns(2);
            var continousLoad = new Mock<IContinousLoad>();
            continousLoad.Setup(cl => cl.StartPosition.Value).Returns(0);
            continousLoad.Setup(cl => cl.EndPosition.Value).Returns(3);

            var horizontalDeflectionResult = new HorizontalDeflectionResult(continousLoad.Object);

           var result =  horizontalDeflectionResult.GetValue(span.Object, distanceFromLeftSide: 4, currentLength: 1);

            Assert.That(result, Is.EqualTo(-1800));
        }
    }
}