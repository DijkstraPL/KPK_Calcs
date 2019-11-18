using Build_IT_ScriptInterpreter.DataSaver;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Scripts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreterTests.IntegrationTests.Scripts
{
    [TestFixture]
    public class ScriptMeanCompressiveStrengthAt28Days
    {
        [Test]
        public void NewlyCreatedScriptTest_Success()
        {
            var scriptBuilder = ScriptBuilder.Create(name: "Mean compresive strength of concrete at 28 days",
                description: "Calculate mean compressive strength of concrete at 28 days. Base on [PN-EN-1992-1-1:2002 Table 3.1].",
                "Eurocode 1992", "Concrete", "Materials", "Strength", "Compressive");

            scriptBuilder.SetDocument("PN-EN-1992-1-1:2002")
                .SetAuthor("Konrad Kania")
                .SetGroupName("Eurocode 2")
                .AppendParameter(new Parameter()
                {
                    Number = 1,
                    Name = "f_ck_",
                    VisibilityValidator = "[f_ck_]>0",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Editable | ParameterOptions.Visible,
                    Unit = "MPa"
                })
                .AppendParameter(new Parameter()
                {
                    Number = 2,
                    Name = "f_cm_",
                    VisibilityValidator = "[f_cm_]>0",
                    Value = "[f_ck_]+8",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                    Unit = "MPa"
                });

            var script = scriptBuilder.Build();

            var calculationEngine = new CalculationEngine(script.Parameters);

            calculationEngine.CalculateFromText("[f_ck_]=30");

            Assert.That(38, Is.EqualTo(script.GetParameterByName("f_cm_").Value));
        }
    }
}
