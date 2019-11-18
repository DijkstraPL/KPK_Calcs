using Build_IT_ScriptInterpreter.Parameters.ValueOptions;
using NUnit.Framework;

namespace Build_IT_ScriptInterpreterTests.UnitTests.Parameters.ValueOptions
{
    [TestFixture]
   public  class ValueOptionTests
    {
        [Test]
        public void ConstructorTest_Success()
        {
            var valueOption = new ValueOption(value: "Test",
                valueOptionSetting: ValueOptionSettings.UserInput);

            Assert.Multiple(() =>
            {
                Assert.That(valueOption.Value.ToString(), Is.EqualTo("Test"));
                Assert.That(valueOption.ValueOptionSetting, Is.EqualTo(ValueOptionSettings.UserInput));
            });
        }
    }
}
