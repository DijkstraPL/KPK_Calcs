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
    public class BeamWithDoubleHingeTests
    {
        private Beam _beam;

        [SetUp]
        public void SetUpBeam()
        {
            var material = new Material() { YoungModulus = 33 };
            var section = new RectangleSection(width: 300, height: 500);

            var node1 = new FixedNode();
            var node2 = new Hinge();
            var node3 = new Hinge();
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

           // node2.ConcentratedForces.Add(new BendingMoment(value: 56));
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
            Assert.That(_beam.Spans[0].LeftNode.ShearForce.Value, Is.EqualTo(150.214).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-604.405).Within(0.001));

            Assert.That(_beam.Spans[1].LeftNode.ShearForce, Is.Null);
            Assert.That(_beam.Spans[1].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[2].LeftNode.ShearForce, Is.Null);
            Assert.That(_beam.Spans[2].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[3].LeftNode.ShearForce.Value, Is.EqualTo(-6.683).Within(0.001));
            Assert.That(_beam.Spans[3].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[3].RightNode.ShearForce.Value, Is.EqualTo(36.468).Within(0.001));
            Assert.That(_beam.Spans[3].RightNode.BendingMoment, Is.Null);
        }
        
    }
}
