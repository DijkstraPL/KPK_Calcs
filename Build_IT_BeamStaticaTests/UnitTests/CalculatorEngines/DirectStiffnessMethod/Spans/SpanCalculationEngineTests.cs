using Build_IT_BeamStatica.CalculationEngines.DirectStiffnessMethod.Spans;
using Build_IT_BeamStatica.CalculationEngines.DirectStiffnessMethod.Spans.Interfaces;
using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_BeamStaticaTests.UnitTests.CalculatorEngines.DirectStiffnessMethod.Spans
{
    [TestFixture]
    public class SpanCalculationEngineTests
    {

        [Test]
        public void SpanCalculate_SpanLoadVector_Success()
        {
            // TODO: Add this
            var span = new Mock<ISpan>();
            span.Setup(s => s.IncludeSelfWeight).Returns(false);

            var continousLoad = new Mock<IContinousLoad>();
            continousLoad.Setup(cl => cl.CalculateSpanLoadVectorNormalForceMember(span.Object, true)).Returns(5);
            var continousLoads = new List<IContinousLoad>() { continousLoad.Object };
            var pointLoad = new Mock<IContinousLoad>();
            pointLoad.Setup(cl => cl.CalculateSpanLoadVectorNormalForceMember(span.Object, true)).Returns(1);
            var pointLoads = new List<ISpanLoad>();

            //span.Setup(s => s.LeftNode).Returns()
            //span.Setup(s => s.RightNode).Returns()
            span.Setup(s => s.ContinousLoads).Returns(continousLoads);
            span.Setup(s => s.PointLoads).Returns(pointLoads);

            var stiffnessMatrix = new Mock<IStiffnessMatrix>();
            stiffnessMatrix.Setup(sm => sm.Size).Returns(2);

            var spanCalculationEngine = new SpanCalculationEngine(span.Object, stiffnessMatrix.Object);

            spanCalculationEngine.CalculateSpanLoadVector();

            Assert.That(spanCalculationEngine.LoadVector[0], Is.EqualTo(0));
            Assert.That(spanCalculationEngine.LoadVector[1], Is.EqualTo(0.0000721182).Within(0.0000000001));
            Assert.That(spanCalculationEngine.LoadVector[2], Is.EqualTo(0.0000841379).Within(0.0000000001));
            Assert.That(spanCalculationEngine.LoadVector[3], Is.EqualTo(0));
            Assert.That(spanCalculationEngine.LoadVector[4], Is.EqualTo(0.0000721182).Within(0.0000000001));
            Assert.That(spanCalculationEngine.LoadVector[5], Is.EqualTo(-0.0000841379).Within(0.0000000001));
        }

        [Test]
        public void SpanCalculate_Displacement_Success()
        {
            // TODO: Add this

            //var span = new Span(
            //    _leftNode, length: 7, _rightNode,
            //    _material, _section, includeSelfWeight: true);

            //span.StiffnessMatrix.Calculate();

            //var deflectionVector = Vector<double>.Build.Dense(8);
            //deflectionVector[0] = 1;
            //deflectionVector[1] = 2;
            //deflectionVector[2] = 3;
            //deflectionVector[3] = 4;
            //deflectionVector[4] = 5;
            //deflectionVector[5] = 6;
            //deflectionVector[6] = 7;
            //deflectionVector[7] = 8;
            //span.CalculateDisplacement(deflectionVector, 4);

            //Assert.That(span.Displacements[0], Is.EqualTo(1));
            //Assert.That(span.Displacements[1], Is.EqualTo(2));
            //Assert.That(span.Displacements[2], Is.EqualTo(4));
            //Assert.That(span.Displacements[3], Is.EqualTo(0));
            //Assert.That(span.Displacements[4], Is.EqualTo(0));
            //Assert.That(span.Displacements[5], Is.EqualTo(0));
        }

        [Test]
        public void SpanCalculate_SetDisplacement_Success()
        {
            // TODO: Add this
        }

        [Test]
        public void SpanCalculate_Force_Success()
        {
            // TODO: Add this
        }
    }
}
