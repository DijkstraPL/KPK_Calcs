using BeamStatica;
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
    [TestFixture]
    public class BeamWithMultipleSpansTests
    {
        private Beam _beam;

        [SetUp]
        public void SetUpBeam()
        {
            var material = new Material() { YoungModulus = 30 };
            var section = new RectangleSection(width: 300, height: 500);

            var node1 = new FixedNode();
            var node2 = new FreeNode();
            var node3 = new FreeNode();
            var node4 = new SupportedNode();
            var node5 = new SupportedNode();

            var nodes = new Node[] { node1, node2, node3, node4, node5 };

            var span1 = new Span(
                leftNode: node1,
                length: 5,
                rightNode: node2,
                material: material,
                section: section
                );

            var span2 = new Span(
                leftNode: node2,
                length: 7,
                rightNode: node3,
                material: material,
                section: section
                );

            var span3 = new Span(
                leftNode: node3,
                length: 5,
                rightNode: node4,
                material: material,
                section: section
                );

            var span4 = new Span(
                leftNode: node4,
                length: 3,
                rightNode: node5,
                material: material,
                section: section
                );

            var spans = new Span[] { span1, span2, span3, span4 };

            node2.ConcentratedForces.Add(new BendingMoment(value: 56));
            node3.ConcentratedForces.Add(new ShearLoad(value: 100));

            var startLoad1 = new ShearLoad(value: -15, position: 1);
            var endLoad1 = new ShearLoad(value: -25, position: 5);
            span1.ContinousLoads.Add(new ContinousLoad(startLoad1, endLoad1));

            var startLoad2 = new ShearLoad(value: -25, position: 0);
            var endLoad2 = new ShearLoad(value: 25, position: 4);
            span3.ContinousLoads.Add(new ContinousLoad(startLoad2, endLoad2));

            var pointLoad1 = new ShearLoad(value: -150, position: 3.4);
            span2.PointLoads.Add(pointLoad1);

            var pointLoad2 = new ShearLoad(value: -50, position: 1.5);
            span4.PointLoads.Add(pointLoad2);

            _beam = new Beam(spans, nodes);

            _beam.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.ShearForce.Value, Is.EqualTo(128.808).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-410.645).Within(0.001));

            Assert.That(_beam.Spans[1].LeftNode.ShearForce, Is.Null);
            Assert.That(_beam.Spans[1].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[2].LeftNode.ShearForce, Is.Null);
            Assert.That(_beam.Spans[2].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[3].LeftNode.ShearForce.Value, Is.EqualTo(68.940).Within(0.001));
            Assert.That(_beam.Spans[3].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[3].RightNode.ShearForce.Value, Is.EqualTo(-17.748).Within(0.001));
            Assert.That(_beam.Spans[3].RightNode.BendingMoment, Is.Null);
        }
        
        [Test()]
        [TestCase(0, 128.808)]
        [TestCase(2, 112.558)]
        [TestCase(4, 72.558)]
        [TestCase(5, 48.808)]
        [TestCase(7, 48.808)]
        [TestCase(8.3999, 48.808)]
        [TestCase(8.4001, -101.192)]
        [TestCase(10, -101.192)]
        [TestCase(12, -101.192)]
        [TestCase(12.0001, -1.195)]
        [TestCase(14, -26.192)]
        [TestCase(17, -1.192)]
        [TestCase(17.0001, 67.748)]
        [TestCase(19, 17.748)]
        [TestCase(20, 17.748)]
        public void ShearForceAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedShear = _beam.ShearResult.GetValue(position).Value;

            Assert.That(calculatedShear, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, -410.645)]
        [TestCase(2, -160.945)]
        [TestCase(4, 25.837)]
        [TestCase(4.9999, 86.723)]
        [TestCase(5, 86.728)]
        [TestCase(5.0001, 142.733)]
        [TestCase(7, 240.344)]
        [TestCase(8.4, 308.675)]
        [TestCase(10, 146.768)]
        [TestCase(12, -55.616)]
        [TestCase(14, -91.334)]
        [TestCase(17, -128.243)]
        [TestCase(19,-17.748)]
        [TestCase(20, 0)]
        public void BendingMomentAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedMoment = _beam.BendingMomentResult.GetValue(position).Value;

            Assert.That(calculatedMoment, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(2, -0.006040)]
        [TestCase(4, -0.007339)]
        [TestCase(5, -0.006718)]
        [TestCase(7, -0.002632)]
        [TestCase(8, 0.000192)]
        [TestCase(10, 0.005354)]
        [TestCase(12, 0.006326)]
        [TestCase(14, 0.004848)]
        [TestCase(17, 0.001068)]
        [TestCase(19, -0.000289)]
        [TestCase(20, -0.000384)]
        public void RotationAtPositionCalculationsTest_Successful(double position, double result)
        {
            double rotation = _beam.RotationResult.GetValue(position).Value;

            Assert.That(rotation, Is.EqualTo(result).Within(0.000001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(2, -6.935)]
        [TestCase(4, -20.980)]
        [TestCase(5, -28.063)]
        [TestCase(7, -37.759)]
        [TestCase(8, -39.022)]
        [TestCase(10, -32.867)]
        [TestCase(12, -20.467)]
        [TestCase(14, -9.160)]
        [TestCase(17, 0)]
        [TestCase(19, 0.352)]
        [TestCase(20, 0)]
        public void DeflectionAtPositionCalculationsTest_Successful(double position, double result)
        {
            double deflection = _beam.DeflectionResult.GetValue(position).Value;

            Assert.That(deflection, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }
    }
}
