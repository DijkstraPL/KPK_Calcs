using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Units;
using NUnit.Framework;
using System.Collections.Generic;
using static Build_IT_ScriptInterpreter.Units.Length;

namespace Build_IT_ScriptInterpreterTests.Parameters
{
    [TestFixture]
    public class ParameterTests
    {
        //[Test]
        //public void ChangeUnitForParameterTest_Success()
        //{
        //    var parameter = new CalculationParameter(
        //        number: 1,
        //        name: "a",
        //        value: "10")
        //    {
        //        Unit = new Length(LengthUnits.cm),
        //        ValueType = ValueTypes.Number
        //    };

        //    parameter.ChangeUnitTo(LengthUnits.mm);

        //    Assert.That(parameter.Value, Is.EqualTo("100"));
        //}

        //[Test]
        //public void ChangeUnitForValueOptionsTest_Success()
        //{
        //    var valueOptions = new List<IValueOption>();
        //    valueOptions.Add(new ValueOption( "5"));
        //    valueOptions.Add(new ValueOption("10"));
        //    valueOptions.Add(new ValueOption("15"));

        //    var parameter = new CalculationParameter(
        //        number: 1,
        //        name: "a",
        //        value: null)
        //    {
        //        Unit= new Length(LengthUnits.cm),
        //        ValueType= ValueTypes.Number,
        //        ValueOptions = valueOptions
        //    };

        //    parameter.ChangeUnitTo(LengthUnits.mm);

        //    Assert.That(parameter.ValueOptions[0].Value, Is.EqualTo(50));
        //    Assert.That(parameter.ValueOptions[1].Value, Is.EqualTo(100));
        //    Assert.That(parameter.ValueOptions[2].Value, Is.EqualTo(150));
        //}

        // NOTE: Not working this way
        //[Test] 
        //public void ChangeUnitForNotExistingUnitTest_MissingMemberException()
        //{
        //    var parameter = new Parameter(
        //        number: 1,
        //        name: "a",
        //        value: "10",
        //        unit: new Length(LengthUnits.cm),
        //        valueType: ValueTypes.Number);

        //    Assert.Throws<MissingMemberException>(() => parameter.ChangeUnitTo(MassUnits.kg));
        //}
    }
}
