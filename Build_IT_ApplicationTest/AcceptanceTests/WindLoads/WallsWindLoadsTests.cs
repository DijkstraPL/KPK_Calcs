using Build_IT_Application.ScriptInterpreter.Calculations.Queries;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Data.Entities.Scripts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using SIP = Build_IT_ScriptInterpreter.Parameters;

namespace Build_IT_ApplicationTest.AcceptanceTests.WindLoads
{
    [TestFixture]
    public class WallsWindLoadsTests
    {
        private const long ID = 10040;
        private ScriptCalculatorTestEngine _testEngine;

        [SetUp]
        public void SetUp()
        {
            _testEngine = new ScriptCalculatorTestEngine();
        }

        [Test]
        [Repeat(25)]
        public void CalculateTests_RandomExamples_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["WindZone"].Value = _testEngine.GetValueFromRange(
                parameters.First(p => p.Name=="WindZone").ValueOptions
                .Select(vo => vo.Value)
                .ToArray());
            parametersForCalculation["TerrainType"].Value = _testEngine.GetValueFromRange(
                parameters.First(p => p.Name == "TerrainType").ValueOptions
                .Select(vo => vo.Value)
                .ToArray());
            parametersForCalculation["A"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["d"].Value = _testEngine.GetSmallRandom(min: 1);
            parametersForCalculation["b"].Value = _testEngine.GetSmallRandom(min:1);
            parametersForCalculation["h"].Value = _testEngine.GetSmallRandom(min:1);
            parametersForCalculation["BuildingOrientation"].Value = _testEngine.GetValueFromRange(
                parameters.First(p => p.Name == "BuildingOrientation").ValueOptions
                .Select(vo => vo.Value)
                .ToArray());

            Assert.DoesNotThrow(() => _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList()),
           String.Join(", ", parametersForCalculation.Select(p => $"{p.Value.Name}={p.Value.Value}")));
        }
        
        [Test]
        public void ExternalWindPressureCalculationsTest_Walls_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["WindZone"].Value = "I_III";
            parametersForCalculation["TerrainType"].Value = "Terrain_III";
            parametersForCalculation["A"].Value = "325";
            parametersForCalculation["d"].Value = "10";
            parametersForCalculation["b"].Value = "10";
            parametersForCalculation["h"].Value = "15";
            parametersForCalculation["BuildingOrientation"].Value = "Degrees_0";

