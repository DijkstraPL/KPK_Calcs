using Build_IT_Data.Entities.Scripts;
using NUnit.Framework;

namespace Build_IT_DataTests.UnitTests.Entities.Scripts
{
    [TestFixture]
    public class ValueOptionTests
    {
        [Test]
        public void ConstructorTest_CollectionsInitialized()
        {
            var valueOption = new ValueOption();

            Assert.That(valueOption.ValueOptionsTranslations, Is.Not.Null);
        }
    }
}
