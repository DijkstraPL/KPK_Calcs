using BeamStatica;
using BeamStatica.Beams;
using BeamStatica.Loads.ContinousLoads;
using BeamStatica.Loads.PointLoads;
using BeamStatica.Materials;
using BeamStatica.Nodes;
using BeamStatica.Sections;
using BeamStatica.Spans;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStaticaTests.BeamsTests
{
    [TestFixture(Description = "18.12.12-14")]
    public class BeamWithPointBendingMomentLoadTests
    {
        private Beam _beam;

        [SetUp]
        public void SetUpBeam()
        {
            var material = new Concrete(youngModulus: 30);
            var section = new RectangleSection(width: 300, height: 500);

            var node1 = new FixedNode();
            var node2 = new FixedNode();
            var nodes = new Node[] { node1, node2 };

            var span1 = new Span(
                leftNode: node1,
                length: 10,
                rightNode: node2,
                material: material,
                section: section
                );

             var spans = new Span[] { span1 };

            var pointLoad3 = new BendingMoment(value: 100, position: 8);
            span1.PointLoads.Add(pointLoad3);
            
            _beam = new Beam(spans, nodes);

            _beam.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.ShearForce.Value, Is.EqualTo(-9.6).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(28).Within(0.001));

            Assert.That(_beam.Spans[0].RightNode.ShearForce.Value, Is.EqualTo(9.6).Within(0.001));
            Assert.That(_beam.Spans[0].RightNode.BendingMoment.Value, Is.EqualTo(-32).Within(0.001));
        }

        [Test()]
        public void NodeDisplacementsCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.VerticalDeflection, Is.Null);
            Assert.That(_beam.Spans[0].LeftNode.RightRotation, Is.Null);

            Assert.That(_beam.Spans[0].RightNode.LeftRotation, Is.Null);
            Assert.That(_beam.Spans[0].RightNode.VerticalDeflection, Is.Null);
        }

        [Test()]
        [TestCase(0, -9.6)]
        [TestCase(2, -9.6)]
        [TestCase(3, -9.6)]
        [TestCase(5, -9.6)]
        [TestCase(7, -9.6)]
        [TestCase(10, -9.6)]
        public void ShearForceAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedShear = _beam.ShearResult.GetValue(position).Value;

            Assert.That(calculatedShear, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 28)]
        [TestCase(2, 8.8)]
        [TestCase(3, -0.8)]
        [TestCase(5, -20)]
        [TestCase(8, -48.8)]
        [TestCase(8.0001, 51.2)]
        [TestCase(10, 32)]
        public void BendingMomentAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedMoment = _beam.BendingMomentResult.GetValue(position).Value;

            Assert.That(calculatedMoment, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(2, 0.000393)]
        [TestCase(3, 0.000435)]
        [TestCase(4, 0.000375)]
        [TestCase(5, 0.000213)]
        [TestCase(7, -0.000418)]
        [TestCase(8, -0.000887)]
        [TestCase(10, 0)]
        public void RotationAtPositionCalculationsTest_Successful(double position, double result)
        {
            double rotation = _beam.RotationResult.GetValue(position).Value;

            Assert.That(rotation, Is.EqualTo(result).Within(0.000001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(2, 0.461)]
        [TestCase(3, 0.883)]
        [TestCase(4, 1.297)]
        [TestCase(5, 1.6)]
        [TestCase(7, 1.463)]
        [TestCase(8, 0.819)]
        [TestCase(9, 0.188)]
        [TestCase(10, 0)]
        public void VerticalDeflectionAtPositionCalculationsTest_Successful(double position, double result)
        {
            double deflection = _beam.VerticalDeflectionResult.GetValue(position).Value;

            Assert.That(deflection, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }
    }
}
