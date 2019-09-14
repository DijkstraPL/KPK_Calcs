using Build_IT_Data.Entities.Scripts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataTests.UnitTests.Entities.Scripts
{
    [TestFixture]
    public class ParameterTests
    {
        [Test]
        public void ConstructorTest_CollectionsInitialized()
        {
            var parameter = new Parameter();

            Assert.Multiple(() =>
            {
                Assert.That(parameter.ValueOptions, Is.Not.Null);
                Assert.That(parameter.ParameterFigures, Is.Not.Null);
                Assert.That(parameter.ParametersTranslations, Is.Not.Null);
            });
        }
    }
}
