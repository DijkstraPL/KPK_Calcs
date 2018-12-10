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
    [TestFixture]
    public class BeamWithTriangleLoad1Tests
    {
        private Beam _beam;

        [SetUp]
        public void SetUpBeam()
        {
            var material = new Material() { YoungModulus = 30 };
            var section1 = new RectangleSection(width: 300, height: 500);
            var section2 = new RectangleSection(width: 200, height: 300);

            var node1 = new FixedNode();
            var node2 = new FreeNode();
            var node3 = new SupportedNode();
            var node4 = new SupportedNode();

            var nodes = new Node[] { node1, node2, node3, node4 };

            var span1 = new Span(
                leftNode: node1,
                length: 6,
                rightNode: node2,
                material: material,
                section: section1
                );

            var span2 = new Span(
                leftNode: node2,
                length: 4,
                rightNode: node3,
                material: material,
                section: section2
                );

            var span3 = new Span(
                leftNode: node3,
                length: 10,
                rightNode: node4,
                material: material,
                section: section2
                );

            var spans = new Span[] { span1, span2, span3 };
            
            node2.ConcentratedForces.Add(new ShearLoad(value: -200));
            node3.ConcentratedForces.Add(new BendingMoment(value: 90));

            var startLoad = new ShearLoad(value: -30, position: 0);
            var endLoad = new ShearLoad(value: 0, position: 6);
            span1.ContinousLoads.Add(new ContinousLoad(startLoad, endLoad));

            var pointLoad = new ShearLoad(value: -150, position: 5);
            span3.PointLoads.Add(pointLoad);

            _beam = new Beam(spans, nodes);

            _beam.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.ShearForce.Value, Is.EqualTo(155.952).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-352.225).Within(0.001));

            Assert.That(_beam.Spans[1].LeftNode.ShearForce, Is.Null);
            Assert.That(_beam.Spans[1].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[2].LeftNode.ShearForce.Value, Is.EqualTo(231.318).Within(0.001));
            Assert.That(_beam.Spans[2].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[2].RightNode.ShearForce.Value, Is.EqualTo(52.730).Within(0.001));
            Assert.That(_beam.Spans[2].RightNode.BendingMoment, Is.Null);
        }

        [Test()]
        [TestCase(0, 155.952)]
        [TestCase(1, 128.452)]
        [TestCase(3, 88.452)]
        [TestCase(6, 65.952)]
        [TestCase(6.00001, -134.048)]
        [TestCase(8, -134.048)]
        [TestCase(10, -134.048)]
        [TestCase(10.00001, 97.270)]
        [TestCase(15, 97.270)]
        [TestCase(15.00001, -52.730)]
        [TestCase(20, -52.730)]
        public void ShearForceAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedShear = _beam.ShearResult.GetValue(position).Value;

            Assert.That(calculatedShear, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, -352.225)]
        [TestCase(1, -210.439)]
        [TestCase(3, 3.132)]
        [TestCase(6, 223.489)]
        [TestCase(8, -44.607)]
        [TestCase(10, -312.702)]
        [TestCase(10.00001, -222.702)]
        [TestCase(15, 263.649)]
        [TestCase(20, 0)]
        public void BendingMomentAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedMoment = _beam.BendingMomentResult.GetValue(position).Value;

            Assert.That(calculatedMoment, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(1, -0.002976)]
        [TestCase(2, -0.004578)]
        [TestCase(3, -0.005045)]
        [TestCase(5, -0.003269)]
        [TestCase(6, -0.001240)]
        [TestCase(8, 0.012011)]
        [TestCase(10, -0.014456)]
        [TestCase(15, -0.006874)]
        [TestCase(20, 0.041950)]
        public void RotationAtPositionCalculationsTest_Successful(double position, double result)
        {
            double rotation = _beam.RotationResult.GetValue(position).Value;

            Assert.That(rotation, Is.EqualTo(result).Within(0.000001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(1, -1.614)]
        [TestCase(2, -5.495)]
        [TestCase(3, -10.393)]
        [TestCase(5, -19.252)]
        [TestCase(6, -21.565)]
        [TestCase(8, -4.174)]
        [TestCase(10, 0)]
        [TestCase(15, -128.379)]
        [TestCase(20, 0)]
        public void DeflectionAtPositionCalculationsTest_Successful(double position, double result)
        {
            double deflection = _beam.VerticalDeflectionResult.GetValue(position).Value;

            Assert.That(deflection, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }
    }
}
