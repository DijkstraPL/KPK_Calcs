using AutoMapper;
using Build_IT_Application.Infrastructures;
using Build_IT_Application.Infrastructures.Interfaces;
using Build_IT_Application.Mapping;
using Build_IT_Application.ScriptInterpreter.Calculations.Commands;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Build_IT_ApplicationTest.AcceptanceTests
{
    [TestFixture]
    public class BendingIBeamTests
    {
        private ScriptInterpreterDbContext _scriptInterpreterDbContext;
        private IScriptRepository _scriptRepository;
        private ITranslationService _translationService;
        private IParameterRepository _parameterRepository;
        private IMapper _mapper;
        private CalculateCommand.Handler _calculateCommand;

        private const long ID = 27;

        [SetUp]
        public void SetUp()
        {
            _scriptInterpreterDbContext = new ScriptInterpreterDbContext(
                new DbContextOptions<ScriptInterpreterDbContext>());
            _parameterRepository = new ParameterRepository(_scriptInterpreterDbContext);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ScriptMappingProfile());
            });
            _scriptRepository = new ScriptRepository(_scriptInterpreterDbContext);
            _translationService = new TranslationService(new TranslationRepository(_scriptInterpreterDbContext));
            _mapper = new Mapper(config);

            _calculateCommand = new CalculateCommand.Handler(_scriptRepository,
                _parameterRepository, _translationService, _mapper);
        }

        [TearDown]
        public void TearDown()
        {
            _scriptInterpreterDbContext.Dispose();
        }

        [Test]
        [Description("27 - Bending - I-Beam")]
        public void BendingResistanceCalculationTest_Example1_9_Success()
        {
            var parameters = _parameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _mapper.Map<List<Parameter>, List<ParameterResource>>(parameters);
            var parametersForCalculation = new List<ParameterResource>
            {
                 parametersResource.First(p => p.Name == "f_y_"),
                 parametersResource.First(p => p.Name == "h"),
                 parametersResource.First(p => p.Name == "b"),
                 parametersResource.First(p => p.Name == "t_f_"),
                 parametersResource.First(p => p.Name == "t_w_"),
                 parametersResource.First(p => p.Name == "Type"),
                 parametersResource.First(p => p.Name == "r")
            };

            parametersForCalculation.First(p => p.Name == "f_y_").Value = "355";
            parametersForCalculation.First(p => p.Name == "h").Value = "300";
            parametersForCalculation.First(p => p.Name == "b").Value = "150";
            parametersForCalculation.First(p => p.Name == "t_f_").Value = "10.7";
            parametersForCalculation.First(p => p.Name == "t_w_").Value = "7.1";
            parametersForCalculation.First(p => p.Name == "Type").Value = "Rolled";
            parametersForCalculation.First(p => p.Name == "r").Value = "15";

            List<ParameterResource> results = Calculate(parametersForCalculation);

            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "W_pl,y_").Value),
                Is.EqualTo(628).Within(1));
            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "M_c,Rd_").Value),
                    Is.EqualTo(223).Within(1));
        }

        [Test]
        [Description("27 - Bending - I-Beam")]
        public void BendingResistanceCalculationTest_Example1_10_Success()
        {
            var parameters = _parameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _mapper.Map<List<Parameter>, List<ParameterResource>>(parameters);
            var parametersForCalculation = new List<ParameterResource>
            {
                 parametersResource.First(p => p.Name == "f_y_"),
                 parametersResource.First(p => p.Name == "h"),
                 parametersResource.First(p => p.Name == "b"),
                 parametersResource.First(p => p.Name == "t_f_"),
                 parametersResource.First(p => p.Name == "t_w_"),
                 parametersResource.First(p => p.Name == "Type"),
                 parametersResource.First(p => p.Name == "a")
            };

            parametersForCalculation.First(p => p.Name == "f_y_").Value = "355";
            parametersForCalculation.First(p => p.Name == "h").Value = "732";
            parametersForCalculation.First(p => p.Name == "b").Value = "250";
            parametersForCalculation.First(p => p.Name == "t_f_").Value = "16";
            parametersForCalculation.First(p => p.Name == "t_w_").Value = "10";
            parametersForCalculation.First(p => p.Name == "Type").Value = "Welded";
            parametersForCalculation.First(p => p.Name == "a").Value = "5";

            List<ParameterResource> results = Calculate(parametersForCalculation);

            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "W_pl,y_").Value),
                Is.EqualTo(4073).Within(10));
            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "M_c,Rd_").Value),
                    Is.EqualTo(1446).Within(5));
        }

        [Test]
        [Description("27 - Bending - I-Beam")]
        public void BendingResistanceCalculationTest_Example1_11_Success()
        {
            var parameters = _parameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _mapper.Map<List<Parameter>, List<ParameterResource>>(parameters);
            var parametersForCalculation = new List<ParameterResource>
            {
                 parametersResource.First(p => p.Name == "f_y_"),
                 parametersResource.First(p => p.Name == "h"),
                 parametersResource.First(p => p.Name == "b"),
                 parametersResource.First(p => p.Name == "t_f_"),
                 parametersResource.First(p => p.Name == "t_w_"),
                 parametersResource.First(p => p.Name == "Type"),
                 parametersResource.First(p => p.Name == "a")
            };

            parametersForCalculation.First(p => p.Name == "f_y_").Value = "355";
            parametersForCalculation.First(p => p.Name == "h").Value = "828";
            parametersForCalculation.First(p => p.Name == "b").Value = "300";
            parametersForCalculation.First(p => p.Name == "t_f_").Value = "14";
            parametersForCalculation.First(p => p.Name == "t_w_").Value = "6";
            parametersForCalculation.First(p => p.Name == "Type").Value = "Welded";
            parametersForCalculation.First(p => p.Name == "a").Value = "4";

            List<ParameterResource> results = Calculate(parametersForCalculation);

            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "W_eff,y_").Value),
                Is.EqualTo(3820).Within(10));
            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "M_c,Rd_").Value),
                    Is.EqualTo(1356).Within(5));
        }


        [Test]
        [Description("27 - Bending - I-Beam")]
        public void BendingResistanceCalculationTest_Example1_12_Success()
        {
            var parameters = _parameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _mapper.Map<List<Parameter>, List<ParameterResource>>(parameters);
            var parametersForCalculation = new List<ParameterResource>
            {
                 parametersResource.First(p => p.Name == "f_y_"),
                 parametersResource.First(p => p.Name == "h"),
                 parametersResource.First(p => p.Name == "b"),
                 parametersResource.First(p => p.Name == "t_f_"),
                 parametersResource.First(p => p.Name == "t_w_"),
                 parametersResource.First(p => p.Name == "Type"),
                 parametersResource.First(p => p.Name == "a")
            };

            parametersForCalculation.First(p => p.Name == "f_y_").Value = "355";
            parametersForCalculation.First(p => p.Name == "h").Value = "674";
            parametersForCalculation.First(p => p.Name == "b").Value = "320";
            parametersForCalculation.First(p => p.Name == "t_f_").Value = "12";
            parametersForCalculation.First(p => p.Name == "t_w_").Value = "6";
            parametersForCalculation.First(p => p.Name == "Type").Value = "Welded";
            parametersForCalculation.First(p => p.Name == "a").Value = "4";

            List<ParameterResource> results = Calculate(parametersForCalculation);

            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "W_eff,y_").Value),
                Is.EqualTo(2710).Within(10));
            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "M_c,Rd_").Value),
                    Is.EqualTo(962).Within(5));
        }

        [Test]
        [Description("27 - Bending - I-Beam")]
        public void BendingResistanceCalculationTest_ExampleMasterThesis5_4_4_Success()
        {
            var parameters = _parameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _mapper.Map<List<Parameter>, List<ParameterResource>>(parameters);
            var parametersForCalculation = new List<ParameterResource>
            {
                 parametersResource.First(p => p.Name == "f_y_"),
                 parametersResource.First(p => p.Name == "h"),
                 parametersResource.First(p => p.Name == "b"),
                 parametersResource.First(p => p.Name == "t_f_"),
                 parametersResource.First(p => p.Name == "t_w_"),
                 parametersResource.First(p => p.Name == "Type"),
                 parametersResource.First(p => p.Name == "a")
            };

            parametersForCalculation.First(p => p.Name == "f_y_").Value = "355";
            parametersForCalculation.First(p => p.Name == "h").Value = "550";
            parametersForCalculation.First(p => p.Name == "b").Value = "550";
            parametersForCalculation.First(p => p.Name == "t_f_").Value = "24";
            parametersForCalculation.First(p => p.Name == "t_w_").Value = "14";
            parametersForCalculation.First(p => p.Name == "Type").Value = "Welded";
            parametersForCalculation.First(p => p.Name == "a").Value = "4";

            List<ParameterResource> results = Calculate(parametersForCalculation);

            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "W_pl,y_").Value),
                Is.EqualTo(7825).Within(10));
            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "M_c,Rd_").Value),
                    Is.EqualTo(2778).Within(5));
        }

        private List<ParameterResource> Calculate(List<ParameterResource> parametersForCalculation)
        {
            var request = new CalculateCommand
            {
                ScriptId = ID,
                InputData = parametersForCalculation,
                LanguageCode = "empty"
            };
            var results = _calculateCommand.Handle(request, CancellationToken.None).Result.ToList();
            return results;
        }
    }
}
