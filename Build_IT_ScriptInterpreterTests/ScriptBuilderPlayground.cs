using Build_IT_ScriptInterpreter.DataSaver;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts;
using NUnit.Framework;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreterTests.Scripts
{
    [TestFixture]
    public class ScriptBuilderPlayground
    {
        [Test]
        public void MomentOfInteriaScriptTest_Success()
        {
            var scriptBuilder = new ScriptBuilder(name: "Moment of interia for rectangle",
                description: "Calculate moment of interia for rectangle",
                "Section", "Moment of interia", "Rectangle");

            scriptBuilder.AppendParameter(new DataParameter(number: 1, name: "b")
            {
                ValueType = ValueTypes.Number
            })
            .AppendParameter(new DataParameter(number: 2, name: "h")
            {
                ValueType = ValueTypes.Number
            });

            scriptBuilder.AppendParameter(new CalculationParameter(
                number: 3, name: "I", value: "[b]*Pow([h],3)/12")
            {
                ValueType = ValueTypes.Number
            });

            scriptBuilder.Calculate(50, 70);

            StringAssert.StartsWith("1429166,666", scriptBuilder.GetParameterByName("I").Value.ToString());
        }
    }
}
