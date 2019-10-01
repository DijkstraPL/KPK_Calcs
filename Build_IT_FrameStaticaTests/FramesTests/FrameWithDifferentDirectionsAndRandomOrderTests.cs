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
    [Property("Name", "2019.10.01-01")]
    public class FrameWithDifferentDirectionsAndRandomOrderTests
    {
        private Frame _frame;

        [SetUp]
        public void SetUpFrame()
        {
            var material = new Material(youngModulus: 30, density: 0, thermalExpansionCoefficient: 0);
            var section = new SectionProperties(area: 1500, momentOfInteria: 312500);

            var node4 = new FixedNode(new Point(0, 0));
            var node1 = new FreeNode(new Point(0, 5));
            var node3 = new FreeNode(new Point(10, 4));
            var node2 = new FixedNode(new Point(5, 0));

            var nodes = new Node[] { node1, node2, node3, node4 };

            var span2 = new Span(
                leftNode: node1,
                rightNode: node4,
                material: material,
                section: section,
                 includeSelfWeight: false
                );

            var span1 = new Span(
                leftNode: node1,
                rightNode: node3,
                material: material,
                section: section,
                 includeSelfWeight: false
                );

            var span3 = new Span(
                leftNode: node2,
                rightNode: node3,
                material: material,
                section: section,
                 includeSelfWeight: false
                );
            
            var spans = new Span[] { span1, span2, span3 };

              node1.ConcentratedForces.Add(new BendingMoment(20));
              node3.ConcentratedForces.Add(new NormalLoad(100));

            span1.ContinousLoads.Add(ContinuousShearLoad.Create(
                   startPosition: 0, startValue: -10, endPosition: span1.Length, endValue: -10));

             span2.PointLoads.Add(new ShearLoad(position: 3, value: 20));

            _frame = new Frame(spans, nodes);

            _frame.CalculationEngine.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_frame.Spans[0].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[0].LeftNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[0].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[0].RightNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[0].RightNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[0].RightNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[1].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[1].LeftNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[1].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[1].RightNode.HorizontalForce.Value, Is.EqualTo(-73.974).Within(0.001));
                Assert.That(_frame.Spans[1].RightNode.VerticalForce.Value, Is.EqualTo(30.642).Within(0.001));
                Assert.That(_frame.Spans[1].RightNode.BendingMoment.Value, Is.EqualTo(-270.049).Within(0.001));

                Assert.That(_frame.Spans[2].LeftNode.HorizontalForce.Value, Is.EqualTo(-36.026).Within(0.001));
                Assert.That(_frame.Spans[2].LeftNode.VerticalForce.Value, Is.EqualTo(69.358).Within(0.001));
                Assert.That(_frame.Spans[2].LeftNode.BendingMoment.Value, Is.EqualTo(-298.162).Within(0.001));

                Assert.That(_frame.Spans[2].RightNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[2].RightNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[2].RightNode.BendingMoment, Is.Null);
            });
        }

        [Test()]
        public void NodeDisplacementsCalculationsTest_Successful()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_frame.Spans[0].LeftNode.HorizontalDeflection.Value, Is.EqualTo(20.528).Within(0.001));
                Assert.That(_frame.Spans[0].LeftNode.VerticalDeflection.Value, Is.EqualTo(-0.034).Within(0.001));
                Assert.That(_frame.Spans[0].LeftNode.RightRotation.Value, Is.EqualTo(-0.005499).Within(0.000001));

                Assert.That(_frame.Spans[0].RightNode.LeftRotation.Value, Is.EqualTo(-0.003600).Within(0.000001));
                Assert.That(_frame.Spans[1].LeftNode.HorizontalDeflection.Value, Is.EqualTo(20.528).Within(0.001));
                Assert.That(_frame.Spans[1].LeftNode.VerticalDeflection.Value, Is.EqualTo(-0.034).Within(0.0001));
                Assert.That(_frame.Spans[1].LeftNode.RightRotation.Value, Is.EqualTo(-0.005499).Within(0.000001));

                Assert.That(_frame.Spans[1].RightNode.LeftRotation, Is.Null);
                Assert.That(_frame.Spans[1].RightNode.HorizontalDeflection, Is.Null);
                Assert.That(_frame.Spans[1].RightNode.VerticalDeflection, Is.Null);

                Assert.That(_frame.Spans[2].LeftNode.HorizontalDeflection, Is.Null);
                Assert.That(_frame.Spans[2].LeftNode.VerticalDeflection, Is.Null);
                Assert.That(_frame.Spans[2].LeftNode.RightRotation, Is.Null);

                Assert.That(_frame.Spans[2].RightNode.HorizontalDeflection.Value, Is.EqualTo(18.360).Within(0.001));
                Assert.That(_frame.Spans[2].RightNode.VerticalDeflection.Value, Is.EqualTo(-22.985).Within(0.001));
                Assert.That(_frame.Spans[2].RightNode.LeftRotation.Value, Is.EqualTo(-0.00360).Within(0.000001));

            });
        }
    }
}