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
    public class CompressiveStrengthOfConcreteAtAnAgeTests
    {
        private const long ID = 2;
        private ScriptCalculatorTestEngine _testEngine;

        [SetUp]
        public void SetUp()
        {
            _testEngine = new ScriptCalculatorTestEngine();
        }

        [Test]
        [Repeat(25)]
        public void CompressiveStrengthOfConcreteAtAnAgeTests_RandomExamples_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<ParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, ParameterResource>(
                parametersResource.Where(p => (p.Context & ParameterOptions.Editable) != 0 &&
                (p.Context & ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["f_ck_"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["f_cm_"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["cement_type_"].Value = _testEngine.GetValueFromRange(
                parametersForCalculation["cement_type_"].ValueOptions
                .Select(vo => vo.Value)
                .ToArray());
            parametersForCalculation["t"].Value = _testEngine.GetBigRandom(min: 3);

            Assert.DoesNotThrow(() => _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList()),
               String.Join(", ", parametersForCalculation.Select(p => $"{p.Value.Name}={p.Value.Value}")));
        }
    }
}
