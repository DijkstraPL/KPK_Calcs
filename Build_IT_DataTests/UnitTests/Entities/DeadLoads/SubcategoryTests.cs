using Build_IT_Data.Entities.DeadLoads;
using NUnit.Framework;

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
