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
    [TestFixture(Description = "18.12.18-02")]
    [Ignore("Not finished")]
    public class BeamWithAngledSupportTests
    {
        private Beam _beam;

        [SetUp]
        public void SetUpBeam()
        {
            var material = new Concrete(youngModulus: 30, withReinforcement: false);
            var section = new RectangleSection(width: 300, height: 500);

            var node1 = new FixedNode();
            var node2 = new PinNode(angle:30);

            var nodes = new Node[] { node1, node2 };

            var span1 = new Span(
                leftNode: node1,
                length: 10,
                rightNode: node2,
                material: material,
                section: section,
                includeSelfWeight: false
                );

            var spans = new Span[] { span1 };
            
            var startLoad = new LoadData(value: -50, position: 0);
            var endLoad = new LoadData(value: -50, position: 10);
            span1.ContinousLoads.Add(ContinousShearLoad.Create(startLoad, endLoad));

            _beam = new Beam(spans, nodes, includeSelfWeight: false);

            _beam.CalculationEngine.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.NormalForce.Value, Is.EqualTo(-108.231).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.ShearForce.Value, Is.EqualTo(312.539).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-625.391).Within(0.001));
            
            Assert.That(_beam.Spans[0].RightNode.NormalForce, Is.Null);
            Assert.That(_beam.Spans[0].RightNode.ShearForce.Value, Is.EqualTo(187.461).Within(0.001));
            Assert.That(_beam.Spans[0].RightNode.BendingMoment, Is.Null);
        }

        [Test()]
        public void NodeDisplacementsCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.HorizontalDeflection, Is.Null);
            Assert.That(_beam.Spans[0].LeftNode.VerticalDeflection, Is.Null);
            Assert.That(_beam.Spans[0].LeftNode.RightRotation, Is.Null);

            Assert.That(_beam.Spans[0].RightNode.LeftRotation.Value, Is.EqualTo(-0.011090).Within(0.000001));
            Assert.That(_beam.Spans[0].RightNode.HorizontalDeflection.Value, Is.EqualTo(0.34).Within(0.000001));
            Assert.That(_beam.Spans[0].RightNode.VerticalDeflection, Is.Null);
        }
    }
}

