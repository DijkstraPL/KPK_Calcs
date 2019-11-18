using Build_IT_Application.ScriptInterpreter.Calculations.Queries;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Data.Entities.Scripts;
using SIP = Build_IT_ScriptInterpreter.Parameters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Build_IT_ApplicationTest.AcceptanceTests
{
    [TestFixture]
    public class BendingIBeamTests
    {
        private const long ID = 27;
        private ScriptCalculatorTestEngine _testEngine;

        [SetUp]
        public void SetUp()
        {
            _testEngine = new ScriptCalculatorTestEngine();
        }
        
        [Test]
        [Description("27 - Bending - I-Beam")]
        public void BendingResistanceCalculationTest_Example1_9_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["f_y_"].Value = "355";
            parametersForCalculation["h"].Value = "300";
            parametersForCalculation["b"].Value = "150";
            parametersForCalculation["t_f_"].Value = "10.7";
            parametersForCalculation["t_w_"].Value = "7.1";
            parametersForCalculation["Type"].Value = "Rolled";
            parametersForCalculation["r"].Value = "15";

            List<ParameterResource> results = _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList());

            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "W_pl,y_").Value),
                Is.EqualTo(628).Within(1));
            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "M_c,Rd_").Value),
                    Is.EqualTo(223).Within(1));
        }

        [Test]
        [Description("27 - Bending - I-Beam")]
        public void BendingResistanceCalculationTest_Example1_10_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["f_y_"].Value = "355";
            parametersForCalculation["h"].Value = "732";
            parametersForCalculation["b"].Value = "250";
            parametersForCalculation["t_f_"].Value = "16";
            parametersForCalculation["t_w_"].Value = "10";
            parametersForCalculation["Type"].Value = "Welded";
            parametersForCalculation["a"].Value = "5";

            List<ParameterResource> results = _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList());

            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "W_pl,y_").Value),
                Is.EqualTo(4073).Within(10));
            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "M_c,Rd_").Value),
                    Is.EqualTo(1446).Within(5));
        }

        [Test]
        [Description("27 - Bending - I-Beam")]
        public void CalculateTests_Example1_11_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["f_y_"].Value = "355";
            parametersForCalculation["h"].Value = "828";
            parametersForCalculation["b"].Value = "300";
            parametersForCalculation["t_f_"].Value = "14";
            parametersForCalculation["t_w_"].Value = "6";
            parametersForCalculation["Type"].Value = "Welded";
            parametersForCalculation["a"].Value = "4";

            List<ParameterResource> results = _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList());

            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "W_eff,y_").Value),
                Is.EqualTo(3820).Within(10));
            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "M_c,Rd_").Value),
                    Is.EqualTo(1356).Within(5));
        }


        [Test]
        [Description("27 - Bending - I-Beam")]
        public void BendingResistanceCalculationTest_Example1_12_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["f_y_"].Value = "355";
            parametersForCalculation["h"].Value = "674";
            parametersForCalculation["b"].Value = "320";
            parametersForCalculation["t_f_"].Value = "12";
            parametersForCalculation["t_w_"].Value = "6";
            parametersForCalculation["Type"].Value = "Welded";
            parametersForCalculation["a"].Value = "4";

            List<ParameterResource> results = _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList());

            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "W_eff,y_").Value),
                Is.EqualTo(2710).Within(10));
            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "M_c,Rd_").Value),
                    Is.EqualTo(962).Within(5));
        }

        [Test]
        [Description("27 - Bending - I-Beam")]
        public void BendingResistanceCalculationTest_ExampleMasterThesis5_4_4_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["f_y_"].Value = "355";
            parametersForCalculation["h"].Value = "550";
            parametersForCalculation["b"].Value = "550";
            parametersForCalculation["t_f_"].Value = "24";
            parametersForCalculation["t_w_"].Value = "14";
            parametersForCalculation["Type"].Value = "Welded";
            parametersForCalculation["a"].Value = "4";

            List<ParameterResource> results = _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList());

            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "W_pl,y_").Value),
                Is.EqualTo(7825).Within(10));
            Assert.That(Convert.ToDouble(results.FirstOrDefault(r => r.Name == "M_c,Rd_").Value),
                    Is.EqualTo(2778).Within(5));
        }

        [Test]
        [Repeat(25)]
        [Description("27 - Bending - I-Beam")]
        public void BendingResistanceCalculationTest_RandomExamples_Success()
        {
            var parameters = _testEngine.ParameterRepository.GetAllParametersForScriptAsync(ID).Result.ToList();

            var parametersResource = _testEngine.Mapper.Map<List<Parameter>, List<CalculateParameterResource>>(parameters);
            var parametersForCalculation = new Dictionary<string, CalculateParameterResource>(
                parametersResource.Where(p => (p.Context & SIP.ParameterOptions.Editable) != 0 &&
                (p.Context & SIP.ParameterOptions.Visible) != 0)
                .ToDictionary(p => p.Name, p => p));

            parametersForCalculation["f_y_"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["h"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["b"].Value = _testEngine.GetBigRandom();
            parametersForCalculation["t_f_"].Value = _testEngine.GetSmallRandom();
            parametersForCalculation["t_w_"].Value = _testEngine.GetSmallRandom();
            parametersForCalculation["Type"].Value =
                _testEngine.GetValueFromRange(parameters.First(p => p.Name=="Type").ValueOptions
                .Select(vo => vo.Value)
                .ToArray());
            parametersForCalculation["a"].Value = _testEngine.GetSmallRandom();
            parametersForCalculation["r"].Value = _testEngine.GetSmallRandom();

            Assert.DoesNotThrow(() => _testEngine.Calculate(ID, parametersForCalculation.Select(p => p.Value).ToList()),
               String.Join(", ", parametersForCalculation.Select(p => $"{p.Value.Name}={p.Value.Value}")));
        }
    }
}