            var results = _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList());

            Assert.That(GetDoubleValue(results,"w_e,A_"), Is.EqualTo(-0.754).Within(0.001));
            Assert.That(GetDoubleValue(results,"w_e,B_"), Is.EqualTo(-0.503).Within(0.001));
            Assert.That(GetDoubleValue(results,"w_e,C_"), Is.EqualTo(double.NaN).Within(0.001));
            Assert.That(GetDoubleValue(results,"w_e,D_"), Is.EqualTo(0.503).Within(0.001));
            Assert.That(GetDoubleValue(results,"w_e,E_"), Is.EqualTo(-0.330).Within(0.001));
        }

        [Test]
        public void ExternalWindPressureCalculationsTest_AS_SX01a_Walls_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["WindZone"].Value = "II";
            parametersForCalculation["TerrainType"].Value = "Terrain_II";
            parametersForCalculation["A"].Value = "325";
            parametersForCalculation["d"].Value = "72";
            parametersForCalculation["b"].Value = "30";
            parametersForCalculation["h"].Value = "7.3";
            parametersForCalculation["BuildingOrientation"].Value = "Degrees_0";

            var results = _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList());

            Assert.That(GetDoubleValue(results, "w_e,D_"), Is.EqualTo(0.638).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,E_"), Is.EqualTo(-0.273).Within(0.001));
        }

        [Test]
        public void ExternalWindPressureCalculationsTest_8_1a_Walls_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["WindZone"].Value = "I";
            parametersForCalculation["TerrainType"].Value = "Terrain_III";
            parametersForCalculation["A"].Value = "175";
            parametersForCalculation["d"].Value = "28.8";
            parametersForCalculation["b"].Value = "42";
            parametersForCalculation["h"].Value = "10.6";
            parametersForCalculation["BuildingOrientation"].Value = "Degrees_0";

            var results = _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList());

            Assert.That(GetDoubleValue(results, "w_e,A_"), Is.EqualTo(-0.704).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,B_"), Is.EqualTo(-0.470).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,C_"), Is.EqualTo(-0.294).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,D_"), Is.EqualTo(0.420).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,E_"), Is.EqualTo(-0.194).Within(0.001));
        }

        [Test]
        public void ExternalWindPressureCalculationsTest_8_1b_Walls_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["WindZone"].Value = "I";
            parametersForCalculation["TerrainType"].Value = "Terrain_III";
            parametersForCalculation["A"].Value = "175";
            parametersForCalculation["d"].Value = "28.8";
            parametersForCalculation["b"].Value = "42";
            parametersForCalculation["h"].Value = "10.6";
            parametersForCalculation["BuildingOrientation"].Value = "Degrees_90";

            var results = _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList());

            Assert.That(GetDoubleValue(results, "w_e,A_"), Is.EqualTo(-0.704).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,B_"), Is.EqualTo(-0.470).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,C_"), Is.EqualTo(-0.294).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,D_"), Is.EqualTo(0.411).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,E_"), Is.EqualTo(-0.177).Within(0.001));
        }

        [Test]
        public void ExternalWindPressureCalculationsTest_8_2_48m_Walls_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["WindZone"].Value = "III";
            parametersForCalculation["TerrainType"].Value = "Terrain_IV";
            parametersForCalculation["A"].Value = "360";
            parametersForCalculation["d"].Value = "16";
            parametersForCalculation["b"].Value = "20";
            parametersForCalculation["h"].Value = "48";
            parametersForCalculation["BuildingOrientation"].Value = "Degrees_0";
            parametersForCalculation["x"].Value = "10";
            parametersForCalculation["h_ave_"].Value = "15";
            parametersForCalculation["StructuralType"].Value = "SteelBuilding";

            var results = _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList());

            Assert.That(GetDoubleValue(results, "w_e,A_"), Is.EqualTo(-0.628).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,B_"), Is.EqualTo(-0.418).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,C_"), Is.EqualTo(double.NaN).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,D_"), Is.EqualTo(0.418).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,E_"), Is.EqualTo(-0.314).Within(0.001));
        }

        [Test]
        public void ExternalWindPressureCalculationsTest_8_2_24m_Walls_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["WindZone"].Value = "III";
            parametersForCalculation["TerrainType"].Value = "Terrain_IV";
            parametersForCalculation["A"].Value = "360";
            parametersForCalculation["d"].Value = "16";
            parametersForCalculation["b"].Value = "20";
            parametersForCalculation["h"].Value = "48";
            parametersForCalculation["BuildingOrientation"].Value = "Degrees_0";
            parametersForCalculation["x"].Value = "10";
            parametersForCalculation["h_ave_"].Value = "15";
            parametersForCalculation["StructuralType"].Value = "SteelBuilding";
            parametersForCalculation["z_e_"].Value = "24";

            var results = _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList());

            Assert.That(GetDoubleValue(results, "w_e,A_"), Is.EqualTo(-0.479).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,B_"), Is.EqualTo(-0.319).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,C_"), Is.EqualTo(double.NaN).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,D_"), Is.EqualTo(0.319).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,E_"), Is.EqualTo(-0.239).Within(0.001));
        }

        [Test]
        public void ExternalWindPressureCalculationsTest_8_2_20m_Walls_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["WindZone"].Value = "III";
            parametersForCalculation["TerrainType"].Value = "Terrain_IV";
            parametersForCalculation["A"].Value = "360";
            parametersForCalculation["d"].Value = "16";
            parametersForCalculation["b"].Value = "20";
            parametersForCalculation["h"].Value = "48";
            parametersForCalculation["BuildingOrientation"].Value = "Degrees_0";
            parametersForCalculation["x"].Value = "10";
            parametersForCalculation["h_ave_"].Value = "15";
            parametersForCalculation["StructuralType"].Value = "SteelBuilding";
            parametersForCalculation["z_e_"].Value = "20";

            var results = _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList());

            Assert.That(GetDoubleValue(results, "w_e,A_"), Is.EqualTo(-0.464).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,B_"), Is.EqualTo(-0.309).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,C_"), Is.EqualTo(double.NaN).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,D_"), Is.EqualTo(0.309).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,E_"), Is.EqualTo(-0.232).Within(0.001));
        }

        [Test]
        public void ExternalWindPressureCalculationsTest_Example2019_04_27_Walls_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["WindZone"].Value = "III";
            parametersForCalculation["TerrainType"].Value = "Terrain_I";
            parametersForCalculation["A"].Value = "400";
            parametersForCalculation["d"].Value = "110";
            parametersForCalculation["b"].Value = "70";
            parametersForCalculation["h"].Value = "200";
            parametersForCalculation["Orography"].Value = "HillRidge";
            parametersForCalculation["L_u_"].Value = "20";
            parametersForCalculation["L_d_"].Value = "10";
            parametersForCalculation["H"].Value = "10";
            parametersForCalculation["x_o_"].Value = "-2";
            parametersForCalculation["BuildingOrientation"].Value = "Degrees_0";
            parametersForCalculation["WindDirection"].Value = "30";
            parametersForCalculation["StructuralType"].Value = "ReinforcementConcreteBuilding";
            parametersForCalculation["z_e_"].Value = "100";

            var results = _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList());

            Assert.That(GetDoubleValue(results, "e"), Is.EqualTo(70).Within(0.001));
            Assert.That(GetDoubleValue(results, "v_b,0_"), Is.EqualTo(23.32).Within(0.001));
            Assert.That(GetDoubleValue(results, "c_dir_"), Is.EqualTo(0.7).Within(0.001));
            Assert.That(GetDoubleValue(results, "v_b_"), Is.EqualTo(16.324).Within(0.001));
            Assert.That(GetDoubleValue(results, "c_r_(z_e_)"), Is.EqualTo(1.619).Within(0.001));
            Assert.That(GetDoubleValue(results, "c_0_(z_e_)"), Is.EqualTo(1).Within(0.001));
            Assert.That(GetDoubleValue(results, "v_m_(z_e_)"), Is.EqualTo(26.425).Within(0.001));
            Assert.That(GetDoubleValue(results, "I_v_(z_e_)"), Is.EqualTo(0.109).Within(0.001));
            Assert.That(GetDoubleValue(results, "q_p_(z_e_)"), Is.EqualTo(0.738).Within(0.001));
            Assert.That(GetDoubleValue(results, "c_s_c_d_"), Is.EqualTo(0.878).Within(0.001));

            Assert.That(GetDoubleValue(results, "w_e,A_"), Is.EqualTo(-0.778).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,B_"), Is.EqualTo(-0.518).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,C_"), Is.EqualTo(-0.324).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,D_"), Is.EqualTo(0.518).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,E_"), Is.EqualTo(-0.350).Within(0.001));
        }


        [Test]
        public void ExternalWindPressureCalculationsTest_Example2019_04_27_At100meters_Walls_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["WindZone"].Value = "III";
            parametersForCalculation["TerrainType"].Value = "Terrain_I";
            parametersForCalculation["A"].Value = "400";
            parametersForCalculation["d"].Value = "110";
            parametersForCalculation["b"].Value = "70";
            parametersForCalculation["h"].Value = "200";
            parametersForCalculation["Orography"].Value = "HillRidge";
            parametersForCalculation["L_u_"].Value = "20";
            parametersForCalculation["L_d_"].Value = "10";
            parametersForCalculation["H"].Value = "10";
            parametersForCalculation["x_o_"].Value = "-2";
            parametersForCalculation["BuildingOrientation"].Value = "Degrees_0";
            parametersForCalculation["WindDirection"].Value = "30";
            parametersForCalculation["StructuralType"].Value = "ReinforcementConcreteBuilding";
            parametersForCalculation["z_e_"].Value = "100";

            var results = _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList());

            Assert.That(GetDoubleValue(results, "e"), Is.EqualTo(70).Within(0.001));
            Assert.That(GetDoubleValue(results, "v_b,0_"), Is.EqualTo(23.32).Within(0.001));
            Assert.That(GetDoubleValue(results, "c_dir_"), Is.EqualTo(0.7).Within(0.001));
            Assert.That(GetDoubleValue(results, "v_b_"), Is.EqualTo(16.324).Within(0.001));
            Assert.That(GetDoubleValue(results, "c_r_(z_e_)"), Is.EqualTo(1.619).Within(0.001));
            Assert.That(GetDoubleValue(results, "c_0_(z_e_)"), Is.EqualTo(1).Within(0.001));
            Assert.That(GetDoubleValue(results, "v_m_(z_e_)"), Is.EqualTo(26.425).Within(0.001));
            Assert.That(GetDoubleValue(results, "I_v_(z_e_)"), Is.EqualTo(0.109).Within(0.001));
            Assert.That(GetDoubleValue(results, "q_p_(z_e_)"), Is.EqualTo(0.738).Within(0.001));
            Assert.That(GetDoubleValue(results, "c_s_c_d_"), Is.EqualTo(0.878).Within(0.001));

            Assert.That(GetDoubleValue(results, "w_e,A_"), Is.EqualTo(-0.778).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,B_"), Is.EqualTo(-0.518).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,C_"), Is.EqualTo(-0.324).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,D_"), Is.EqualTo(0.518).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,E_"), Is.EqualTo(-0.350).Within(0.001));
        }

        [Test]
        public void ExternalWindPressureCalculationsTest_Example2019_04_28_Walls_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["WindZone"].Value = "II";
            parametersForCalculation["TerrainType"].Value = "Terrain_III";
            parametersForCalculation["A"].Value = "123";
            parametersForCalculation["d"].Value = "40";
            parametersForCalculation["b"].Value = "50";
            parametersForCalculation["h"].Value = "30";
            parametersForCalculation["Orography"].Value = "HillRidge";
            parametersForCalculation["L_u_"].Value = "20";
            parametersForCalculation["L_d_"].Value = "10";
            parametersForCalculation["H"].Value = "10";
            parametersForCalculation["x_o_"].Value = "2";
            parametersForCalculation["BuildingOrientation"].Value = "Degrees_0";
            parametersForCalculation["WindDirection"].Value = "210";
            parametersForCalculation["StructuralType"].Value = "ReinforcementConcreteBuilding";

            var results = _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList());

            Assert.That(GetDoubleValue(results, "e"), Is.EqualTo(50).Within(0.001));
            Assert.That(GetDoubleValue(results, "v_b,0_"), Is.EqualTo(26).Within(0.001));
            Assert.That(GetDoubleValue(results, "c_dir_"), Is.EqualTo(0.8).Within(0.001));
            Assert.That(GetDoubleValue(results, "v_b_"), Is.EqualTo(20.8).Within(0.001));
            Assert.That(GetDoubleValue(results, "c_r_(z_e_)"), Is.EqualTo(0.986).Within(0.001));
            Assert.That(GetDoubleValue(results, "c_0_(z_e_)"), Is.EqualTo(1.115).Within(0.001));
            Assert.That(GetDoubleValue(results, "v_m_(z_e_)"), Is.EqualTo(22.851).Within(0.001));
            Assert.That(GetDoubleValue(results, "I_v_(z_e_)"), Is.EqualTo(0.195).Within(0.001));
            Assert.That(GetDoubleValue(results, "q_p_(z_e_)"), Is.EqualTo(0.771).Within(0.001));
            Assert.That(GetDoubleValue(results, "c_s_c_d_"), Is.EqualTo(0.817).Within(0.001));

            Assert.That(GetDoubleValue(results, "w_e,A_"), Is.EqualTo(-0.756).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,B_"), Is.EqualTo(-0.504).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,C_"), Is.EqualTo(double.NaN).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,D_"), Is.EqualTo(0.483).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,E_"), Is.EqualTo(-0.273).Within(0.001));
        }

        private double GetDoubleValue(List<ParameterResource> resultParameters, string name) 
            => Convert.ToDouble(resultParameters.First(r => r.Name == name).Value);
    }
}
