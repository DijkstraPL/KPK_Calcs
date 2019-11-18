using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Build_IT_ApplicationTest.AcceptanceTests.WindLoads
{
    [TestFixture]
    public class FlatRoofWindLoadsTests
    {
        private const long ID = 10041;
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

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<ParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, ParameterResource>(
                parametersResource.Where(p => (p.Context & ParameterOptions.Editable) != 0 &&
                (p.Context & ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["WindZone"].Value = _testEngine.GetValueFromRange(
                parametersForCalculation["WindZone"].ValueOptions
                .Select(vo => vo.Value)
                .ToArray());
            parametersForCalculation["TerrainType"].Value = _testEngine.GetValueFromRange(
                parametersForCalculation["TerrainType"].ValueOptions
                .Select(vo => vo.Value)
                .ToArray());
            parametersForCalculation["A"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["d"].Value = _testEngine.GetSmallRandom(min: 1);
            parametersForCalculation["b"].Value = _testEngine.GetSmallRandom(min: 1);
            parametersForCalculation["h"].Value = _testEngine.GetSmallRandom(min: 1);
            parametersForCalculation["BuildingOrientation"].Value = _testEngine.GetValueFromRange(
                parametersForCalculation["BuildingOrientation"].ValueOptions
                .Select(vo => vo.Value)
                .ToArray());
            parametersForCalculation["Type"].Value = _testEngine.GetValueFromRange(
                parametersForCalculation["Type"].ValueOptions
                .Select(vo => vo.Value)
                .ToArray());
            parametersForCalculation["r"].Value = _testEngine.GetSmallRandom(min: 1);
            parametersForCalculation["α"].Value = _testEngine.GetSmallRandom(min: 30, max: 90);
            parametersForCalculation["h_p_"].Value = _testEngine.GetSmallRandom(min: 1);

            Assert.DoesNotThrow(() => _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList()),
           String.Join(", ", parametersForCalculation.Select(p => $"{p.Value.Name}={p.Value.Value}")));
        }


        [Test]
        public void CalculateTests_Roof1_MaxValues_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<ParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, ParameterResource>(
                parametersResource.Where(p => (p.Context & ParameterOptions.Editable) != 0 &&
                (p.Context & ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["WindZone"].Value = "III";
            parametersForCalculation["TerrainType"].Value = "Terrain_III";
            parametersForCalculation["A"].Value = "325";
            parametersForCalculation["d"].Value = "20";
            parametersForCalculation["b"].Value = "10";
            parametersForCalculation["h"].Value = "15";
            parametersForCalculation["BuildingOrientation"].Value = "Degrees_0";
            parametersForCalculation["Type"].Value = "Normal";
            parametersForCalculation["Orography"].Value = "CliffEscarpment";
            parametersForCalculation["L_u_"].Value = "15";
            parametersForCalculation["H"].Value = "5";
            parametersForCalculation["x_o_"].Value = "2";
            parametersForCalculation["WindDirection"].Value = "30";

            var results = _testEngine.Calculate(ID, parametersForCalculation
                .Where(p=> !string.IsNullOrWhiteSpace(p.Value.Value))
                .Select(p => p.Value).ToList());

            Assert.That(GetDoubleValue(results, "w_e,F,max_"), Is.EqualTo(-0.818).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,G,max_"), Is.EqualTo(-0.530).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,H,max_"), Is.EqualTo(-0.258).Within(0.001));
            Assert.That(GetDoubleValue(results, "w_e,I,max_"), Is.EqualTo(0.074).Within(0.001));
        }


        private double GetDoubleValue(List<ParameterResource> resultParameters, string name)
            => Convert.ToDouble(resultParameters.First(r => r.Name == name).Value);
    }
}
