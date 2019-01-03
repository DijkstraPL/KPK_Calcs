using Build_IT_ScriptInterpreter.DataSaver;
using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Scripts;
using NUnit.Framework;

namespace Build_IT_ScriptInterpreterTests.Scripts
{
    [TestFixture]
    public class ShearResistanceWithoutShearReinforcement
    {
        [Test]
        public void CreationTest_Success()
        {
            var scriptBuilder = new ScriptBuilder(name: "Shear resistance without shear reinforcement",
                description: "Calculate shear resistance without shear reinforcement. Base on [PN-EN-1992-1-1:2002 6.2.2].",
                "Eurocode 1992", "Concrete", "Shear", "Resistance");

            scriptBuilder
                .AppendParameter(new Parameter()
                {
                    Number = 1,
                    Name = "V_Ed_",
                    Description = "Shear force at calculated position.",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Editable | ParameterOptions.Visible,
                    Unit = "kN"
                })
                .AppendParameter(new Parameter()
                {
                    Number = 2,
                    Name = "f_ck_",
                    Description = "Mean compressive strength at 28 days.",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Editable | ParameterOptions.Visible,
                    Unit = "MPa"
                })
                .AppendParameter(new Parameter()
                {
                    Number = 4,
                    Name = "b_w_",
                    Description = "Section width.",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Editable | ParameterOptions.Visible,
                    Unit = "mm"
                })
                .AppendParameter(new Parameter()
                {
                    Number = 5,
                    Name = "d",
                    Description = "Effective depth of a cross-section.",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Editable | ParameterOptions.Visible,
                    Unit = "mm"
                })
                .AppendParameter(new Parameter()
                {
                    Number = 6,
                    Name = "A_sl_",
                    Description = "Area of the tensile reinforcement, which extends ≥ (lbd + d) beyond the section considered.",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Editable | ParameterOptions.Visible,
                    Unit = "cm^2"
                })
                .AppendParameter(new Parameter()
                {
                    Number = 7,
                    Name = "N_Ed_",
                    Description = "Axial force in the cross-section due to loading or prestressing in newtons (NEd>0 for compression)." +
                    " The influence of imposed deformations on NEd may be ignored.",
                    Value = 0,
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Editable | ParameterOptions.Visible,
                    Unit = "N"
                })
                .AppendParameter(new Parameter()
                {
                    Number = 8,
                    Name = "A_c_",
                    Description = "Area of concrete cross section [mm2].",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.Editable | ParameterOptions.Visible,
                    Unit = "mm^2"
                })
                .AppendParameter(new Parameter()
                {
                    Number = 10,
                    Name = "k_1_",
                    Value = 0.15,
                    Description = "Coefficient",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.StaticData,
                    Unit = "-"
                })
                .AppendParameter(new Parameter()
                {
                    Number = 11,
                    Name = "γ_c_",
                    Value = 1.4,
                    Description = "Partial factors for concrete.",
                    ValueType = ValueTypes.Number,
                    Context = ParameterOptions.StaticData,
                    Unit = "-"
                }); 

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 20,
                Name = "C_Rd,c_",
                Value = "0.18/[γ_c_]",
                Description = "Coefficient.",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                Unit = "-"
            });

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 21,
                Name = "k",
                Value = "Min(1+Sqrt(200/[d]),2)",
                Description = "Coefficient.",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                Unit = "-"
            });

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 22,
                Name = "ρ_l_",
                Value = "Min(0.02,[A_sl_]/([b_w_]*[d]))",
                Description = "Reinforcement ratio for longitudinal reinforcement.",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                Unit = "-"
            });

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 23,
                Name = "f_cd_",
                Value = "[f_ck_]/[γ_c_]",
                Description = "Design value of concrete compressive strength.",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                Unit = "MPa"
            });

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 24,
                Name = "σ _cp_",
                Value = "Min([N_Ed_]/[A_c_],0.2*[f_cd_])",
                Description = "Compressive stress in the concrete from axial load or prestressing.",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                Unit = "MPa"
            });

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 25,
                Name = "v_min_",
                Value = "0.035*Pow([k],3/2)*Pow([f_ck_],1/2)",
                Description = "Coefficient.",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                Unit = "MPa"
            });

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 26,
                Name = "V_Rd,c_",
                Value = "Max(([v_min_]+[k_1_]*[σ _cp_])*[b_w_]*[d]," +
                "([C_Rd,c_]*[k]*Pow(100*[ρ_l_]*[f_ck_],1/3)+[k_1_]*[σ _cp_])*[b_w_]*[d])" +
                "/1000",
                Description = "Design value for the shear resistance.",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                Unit = "kN"
            });

            scriptBuilder.AppendParameter(new Parameter()
            {
                Number = 27,
                Name = "Resistance",
                Value = "[V_Ed_]/[V_Rd,c_]*100",
                Description = "Resistance of the element without shear reinforcement.",
                ValueType = ValueTypes.Number,
                Context = ParameterOptions.Calculation | ParameterOptions.Visible,
                Unit = "%"
            });

            scriptBuilder.Save(new XmlSave(),
                @"C:\Users\Disseminate\Desktop\Script Interpreter\" + scriptBuilder.Name + ".xml");

            scriptBuilder.Calculate(100, 30, 240, 461, 339, 100, 150000);

            Assert.That(0.128571, Is.EqualTo(scriptBuilder.GetParameterByName("C_Rd,c_").Value).Within(0.000001));
            Assert.That(1.658664, Is.EqualTo(scriptBuilder.GetParameterByName("k").Value).Within(0.000001));
            Assert.That(0.003063, Is.EqualTo(scriptBuilder.GetParameterByName("ρ_l_").Value).Within(0.000001));
            Assert.That(21.428571, Is.EqualTo(scriptBuilder.GetParameterByName("f_cd_").Value).Within(0.000001));
            Assert.That(0.000666, Is.EqualTo(scriptBuilder.GetParameterByName("σ _cp_").Value).Within(0.000001));
            Assert.That(0.409512, Is.EqualTo(scriptBuilder.GetParameterByName("v_min_").Value).Within(0.000001));
            Assert.That(49.436619, Is.EqualTo(scriptBuilder.GetParameterByName("V_Rd,c_").Value).Within(0.000001));
            Assert.That(202.279, Is.EqualTo(scriptBuilder.GetParameterByName("Resistance").Value).Within(0.001));
        }

        [Test]
        public void LoadTest_Success()
        {
            string name = "Shear resistance without shear reinforcement";
            var loader = new XmlLoad<Build_IT_ScriptInterpreter.DataSaver.SerializableClasses.Script>();
            var scriptData = loader.LoadData(@"C:\Users\Disseminate\Desktop\Script Interpreter\" + name + ".xml");

            var script = scriptData.Initialize();
          //  script.Calculate(30, 240, 461, 339, 100, 150000);
            script.CalculateFromText("[V_Ed_]=100|[f_ck_]=30|[b_w_]=240|[d]=461|[A_sl_]=339|[N_Ed_]=100|[A_c_]=150000");

            Assert.That(0.128571, Is.EqualTo(script.GetParameterByName("C_Rd,c_").Value).Within(0.000001));
            Assert.That(1.658664, Is.EqualTo(script.GetParameterByName("k").Value).Within(0.000001));
            Assert.That(0.003063, Is.EqualTo(script.GetParameterByName("ρ_l_").Value).Within(0.000001));
            Assert.That(21.428571, Is.EqualTo(script.GetParameterByName("f_cd_").Value).Within(0.000001));
            Assert.That(0.000666, Is.EqualTo(script.GetParameterByName("σ _cp_").Value).Within(0.000001));
            Assert.That(0.409512, Is.EqualTo(script.GetParameterByName("v_min_").Value).Within(0.000001));
            Assert.That(49.436619, Is.EqualTo(script.GetParameterByName("V_Rd,c_").Value).Within(0.000001));
            Assert.That(202.279, Is.EqualTo(script.GetParameterByName("Resistance").Value).Within(0.001));
        }
    }
}
