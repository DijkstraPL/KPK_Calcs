using Build_IT_Application.ScriptInterpreter.Calculations.Queries;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Enums;
using SIP = Build_IT_ScriptInterpreter.Parameters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Build_IT_ApplicationTest.AcceptanceTests
{
    [TestFixture]
    public class MandrelDiameterTests
    {
        private const long ID = 7;
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

            parametersForCalculation["φ"].Value = _testEngine.GetSmallRandom();
            parametersForCalculation["Type"].Value = _testEngine.GetValueFromRange(
                parameters.First(p=>p.Name == "Type").ValueOptions
                .Select(vo => vo.Value)
                .ToArray());
            parametersForCalculation["Position"].Value = _testEngine.GetValueFromRange(
                parameters.First(p => p.Name == "Position").ValueOptions
                .Select(vo => vo.Value)
                .ToArray());
            parametersForCalculation["d"].Value = _testEngine.GetBigRandom();

            Assert.DoesNotThrow(() => _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList()),
               String.Join(", ", parametersForCalculation.Select(p => $"{p.Value.Name}={p.Value.Value}")));
        }
    }
}
