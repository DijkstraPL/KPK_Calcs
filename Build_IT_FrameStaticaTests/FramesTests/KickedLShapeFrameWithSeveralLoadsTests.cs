using Build_IT_FrameStatica.Nodes.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Build_IT_FrameStatica.Spans;
using Build_IT_FrameStatica.Frames;
using Build_IT_FrameStatica.Nodes;
using Build_IT_FrameStatica.Loads.PointLoads;
using Build_IT_Data.Sections;
using Build_IT_Data.Materials;
using Build_IT_FrameStatica.Coords;
using Build_IT_FrameStatica.Loads.ContinuousLoads;

namespace Build_IT_FrameStaticaTests.FramesTests
{
    [TestFixture]
    public class KickedLShapeFrameWithSeveralLoadsTests
    {
        private Frame _frame;

        [SetUp]
        public void SetUpFrame()
        {
            var material = new Material(youngModulus: 200, density:0, thermalExpansionCoefficient:0);
            var section = new SectionProperties(area: 6, momentOfInteria: 6000);

            var node1 = new FixedNode(new Point(0, 0));
            var node2 = new FreeNode(new Point(6, 4.5));
            var node3 = new FixedNode(new Point(12, 4.5));

            var nodes = new Node[] { node1, node2, node3 };

            var span1 = new Span(
                leftNode: node1,
                rightNode: node2,
                material: material,
                section: section,
                 includeSelfWeight: false
                );

            var span2 = new Span(
                leftNode: node2,
                rightNode: node3,
                material: material,
                section: section,
                 includeSelfWeight: false
                );

            var spans = new Span[] { span1, span2 };

            node2.ConcentratedForces.Add(new NormalLoad(value: 15));
            node2.ConcentratedForces.Add(new BendingMoment(value: -20));
            span1.ContinousLoads.Add(ContinuousShearLoad.Create(
                    startPosition: 0, startValue: -3, endPosition: span1.Length, endValue: -3 ));
            span2.PointLoads.Add(new ShearLoad(position: 3, value: -10));

            _frame = new Frame(spans, nodes);

            _frame.CalculationEngine.Calculate();
        }
        
        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_frame.Spans[0].LeftNode.HorizontalForce.Value, Is.EqualTo(6.51).Within(0.01));
                Assert.That(_frame.Spans[0].LeftNode.VerticalForce.Value, Is.EqualTo(24.17).Within(0.01));
                Assert.That(_frame.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-26.46).Within(0.01));

                Assert.That(_frame.Spans[0].RightNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[0].RightNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[0].RightNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[1].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[1].LeftNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[1].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[1].RightNode.HorizontalForce.Value, Is.EqualTo(-35.02).Within(0.01));
                Assert.That(_frame.Spans[1].RightNode.VerticalForce.Value, Is.EqualTo(3.83).Within(0.01));
                Assert.That(_frame.Spans[1].RightNode.BendingMoment.Value, Is.EqualTo(8.08).Within(0.01));
            });
        }

        [Test()]
        public void NodeDisplacementsCalculationsTest_Successful()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_frame.Spans[0].LeftNode.HorizontalDeflection, Is.Null);
                Assert.That(_frame.Spans[0].LeftNode.VerticalDeflection, Is.Null);
                Assert.That(_frame.Spans[0].LeftNode.RightRotation, Is.Null);

                Assert.That(_frame.Spans[0].RightNode.LeftRotation.Value, Is.EqualTo(0.002049).Within(0.000001));
                Assert.That(_frame.Spans[1].LeftNode.HorizontalDeflection.Value, Is.EqualTo(1.751).Within(0.001));
                Assert.That(_frame.Spans[1].LeftNode.VerticalDeflection.Value, Is.EqualTo(-4.388).Within(0.001));
                Assert.That(_frame.Spans[1].LeftNode.RightRotation.Value, Is.EqualTo(0.002049).Within(0.000001));

                Assert.That(_frame.Spans[1].RightNode.LeftRotation, Is.Null);
                Assert.That(_frame.Spans[1].RightNode.HorizontalDeflection, Is.Null);
                Assert.That(_frame.Spans[1].RightNode.VerticalDeflection, Is.Null);
            });
        }
    }
}
