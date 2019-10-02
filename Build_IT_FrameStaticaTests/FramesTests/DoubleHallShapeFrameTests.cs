﻿using Build_IT_Data.Materials;
using Build_IT_Data.Sections;
using Build_IT_FrameStatica.Coords;
using Build_IT_FrameStatica.Frames;
using Build_IT_FrameStatica.Loads.ContinuousLoads;
using Build_IT_FrameStatica.Loads.PointLoads;
using Build_IT_FrameStatica.Nodes;
using Build_IT_FrameStatica.Spans;
using NUnit.Framework;

namespace Build_IT_FrameStaticaTests.FramesTests
{
    [TestFixture]
    [Property("Name", "2019.09.30-06")]
    public class DoubleHallShapeFrameTests
    {
        private Frame _frame;

        [SetUp]
        public void SetUpFrame()
        {
            //var material = new Material(youngModulus: 200, density:0, thermalExpansionCoefficient:0);
            //var section = new SectionProperties(area: 6, momentOfInteria: 6000);

            var material = new Material(youngModulus: 30, density: 0, thermalExpansionCoefficient: 0);
            var section = new SectionProperties(area: 1500, momentOfInteria: 312500);

            var node1 = new FixedNode(new Point(0, 0));
            var node2 = new FreeNode(new Point(0, 10));
            var node3 = new FreeNode(new Point(10, 10));
            var node4 = new FreeNode(new Point(10, 5));
            var node5 = new FreeNode(new Point(15, 5));
            var node6 = new SupportedNode(new Point(15, 0));
            var node7 = new FixedNode(new Point(10, 0));

            var nodes = new Node[] { node1, node2, node3, node4, node5, node6, node7 };

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

            var span3 = new Span(
                leftNode: node3,
                rightNode: node4,
                material: material,
                section: section,
                 includeSelfWeight: false
                );

            var span4 = new Span(
                leftNode: node4,
                rightNode: node5,
                material: material,
                section: section,
                 includeSelfWeight: false
                );

            var span5 = new Span(
                leftNode: node5,
                rightNode: node6,
                material: material,
                section: section,
                 includeSelfWeight: false
                );

            var span6 = new Span(
                leftNode: node4,
                rightNode: node7,
                material: material,
                section: section,
                 includeSelfWeight: false
                );
            
            var spans = new Span[] { span1, span2, span3, span4, span5, span6 };

            node2.ConcentratedForces.Add(new NormalLoad(20));

            span2.ContinousLoads.Add(ContinuousShearLoad.Create(
                    startPosition: 0, startValue: -3, endPosition: 10, endValue: -3));

            span4.ContinousLoads.Add(ContinuousShearLoad.Create(
                    startPosition: 0, startValue: -10, endPosition: 5, endValue: -10));

            _frame = new Frame(spans, nodes);

            _frame.CalculationEngine.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_frame.Spans[0].LeftNode.HorizontalForce.Value, Is.EqualTo(-3.783).Within(0.001));
                Assert.That(_frame.Spans[0].LeftNode.VerticalForce.Value, Is.EqualTo(8.815).Within(0.001));
                Assert.That(_frame.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-26.705).Within(0.001));

                Assert.That(_frame.Spans[0].RightNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[0].RightNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[0].RightNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[1].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[1].LeftNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[1].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[1].RightNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[1].RightNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[1].RightNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[2].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[2].LeftNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[2].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[2].RightNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[2].RightNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[2].RightNode.BendingMoment, Is.Null);
                
                Assert.That(_frame.Spans[3].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[3].LeftNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[3].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[3].RightNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[3].RightNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[3].RightNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[4].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[4].LeftNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[4].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[4].RightNode.HorizontalForce.Value, Is.EqualTo(-8.169).Within(0.001));
                Assert.That(_frame.Spans[4].RightNode.VerticalForce.Value, Is.EqualTo(40.195).Within(0.001));
                Assert.That(_frame.Spans[4].RightNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[5].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[5].LeftNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[5].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[5].RightNode.HorizontalForce.Value, Is.EqualTo(-8.048).Within(0.001));
                Assert.That(_frame.Spans[5].RightNode.VerticalForce.Value, Is.EqualTo(30.990).Within(0.001));
                Assert.That(_frame.Spans[5].RightNode.BendingMoment.Value, Is.EqualTo(-35.476).Within(0.001));
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

