﻿using Build_IT_Data.Entities.DeadLoads;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataTests.UnitTests.Entities.DeadLoads
{
    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void ConstructorTest_CollectionsInitialized()
        {
            var category = new Category();

            Assert.That(category.Subcategories, Is.Not.Null);
        }
    }
}
