using AutoMapper;
using Build_IT_Application.Infrastructures;
using Build_IT_Application.Infrastructures.Interfaces;
using Build_IT_Application.Mapping;
using Build_IT_Application.ScriptInterpreter.Calculations.Queries;
using Build_IT_Application.ScriptInterpreter.Calculations.Queries.Calculate;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_DataAccess.ScriptInterpreter;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Build_IT_ApplicationTest.AcceptanceTests
{
    public class ScriptCalculatorTestEngine
    {
        public ScriptInterpreterDbContext ScriptInterpreterDbContext { get; }
        public IScriptRepository ScriptRepository { get; }
        public ITranslationService TranslationService { get; }
        public IParameterRepository ParameterRepository { get; }
        public IMapper Mapper { get; }
        public CalculateQuery.Handler CalculateCommand { get; }

        private readonly Random _random = new Random();

        public ScriptCalculatorTestEngine()
        {
            var logger = new Mock<ILogger<CalculateQuery.Handler>>();

            ScriptInterpreterDbContext = new ScriptInterpreterDbContext(
                new DbContextOptions<ScriptInterpreterDbContext>());
            ParameterRepository = new ParameterRepository(context: ScriptInterpreterDbContext);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ScriptMappingProfile());
            });
            ScriptRepository = new ScriptRepository(ScriptInterpreterDbContext);
            TranslationService = new TranslationService(new TranslationRepository(ScriptInterpreterDbContext));
            Mapper = new Mapper(config);

            CalculateCommand = new CalculateQuery.Handler(ScriptRepository,
                ParameterRepository, TranslationService, Mapper);
        }

        ~ScriptCalculatorTestEngine()
        {
            ScriptInterpreterDbContext.Dispose();
        }

        public List<ParameterResource> Calculate(long scriptId, ICollection<CalculateParameterResource> parametersForCalculation)
        {
            var request = new CalculateQuery
            {
                ScriptId = scriptId,
                InputData = parametersForCalculation,
                LanguageCode = "empty"
            };
            var results = CalculateCommand.Handle(request, CancellationToken.None).Result.ToList();
            return results;
        }

        public string GetBigRandom(double? min = null, double? max = null)
        {
            var number = _random.NextDouble() * _random.Next(1000);
            if (min != null)
                number = Math.Max(number, (double)min);
            if (max != null)
                number = Math.Min(number, (double)max);
            return number.ToString();
        }

        public string GetSmallRandom(double? min = null, double? max = null)
        {
            var number = _random.NextDouble() * _random.Next(100);
            if (min != null)
                number = Math.Max(number, (double)min);
            if (max != null)
                number = Math.Min(number, (double)max);
            return number.ToString();
        }

        public string GetValueFromRange(string[] possibleValues)
            => possibleValues[_random.Next(possibleValues.Length)];

        public bool GetRandomBoolean()
            => Convert.ToBoolean(_random.Next(0, 2));

    }
}