                Assert.That(_frame.Spans[0].RightNode.LeftRotation.Value, Is.EqualTo(-0.000831).Within(0.000001));
                Assert.That(_frame.Spans[1].LeftNode.HorizontalDeflection.Value, Is.EqualTo(7.518).Within(0.001));
                Assert.That(_frame.Spans[1].LeftNode.VerticalDeflection.Value, Is.EqualTo(-0.0196).Within(0.0001));
                Assert.That(_frame.Spans[1].LeftNode.RightRotation.Value, Is.EqualTo(-0.000831).Within(0.000001));

                Assert.That(_frame.Spans[1].RightNode.LeftRotation.Value, Is.EqualTo(-0.000276).Within(0.000001));
                Assert.That(_frame.Spans[1].RightNode.HorizontalDeflection.Value, Is.EqualTo(7.482).Within(0.001));
                Assert.That(_frame.Spans[1].RightNode.VerticalDeflection.Value, Is.EqualTo(-0.058).Within(0.001));

                Assert.That(_frame.Spans[2].LeftNode.HorizontalDeflection.Value, Is.EqualTo(7.482).Within(0.001));
                Assert.That(_frame.Spans[2].LeftNode.VerticalDeflection.Value, Is.EqualTo(-0.058).Within(0.001));
                Assert.That(_frame.Spans[2].LeftNode.RightRotation.Value, Is.EqualTo(-0.000276).Within(0.000001));

                Assert.That(_frame.Spans[2].RightNode.HorizontalDeflection.Value, Is.EqualTo(2.942).Within(0.001));
                Assert.That(_frame.Spans[2].RightNode.VerticalDeflection.Value, Is.EqualTo(-0.034).Within(0.001));
                Assert.That(_frame.Spans[2].RightNode.LeftRotation.Value, Is.EqualTo(-0.000819).Within(0.000001));

                Assert.That(_frame.Spans[3].LeftNode.HorizontalDeflection.Value, Is.EqualTo(2.942).Within(0.001));
                Assert.That(_frame.Spans[3].LeftNode.VerticalDeflection.Value, Is.EqualTo(-0.034).Within(0.001));
                Assert.That(_frame.Spans[3].LeftNode.RightRotation.Value, Is.EqualTo(-0.000819).Within(0.000001));

                Assert.That(_frame.Spans[3].RightNode.HorizontalDeflection.Value, Is.EqualTo(2.933).Within(0.001));
                Assert.That(_frame.Spans[3].RightNode.VerticalDeflection.Value, Is.EqualTo(-0.045).Within(0.001));
                Assert.That(_frame.Spans[3].RightNode.LeftRotation.Value, Is.EqualTo(0.000140).Within(0.000001));

                Assert.That(_frame.Spans[4].LeftNode.HorizontalDeflection.Value, Is.EqualTo(2.933).Within(0.001));
                Assert.That(_frame.Spans[4].LeftNode.VerticalDeflection.Value, Is.EqualTo(-0.045).Within(0.001));
                Assert.That(_frame.Spans[4].LeftNode.RightRotation.Value, Is.EqualTo(0.000140).Within(0.000001));

                Assert.That(_frame.Spans[4].RightNode.HorizontalDeflection, Is.Null);
                Assert.That(_frame.Spans[4].RightNode.VerticalDeflection, Is.Null);
                Assert.That(_frame.Spans[4].RightNode.LeftRotation.Value, Is.EqualTo(-0.000950).Within(0.000001));

                Assert.That(_frame.Spans[5].LeftNode.HorizontalDeflection.Value, Is.EqualTo(2.942).Within(0.001));
                Assert.That(_frame.Spans[5].LeftNode.VerticalDeflection.Value, Is.EqualTo(-0.034).Within(0.001));
                Assert.That(_frame.Spans[5].LeftNode.RightRotation.Value, Is.EqualTo(-0.000819).Within(0.000001));

                Assert.That(_frame.Spans[5].RightNode.HorizontalDeflection, Is.Null);
                Assert.That(_frame.Spans[5].RightNode.VerticalDeflection, Is.Null);
                Assert.That(_frame.Spans[5].RightNode.LeftRotation, Is.Null);
            });
        }
    }
}