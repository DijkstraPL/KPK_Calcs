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

            scriptBuilder.AppendParameter(new DataParameter(
                number: 1,
                name: "f_ck")
            {
                Description = "Characteristic compressive cylinder strength of concrete at 28 days.",
                ValueType = ValueTypes.Number,
                Unit = "MPa"
            })
                .AppendParameter(new DataParameter(
                    number: 2,
                    name: "f_cm")
                {
                    Description = "Mean compressive strength at 28 days.",
                    ValueType = ValueTypes.Number,
                    Unit = "MPa"
                })
                .AppendParameter(new DataParameter(
                    number: 3,
                    name: "cement_type")
                {
                    Description = "Type of cement.",
                    ValueOptions = cementTypes,
                    ValueType = ValueTypes.Text,
                    Unit = "-"
                })
                .AppendParameter(new DataParameter(
                    number: 4,
                    name: "t")
                {
                    Description = "Age of the concrete in days.",
                    ValueType = ValueTypes.Number,
                    Unit = "day"
                });

            scriptBuilder.AppendParameter(new CalculationParameter(
                number: 10,
                name: "s",
                value: "if(in([cement_type],'CEM 42,5R','CEM 52,5N', 'CEM 52,5R') == true,0.2," +
                "if(in([cement_type],'CEM 32,5R','CEM 42,5') == true,0.25," +
                "if(in([cement_type],'CEM 32,5N') == true,0.38, ERROR('Invalid cement type.'))))")
            {
                Description = "Coefficient which depends on the type of cement.",
                ValueType = ValueTypes.Number,
                Unit = "-"
            });

            scriptBuilder.AppendParameter(new CalculationParameter(
                number: 11,
                name: "beta_cc(t)",
                value: "Exp([s]*(1-Sqrt(28/[t])))")
            {
                Description = "Coefficient which depends on the age of the concrete t.",
                ValueType = ValueTypes.Number,
                Unit = "-"
            });

            scriptBuilder.AppendParameter(new CalculationParameter(
                number: 12,
                name: "f_cm(t)",
                value: "[beta_cc(t)]*[f_cm]")
            {
                Description = "Mean concrete compressive strength at an age of t days.",
                ValueType = ValueTypes.Number,
                Unit = "MPa"
            });

            scriptBuilder.AppendParameter(new CalculationParameter(
                number: 13,
                name: "f_ck(t)",
                value: "if([t]>=28,[f_ck],if([t]>3,[f_cm(t)]-8,ERROR('Not even 3 days.')))")
            {
                Description = "Concrete compressive strength at time t.",
                ValueType = ValueTypes.Number,
                Unit = "MPa"
            });

            scriptBuilder.Save(new XmlSave(),
                @"C:\Users\Disseminate\Desktop\Beam Statica\" + scriptBuilder.Name + ".xml");

            scriptBuilder.Calculate(30, 38, "CEM 42,5R", 5);

            StringAssert.StartsWith("0,2", scriptBuilder.GetParameterByName("s").Value.ToString());
            StringAssert.StartsWith("0,760874", scriptBuilder.GetParameterByName("beta_cc(t)").Value.ToString());
            StringAssert.StartsWith("28,913244", scriptBuilder.GetParameterByName("f_cm(t)").Value.ToString());
            StringAssert.StartsWith("20,913244", scriptBuilder.GetParameterByName("f_ck(t)").Value.ToString());
        }

        [Test]
        public void LoadTest_Success()
        {
            string name = "Compressive strength of concrete at an age";
            var loader = new XmlLoad<Build_IT_ScriptInterpreter.DataSaver.SerializableClasses.Script>();
            var scriptData = loader.LoadData(@"C:\Users\Disseminate\Desktop\Beam Statica\" + name + ".xml");

            var script = scriptData.Initialize();
            script.Calculate(30, 38, "CEM 42,5R", 5);

            StringAssert.StartsWith("0,2", script.GetParameterByName("s").Value.ToString());
            StringAssert.StartsWith("0,760874", script.GetParameterByName("beta_cc(t)").Value.ToString());
            StringAssert.StartsWith("28,913244", script.GetParameterByName("f_cm(t)").Value.ToString());
            StringAssert.StartsWith("20,913244", script.GetParameterByName("f_ck(t)").Value.ToString());
        }
    }
}
