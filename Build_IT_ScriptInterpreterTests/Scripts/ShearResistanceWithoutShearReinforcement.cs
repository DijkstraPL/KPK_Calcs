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
                .AppendParameter(new DataParameter(
                    number: 2,
                    name: "f_ck")
                {
                    Description = "Mean compressive strength at 28 days.",
                    ValueType = ValueTypes.Number,
                    Unit = "MPa"
                })
                .AppendParameter(new DataParameter(
                    number: 4,
                    name: "b_w")
                {
                    Description = "Section width.",
                    ValueType = ValueTypes.Number,
                    Unit = "mm"
                })
                .AppendParameter(new DataParameter(
                    number: 5,
                    name: "d")
                {
                    Description = "Effective depth of a cross-section.",
                    ValueType = ValueTypes.Number,
                    Unit = "mm"
                })
                .AppendParameter(new DataParameter(
                    number: 6,
                    name: "A_sl")
                {
                    Description = "Area of the tensile reinforcement, which extends ≥ (lbd + d) beyond the section considered.",
                    ValueType = ValueTypes.Number,
                    Unit = "cm^2"
                })
                .AppendParameter(new DataParameter(
                    number: 7,
                    name: "N_Ed")
                {
                    Description = "Axial force in the cross-section due to loading or prestressing in newtons (NEd>0 for compression)." +
                    " The influence of imposed deformations on NE may be ignored.",
                    Value = 0,
                    ValueType = ValueTypes.Number,
                    Unit = "N"
                })
                .AppendParameter(new DataParameter(
                    number: 8,
                    name: "A_c")
                {
                    Description = "Area of concrete cross section [mm2].",
                    ValueType = ValueTypes.Number,
                    Unit = "mm^2"
                })
                .AppendParameter(new StaticDataParameter(
                    number: 10,
                    name: "k_1",
                    value: 0.15)
                {
                    Description = "Coefficient",
                    ValueType = ValueTypes.Number,
                    Unit = "-"
                })
                .AppendParameter(new StaticDataParameter(
                number: 11,
                name: "gamma_C",
                value: 1.4)
                {
                    Description = "Partial factors for concrete.",
                    ValueType = ValueTypes.Number,
                    Unit = "-"
                }); 

            scriptBuilder.AppendParameter(new CalculationParameter(
                number: 20,
                name: "C_Rd,c",
                value: "0.18/[gamma_C]")
            {
                Description = "Coefficient.",
                ValueType = ValueTypes.Number,
                Unit = "-"
            });

            scriptBuilder.AppendParameter(new CalculationParameter(
                number: 21,
                name: "k",
                value: "Min(1+Sqrt(200/[d]),2)")
            {
                Description = "Coefficient.",
                ValueType = ValueTypes.Number,
                Unit = "-"
            });

            scriptBuilder.AppendParameter(new CalculationParameter(
                number: 22,
                name: "rho_l",
                value: "Min(0.02,[A_sl]/([b_w]*[d]))")
            {
                Description = "Reinforcement ratio for longitudinal reinforcement.",
                ValueType = ValueTypes.Number,
                Unit = "-"
            });

            scriptBuilder.AppendParameter(new CalculationParameter(
                number: 23,
                name: "f_cd",
                value: "[f_ck]/[gamma_C]")
            {
                Description = "Design value of concrete compressive strength.",
                ValueType = ValueTypes.Number,
                Unit = "MPa"
            });

            scriptBuilder.AppendParameter(new CalculationParameter(
                number: 24,
                name: "sigma_cp",
                value: "Min([N_Ed]/[A_c],0.2*[f_cd])")
            {
                Description = "Compressive stress in the concrete from axial load or prestressing.",
                ValueType = ValueTypes.Number,
                Unit = "MPa"
            });

            scriptBuilder.AppendParameter(new CalculationParameter(
                number: 25,
                name: "v_min",
                value: "0.035*Pow([k],3/2)*Pow([f_ck],1/2)")
            {
                Description = "Coefficient.",
                ValueType = ValueTypes.Number,
                Unit = "MPa"
            });

            scriptBuilder.AppendParameter(new CalculationParameter(
                number: 26,
                name: "V_Rd,c",
                value: "Max(([v_min]+[k_1]*[sigma_cp])*[b_w]*[d]," +
                "([C_Rd,c]*[k]*Pow(100*[rho_l]*[f_ck],1/3)+[k_1]*[sigma_cp])*[b_w]*[d])" +
                "/1000")
            {
                Description = "Design value for the shear resistance.",
                ValueType = ValueTypes.Number,
                Unit = "kN"
            });

            scriptBuilder.Save(new XmlSave(),
                @"C:\Users\Disseminate\Desktop\Beam Statica\" + scriptBuilder.Name + ".xml");

            scriptBuilder.Calculate(30, 240, 461, 339, 100, 150000);

            StringAssert.StartsWith("0,128571", scriptBuilder.GetParameterByName("C_Rd,c").Value.ToString());
            StringAssert.StartsWith("1,658664", scriptBuilder.GetParameterByName("k").Value.ToString());
            StringAssert.StartsWith("0,003063", scriptBuilder.GetParameterByName("rho_l").Value.ToString());
            StringAssert.StartsWith("21,428571", scriptBuilder.GetParameterByName("f_cd").Value.ToString());
            StringAssert.StartsWith("0,000666", scriptBuilder.GetParameterByName("sigma_cp").Value.ToString());
            StringAssert.StartsWith("0,409512", scriptBuilder.GetParameterByName("v_min").Value.ToString());
            StringAssert.StartsWith("49,436619", scriptBuilder.GetParameterByName("V_Rd,c").Value.ToString());
        }

        [Test]
        public void LoadTest_Success()
        {
            string name = "Shear resistance without shear reinforcement";
            var loader = new XmlLoad<Build_IT_ScriptInterpreter.DataSaver.SerializableClasses.Script>();
            var scriptData = loader.LoadData(@"C:\Users\Disseminate\Desktop\Beam Statica\" + name + ".xml");

            var script = scriptData.Initialize();
          //  script.Calculate(30, 240, 461, 339, 100, 150000);
            script.CalculateFromText("[f_ck]=30,[b_w]=240,[d]=461,[A_sl]=339,[N_Ed]=100,[A_c]=150000");

            StringAssert.StartsWith("0,128571", script.GetParameterByName("C_Rd,c").Value.ToString());
            StringAssert.StartsWith("1,658664", script.GetParameterByName("k").Value.ToString());
            StringAssert.StartsWith("0,003063", script.GetParameterByName("rho_l").Value.ToString());
            StringAssert.StartsWith("21,428571", script.GetParameterByName("f_cd").Value.ToString());
            StringAssert.StartsWith("0,000666", script.GetParameterByName("sigma_cp").Value.ToString());
            StringAssert.StartsWith("0,409512", script.GetParameterByName("v_min").Value.ToString());
            StringAssert.StartsWith("49,436619", script.GetParameterByName("V_Rd,c").Value.ToString());
        }
    }
}
