using Build_IT_Data.Entities.DeadLoads;
using NUnit.Framework;

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
