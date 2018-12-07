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
    public class BeamWithTriangleLoadPaperTests
    {
        private Beam _beam;

        [SetUp]
        public void SetUpBeam()
        {
            var material = new Material() { YoungModulus = 28 };
            var section1 = new PolygonSection() { MomentOfInteria = 580000 * 1.5 };
            var section2 = new PolygonSection() { MomentOfInteria = 580000 };

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
            Assert.That(_beam.Spans[0].LeftNode.ShearForce.Value, Is.EqualTo(146.327).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-281.187).Within(0.001));

            Assert.That(_beam.Spans[1].LeftNode.ShearForce, Is.Null);
            Assert.That(_beam.Spans[1].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[2].LeftNode.ShearForce.Value, Is.EqualTo(243.465).Within(0.001));
            Assert.That(_beam.Spans[2].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[2].RightNode.ShearForce.Value, Is.EqualTo(50.208).Within(0.001));
            Assert.That(_beam.Spans[2].RightNode.BendingMoment, Is.Null);
        }
    }
}
