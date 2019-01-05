using Build_IT_ScriptInterpreter.DataSaver;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Scripts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreterTests.Scripts
{
    [TestFixture]
    public class ScriptMeanCompressiveStrengthAt28Days
    {
        [Test]
        public void CreationTest_Success()
        {
            var scriptBuilder = ScriptBuilder.Create(name: "Mean compresive strength of concrete at 28 days",
                description: "Calculate mean compressive strength of concrete at 28 days. Base on [PN-EN-1992-1-1:2002 Table 3.1].",
                "Eurocode 1992", "Concrete", "Materials", "Strength", "Compressive");

            scriptBuilder.SetDocument("PN-EN-1992-1-1:2002")
                .SetAuthor("Konnrad Kania")
                .SetGroupName("Eurocode 2")
                .AppendParameter(new Parameter()
                {
                    Number = 1,
                    Name = "f_ck_",
                    DataValidator = "[f_ck_]>0",
                    Description = "Characteristic compressive cylinder strength of concrete at 28 days.",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Editable | ParameterOptions.Visible,
                    Unit = "MPa"
                })
                .AppendParameter(new Parameter()
                {
                    Number = 2,
                    Name = "f_cm_",
                    DataValidator = "[f_cm_]>0",
                    Description = "Mean compressive strength at 28 days.",
                    Value = "[f_ck_]+8",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                    Unit = "MPa"
                });

            var script = scriptBuilder.Build();
            new XmlSave().SaveData(script,
                @"C:\Users\Disseminate\Desktop\Script Interpreter\Scripts\" + script.Name + ".xml");

            var calculationEngine = new CalculationEngine(script);

            calculationEngine.Calculate(30);

            Assert.That(38, Is.EqualTo(script.GetParameterByName("f_cm_").Value));
        }
    }
}
