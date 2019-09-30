using Build_IT_Data.Materials;
using Build_IT_Data.Sections;
using Build_IT_FrameStatica.Coords;
using Build_IT_FrameStatica.Frames;
using Build_IT_FrameStatica.Loads.PointLoads;
using Build_IT_FrameStatica.Nodes;
using Build_IT_FrameStatica.Spans;
using NUnit.Framework;


namespace Build_IT_FrameStaticaTests.FramesTests
{
    [TestFixture]
    [Property("Name", "2019.09.30-07")]
    public class FrameGoingBackwardAtTheBeginingTests
    {
        private Frame _frame;

        [SetUp]
        public void SetUpFrame()
        {
            var material = new Material(youngModulus: 30, density: 0, thermalExpansionCoefficient: 0);
            var section = new SectionProperties(area: 1500, momentOfInteria: 312500);

            var node1 = new PinNode(new Point(10, 0));
            var node2 = new FreeNode(new Point(0, 5));
            var node3 = new FreeNode(new Point(15, 5));
            var node4 = new FixedNode(new Point(15, 0));

            var nodes = new Node[] { node1, node2, node3, node4 };

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

            var spans = new Span[] { span1, span2, span3 };

            node2.ConcentratedForces.Add(new ShearLoad(value: -10));
            span3.PointLoads.Add(new ShearLoad(value: -10, position: 2.5));

            _frame = new Frame(spans, nodes);

            _frame.CalculationEngine.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_frame.Spans[0].RightNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[0].RightNode.VerticalForce.Value, Is.EqualTo(4.477).Within(0.001));
                Assert.That(_frame.Spans[0].RightNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[0].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[0].LeftNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[0].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[1].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[1].LeftNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[1].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[1].RightNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[1].RightNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[1].RightNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[2].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[2].LeftNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[2].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[2].RightNode.HorizontalForce.Value, Is.EqualTo(10).Within(0.01));
                Assert.That(_frame.Spans[2].RightNode.VerticalForce.Value, Is.EqualTo(5.523).Within(0.001));
                Assert.That(_frame.Spans[2].RightNode.BendingMoment.Value, Is.EqualTo(152.617).Within(0.001));
            });
        }

        [Test()]
        public void NodeDisplacementsCalculationsTest_Successful()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_frame.Spans[0].RightNode.HorizontalDeflection.Value, Is.EqualTo(95.140).Within(0.001));
                Assert.That(_frame.Spans[0].RightNode.VerticalDeflection, Is.Null);
                Assert.That(_frame.Spans[0].RightNode.LeftRotation.Value, Is.EqualTo(0.023600).Within(0.000001));

                Assert.That(_frame.Spans[0].LeftNode.RightRotation.Value, Is.EqualTo(0.020930).Within(0.000001));
                Assert.That(_frame.Spans[1].LeftNode.HorizontalDeflection.Value, Is.EqualTo(-18.404).Within(0.001));
                Assert.That(_frame.Spans[1].LeftNode.VerticalDeflection.Value, Is.EqualTo(-227.100).Within(0.001));
                Assert.That(_frame.Spans[1].LeftNode.RightRotation.Value, Is.EqualTo(0.020930).Within(0.000001));

                Assert.That(_frame.Spans[1].RightNode.LeftRotation.Value, Is.EqualTo(0.007140).Within(0.000001));
                Assert.That(_frame.Spans[1].RightNode.HorizontalDeflection.Value, Is.EqualTo(-18.404).Within(0.001));
                Assert.That(_frame.Spans[1].RightNode.VerticalDeflection.Value, Is.EqualTo(-0.006).Within(0.001));

                Assert.That(_frame.Spans[2].LeftNode.HorizontalDeflection.Value, Is.EqualTo(-18.404).Within(0.001));
                Assert.That(_frame.Spans[2].LeftNode.VerticalDeflection.Value, Is.EqualTo(-0.006).Within(0.001));
                Assert.That(_frame.Spans[2].LeftNode.RightRotation.Value, Is.EqualTo(0.007140).Within(0.000001));

                Assert.That(_frame.Spans[2].RightNode.HorizontalDeflection, Is.Null);
                Assert.That(_frame.Spans[2].RightNode.VerticalDeflection, Is.Null);
                Assert.That(_frame.Spans[2].RightNode.RightRotation, Is.Null);
            });
        }
    }
}