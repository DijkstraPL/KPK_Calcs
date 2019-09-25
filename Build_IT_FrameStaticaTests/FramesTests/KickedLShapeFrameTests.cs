﻿using Build_IT_FrameStatica.Nodes.Interfaces;
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
    public class KickedLShapeFrameTests
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

            span2.ContinousLoads.Add(ContinuousShearLoad.Create(
                    startPosition: 0, startValue: -3, endPosition: 6, endValue: -3));

            _frame = new Frame(spans, nodes);

            _frame.CalculationEngine.Calculate();
        }
        
        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_frame.Spans[0].LeftNode.HorizontalForce.Value, Is.EqualTo(9.15).Within(0.01));
                Assert.That(_frame.Spans[0].LeftNode.VerticalForce.Value, Is.EqualTo(6.75).Within(0.01));
                Assert.That(_frame.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-0.5).Within(0.01));

                Assert.That(_frame.Spans[0].RightNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[0].RightNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[0].RightNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[1].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[1].LeftNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[1].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[1].RightNode.HorizontalForce.Value, Is.EqualTo(-9.15).Within(0.01));
                Assert.That(_frame.Spans[1].RightNode.VerticalForce.Value, Is.EqualTo(11.25).Within(0.01));
                Assert.That(_frame.Spans[1].RightNode.BendingMoment.Value, Is.EqualTo(14.7).Within(0.01));
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

                Assert.That(_frame.Spans[0].RightNode.LeftRotation.Value, Is.EqualTo(-0.0005278).Within(0.0000001));
                Assert.That(_frame.Spans[1].LeftNode.HorizontalDeflection.Value, Is.EqualTo(0.46).Within(0.01));
                Assert.That(_frame.Spans[1].LeftNode.VerticalDeflection.Value, Is.EqualTo(-1.79).Within(0.01));
                Assert.That(_frame.Spans[1].LeftNode.RightRotation.Value, Is.EqualTo(-0.0005278).Within(0.0000001));

                Assert.That(_frame.Spans[1].RightNode.LeftRotation, Is.Null);
                Assert.That(_frame.Spans[1].RightNode.HorizontalDeflection, Is.Null);
                Assert.That(_frame.Spans[1].RightNode.VerticalDeflection, Is.Null);
            });
        }
    }
}
