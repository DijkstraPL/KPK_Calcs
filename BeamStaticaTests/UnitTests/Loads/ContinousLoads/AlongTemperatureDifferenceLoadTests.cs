﻿using BeamStatica.Loads.ContinousLoads;
using BeamStatica.Loads.Interfaces;
using BeamStatica.Spans.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStaticaTests.UnitTests.Loads.ContinousLoads
{
    [TestFixture]
    public class AlongTemperatureDifferenceLoadTests
    {
        private IContinousLoad _alongTemperatureDifferenceLoad;
        private ISpan _span;

        [SetUp]
        public void SetUpData()
        {
            var span = new Mock<ISpan>();
            span.Setup(s => s.Length).Returns(10);
            span.Setup(s => s.Section.Area).Returns(5);
            span.Setup(s => s.Material.YoungModulus).Returns(2);
            span.Setup(s => s.Material.ThermalExpansionCoefficient).Returns(3);
            _span = span.Object;

            _alongTemperatureDifferenceLoad = AlongTemperatureDifferenceLoad.Create(span.Object, 10);
        }

        [Test]
        public void CalculateSpanLoadVectorNormalForceMemberTest_LeftNode_Success()
        {
            var result = _alongTemperatureDifferenceLoad.CalculateSpanLoadVectorNormalForceMember(
                _span, leftNode: true);

            Assert.That(result, Is.EqualTo(30000));
        }

        [Test]
        public void CalculateSpanLoadVectorNormalForceMemberTest_RightNode_Success()
        {
            var result = _alongTemperatureDifferenceLoad.CalculateSpanLoadVectorNormalForceMember(
                _span, leftNode:false);

            Assert.That(result, Is.EqualTo(-30000));
        }

        [Test]
        public void CalculateSpanLoadVectorShearMemberTest_LeftNode_Success()
        {
            var result = _alongTemperatureDifferenceLoad.CalculateSpanLoadVectorShearMember(
                _span, leftNode: true);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateSpanLoadVectorShearMemberTest_RightNode_Success()
        {
            var result = _alongTemperatureDifferenceLoad.CalculateSpanLoadVectorShearMember(
                _span, leftNode: false);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateSpanLoadVectorBendingMomentMemberTest_LeftNode_Success()
        {
            var result = _alongTemperatureDifferenceLoad.CalculateSpanLoadVectorBendingMomentMember(
                _span, leftNode: true);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateSpanLoadVectorBendingMomentMemberTest_RightNode_Success()
        {
            var result = _alongTemperatureDifferenceLoad.CalculateSpanLoadVectorBendingMomentMember(
                _span, leftNode: false);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateNormalForceTest_Success()
        {
            var result = _alongTemperatureDifferenceLoad.CalculateNormalForce(distanceFromLoadStartPosition: 5);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateShearTest_Success()
        {
            var result = _alongTemperatureDifferenceLoad.CalculateShear(distanceFromLoadStartPosition: 5);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateBendingMomentTest_Success()
        {
            var result = _alongTemperatureDifferenceLoad.CalculateBendingMoment(distanceFromLoadStartPosition: 5);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateRotationTest_Success()
        {
            var result = _alongTemperatureDifferenceLoad.CalculateRotation(
                _span, distanceFromLeftSide: 5, currentLength: 1);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateHorizontalDeflectionTest_Success()
        {
            var result = _alongTemperatureDifferenceLoad.CalculateHorizontalDeflection(
                _span, distanceFromLeftSide: 5, currentLength: 1);

            Assert.That(result, Is.Not.EqualTo(0));
        }

        [Test]
        public void CalculateVerticalDeflectionTest_Success()
        {
            var result = _alongTemperatureDifferenceLoad.CalculateVerticalDeflection(
                _span, distanceFromLeftSide: 5, currentLength: 1);

            Assert.That(result, Is.EqualTo(0));
        }
    }
}
