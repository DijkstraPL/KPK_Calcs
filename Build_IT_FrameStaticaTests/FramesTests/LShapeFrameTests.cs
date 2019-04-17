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

namespace Build_IT_FrameStaticaTests.FramesTests
{
    [TestFixture]
    public class LShapeFrameTests
    {
        private Frame _frame;

        [SetUp]
        public void SetUpFrame()
        {
            var material = new Material(youngModulus: 200, density:0, thermalExpansionCoefficient:0);
            var section = new SectionProperties(area: 600, momentOfInteria: 6000);

            var node1 = new PinNode(new Point(0, 0));
            var node2 = new FreeNode(new Point(6, 0));
            var node3 = new FixedNode(new Point(6, -6));

            var nodes = new Node[] { node1, node2, node3 };

            var span1 = new Span(
                leftNode: node1,
                rightNode: node2,
                material: material,
                section: section
                );

            var span2 = new Span(
                leftNode: node2,
                rightNode: node3,
                material: material,
                section: section
                );

            var spans = new Span[] { span1, span2 };

            node2.ConcentratedForces.Add(new NormalLoad(value: 5));

            _frame = new Frame(spans, nodes);

            _frame.CalculationEngine.Calculate();
        }


        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.That(_frame.Spans[0].LeftNode.NormalForce, Is.Null);
            Assert.That(_frame.Spans[0].LeftNode.ShearForce.Value, Is.EqualTo(-1.875).Within(0.001));
            Assert.That(_frame.Spans[0].LeftNode.BendingMoment, Is.Null);

            Assert.That(_frame.Spans[0].RightNode.NormalForce.Value, Is.EqualTo(0).Within(0.001));
            Assert.That(_frame.Spans[0].RightNode.ShearForce.Value, Is.EqualTo(-1.875).Within(0.001));
            Assert.That(_frame.Spans[0].RightNode.BendingMoment.Value, Is.EqualTo(-11.248).Within(0.001));

            Assert.That(_frame.Spans[1].LeftNode.NormalForce.Value, Is.EqualTo(1.875).Within(0.001));
            Assert.That(_frame.Spans[1].LeftNode.ShearForce.Value, Is.EqualTo(5).Within(0.001));
            Assert.That(_frame.Spans[1].LeftNode.BendingMoment.Value, Is.EqualTo(-11.248).Within(0.001));

            Assert.That(_frame.Spans[1].RightNode.NormalForce.Value, Is.EqualTo(-5).Within(0.001));
            Assert.That(_frame.Spans[1].RightNode.ShearForce.Value, Is.EqualTo(1.875).Within(0.001));
            Assert.That(_frame.Spans[1].RightNode.BendingMoment.Value, Is.EqualTo(-18.752).Within(0.001));
        }
    }
}
