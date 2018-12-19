using Build_IT_BeamStatica.Beams;
using Build_IT_BeamStatica.Beams.Interfaces;
using Build_IT_BeamStatica.Loads;
using Build_IT_BeamStatica.Loads.ContinousLoads;
using Build_IT_BeamStatica.Loads.PointLoads;
using Build_IT_BeamStatica.Materials;
using Build_IT_BeamStatica.Nodes;
using Build_IT_BeamStatica.Sections;
using Build_IT_BeamStatica.Spans;
using NUnit.Framework;

namespace Build_IT_BeamStaticaTests.BeamsTests
{
    [TestFixture]
    public class BeamPerformanceTests
    {
        private IBeam _beam;

        [Test]
        [MaxTime(300)]      
        public void FullBeamCalculationsTest_TimeoutPerformanceChecking_Success(
        [Random(27.0,37.0,1)] double youngModulus,
        [Random(150.0, 500.0, 1)] double width,
        [Random(240.0, 1000.0, 1)] double height,
        [Random(1.0, 10.0, 2)] double length1,
        [Random(1.0, 10.0, 1)] double length2,
        [Random(1.0, 10.0, 2)] double length3,
        [Random(1.0, 10.0, 2)] double length4,
        [Random(-1000.0, -1.0, 2)] double nodeForce,
        [Random(-100.0, -1.0, 2)] double shearForce,
        [Random(0.0, 1.0, 1)] double minPosition,
        [Random(-300.0, -10.0, 2)] double pointLoad,
        [Random(1.1, 3.0, 2)] double divider
        )
        {
            var material = new Concrete(youngModulus: youngModulus);
            var section = new RectangleSection(width: width, height: height);

            var node1 = new FixedNode();
            var node2 = new Hinge();
            var node3 = new Hinge();
            var node4 = new SupportedNode();
            var node5 = new SupportedNode();

            var nodes = new Node[] { node1, node2, node3, node4, node5 };

            var span1 = new Span(
                leftNode: node1,
                length: length1,
                rightNode: node2,
                material: material,
                section: section
                );

            var span2 = new Span(
                leftNode: node2,
                length: length2,
                rightNode: node3,
                material: material,
                section: section
                );

            var span3 = new Span(
                leftNode: node3,
                length: length3,
                rightNode: node4,
                material: material,
                section: section
                );

            var span4 = new Span(
                leftNode: node4,
                length: length4,
                rightNode: node5,
                material: material,
                section: section
                );

            var spans = new Span[] { span1, span2, span3, span4 };

            node3.ConcentratedForces.Add(new ShearLoad(value: nodeForce));

            var startLoad1 = new LoadData(value: shearForce, position: minPosition);
            var endLoad1 = new LoadData(value: shearForce, position: length1);
            span1.ContinousLoads.Add(ContinousShearLoad.Create(startLoad1, endLoad1));

            var pointLoad1 = new ShearLoad(value: pointLoad, position: length2 / divider);
            span2.PointLoads.Add(pointLoad1);

            _beam = new Beam(spans, nodes);

            _beam.Calculate();

            for (int i = 0; i < _beam.Length*100; i++)
            {
                _beam.ShearResult.GetValue(i);
                _beam.BendingMomentResult.GetValue(i);
                _beam.VerticalDeflectionResult.GetValue(i);
                _beam.RotationResult.GetValue(i);
            }
            
            Assert.That(_beam.Spans[0].LeftNode.NormalForce?.Value, Is.Not.Null);
            Assert.That(_beam.Spans[0].LeftNode.ShearForce?.Value, Is.Not.Null);
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment?.Value, Is.Not.Null);

            Assert.That(_beam.Spans[1].LeftNode.NormalForce, Is.Null);
            Assert.That(_beam.Spans[1].LeftNode.ShearForce, Is.Null);
            Assert.That(_beam.Spans[1].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[2].LeftNode.NormalForce, Is.Null);
            Assert.That(_beam.Spans[2].LeftNode.ShearForce, Is.Null);
            Assert.That(_beam.Spans[2].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[3].LeftNode.NormalForce?.Value, Is.Not.Null);
            Assert.That(_beam.Spans[3].LeftNode.ShearForce?.Value, Is.Not.Null);
            Assert.That(_beam.Spans[3].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[3].RightNode.NormalForce?.Value, Is.Not.Null);
            Assert.That(_beam.Spans[3].RightNode.ShearForce?.Value, Is.Not.Null);
            Assert.That(_beam.Spans[3].RightNode.BendingMoment, Is.Null);
        }
    }
}
