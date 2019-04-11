using Build_IT_ScriptInterpreter.DataSaver;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Parameters.ValueOptions;
using Build_IT_ScriptInterpreter.Scripts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreterTests.Scripts
{
    [TestFixture]
    [Ignore("Not finished")]
    public class SteelTension
    {
        [Test]
        public void CreationTest_Success()
        {
            var scriptBuilder = ScriptBuilder.Create(name: "Steel tension",
                description: "Calculate tension resistance. Base on [PN-EN-1993-1-1:2005 6.2.3.(2)a)].",
                "Eurocode 1993", "Steel", "Tension", "Resistance");

            scriptBuilder.SetAuthor("Konrad Kania");
            scriptBuilder.SetDocument("PN-EN-1993-1-1:2005");
            scriptBuilder.SetGroupName("Eurocode 3");
            scriptBuilder.SetNotes("Net area not included.");

            scriptBuilder
                .AppendParameter(new Parameter()
                {
                    Number = 1,
                    Name = "N_Ed_",
                    Description = "Normal design force at calculated position.",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Editable | ParameterOptions.Visible,
                    Unit = "kN"
                })
                .AppendParameter(new Parameter()
                {
                    Number = 2,
                    Name = "A",
                    Description = "Area of the section.",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Editable | ParameterOptions.Visible,
                    Unit = "cm^2^"
                })
                .AppendParameter(new Parameter()
                {
                    Number = 3,
                    Name = "f_y_",
                    Description = "Yield strength.",
                    ValueType = ValueTypes.Number,
                    ValueOptions = new List<ValueOption>()
                    {
                        new ValueOption(235),
                        new ValueOption(275),
                        new ValueOption(355),
                        new ValueOption(420),
                        new ValueOption(440),
                        new ValueOption(460),
                        new ValueOption(null),
                    },
                    Context = ParameterOptions.Editable | ParameterOptions.Visible,
                    Unit = "MPa"
                })
                .AppendParameter(new Parameter()
                {
                    Number = 4,
                    Name = "γ_M0_",
                    Description = "Partial safety factor.",
                    Value = 1.0,
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.StaticData,
                    Unit = ""
                })
                .AppendParameter(new Parameter()
                {
                    Number = 5,
                    Name = "N_pl,Rd_",
                    Value = "[A]*[f_y_]/[γ_M0_]/10",
                    Description = "Design plastic resistance of the gross cross-section.",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                    Unit = "kN"
                });

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 27,
                Name = "Resistance",
                Value = "[N_Ed_]/[N_pl,Rd_]*100",
                Description = "Resistance of the element loaded with normal force.",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                Unit = "%"
            });

            var script = scriptBuilder.Build();
            new XmlSave().SaveData(script,
                @"C:\Users\Disseminate\Desktop\Script Interpreter\Scripts\" + script.Name + ".xml");

            var calculationEngine = new CalculationEngine(script);
            calculationEngine.CalculateFromText("[A]=60|[f_y_]=235|[N_Ed_]=1400");

            Assert.That(script.GetParameterByName("N_pl,Rd_").Value, Is.EqualTo(1410).Within(0.000001));
            Assert.That(script.GetParameterByName("Resistance").Value, Is.EqualTo(99.29078).Within(0.000001));
        }
    }
}
