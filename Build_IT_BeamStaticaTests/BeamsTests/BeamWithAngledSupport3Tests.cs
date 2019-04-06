using Build_IT_BeamStatica.Beams;
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
    [TestFixture(Description = "19.04.06-03")]
    public class BeamWithAngledSupport3Tests
    {
        private Beam _beam;

        [SetUp]
        public void SetUpBeam()
        {
            var material1 = new Material(youngModulus: 400, density: 0, thermalExpansionCoefficient: 0);
            var material2 = new Material(youngModulus: 200, density: 0, thermalExpansionCoefficient: 0);
            var section = new SectionProperties(area: 60, momentOfInteria: 20000);

            var node1 = new FixedNode();
            var node2 = new PinNode();
            var node3 = new PinNode(angle:22.02);

            var nodes = new Node[] { node1, node2, node3 };

            var span1 = new Span(
                leftNode: node1,
                length: 8,
                rightNode: node2,
                material: material1,
                section: section,
                includeSelfWeight: false
                );
            var span2 = new Span(
                leftNode: node2,
                length: 8,
                rightNode: node3,
                material: material2,
                section: section,
                includeSelfWeight: false
                );

            var spans = new Span[] { span1, span2 };

            var shearLoad = ContinousShearLoad.Create(0, -6, 8, -6);
            span1.ContinousLoads.Add(shearLoad);

            var pointLoad = new ShearLoad(value: -40, position: 4);
            span2.PointLoads.Add(pointLoad);

            _beam = new Beam(spans, nodes, includeSelfWeight: false);

            _beam.CalculationEngine.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.NormalForce.Value, Is.EqualTo(-5.054).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.ShearForce.Value, Is.EqualTo(27.503).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-60.026).Within(0.001));
            
            Assert.That(_beam.Spans[0].RightNode.NormalForce.Value, Is.EqualTo(5.054).Within(0.001));
            Assert.That(_beam.Spans[0].RightNode.ShearForce.Value, Is.EqualTo(12.497).Within(0.001));
            Assert.That(_beam.Spans[0].RightNode.BendingMoment, Is.Null);
        }

        [Test()]
        public void NodeDisplacementsCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.HorizontalDeflection, Is.Null);
            Assert.That(_beam.Spans[0].LeftNode.VerticalDeflection, Is.Null);
            Assert.That(_beam.Spans[0].LeftNode.RightRotation, Is.Null);

            Assert.That(_beam.Spans[0].RightNode.LeftRotation.Value, Is.EqualTo(0.001997).Within(0.000001));
            Assert.That(_beam.Spans[0].RightNode.HorizontalDeflection.Value, Is.EqualTo(0.033694).Within(0.000001));
            Assert.That(_beam.Spans[0].RightNode.VerticalDeflection.Value, Is.EqualTo(-0.013627).Within(0.000001));
        }
        
    }
}

