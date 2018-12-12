using BeamStatica;
using BeamStatica.Beams;
using BeamStatica.Loads.ContinousLoads;
using BeamStatica.Loads.PointLoads;
using BeamStatica.Materials;
using BeamStatica.Nodes;
using BeamStatica.Sections;
using BeamStatica.Spans;
using NUnit.Framework;

namespace BeamStaticaTests.BeamsTests
{
    [TestFixture(Description = "18.12.12-02")]
    public class BeamWithVerticalDisplacementAtNode2Tests
    {
        private Beam _beam;

        [SetUp]
        public void SetUpBeam()
        {
            var material = new Material(youngModulus: 30);
            var section1 = new RectangleSection(width:300, height: 500);
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
                section: section1
                );

            var span2 = new Span(
                leftNode: node2,
                length: 8,
                rightNode: node3,
                material: material,
                section: section2
                );
            
            var spans = new Span[] { span1, span2 };

            node2.ConcentratedForces.Add(new VerticalDisplacement(value: -10));

            var pointLoad = new ShearLoad(value: -40, position: 4);
            span2.PointLoads.Add(pointLoad);

            var startLoad = new ShearLoad(value: -6, position: 0);
            var endLoad = new ShearLoad(value: -6, position: 8);
            span1.ContinousLoads.Add(new ContinousLoad(startLoad, endLoad));

            _beam = new Beam(spans, nodes);

            _beam.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.ShearForce.Value, Is.EqualTo(43.873).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-114.291).Within(0.001));

            Assert.That(_beam.Spans[1].LeftNode.ShearForce.Value, Is.EqualTo(18.541).Within(0.001));
            Assert.That(_beam.Spans[1].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[1].RightNode.ShearForce.Value, Is.EqualTo(25.586).Within(0.001));
            Assert.That(_beam.Spans[1].RightNode.BendingMoment, Is.Null);
        }

        [Test()]
        [TestCase(0, 43.873)]
        [TestCase(3, 25.873)]
        [TestCase(5, 13.873)]
        [TestCase(8, -4.127)]
        [TestCase(8.0001, 14.414)]
        [TestCase(10, 14.414)]
        [TestCase(12, 14.414)]
        [TestCase(12.0001, -25.586)]
        [TestCase(13, -25.586)]
        [TestCase(16, -25.586)]
        public void ShearForceAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedShear = _beam.ShearResult.GetValue(position).Value;

            Assert.That(calculatedShear, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, -114.291)]
        [TestCase(3, -9.672)]
        [TestCase(5, 30.073)]
        [TestCase(8, 44.691)]
        [TestCase(10, 73.518)]
        [TestCase(12, 102.345)]
        [TestCase(13, 76.759)]
        [TestCase(16, 0)]
        public void BendingMomentAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedMoment = _beam.BendingMomentResult.GetValue(position).Value;

            Assert.That(calculatedMoment, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(3, -0.001839)]
        [TestCase(5, -0.001579)]
        [TestCase(8, -0.000239)]
        [TestCase(10, 0.000392)]
        [TestCase(13, 0.001807)]
        [TestCase(16, 0.002421)]
        public void RotationAtPositionCalculationsTest_Successful(double position, double result)
        {
            double rotation = _beam.RotationResult.GetValue(position).Value;

            Assert.That(rotation, Is.EqualTo(result).Within(0.000001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(3, -3.596)]
        [TestCase(5, -7.156)]
        [TestCase(8, -10)]
        [TestCase(10, -9.899)]
        [TestCase(13, -6.649)]
        [TestCase(16, 0)]
        public void VerticalDeflectionAtPositionCalculationsTest_Successful(double position, double result)
        {
            double deflection = _beam.VerticalDeflectionResult.GetValue(position).Value;

            Assert.That(deflection, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }
    }
}
