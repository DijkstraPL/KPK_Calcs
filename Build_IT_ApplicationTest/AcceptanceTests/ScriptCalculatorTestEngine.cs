using AutoMapper;
using Build_IT_Application.Infrastructures;
using Build_IT_Application.Infrastructures.Interfaces;
using Build_IT_Application.Mapping;
using Build_IT_Application.ScriptInterpreter.Calculations.Commands;
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
using System.Text;
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
        public CalculateCommand.Handler CalculateCommand { get; }

        private readonly Random _random = new Random();

        public ScriptCalculatorTestEngine()
        {
            var logger = new Mock<ILogger<CalculateCommand.Handler>>();

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

            CalculateCommand = new CalculateCommand.Handler(ScriptRepository,
                ParameterRepository, TranslationService, Mapper, logger.Object);
        }

        ~ScriptCalculatorTestEngine()
        {
            ScriptInterpreterDbContext.Dispose();
        }
        
        public List<ParameterResource> Calculate(long scriptId, ICollection<ParameterResource> parametersForCalculation)
        {
            var request = new CalculateCommand
            {
                ScriptId = scriptId,
                InputData = parametersForCalculation,
                LanguageCode = "empty"
            };
            var results = CalculateCommand.Handle(request, CancellationToken.None).Result.ToList();
            return results;
        }

        public string GetBigRandom() 
            => (_random.NextDouble() * _random.Next(1000)).ToString();

        public string GetSmallRandom()
            => (_random.NextDouble() * _random.Next(1000)).ToString();

        public string GetValueFromRange(string[] possibleValues)
            => possibleValues[_random.Next(possibleValues.Length)];

    }
}
