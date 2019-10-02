using Build_IT_Data.Materials;
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
    [Property("Name", "2019.10.02-01")]
    public class TriangleFrameTests
    {
        private Frame _frame;

        [SetUp]
        public void SetUpFrame()
        {
            var material = new Material(youngModulus: 30, density: 0, thermalExpansionCoefficient: 0);
            var section = new SectionProperties(area: 1500, momentOfInteria: 312500);

            var node1 = new SupportedNode(new Point(0, 0));
            var node2 = new SupportedNode(new Point(10, 0));
            var node3 = new FreeNode(new Point(5, 5));

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

            var span3 = new Span(
                leftNode: node3,
                rightNode: node1,
                material: material,
                section: section,
                 includeSelfWeight: false
                );

            var spans = new Span[] { span1, span2, span3 };

            node3.ConcentratedForces.Add(new ShearLoad(value: -25));
            span3.ContinousLoads.Add(ContinuousShearLoad.Create(
                startPosition: 0, endPosition: span3.Length, startValue:-15, endValue:-15));
            span1.ContinousLoads.Add(ContinuousShearLoad.Create(
                startPosition: 7, endPosition: 9, startValue: -10, endValue: -25));

            _frame = new Frame(spans, nodes);

            _frame.CalculationEngine.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_frame.Spans[0].LeftNode.HorizontalForce.Value, Is.EqualTo(48.848).Within(0.001));
                Assert.That(_frame.Spans[0].LeftNode.VerticalForce.Value, Is.EqualTo(-18.5).Within(0.001));
                Assert.That(_frame.Spans[0].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[0].RightNode.HorizontalForce.Value, Is.EqualTo(26.152).Within(0.001));
                Assert.That(_frame.Spans[0].RightNode.VerticalForce.Value, Is.EqualTo(3.5).Within(0.001));
                Assert.That(_frame.Spans[0].RightNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[1].LeftNode.HorizontalForce.Value, Is.EqualTo(26.152).Within(0.001));
                Assert.That(_frame.Spans[1].LeftNode.VerticalForce.Value, Is.EqualTo(3.5).Within(0.001));
                Assert.That(_frame.Spans[1].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[1].RightNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[1].RightNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[1].RightNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[2].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[2].LeftNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[2].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[2].RightNode.HorizontalForce.Value, Is.EqualTo(48.848).Within(0.001));
                Assert.That(_frame.Spans[2].RightNode.VerticalForce.Value, Is.EqualTo(-18.5).Within(0.001));
                Assert.That(_frame.Spans[2].RightNode.BendingMoment, Is.Null);
            });
        }

        [Test()]
        public void NodeDisplacementsCalculationsTest_Successful()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_frame.Spans[0].LeftNode.HorizontalDeflection, Is.Null);
                Assert.That(_frame.Spans[0].LeftNode.VerticalDeflection, Is.Null);
                Assert.That(_frame.Spans[0].LeftNode.LeftRotation.Value, Is.EqualTo(0.000730).Within(0.000001));

                Assert.That(_frame.Spans[0].RightNode.RightRotation.Value, Is.EqualTo(0.000576).Within(0.000001));
                Assert.That(_frame.Spans[1].LeftNode.HorizontalDeflection, Is.Null);
                Assert.That(_frame.Spans[1].LeftNode.VerticalDeflection, Is.Null);
                Assert.That(_frame.Spans[1].LeftNode.RightRotation.Value, Is.EqualTo(0.000576).Within(0.000001));

                Assert.That(_frame.Spans[1].RightNode.LeftRotation.Value, Is.EqualTo(-0.000908).Within(0.000001));
                Assert.That(_frame.Spans[1].RightNode.HorizontalDeflection.Value, Is.EqualTo(-0.052).Within(0.001));
                Assert.That(_frame.Spans[1].RightNode.VerticalDeflection.Value, Is.EqualTo(0.021).Within(0.001));

                Assert.That(_frame.Spans[2].LeftNode.HorizontalDeflection.Value, Is.EqualTo(-0.052).Within(0.001));
                Assert.That(_frame.Spans[2].LeftNode.VerticalDeflection.Value, Is.EqualTo(0.021).Within(0.001));
                Assert.That(_frame.Spans[2].LeftNode.RightRotation.Value, Is.EqualTo(-0.000908).Within(0.000001));

                Assert.That(_frame.Spans[2].RightNode.HorizontalDeflection, Is.Null);
                Assert.That(_frame.Spans[2].RightNode.VerticalDeflection, Is.Null);
                Assert.That(_frame.Spans[2].RightNode.RightRotation.Value, Is.EqualTo(0.000730).Within(0.000001));
            });
        }
    }
}