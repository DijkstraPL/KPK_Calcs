using Build_IT_BeamStatica.Loads.Interfaces;
using Build_IT_BeamStatica.Materials.Intefaces;
using Build_IT_BeamStatica.Nodes.Interfaces;
using Build_IT_BeamStatica.Sections.Interfaces;
using Build_IT_BeamStatica.Spans;
using Build_IT_BeamStatica.Spans.Interfaces;
using MathNet.Numerics.LinearAlgebra;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Build_IT_BeamStaticaTests.UnitTests.Spans
{
    [TestFixture]
    public class SpanTests
    {
        private INode _leftNode;
        private INode _rightNode;
        private IMaterial _material;
        private ISection _section;
        private IStiffnessMatrix _stiffnessMatrix;

        [SetUp]
        public void SetUp()
        {
            var leftNode = new Mock<INode>();
            var rightNode = new Mock<INode>();
            var material = new Mock<IMaterial>();
            var section = new Mock<ISection>();
            var stiffnessMatrix = new Mock<IStiffnessMatrix>();

            section.Setup(s => s.Area).Returns(3);
            section.Setup(s => s.MomentOfInteria).Returns(11);
            material.Setup(m => m.YoungModulus).Returns(5);
            material.Setup(m => m.Density).Returns(7);
            leftNode.Setup(ln => ln.HorizontalMovementNumber).Returns(0);
            leftNode.Setup(ln => ln.VerticalMovementNumber).Returns(1);
            leftNode.Setup(ln => ln.LeftRotationNumber).Returns(2);
            leftNode.Setup(ln => ln.RightRotationNumber).Returns(3);
            leftNode.Setup(ln => ln.ConcentratedForces).Returns(new List<INodeLoad>());
            rightNode.Setup(rn => rn.HorizontalMovementNumber).Returns(4);
            rightNode.Setup(rn => rn.VerticalMovementNumber).Returns(5);
            rightNode.Setup(rn => rn.LeftRotationNumber).Returns(6);
            rightNode.Setup(rn => rn.RightRotationNumber).Returns(7);
            rightNode.Setup(rn => rn.ConcentratedForces).Returns(new List<INodeLoad>());
            
            _leftNode = leftNode.Object;
            _rightNode = rightNode.Object;
            _material = material.Object;
            _section = section.Object;
            _stiffnessMatrix = stiffnessMatrix.Object;

        }

        [Test]
        public void SpanCreationTest_Properties_Success()
        {
            var span = new Span(
                _leftNode, length: 7, _rightNode,
                _material, _section, includeSelfWeight: true);

            Assert.That(span.LeftNode, Is.EqualTo(_leftNode));
            Assert.That(span.RightNode, Is.EqualTo(_rightNode));
            Assert.That(span.Length, Is.EqualTo(7));
            Assert.That(span.Material, Is.EqualTo(_material));
            Assert.That(span.Section, Is.EqualTo(_section));
            Assert.That(span.IncludeSelfWeight, Is.EqualTo(true));
            Assert.That(span.ContinousLoads, Is.Not.Null);
            Assert.That(span.PointLoads, Is.Not.Null);
            Assert.That(span.StiffnessMatrix, Is.Not.Null);

            Assert.That(span.LoadVector, Is.Null);
            Assert.That(span.Displacements, Is.Null);
            Assert.That(span.Forces, Is.Null);
        }

        [Test]
        public void SpanCreationTest_Properties_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => 
            new Span(null, 7, _rightNode, _material, _section, false));
            Assert.Throws<ArgumentNullException>(() =>
            new Span(_leftNode, 7, null, _material, _section, false));
            Assert.Throws<ArgumentNullException>(() =>
            new Span(_leftNode, 7, _rightNode, null, _section, false));
            Assert.Throws<ArgumentNullException>(() =>
            new Span(_leftNode, 7, _rightNode, _material, null, false));
        }
        
        [Test]
        public void SpanCalculate_SpanLoadVector_Success()
        {
            var span = new Span(
                _leftNode, length: 7, _rightNode,
                _material, _section, includeSelfWeight: true);

            span.StiffnessMatrix.Calculate();

            span.CalculateSpanLoadVector();

            var selfWeightLoad = span.ContinousLoads.First();

            Assert.That(selfWeightLoad.StartPosition.Position, Is.EqualTo(0));
            Assert.That(selfWeightLoad.StartPosition.Value, Is.EqualTo(-0.0000206052).Within(0.0000000001));
            Assert.That(selfWeightLoad.EndPosition.Position, Is.EqualTo(7));
            Assert.That(selfWeightLoad.EndPosition.Value, Is.EqualTo(-0.0000206052).Within(0.0000000001));
            Assert.That(selfWeightLoad.Length, Is.EqualTo(7));

            Assert.That(span.LoadVector[0], Is.EqualTo(0));
            Assert.That(span.LoadVector[1], Is.EqualTo(0.0000721182).Within(0.0000000001));
            Assert.That(span.LoadVector[2], Is.EqualTo(0.0000841379).Within(0.0000000001));
            Assert.That(span.LoadVector[3], Is.EqualTo(0));
            Assert.That(span.LoadVector[4], Is.EqualTo(0.0000721182).Within(0.0000000001));
            Assert.That(span.LoadVector[5], Is.EqualTo(-0.0000841379).Within(0.0000000001));
        }

        [Test]
        public void SpanCalculate_Displacement_Success()
        {
            var span = new Span(
                _leftNode, length: 7, _rightNode,
                _material, _section, includeSelfWeight: true);

            span.StiffnessMatrix.Calculate();

            var deflectionVector = Vector<double>.Build.Dense(8);
            deflectionVector[0] = 1;
            deflectionVector[1] = 2;
            deflectionVector[2] = 3;
            deflectionVector[3] = 4;
            deflectionVector[4] = 5;
            deflectionVector[5] = 6;
            deflectionVector[6] = 7;
            deflectionVector[7] = 8;
            span.CalculateDisplacement(deflectionVector, 4);

            Assert.That(span.Displacements[0], Is.EqualTo(1));
            Assert.That(span.Displacements[1], Is.EqualTo(2));
            Assert.That(span.Displacements[2], Is.EqualTo(4));
            Assert.That(span.Displacements[3], Is.EqualTo(0));
            Assert.That(span.Displacements[4], Is.EqualTo(0));
            Assert.That(span.Displacements[5], Is.EqualTo(0));
        }

        [Test]
        public void SpanCalculate_SetDisplacement_Success()
        {
            // TODO: Add this
        }

        [Test]
        public void SpanCalculate_Force_Success()
        {
            // TODO: Add this
        }
    }
}
