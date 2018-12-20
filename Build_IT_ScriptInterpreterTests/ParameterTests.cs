using Build_IT_ScriptInterpreter;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Units;
using NUnit.Framework;
using System.Collections.Generic;
using static Build_IT_ScriptInterpreter.Units.Length;

namespace Build_IT_ScriptInterpreterTests
{
    [TestFixture]
    public class ParameterTests
    {
        [Test]
        public void ChangeUnitForParameterTest_Success()
        {
            var parameter = new Parameter(
                name: "a",
                value: "10",
                unit: new Length(LengthUnits.cm),
                valueType: ValueTypes.Number);
           
            parameter.ChangeUnitTo(LengthUnits.mm);

            Assert.That(parameter.Value, Is.EqualTo("100"));
        }

        [Test]
        public void ChangeUnitForValueOptionsTest_Success()
        {
            var valueOptions = new List<string>();
            valueOptions.Add("5");
            valueOptions.Add("10");
            valueOptions.Add("15");

            var parameter = new Parameter(
                name: "a",
                value: null,
                unit: new Length(LengthUnits.cm),
                valueType: ValueTypes.Number)
            { ValueOptions = valueOptions };

            parameter.ChangeUnitTo(LengthUnits.mm);

            Assert.That(parameter.ValueOptions[0], Is.EqualTo("50"));
            Assert.That(parameter.ValueOptions[1], Is.EqualTo("100"));
            Assert.That(parameter.ValueOptions[2], Is.EqualTo("150"));
        }
    }
}
