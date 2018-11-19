﻿using BeamStatica;
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
    public class BeamWithRightOverhangingTests
    {
        private Beam _beam;

        [SetUp]
        public void SetUpBeam()
        {
            var material = new Material() { YoungModulus = 30 };
            var section = new RectangleSection(width: 300, height: 500);

            var node1 = new SupportedNode();
            var node2 = new SupportedNode();
            var node3 = new FreeNode();

            var nodes = new Node[] { node1, node2, node3 };

            var span1 = new Span(
                leftNode: node1,
                length: 15,
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

            node3.ConcentratedForces.Add(new BendingMoment(value: 30));

            var startLoad1 = new ShearLoad(value: -60, position: 0);
            var endLoad1 = new ShearLoad(value: -60, position: 15);
            span1.ContinousLoads.Add(new ContinousLoad(startLoad1, endLoad1));

            var startLoad2 = new ShearLoad(value: -60, position: 0);
            var endLoad2 = new ShearLoad(value: -60, position: 5);
            span2.ContinousLoads.Add(new ContinousLoad(startLoad2, endLoad2));

            _beam = new Beam(spans, nodes);

            _beam.Calculate();
        }

        [Test()]
        public void NodeForcesCalculationsTest_Successful()
        {
            Assert.That(_beam.Spans[0].LeftNode.ShearForce.Value, Is.EqualTo(398).Within(0.001));
            Assert.That(_beam.Spans[0].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[1].LeftNode.ShearForce.Value, Is.EqualTo(802).Within(0.001));
            Assert.That(_beam.Spans[1].LeftNode.BendingMoment, Is.Null);

            Assert.That(_beam.Spans[1].RightNode.ShearForce, Is.Null);
            Assert.That(_beam.Spans[1].RightNode.BendingMoment, Is.Null);
        }

        [Test()]
        [TestCase(0, 398)]
        [TestCase(1, 338)]
        [TestCase(3, 218)]
        [TestCase(6, 38)]
        [TestCase(13, -382)]
        [TestCase(15, -502)]
        [TestCase(15.00001, 300)]
        [TestCase(17, 180)]
        [TestCase(20, 0)]
        public void ShearForceAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedShear = _beam.ShearResult.GetValue(position).Value;

            Assert.That(calculatedShear, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(1, 368)]
        [TestCase(7, 1316)]
        [TestCase(9, 1152)]
        [TestCase(12, 456)]
        [TestCase(13, 104)]
        [TestCase(14, -308)]
        [TestCase(15, -780)]
        [TestCase(17, -300)]
        [TestCase(20, -30)]
        public void BendingMomentAtPositionCalculationsTest_Successful(double position, double result)
        {
            double calculatedMoment = _beam.BendingMomentResult.GetValue(position).Value;

            Assert.That(calculatedMoment, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, -0.069200)]
        [TestCase(3, -0.052976)]
        [TestCase(7, -0.001776)]
        [TestCase(9, 0.024976)]
        [TestCase(12, 0.052144)]
        [TestCase(13, 0.055184)]
        [TestCase(15, 0.048400)]
        [TestCase(16, 0.041573)]
        [TestCase(20, 0.033467)]
        public void RotationAtPositionCalculationsTest_Successful(double position, double result)
        {
            double rotation = _beam.RotationResult.GetValue(position).Value;

            Assert.That(rotation, Is.EqualTo(result).Within(0.000001), message: $"At {position}m.");
        }

        [Test()]
        [TestCase(0, 0)]
        [TestCase(3, -190.656)]
        [TestCase(7, -305.735)]
        [TestCase(9, -281.952)]
        [TestCase(12, -160.704)]
        [TestCase(13, -106.727)]
        [TestCase(15, 0)]
        [TestCase(16, 44.747)]
        [TestCase(20, 188)]
        public void DeflectionAtPositionCalculationsTest_Successful(double position, double result)
        {
            double deflection = _beam.DeflectionResult.GetValue(position).Value;

            Assert.That(deflection, Is.EqualTo(result).Within(0.001), message: $"At {position}m.");
        }
    }
}
