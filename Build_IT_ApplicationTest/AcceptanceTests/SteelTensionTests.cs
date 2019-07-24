using AutoMapper;
using Build_IT_Application.Infrastructures;
using Build_IT_Application.Infrastructures.Interfaces;
using Build_IT_Application.Mapping;
using Build_IT_Application.ScriptInterpreter.Calculations.Commands;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_DataAccess.ScriptInterpreter;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
        public void SteelTensionCalculationTest_RandomExamples_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<ParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, ParameterResource>(
                parametersResource.Where(p => (p.Context & ParameterOptions.Editable) != 0 &&
                (p.Context & ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            var random = new Random();
            Func<string> getBigRandom = () => (random.NextDouble() * random.Next(1000)).ToString();
            Func<string> getSmallRandom = () => (random.NextDouble() * random.Next(50)).ToString();
            Func<string[], string> getValueFromRange = possibleValues => possibleValues[random.Next(possibleValues.Length)];
            parametersForCalculation["A"].Value = getBigRandom();
            parametersForCalculation["N_Ed_"].Value = getBigRandom();
            parametersForCalculation["f_y_"].Value = getBigRandom();

            Assert.DoesNotThrow(() => _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList()),
               String.Join(", ", parametersForCalculation.Select(p => $"{p.Value.Name}={p.Value.Value}")));
        }
    }
}
