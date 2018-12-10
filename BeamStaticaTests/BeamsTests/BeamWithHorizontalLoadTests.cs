using BeamStatica;
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
    [TestFixture]
    public class BeamWithHorizontalLoadTests
    {
        private Beam _beam;

        [SetUp]
        public void SetUpBeam()
        {
            var material = new Material() { YoungModulus = 30 };
            var section = new RectangleSection(width: 300, height: 500);

            var node1 = new FixedNode();
            var node2 = new FreeNode();

            var nodes = new Node[] { node1, node2 };

            var span1 = new Span(
                leftNode: node1,
                length: 10,
                rightNode: node2,
                material: material,
                section: section
                );

            var spans = new Span[] { span1 };

            var pointLoad1 = new NormalLoad(value: 100, position: 3);
            span1.PointLoads.Add(pointLoad1);
            var pointLoad2 = new ShearLoad(value: -100, position: 5);
            span1.PointLoads.Add(pointLoad2);

            node2.ConcentratedForces.Add(new NormalLoad(value: 150));

            _beam = new Beam(spans, nodes);

            _beam.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.NormalForce.Value, Is.EqualTo(-250).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.ShearForce.Value, Is.EqualTo(100).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-500).Within(0.001));

            Assert.That(_beam.Spans[0].RightNode.NormalForce, Is.Null);
            Assert.That(_beam.Spans[0].RightNode.ShearForce, Is.Null);
            Assert.That(_beam.Spans[0].RightNode.BendingMoment, Is.Null);
        }

        [Test()]
        [TestCase(0, -250)]
        [TestCase(2, -250)]
        [TestCase(3, -250)]
        [TestCase(3.0001, -150)]
        [TestCase(5, -150)]
        [TestCase(7, -150)]
        [TestCase(10, -150)]
        public void NormalForceAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedNormalForce = _beam.NormalForceResult.GetValue(position).Value;

            Assert.That(calculatedNormalForce, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 100)]
        [TestCase(2, 100)]
        [TestCase(3, 100)]
        [TestCase(5, 100)]
        [TestCase(5.0001, 0)]
        [TestCase(7, 0)]
        [TestCase(10, 0)]
        public void ShearForceAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedShear = _beam.ShearResult.GetValue(position).Value;

            Assert.That(calculatedShear, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, -500)]
        [TestCase(2, -300)]
        [TestCase(3, -200)]
        [TestCase(5, 0)]
        [TestCase(7, 0)]
        [TestCase(10, 0)]
        public void BendingMomentAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedMoment = _beam.BendingMomentResult.GetValue(position).Value;

            Assert.That(calculatedMoment, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(2, -0.008533)]
        [TestCase(3, -0.0112)]
        [TestCase(4, -0.0128)]
        [TestCase(5, -0.013333)]
        [TestCase(7, -0.013333)]
        [TestCase(10, -0.013333)]
        public void RotationAtPositionCalculationsTest_Successful(double position, double result)
        {
            double rotation = _beam.RotationResult.GetValue(position).Value;

            Assert.That(rotation, Is.EqualTo(result).Within(0.000001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(2, -9.244)]
        [TestCase(3, -19.2)]
        [TestCase(4, -31.289)]
        [TestCase(5, -44.444)]
        [TestCase(7, -71.111)]
        [TestCase(10, -111.111)]
        public void DeflectionAtPositionCalculationsTest_Successful(double position, double result)
        {
            double deflection = _beam.DeflectionResult.GetValue(position).Value;

            Assert.That(deflection, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }
    }
}
