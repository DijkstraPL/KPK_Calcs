using Build_IT_Data.Entities.DeadLoads;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataTests.UnitTests.Entities.DeadLoads
{
    [TestFixture]
    public class MaterialTests
    {
        [Test]
        public void ConstructorTest_CollectionsInitialized()
        {
            var material = new Material();

            Assert.That(material.MaterialAdditions, Is.Not.Null);
        }
    }
}
