﻿using Build_IT_Data.Sections;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataTests.UnitTests.Sections
{
    [TestFixture]
    public class SectionPropertiesTests
    {
        [Test()]
        public void ConstructorTest_MinusArgument_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => new SectionProperties(area: -1, momentOfInteria: 250));
            Assert.Throws<ArgumentOutOfRangeException>(()
                => new SectionProperties(area: 100, momentOfInteria: -1));
        }

        [Test()]
        public void ConstructorTest_Success()
        {
            var sectionProperties = new SectionProperties(area: 1, momentOfInteria: 2);
            Assert.That(sectionProperties.Area, Is.EqualTo(1));
            Assert.That(sectionProperties.MomentOfInteria, Is.EqualTo(2));
        }
    }
}
