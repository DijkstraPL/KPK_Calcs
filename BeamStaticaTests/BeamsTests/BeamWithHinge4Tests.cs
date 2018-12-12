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
using BeamStatica.Loads.ContinousLoads;
using BeamStatica.Beams;

namespace BeamStaticaTests.BeamsTests
{
    [TestFixture(Description = "18.12.12-10")]
    public class BeamWithHinge4Tests
    {
        private Beam _beam;

        [SetUp]
        public void SetUpBeam()
        {
            var material1 = new Material(youngModulus: 27);
            var material2 = new Material(youngModulus: 37);
            var section = new RectangleSection(width: 300, height: 500);

            var node1 = new FixedNode();
            var node2 = new Hinge();
            var node3 = new FixedNode();

            var nodes = new Node[] { node1, node2, node3 };

            var span1 = new Span(
                leftNode: node1,
                length: 4,
                rightNode: node2,
                material: material1,
                section: section
                );

            var span2 = new Span(
                leftNode: node2,
                length: 4,
                rightNode: node3,
                material: material2,
                section: section
                );

            var spans = new Span[] { span1, span2 };

            node2.ConcentratedForces.Add(new ShearLoad(value: -20));
            span1.ContinousLoads.Add(new ContinousShearLoad(
                new ShearLoad(value: -9, position: 0), 
                new ShearLoad(value: -9, position: 4)));

            _beam = new Beam(spans, nodes);

            _beam.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.ShearForce.Value, Is.EqualTo(36.633).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-74.531).Within(0.001));

            Assert.That(_beam.Spans[1].LeftNode.ShearForce, Is.Null);
            Assert.That(_beam.Spans[1].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[1].RightNode.ShearForce.Value, Is.EqualTo(19.367).Within(0.001));
            Assert.That(_beam.Spans[1].RightNode.BendingMoment.Value, Is.EqualTo(77.469).Within(0.001));
        }

        [Test()]
        public void NodeDisplacementsCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.VerticalDeflection, Is.Null);
            Assert.That(_beam.Spans[0].LeftNode.RightRotation, Is.Null);

            Assert.That(_beam.Spans[0].RightNode.LeftRotation.Value, Is.EqualTo(-0.001198).Within(0.000001));
            Assert.That(_beam.Spans[1].LeftNode.VerticalDeflection.Value, Is.EqualTo(-3.573).Within(0.001));
            Assert.That(_beam.Spans[1].LeftNode.RightRotation.Value, Is.EqualTo(0.00134).Within(0.000001));

            Assert.That(_beam.Spans[1].RightNode.LeftRotation, Is.Null);
            Assert.That(_beam.Spans[1].RightNode.VerticalDeflection, Is.Null);
        }

        [Test()]
        [TestCase(0, 36.633)]
        [TestCase(3, 9.633)]
        [TestCase(3.9999999, 0.633)]
        [TestCase(4, 0.633)]
        [TestCase(4.01, -19.367)]
        [TestCase(7, -19.367)]
        [TestCase(8, -19.367)]
        public void ShearForceAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedShear = _beam.ShearResult.GetValue(position).Value;

            Assert.That(calculatedShear, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, -74.531)]
        [TestCase(2, -19.266)]
        [TestCase(3, -5.132)]
        [TestCase(4, 0)]
        [TestCase(6, -38.734)]
        [TestCase(7, -58.102)]
        [TestCase(8, -77.469)]
        public void BendingMomentAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedMoment = _beam.BendingMomentResult.GetValue(position).Value;

            Assert.That(calculatedMoment, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(3, -0.001176)]
        [TestCase(3.99999, -0.001198)]
        [TestCase(4, 0.00134)]
        [TestCase(4.00001, 0.00134)]
        [TestCase(6, 0.001005)]
        [TestCase(8, 0)]
        public void RotationAtPositionCalculationsTest_Successful(double position, double result)
        {
            double rotation = _beam.RotationResult.GetValue(position).Value;

            Assert.That(rotation, Is.EqualTo(result).Within(0.000001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(2, -1.259)]
        [TestCase(4, -3.573)]
        [TestCase(5, -2.261)]
        [TestCase(7, -0.307)]
        [TestCase(8, 0)]
        public void VerticalDeflectionAtPositionCalculationsTest_Successful(double position, double result)
        {
            double deflection = _beam.VerticalDeflectionResult.GetValue(position).Value;

            Assert.That(deflection, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }
    }
}
