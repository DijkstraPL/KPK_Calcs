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
    [TestFixture(Description = "18.12.14-01")]
    [Ignore("Not finished")]
    public class BeamWithAngledLoads1Tests
    {
        private Beam _beam;

        [SetUp]
        public void SetUpBeam()
        {
            var material = new Concrete(youngModulus: 30, withReinforcement: false);
            var section = new RectangleSection(width: 300, height: 500);

            var node1 = new TelescopeNode();
            var node2 = new PinNode();
            var node3 = new Hinge();
            var node4 = new SupportedNode();

            var nodes = new Node[] { node1, node2, node3, node4 };

            var span1 = new Span(
                leftNode: node1,
                length: 3,
                rightNode: node2,
                material: material,
                section: section,
                includeSelfWeight: false
                );

            var span2 = new Span(
                leftNode: node2,
                length: 7,
                rightNode: node3,
                material: material,
                section: section,
                includeSelfWeight: false
                );

            var span3 = new Span(
                leftNode: node3,
                length: 5,
                rightNode: node4,
                material: material,
                section: section,
                includeSelfWeight: false
                );

            var spans = new Span[] { span1, span2, span3 };
            
            node3.ConcentratedForces.Add(new AngledLoad(value: -100, angle: 30));
            node2.ConcentratedForces.Add(new VerticalDisplacement(value: -10));

            var pointLoad1 = new AngledLoad(value: -200, position: 1.5, angle: -45);
            span1.PointLoads.Add(pointLoad1);

            var startLoad = new LoadData(value: -20, position: 0);
            var endLoad = new LoadData(value: -20, position: 7);
            span2.ContinousLoads.Add(ContinousShearLoad.Create(startLoad, endLoad));

            var upDownTemperatureLoad = UpDownTemperatureDifferenceLoad.Create( // TODO: Check Hinge - something wrong
                span3, upperTemperature: 5, lowerTemperature: 0);
            span3.ContinousLoads.Add(upDownTemperatureLoad);
            
            var alongTemperatureLoad = AlongTemperatureDifferenceLoad.Create(
                span3, temperatureDifference: 10);
            span3.ContinousLoads.Add(alongTemperatureLoad);

            _beam = new Beam(spans, nodes, includeSelfWeight: false);

            _beam.CalculationEngine.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.NormalForce.Value, Is.EqualTo(39.379).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.ShearForce, Is.Null);
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment.Value, Is.EqualTo(-884.086).Within(0.001));

            Assert.That(_beam.Spans[1].LeftNode.NormalForce, Is.Null);
            Assert.That(_beam.Spans[1].LeftNode.ShearForce.Value, Is.EqualTo(368.024).Within(0.001));
            Assert.That(_beam.Spans[1].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[2].LeftNode.NormalForce, Is.Null);
            Assert.That(_beam.Spans[2].LeftNode.ShearForce, Is.Null);
            Assert.That(_beam.Spans[2].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[2].RightNode.NormalForce.Value, Is.EqualTo(-130.8).Within(0.001));
            Assert.That(_beam.Spans[2].RightNode.ShearForce.Value, Is.EqualTo(0).Within(0.001));
            Assert.That(_beam.Spans[2].RightNode.BendingMoment, Is.Null);
        }

        [Test()]
        public void NodeDisplacementsCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.HorizontalDeflection, Is.Null);
            Assert.That(_beam.Spans[0].LeftNode.VerticalDeflection.Value, Is.EqualTo(33.285).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.RightRotation, Is.Null);

            Assert.That(_beam.Spans[0].RightNode.LeftRotation.Value, Is.EqualTo(-0.029988).Within(0.000001));
            Assert.That(_beam.Spans[1].LeftNode.HorizontalDeflection.Value, Is.EqualTo(-0.073).Within(0.001));
            Assert.That(_beam.Spans[1].LeftNode.VerticalDeflection, Is.Null);
            Assert.That(_beam.Spans[1].LeftNode.RightRotation.Value, Is.EqualTo(-0.029988).Within(0.000001));

            Assert.That(_beam.Spans[1].RightNode.LeftRotation.Value, Is.EqualTo(-0.064815).Within(0.000001));
            Assert.That(_beam.Spans[2].LeftNode.HorizontalDeflection.Value, Is.EqualTo(-0.355).Within(0.001));
            Assert.That(_beam.Spans[2].LeftNode.VerticalDeflection.Value, Is.EqualTo(-389.561).Within(0.001));
            Assert.That(_beam.Spans[2].LeftNode.RightRotation.Value, Is.EqualTo(0.078162).Within(0.000001));

            Assert.That(_beam.Spans[2].RightNode.LeftRotation.Value, Is.EqualTo(0.077662).Within(0.000001));
            Assert.That(_beam.Spans[2].RightNode.HorizontalDeflection, Is.Null);
            Assert.That(_beam.Spans[2].RightNode.VerticalDeflection, Is.Null);
        }
    }
}

