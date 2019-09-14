using Build_IT_Data.Entities.SteelProfiles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataTests.UnitTests.Entities.SteelProfiles
{
    [TestFixture]
    public class ProfileTypeTests
    {
        [Test]
        public void ConstructorTest_CollectionsInitialized()
        {
            var profileType = new ProfileType();

            Assert.Multiple(() =>
            {
                Assert.That(profileType.Parameters, Is.Not.Null);
                Assert.That(profileType.SectionPoints, Is.Not.Null);
                Assert.That(profileType.SteelProfiles, Is.Not.Null);
            });
        }
    }
}
