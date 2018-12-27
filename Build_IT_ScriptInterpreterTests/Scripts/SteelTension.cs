using Build_IT_ScriptInterpreter.DataSaver;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreterTests.Scripts
{
    [TestFixture]
    public class SteelTension
    {
        [Test]
        public void CreationTest_Success()
        {
            var scriptBuilder = new ScriptBuilder(name: "Steel tension",
                description: "Calculate tension resistance. Base on [PN-EN-1993-1-1:2005 6.2.3.(2)a)].",
                "Eurocode 1993", "Steel", "Tension", "Resistance");

            scriptBuilder
                .AppendParameter(new Parameter()
                {
                    Number = 1,
                    Name = "N_Ed",
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
                    Unit = "cm2"
                })
                .AppendParameter(new Parameter()
                {
                    Number = 3,
                    Name = "f_y",
                    Description = "Yield strength.",
                    ValueType = ValueTypes.Number,
                    ValueOptions = new List<IValueOption>()
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
                    Name = "gamma_M0",
                    Description = "Partial safety factor.",
                    Value = 1.0,
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.StaticData,
                    Unit = ""
                })
                .AppendParameter(new Parameter()
                {
                    Number = 5,
                    Name = "N_pl,Rd",
                    Value = "[A]*[f_y]/[gamma_M0]/10",
                    Description = "Design plastic resistance of the gross cross-section.",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                    Unit = "kN"
                });

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 27,
                Name = "Resistance",
                Value = "[N_Ed]/[N_pl,Rd]*100",
                Description = "Resistance of the element loaded with normal force.",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                Unit = "%"
            });

            scriptBuilder.Save(new XmlSave(),
                @"C:\Users\Disseminate\Desktop\Beam Statica\" + scriptBuilder.Name + ".xml");

            scriptBuilder.CalculateFromText("[A]=60,[f_y]=235,[N_Ed]=1400");

            Assert.That(scriptBuilder.GetParameterByName("N_pl,Rd").Value, Is.EqualTo(1410).Within(0.000001));
            Assert.That(scriptBuilder.GetParameterByName("Resistance").Value, Is.EqualTo(99.29078).Within(0.000001));
        }
    }
}
