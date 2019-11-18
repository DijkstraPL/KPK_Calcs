using Build_IT_Application.ScriptInterpreter.Calculations.Queries;
using Build_IT_Data.Entities.Scripts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using SIP = Build_IT_ScriptInterpreter.Parameters;

namespace Build_IT_ApplicationTest.AcceptanceTests.SnowLoads
{
    [TestFixture]
    public class MonopitchRoofTests
    {
        private const long ID = 10;
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

            parametersForCalculation["Zone"].Value = _testEngine.GetValueFromRange(
                parameters.First(p => p.Name == "Zone").ValueOptions
                .Select(vo => vo.Value)
                .ToArray());
            parametersForCalculation["Topography"].Value = _testEngine.GetValueFromRange(
                parameters.First(p => p.Name == "Topography").ValueOptions
                .Select(vo => vo.Value)
                .ToArray());
            parametersForCalculation["A"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["α"].Value = _testEngine.GetSmallRandom(max: 90);
            parametersForCalculation["SnowFences"].Value = _testEngine.GetValueFromRange(
                new string[] { "true", "false" });

            if(_testEngine.GetRandomBoolean())
            {
                parametersForCalculation["n"].Value = _testEngine.GetSmallRandom();
                parametersForCalculation["DesignSituation"].Value = _testEngine.GetValueFromRange(
                    parameters.First(p => p.Name == "DesignSituation").ValueOptions
                    .Select(vo => vo.Value)
                    .ToArray());
                parametersForCalculation["ExceptionalSituation"].Value = _testEngine.GetValueFromRange(
                    new string[] { "true", "false" });
            }

            if (_testEngine.GetRandomBoolean())
            {
                parametersForCalculation["t_i_"].Value = _testEngine.GetSmallRandom();
                parametersForCalculation["U"].Value = _testEngine.GetSmallRandom();
            }

                Assert.DoesNotThrow(() => _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList()),
               String.Join(", ", parametersForCalculation.Select(p => $"{p.Value.Name}={p.Value.Value}")));
        }
    }
}
