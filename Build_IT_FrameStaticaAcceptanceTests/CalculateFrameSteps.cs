using Build_IT_FrameStatica.Coords;
using Build_IT_FrameStatica.Nodes.Interfaces;
using System;
using TechTalk.SpecFlow;
using Build_IT_FrameStatica.Nodes;
using Build_IT_Data.Materials;
using Build_IT_Data.Sections;
using Build_IT_FrameStatica.Spans;
using Build_IT_FrameStatica.Loads.PointLoads;
using Build_IT_FrameStatica.Frames;
using NUnit.Framework;

namespace Build_IT_FrameStaticaAcceptanceTests
{
    [Binding]
    public class CalculateFrameSteps
    {
        private INode _node1;
        private INode _node2;
        private INode _node3;
        private INode[] _nodes;
        private Material _material;
        private SectionProperties _section;
        private Span _span1;
        private Span _span2;
        private Span[] _spans;
        private Frame _frame;

        [Given(@"I have entered Nodes positions")]
        public void GivenIHaveEnteredNodesPositions()
        {
            _node1 = new PinNode(new Point(0, 0));
            _node2 = new FreeNode(new Point(6, 0));
            _node3 = new FixedNode(new Point(6, -6));

            _nodes = new INode[] { _node1, _node2, _node3 };
        }
        
        [Given(@"I have entered Materials")]
        public void GivenIHaveEnteredMaterials()
        {
            _material = new Material(youngModulus: 200, density: 0, thermalExpansionCoefficient: 0);
        }
        
        [Given(@"I have entered Sections")]
        public void GivenIHaveEnteredSections()
        {
            _section = new SectionProperties(area: 600, momentOfInteria: 6000);
        }

        [Given(@"I have entered Spans")]
        public void GivenIHaveEnteredSpans()
        {
            _span1 = new Span(
              leftNode: _node1,
              rightNode: _node2,
              material: _material,
              section: _section,
              includeSelfWeight: false
              );

            _span2 = new Span(
                leftNode: _node2,
                rightNode: _node3,
                material: _material,
                section: _section,
                includeSelfWeight: false
                );

            _spans = new Span[] { _span1, _span2 };
        }

        [Given(@"I have entered Loads")]
        public void GivenIHaveEnteredLoads()
        {
            _node2.ConcentratedForces.Add(new NormalLoad(value: 5));
        }

        [When(@"I press calculate")]
        public void WhenIPressCalculate()
        {
            _frame = new Frame(_spans, _nodes);

            _frame.CalculationEngine.Calculate();
        }
        
        [Then(@"the result should be correct")]
        public void ThenTheResultShouldBeCorrect()
        {
            Assert.That(_frame.Spans[0].LeftNode.HorizontalForce, Is.Null);
            Assert.That(_frame.Spans[0].LeftNode.VerticalForce.Value, Is.EqualTo(-1.875).Within(0.001));
            Assert.That(_frame.Spans[0].LeftNode.BendingMoment, Is.Null);

            Assert.That(_frame.Spans[0].RightNode.HorizontalForce.Value, Is.EqualTo(0).Within(0.001));
            Assert.That(_frame.Spans[0].RightNode.VerticalForce.Value, Is.EqualTo(-1.875).Within(0.001));
            Assert.That(_frame.Spans[0].RightNode.BendingMoment.Value, Is.EqualTo(-11.248).Within(0.001));

            Assert.That(_frame.Spans[1].LeftNode.HorizontalForce.Value, Is.EqualTo(1.875).Within(0.001));
            Assert.That(_frame.Spans[1].LeftNode.VerticalForce.Value, Is.EqualTo(5).Within(0.001));
            Assert.That(_frame.Spans[1].LeftNode.BendingMoment.Value, Is.EqualTo(-11.248).Within(0.001));

            Assert.That(_frame.Spans[1].RightNode.HorizontalForce.Value, Is.EqualTo(-5).Within(0.001));
            Assert.That(_frame.Spans[1].RightNode.VerticalForce.Value, Is.EqualTo(1.875).Within(0.001));
            Assert.That(_frame.Spans[1].RightNode.BendingMoment.Value, Is.EqualTo(-18.752).Within(0.001));
        }
    }
}
