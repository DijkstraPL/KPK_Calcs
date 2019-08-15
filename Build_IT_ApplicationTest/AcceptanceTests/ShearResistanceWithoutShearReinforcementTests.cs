using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Build_IT_ApplicationTest.AcceptanceTests
{
    [TestFixture]
    public class ShearResistanceWithoutShearReinforcementTests
    {
        private const long ID = 4;
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

            parametersForCalculation["V_Ed_"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["f_ck_"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["b_w_"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["d"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["A_sl_"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["N_Ed_"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["A_c_"].Value = _testEngine.GetBigRandom();

            Assert.DoesNotThrow(() => _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList()),
               String.Join(", ", parametersForCalculation.Select(p => $"{p.Value.Name}={p.Value.Value}")));
        }
    }
}
