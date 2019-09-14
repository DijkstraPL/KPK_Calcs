using Build_IT_Data.Entities.SteelProfiles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataTests.UnitTests.Entities.SteelProfiles
{
    [TestFixture]
    public class SteelProfileTests
    {
        [Test]
        public void ConstructorTest_CollectionsInitialized()
        {
            var steelProfile = new SteelProfile();

            Assert.That(steelProfile.ParametersValues, Is.Not.Null);
        }
    }
}
