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
    public class BeamWithSupportWithHingeTests
    {
        private Beam _beam;

        [SetUp]
        public void SetUpBeam()
        {
            var material = new Material() { YoungModulus = 30 };
            var section = new RectangleSection(width: 300, height: 500);

            var node1 = new FixedNode();
            var node2 = new SupportedNodeWithHinge();
            var node3 = new SupportedNode();

            var nodes = new Node[] { node1, node2, node3 };
           
            var span1 = new Span(
                leftNode: node1,
                length: 10,
                rightNode: node2,
                material: material,
                section: section
                );

            var span2 = new Span(
                leftNode: node2,
                length: 5,
                rightNode: node3,
                material: material,
                section: section
                );

             var spans = new Span[] { span1, span2 };

            var pointLoad1 = new NormalLoad(value: 150, position: 4);
            span1.PointLoads.Add(pointLoad1);
            var pointLoad2 = new NormalLoad(value: -100, position: 4);
            span2.PointLoads.Add(pointLoad2);
            var pointLoad3 = new BendingMoment(value: 100, position: 8);
            span1.PointLoads.Add(pointLoad3);

            var startLoad1 = new ShearLoad(value: -10, position: 0);
            var endLoad1 = new ShearLoad(value: -10, position: 10);
            span1.ContinousLoads.Add(new ContinousLoad(startLoad1, endLoad1));
            
            _beam = new Beam(spans, nodes);

            _beam.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.NormalForce.Value, Is.EqualTo(-90).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.ShearForce.Value, Is.EqualTo(48.1).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-81).Within(0.001));

            Assert.That(_beam.Spans[1].LeftNode.NormalForce.Value, Is.EqualTo(-40).Within(0.001));
            Assert.That(_beam.Spans[1].LeftNode.ShearForce.Value, Is.EqualTo(51.9).Within(0.001));
            Assert.That(_beam.Spans[1].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[1].RightNode.NormalForce.Value, Is.EqualTo(80).Within(0.001));
            Assert.That(_beam.Spans[1].RightNode.ShearForce.Value, Is.EqualTo(0).Within(0.001));
            Assert.That(_beam.Spans[1].RightNode.BendingMoment, Is.Null);
        }

        [Test()]
        [TestCase(0, -90)]
        [TestCase(2, -90)]
        [TestCase(3, -90)]
        [TestCase(4, -90)]
        [TestCase(4.0001, 60)]
        [TestCase(5, 60)]
        [TestCase(7, 60)]
        [TestCase(10, 60)]
        [TestCase(10.0001, 20)]
        [TestCase(12, 20)]
        [TestCase(14, 20)]
        [TestCase(14.0001, -80)]
        [TestCase(15, -80)]
        public void NormalForceAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedNormalForce = _beam.NormalForceResult.GetValue(position).Value;

            Assert.That(calculatedNormalForce, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 48.1)]
        [TestCase(2, 28.10)]
        [TestCase(3, 18.10)]
        [TestCase(4, 8.10)]
        [TestCase(5, -1.9)]
        [TestCase(7, -21.9)]
        [TestCase(10, -51.9)]
        [TestCase(10.0001, 0)]
        [TestCase(12, 0)]
        [TestCase(14, 0)]
        [TestCase(15, 0)]
        public void ShearForceAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedShear = _beam.ShearResult.GetValue(position).Value;

            Assert.That(calculatedShear, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, -81)]
        [TestCase(2, -4.8)]
        [TestCase(3, 18.3)]
        [TestCase(4, 31.399)]
        [TestCase(5, 34.5)]
        [TestCase(7, 10.7)]
        [TestCase(8, -16.2)]
        [TestCase(8.00001, 83.8)]
        [TestCase(10, 0)]
        [TestCase(12, 0)]
        [TestCase(14, 0)]
        [TestCase(15, 0)]
        public void BendingMomentAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedMoment = _beam.BendingMomentResult.GetValue(position).Value;

            Assert.That(calculatedMoment, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(2, -0.000844)]
        [TestCase(3, -0.000763)]
        [TestCase(4, -0.000489)]
        [TestCase(5, -0.000129)]
        [TestCase(7, 0.000424)]
        [TestCase(8, 0.000404)]
        [TestCase(9.9999, 0.001369)]
        [TestCase(10, 0)]
        [TestCase(10.0001, 0)]
        [TestCase(12, 0)]
        [TestCase(14, 0)]
        [TestCase(15, 0)]
        public void RotationAtPositionCalculationsTest_Successful(double position, double result)
        {
            double rotation = _beam.RotationResult.GetValue(position).Value;

            Assert.That(rotation, Is.EqualTo(result).Within(0.000001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(2, 0.04)]
        [TestCase(3, 0.06)]
        [TestCase(4, 0.08)]
        [TestCase(5, 0.067)]
        [TestCase(7, 0.04)]
        [TestCase(8, 0.027)]
        [TestCase(10, 0)]
        [TestCase(12, -0.009)]
        [TestCase(14, -0.018)]
        [TestCase(15, 0)]
        public void HorizontalDeflectionAtPositionCalculationsTest_Successful(double position, double result)
        {
            double deflection = _beam.HorizontalDeflectionResult.GetValue(position).Value;

            Assert.That(deflection, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(2, -1.115)]
        [TestCase(3, -1.939)]
        [TestCase(4, -2.577)]
        [TestCase(5, -2.889)]
        [TestCase(7, -2.509)]
        [TestCase(8, -2.071)]
        [TestCase(10, 0)]
        [TestCase(12, 0)]
        [TestCase(14, 0)]
        [TestCase(15, 0)]
        public void VerticalDeflectionAtPositionCalculationsTest_Successful(double position, double result)
        {
            double deflection = _beam.VerticalDeflectionResult.GetValue(position).Value;

            Assert.That(deflection, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }
    }
}
