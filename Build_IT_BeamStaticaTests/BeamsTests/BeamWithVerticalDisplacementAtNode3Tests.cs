using Build_IT_BeamStatica.Beams;
using Build_IT_BeamStatica.Loads.PointLoads;
using Build_IT_BeamStatica.Materials;
using Build_IT_BeamStatica.Nodes;
using Build_IT_BeamStatica.Sections;
using Build_IT_BeamStatica.Spans;
using NUnit.Framework;

namespace BeamStaticaTests.BeamsTests
{
    [TestFixture(Description = "18.12.12-01")]
    public class BeamWithVerticalDisplacementAtNode3Tests
    {
        private Beam _beam;

        [SetUp]
        public void SetUpBeam()
        {
            var material = new Concrete(youngModulus: 30, withReinforcement: false);
            var section1 = new RectangleSection(width: 300, height: 500);
            var section2 = new RectangleSection(width: 600, height: 500);

            var node1 = new FixedNode();
            var node2 = new SupportedNode();
            var node3 = new PinNode();

            var nodes = new Node[] { node1, node2, node3 };

            var span1 = new Span(
                leftNode: node1,
                length: 8,
                rightNode: node2,
                material: material,
                section: section1,
                includeSelfWeight: false
                );

            var span2 = new Span(
                leftNode: node2,
                length: 8,
                rightNode: node3,
                material: material,
                section: section2,
                includeSelfWeight: false
                );
            
            var spans = new Span[] { span1, span2 };

            node2.ConcentratedForces.Add(new VerticalDisplacement(value: -10));

            _beam = new Beam(spans, nodes, includeSelfWeight: false);

            _beam.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.ShearForce.Value, Is.EqualTo(21.973).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-87.891).Within(0.001));

            Assert.That(_beam.Spans[1].LeftNode.ShearForce.Value, Is.EqualTo(-32.959).Within(0.001));
            Assert.That(_beam.Spans[1].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[1].RightNode.ShearForce.Value, Is.EqualTo(10.986).Within(0.001));
            Assert.That(_beam.Spans[1].RightNode.BendingMoment, Is.Null);
        }
        
        [Test()]
        [TestCase(0, 21.973)]
        [TestCase(3, 21.973)]
        [TestCase(5, 21.973)]
        [TestCase(8, 21.973)]
        [TestCase(8.0001, -10.986)]
        [TestCase(10, -10.986)]
        [TestCase(13, -10.986)]
        [TestCase(16, -10.986)]
        public void ShearForceAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedShear = _beam.ShearResult.GetValue(position).Value;

            Assert.That(calculatedShear, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, -87.891)]
        [TestCase(3, -21.973)]
        [TestCase(5, 21.973)]
        [TestCase(8, 87.8911)]
        [TestCase(10, 65.918)]
        [TestCase(13, 32.959)]
        [TestCase(16, 0)]
        public void BendingMomentAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedMoment = _beam.BendingMomentResult.GetValue(position).Value;

            Assert.That(calculatedMoment, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(3, -0.001758)]
        [TestCase(5, -0.001758)]
        [TestCase(8, 0)]
        [TestCase(10, 0.000820)]
        [TestCase(13, 0.001611)]
        [TestCase(16, 0.001875)]
        public void RotationAtPositionCalculationsTest_Successful(double position, double result)
        {
            double rotation = _beam.RotationResult.GetValue(position).Value;

            Assert.That(rotation, Is.EqualTo(result).Within(0.000001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(3, -3.164)]
        [TestCase(5, -6.836)]
        [TestCase(8, -10)]
        [TestCase(10, -9.141)]
        [TestCase(13, -5.361)]
        [TestCase(16, 0)]
        public void VerticalDeflectionAtPositionCalculationsTest_Successful(double position, double result)
        {
            double deflection = _beam.VerticalDeflectionResult.GetValue(position).Value;

            Assert.That(deflection, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }
    }
}
