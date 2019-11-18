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
    public class SteelTensionTests
    {
        private const long ID = 1;
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

            parametersForCalculation["A"].Value = _testEngine.GetBigRandom(min:1);
            parametersForCalculation["N_Ed_"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["f_y_"].Value = _testEngine.GetBigRandom();

            Assert.DoesNotThrow(() => _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList()),
               String.Join(", ", parametersForCalculation.Select(p => $"{p.Value.Name}={p.Value.Value}")));
        }
    }
}
