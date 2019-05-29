using Build_IT_ScriptInterpreter.Parameters.ValueOptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreterTests.UnitTests.Parameters.ValueOptions
{
    [TestFixture]
   public  class ValueOptionTests
    {
        [Test]
        public void ConstructorTest_Success()
        {
            var valueOption = new ValueOption(value: "Test", description: "Description",
                valueOptionSetting: ValueOptionSettings.UserInput);

            Assert.Multiple(() =>
            {
                Assert.That(valueOption.Value.ToString(), Is.EqualTo("Test"));
                Assert.That(valueOption.Description, Is.EqualTo("Description"));
                Assert.That(valueOption.ValueOptionSetting, Is.EqualTo(ValueOptionSettings.UserInput));
            });
        }
    }
}
