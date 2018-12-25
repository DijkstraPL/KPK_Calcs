using Build_IT_ScriptInterpreter.DataSaver;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts;
using NUnit.Framework;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreterTests.Scripts
{
    [TestFixture]
    public class ScriptCompressiveStrengthAtAge
    {
        [Test]
        public void CreationTest_Success()
        {
            var scriptBuilder = new ScriptBuilder(name: "Compressive strength of concrete at an age",
                description: "Calculate compressive strength of concrete at an age. Base on [PN-EN-1992-1-1:2002 3.1.2].",
                "Eurocode 1992", "Concrete", "Materials", "Strength", "Time", "Compressive");

            var cementTypes = new List<IValueOption>();
            cementTypes.Add(new ValueOption(value: "CEM 42,5R",
                description: "Rapid hardening high strength cements (R)."));
            cementTypes.Add(new ValueOption(value: "CEM 52,5N",
                description: "Rapid hardening high strength cements (R)."));
            cementTypes.Add(new ValueOption(value: "CEM 52,5R",
                description: "Rapid hardening high strength cements (R)."));
            cementTypes.Add(new ValueOption(value: "CEM 32,5R",
                description: "Normal and rapid hardening cements (N)."));
            cementTypes.Add(new ValueOption(value: "CEM 42,5",
                description: "Normal and rapid hardening cements (N)."));
            cementTypes.Add(new ValueOption(value: "CEM 32,5N",
                description: "Slow hardening cements (S)."));

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 1,
                Name = "f_ck",
                Description = "Characteristic compressive cylinder strength of concrete at 28 days.",
                ValueType = ValueTypes.Number,
                Unit = "MPa"
            })
                .AppendParameter(new Parameter()
                {
                    Number = 2,
                    Name = "f_cm",
                    Description = "Mean compressive strength at 28 days.",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Editable | ParameterOptions.Visible,
                    Unit = "MPa"
                })
                .AppendParameter(new Parameter()
                {
                    Number = 3,
                    Name = "cement_type",
                    Description = "Type of cement.",
                    ValueOptions = cementTypes,
                    ValueType = ValueTypes.Text,
                    Context = ParameterOptions.Editable | ParameterOptions.Visible,
                    Unit = "-"
                })
                .AppendParameter(new Parameter()
                {
                    Number = 4,
                    Name = "t",
                    Description = "Age of the concrete in days.",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Editable | ParameterOptions.Visible,
                    Unit = "day"
                });

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 10,
                Name = "s",
                Value = "if(in([cement_type],'CEM 42,5R','CEM 52,5N', 'CEM 52,5R') == true,0.2," +
                "if(in([cement_type],'CEM 32,5R','CEM 42,5') == true,0.25," +
                "if(in([cement_type],'CEM 32,5N') == true,0.38, ERROR('Invalid cement type.'))))",
                Description = "Coefficient which depends on the type of cement.",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                Unit = "-"
            });

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 11,
                Name = "beta_cc(t)",
                Value = "Exp([s]*(1-Sqrt(28/[t])))",
                Description = "Coefficient which depends on the age of the concrete t.",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                Unit = "-"
            });

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 12,
                Name = "f_cm(t)",
                Value = "[beta_cc(t)]*[f_cm]",
                Description = "Mean concrete compressive strength at an age of t days.",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                Unit = "MPa"
            });

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 13,
                Name = "f_ck(t)",
                Value = "if([t]>=28,[f_ck],if([t]>3,[f_cm(t)]-8,ERROR('Not even 3 days.')))",
                Description = "Concrete compressive strength at time t.",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                Unit = "MPa"
            });

            scriptBuilder.Save(new XmlSave(),
                @"C:\Users\User\Desktop\Visual Studio\KPK_Calcs_Scripts\" + scriptBuilder.Name + ".xml");

            scriptBuilder.Calculate(30, 38, "CEM 42,5R", 5);

            Assert.That(0.2, Is.EqualTo(scriptBuilder.GetParameterByName("s").Value).Within(0.000001));
            Assert.That(0.760874, Is.EqualTo(scriptBuilder.GetParameterByName("beta_cc(t)").Value).Within(0.000001));
            Assert.That(28.913244, Is.EqualTo(scriptBuilder.GetParameterByName("f_cm(t)").Value).Within(0.000001));
            Assert.That(20.913244, Is.EqualTo(scriptBuilder.GetParameterByName("f_ck(t)").Value).Within(0.000001));

            StringAssert.Contains("MPa", scriptBuilder.GetParameterByName("f_ck(t)").ToString());
        }

        [Test]
        public void LoadTest_Success()
        {
            string name = "Compressive strength of concrete at an age";
            var loader = new XmlLoad<Build_IT_ScriptInterpreter.DataSaver.SerializableClasses.Script>();
            var scriptData = loader.LoadData(@"C:\Users\User\Desktop\Visual Studio\KPK_Calcs_Scripts\" + name + ".xml");

            var script = scriptData.Initialize();
            script.Calculate(30, 38, "CEM 42,5R", 5);

            Assert.That(0.2, Is.EqualTo(script.GetParameterByName("s").Value).Within(0.000001));
            Assert.That(0.760874, Is.EqualTo(script.GetParameterByName("beta_cc(t)").Value).Within(0.000001));
            Assert.That(28.913244, Is.EqualTo(script.GetParameterByName("f_cm(t)").Value).Within(0.000001));
            Assert.That(20.913244, Is.EqualTo(script.GetParameterByName("f_ck(t)").Value).Within(0.000001));

            StringAssert.Contains("MPa", script.GetParameterByName("f_ck(t)").ToString());
        }
    }
}
