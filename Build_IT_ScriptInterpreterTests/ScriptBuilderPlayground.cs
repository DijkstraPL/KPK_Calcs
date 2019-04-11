using Build_IT_ScriptInterpreter.DataSaver;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts;
using NUnit.Framework;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreterTests.Scripts
{
    [TestFixture]
    [Ignore("Not finished")]
    public class ScriptBuilderPlayground
    {
        [Test]
        public void MomentOfInteriaScriptTest_Success()
        {
            var scriptBuilder = ScriptBuilder.Create(name: "Moment of interia for rectangle",
                description: "Calculate moment of interia for rectangle",
                "Section", "Moment of interia", "Rectangle");

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 1,
                Name = "b",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Editable | ParameterOptions.Visible
            })
            .AppendParameter(new Parameter()
            {
                Number = 2,
                Name = "h",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Editable | ParameterOptions.Visible
            });

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 3,
                Name = "I",
                Value= "[b]*Pow([h],3)/12",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Calculation | ParameterOptions.Visible
            });

            var script = scriptBuilder.Build();
            var calculationEngine = new CalculationEngine(script);
            calculationEngine.CalculateFromText("[b]=50,[h]=70");

            Assert.That(1429166.667, Is.EqualTo(script.GetParameterByName("I").Value).Within(0.001));
        }
    }
}
