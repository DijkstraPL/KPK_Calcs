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
    //[Explicit("Not ready")]
    public class ThreeSlabsInOnePointFrameTests
    {
        private Frame _frame;

        [SetUp]
        public void SetUpFrame()
        {
            var material = new Material(youngModulus: 205, density:0, thermalExpansionCoefficient:0);
            var section = new SectionProperties(area: 10.6, momentOfInteria: 171);

            var node1 = new FixedNode(new Point(0, 0));
            var node2 = new FixedNode(new Point(3, 0));
            var node3 = new SupportedNode(new Point(6, 4));
            var nodeX = new FreeNode(new Point(3, 4));

            var nodes = new Node[] { node1, node2, node3, nodeX };

            var span1 = new Span(
                leftNode: node1,
                rightNode: nodeX,
                material: material,
                section: section,
                 includeSelfWeight: false
                );

            var span2 = new Span(
                leftNode: node2,
                rightNode: nodeX,
                material: material,
                section: section,
                 includeSelfWeight: false
                );

            var span3 = new Span(
                leftNode: node3,
                rightNode: nodeX,
                material: material,
                section: section,
                 includeSelfWeight: false
                );

            var spans = new Span[] { span1, span2, span3 };

            nodeX.ConcentratedForces.Add(new NormalLoad(value: 10));
            span3.ContinousLoads.Add(
                ContinuousShearLoad.Create(
                    startPosition: 0, startValue: -5, 
                    endPosition: span3.Length, endValue: -5));

            _frame = new Frame(spans, nodes);

            _frame.CalculationEngine.Calculate();
        }
        
        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_frame.Spans[0].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[0].LeftNode.VerticalForce.Value, Is.EqualTo(-1.87).Within(0.01));
                Assert.That(_frame.Spans[0].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[0].RightNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[0].RightNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[0].RightNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[1].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[1].LeftNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[1].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[1].RightNode.HorizontalForce.Value, Is.EqualTo(-5).Within(0.01));
                Assert.That(_frame.Spans[1].RightNode.VerticalForce.Value, Is.EqualTo(1.87).Within(0.01));
                Assert.That(_frame.Spans[1].RightNode.BendingMoment.Value, Is.EqualTo(-18.77).Within(0.01));
            });
        }

        [Test()]
        public void NodeDisplacementsCalculationsTest_Successful()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_frame.Spans[0].LeftNode.HorizontalDeflection.Value, Is.EqualTo(13.16).Within(0.01));
                Assert.That(_frame.Spans[0].LeftNode.VerticalDeflection, Is.Null);
                Assert.That(_frame.Spans[0].LeftNode.RightRotation.Value, Is.EqualTo(0.00092).Within(0.00001));

                Assert.That(_frame.Spans[0].RightNode.LeftRotation.Value, Is.EqualTo(-0.00189).Within(0.00001));
                Assert.That(_frame.Spans[1].LeftNode.HorizontalDeflection.Value, Is.EqualTo(13.16).Within(0.01));
                Assert.That(_frame.Spans[1].LeftNode.VerticalDeflection.Value, Is.EqualTo(-0.09).Within(0.01));
                Assert.That(_frame.Spans[1].LeftNode.RightRotation.Value, Is.EqualTo(-0.00189).Within(0.00001));

                Assert.That(_frame.Spans[1].RightNode.LeftRotation, Is.Null);
                Assert.That(_frame.Spans[1].RightNode.HorizontalDeflection, Is.Null);
                Assert.That(_frame.Spans[1].RightNode.VerticalDeflection, Is.Null);
            });
        }

        //[Test()]
        //[TestCase(0, 0)]
        //[TestCase(2, 0)]
        //[TestCase(3, 0)]
        //[TestCase(4, 0)]
        //[TestCase(6, 0)]
        //public void NormalForceAtPositionCalculationsTest_Successful(double position, double result)
        //{
        //    double calculatedShear = _frame.Results.NormalForce.GetValue(position).Value;

        //    Assert.That(calculatedShear, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        //}

        //[Test()]
        //[TestCase(0, -1.871)]
        //[TestCase(2, -1.871)]
        //[TestCase(3, -1.871)]
        //[TestCase(4, -1.871)]
        //[TestCase(6, -1.871)]
        //public void ShearForceAtPositionCalculationsTest_Successful(double position, double result)
        //{
        //    double calculatedShear = _frame.Results.Shear.GetValue(position).Value;

        //    Assert.That(calculatedShear, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        //}
    }
}
