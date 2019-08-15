using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Build_IT_ApplicationTest.AcceptanceTests.SnowLoads
{
    [TestFixture]
    public class SnowOverhangingTests
    {
        private const long ID = 25;
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

            parametersForCalculation["Zone"].Value = _testEngine.GetValueFromRange(
                 parametersForCalculation["Zone"].ValueOptions
                 .Select(vo => vo.Value)
                 .ToArray());
            parametersForCalculation["Topography"].Value = _testEngine.GetValueFromRange(
                parametersForCalculation["Topography"].ValueOptions
                .Select(vo => vo.Value)
                .ToArray());
            parametersForCalculation["A"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["s"].Value = _testEngine.GetSmallRandom();

            if (_testEngine.GetRandomBoolean())
            {
                parametersForCalculation["n"].Value = _testEngine.GetSmallRandom();
                parametersForCalculation["DesignSituation"].Value = _testEngine.GetValueFromRange(
                    parametersForCalculation["DesignSituation"].ValueOptions
                    .Select(vo => vo.Value)
                    .ToArray());
                parametersForCalculation["ExceptionalSituation"].Value = _testEngine.GetValueFromRange(
                    new string[] { "true", "false" });
            }

            parametersForCalculation["γ"].Value = _testEngine.GetSmallRandom();

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
