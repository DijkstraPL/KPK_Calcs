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
    public class BeamWithHinge2Tests
    {
        private Beam _beam;

        [SetUp]
        public void SetUpBeam()
        {
            var material = new Material() { YoungModulus = 30 };
            var section = new RectangleSection(width: 300, height: 500);

            var node1 = new FixedNode();
            var node2 = new Hinge();
            var node3 = new SupportedNode();
            var node4 = new SupportedNode();

            var nodes = new Node[] { node1, node2, node3, node4 };

            var span1 = new Span(
                leftNode: node1,
                length: 3,
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

            var spans = new Span[] { span1, span2, span3 };

            var startLoad1 = new ShearLoad(value: -10, position: 0);
            var endLoad1 = new ShearLoad(value: -10, position: 3);
            span1.ContinousLoads.Add(new ContinousLoad(startLoad1, endLoad1));

            var startLoad2 = new ShearLoad(value: -10, position: 0);
            var endLoad2 = new ShearLoad(value: -10, position: 7);
            span2.ContinousLoads.Add(new ContinousLoad(startLoad2, endLoad2));

            var startLoad3 = new ShearLoad(value: -10, position: 0);
            var endLoad3 = new ShearLoad(value: -10, position: 5);
            span3.ContinousLoads.Add(new ContinousLoad(startLoad3, endLoad3));

            var pointLoad = new ShearLoad(value: -100, position: 2.5);
            span3.PointLoads.Add(pointLoad);

            _beam = new Beam(spans, nodes);

            _beam.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.ShearForce.Value, Is.EqualTo(50.976).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-107.927).Within(0.001));

            Assert.That(_beam.Spans[1].LeftNode.ShearForce, Is.Null);
            Assert.That(_beam.Spans[1].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[2].LeftNode.ShearForce.Value, Is.EqualTo(143.659).Within(0.001));
            Assert.That(_beam.Spans[2].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[2].RightNode.ShearForce.Value, Is.EqualTo(55.366).Within(0.001));
            Assert.That(_beam.Spans[2].RightNode.BendingMoment, Is.Null);

        }

        
    }
}
