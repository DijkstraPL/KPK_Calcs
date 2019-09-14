using Build_IT_Data.Entities.DeadLoads;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataTests.UnitTests.Entities.DeadLoads
{
    [TestFixture]
    public class SubcategoryTests
    {
        [Test]
        public void ConstructorTest_CollectionsInitialized()
        {
            var subcategory = new Subcategory();

            Assert.That(subcategory.Materials, Is.Not.Null);
        }
    }
}
