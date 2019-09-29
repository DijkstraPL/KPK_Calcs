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
    //[Explicit("Not ready")]
    public class ThreeSlabsInOnePointFrameTests
    {
        private Frame _frame;

        [SetUp]
        public void SetUpFrame()
        {
            var material = new Material(youngModulus: 210, density: 0, thermalExpansionCoefficient: 0);
            var section = new SectionProperties(area: 1500, momentOfInteria: 312500);

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
                leftNode: nodeX,
                rightNode: node2,
                material: material,
                section: section,
                 includeSelfWeight: false
                );

            var span3 = new Span(
                leftNode: nodeX,
                rightNode: node3,
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
                Assert.That(_frame.Spans[0].LeftNode.HorizontalForce.Value, Is.EqualTo(0.921993).Within(0.000001));
                Assert.That(_frame.Spans[0].LeftNode.VerticalForce.Value, Is.EqualTo(0.542354).Within(0.000001));
                Assert.That(_frame.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(0.608440).Within(0.000001));

                Assert.That(_frame.Spans[0].RightNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[0].RightNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[0].RightNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[1].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[1].LeftNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[1].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[1].RightNode.HorizontalForce.Value, Is.EqualTo(0.655601).Within(0.000001));
                Assert.That(_frame.Spans[1].RightNode.VerticalForce.Value, Is.EqualTo(8.054708).Within(0.000001));
                Assert.That(_frame.Spans[1].RightNode.BendingMoment.Value, Is.EqualTo(0.783685).Within(0.000001));

                Assert.That(_frame.Spans[2].LeftNode.HorizontalForce, Is.Null);
                Assert.That(_frame.Spans[2].LeftNode.VerticalForce, Is.Null);
                Assert.That(_frame.Spans[2].LeftNode.BendingMoment, Is.Null);

                Assert.That(_frame.Spans[2].RightNode.HorizontalForce.Value, Is.EqualTo(-11.577594).Within(0.000001));
                Assert.That(_frame.Spans[2].RightNode.VerticalForce.Value, Is.EqualTo(6.402937).Within(0.000001));
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
                Assert.That(_frame.Spans[0].LeftNode.RightRotation, Is.Null);

                Assert.That(_frame.Spans[0].RightNode.LeftRotation.Value, Is.EqualTo(-0.000003).Within(0.000001));
                Assert.That(_frame.Spans[0].RightNode.HorizontalDeflection.Value, Is.EqualTo(0.001103).Within(0.000001));
                Assert.That(_frame.Spans[0].RightNode.VerticalDeflection.Value, Is.EqualTo(-0.001023).Within(0.000001));

                Assert.That(_frame.Spans[1].LeftNode.HorizontalDeflection.Value, Is.EqualTo(0.001103).Within(0.000001));
                Assert.That(_frame.Spans[1].LeftNode.VerticalDeflection.Value, Is.EqualTo(-0.001023).Within(0.000001));
                Assert.That(_frame.Spans[1].LeftNode.RightRotation.Value, Is.EqualTo(-0.000003).Within(0.000001));

                Assert.That(_frame.Spans[1].RightNode.LeftRotation, Is.Null);
                Assert.That(_frame.Spans[1].RightNode.HorizontalDeflection, Is.Null);
                Assert.That(_frame.Spans[1].RightNode.VerticalDeflection, Is.Null);

                Assert.That(_frame.Spans[2].LeftNode.HorizontalDeflection.Value, Is.EqualTo(0.001103).Within(0.000001));
                Assert.That(_frame.Spans[2].LeftNode.VerticalDeflection.Value, Is.EqualTo(-0.001023).Within(0.000001));
                Assert.That(_frame.Spans[2].LeftNode.RightRotation.Value, Is.EqualTo(-0.000003).Within(0.000001));

                Assert.That(_frame.Spans[2].RightNode.LeftRotation.Value, Is.EqualTo(0.000006).Within(0.000001));
                Assert.That(_frame.Spans[2].RightNode.HorizontalDeflection, Is.Null);
                Assert.That(_frame.Spans[2].RightNode.VerticalDeflection, Is.Null);
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