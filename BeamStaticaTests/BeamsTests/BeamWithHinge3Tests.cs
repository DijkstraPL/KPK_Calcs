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
    public class BeamWithHinge3Tests
    {
        private Beam _beam;

        [SetUp]
        public void SetUpBeam()
        {
            var material = new Material() { YoungModulus = 30 };
            var section = new RectangleSection(width: 300, height: 500);

            var node1 = new FixedNode();
            var node2 = new Hinge();
            var node3 = new FixedNode();

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

            span1.PointLoads.Add(new ShearLoad(value: -100, position: 3));

            _beam = new Beam(spans, nodes);

            _beam.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.ShearForce.Value, Is.EqualTo(89.2).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-192).Within(0.001));

            Assert.That(_beam.Spans[1].LeftNode.ShearForce, Is.Null);
            Assert.That(_beam.Spans[1].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[1].RightNode.ShearForce.Value, Is.EqualTo(10.8).Within(0.001));
            Assert.That(_beam.Spans[1].RightNode.BendingMoment.Value, Is.EqualTo(54).Within(0.001));
        }

      
    }
}
