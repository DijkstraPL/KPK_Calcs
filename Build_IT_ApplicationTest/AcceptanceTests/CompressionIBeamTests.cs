using Build_IT_Application.ScriptInterpreter.Calculations.Queries;
using Build_IT_Data.Entities.Scripts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using SIP = Build_IT_ScriptInterpreter.Parameters;

namespace Build_IT_ApplicationTest.AcceptanceTests
{
    [TestFixture]
    public class CompressionIBeamTests
    {
        private const long ID = 6;
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

            parametersForCalculation["f_y_"].Value = _testEngine.GetBigRandom(min: 0.01);
            parametersForCalculation["h"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["b"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["t_f_"].Value = _testEngine.GetSmallRandom(min: 0.01);
            parametersForCalculation["t_w_"].Value = _testEngine.GetSmallRandom(min: 0.01);
            parametersForCalculation["r"].Value = _testEngine.GetSmallRandom(min: 0.01);
            parametersForCalculation["a"].Value = _testEngine.GetSmallRandom(min: 0.01);
            parametersForCalculation["Type"].Value = _testEngine.GetValueFromRange(
                parameters.First(p => p.Name == "Type").ValueOptions
                .Select(vo => vo.Value)
                .ToArray());

            Assert.DoesNotThrow(() => _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList()),
               String.Join(", ", parametersForCalculation.Select(p => $"{p.Value.Name}={p.Value.Value}")));
        }
    }
}
