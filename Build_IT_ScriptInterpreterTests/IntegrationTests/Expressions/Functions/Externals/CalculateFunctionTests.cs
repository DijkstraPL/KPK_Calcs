using Build_IT_Data.Calculators.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_ScriptInterpreter.Expressions.Functions.Externals;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_ScriptInterpreterTests.IntegrationTests.Expressions.Functions.Externals
{
    [TestFixture]
    public class CalculateFunctionTests
    {
        [Test]
        public void CalculateFunctionTest_ScriptFromFakeDatabase_Success()
        {
            var scriptRepository = new Mock<IScriptRepository>();
            scriptRepository.Setup(sr => sr.GetScriptBaseOnNameAsync("a"))
                .Returns(Task.FromResult(new Script()
                {
                    Id = 1,
                    Name = "a",
                    Description = string.Empty
                }));

            var parameterRepository = new Mock<IParameterRepository>();
            parameterRepository.Setup(pr => pr.GetAllParametersForScriptAsync(1))
            .Returns(Task.FromResult(GetParameters()));

            var calculateFunction = new CalculateFunction(scriptRepository.Object, parameterRepository.Object);

            var parameters = new NCalc.Expression[5];
            parameters[0] = new NCalc.Expression("'a'");
            parameters[1] = new NCalc.Expression("'par1'");
            parameters[2] = new NCalc.Expression("1");
            parameters[3] = new NCalc.Expression("'par2'");
            parameters[4] = new NCalc.Expression("3");

            var functionArgs = new NCalc.FunctionArgs() { Parameters = parameters };

            Assert.That(calculateFunction.Function(functionArgs), Is.EqualTo(true));
            Assert.That(functionArgs.Parameters[0].Parameters.ContainsKey("#result"));
            Assert.That(functionArgs.Parameters[0].Parameters["#result"], Is.EqualTo("4"));
        }

        private IEnumerable<Parameter> GetParameters()
        {
            yield return new Parameter()
            {
                Number = 1,
                Name = "par1",
                Value = string.Empty,
                VisibilityValidator = null,
                Context = ParameterOptions.Editable | ParameterOptions.Visible
            };
            yield return new Parameter()
            {
                Number = 2,
                Name = "par2",
                Value = string.Empty,
                VisibilityValidator = null,
                Context = ParameterOptions.Editable | ParameterOptions.Visible
            };
            yield return new Parameter()
            {
                Number = 3,
                Name = "result",
                Value = "[par1]+[par2]",
                VisibilityValidator = null,
                Context = ParameterOptions.Calculation | ParameterOptions.Visible
            };
        }


        [Test]
        public void CalculateFunctionTest_ScriptFromFakeAssembly_Success()
        {
            var parameters = new NCalc.Expression[5];
            parameters[0] = new NCalc.Expression("'a'");
            parameters[1] = new NCalc.Expression("'par1'");
            parameters[2] = new NCalc.Expression("1");
            parameters[3] = new NCalc.Expression("'par2'");
            parameters[4] = new NCalc.Expression("3");

            var result = new Mock<IResult>();
            result.Setup(r => r.Properties)
                .Returns(new Dictionary<string, object>()
                {
                    { "result", "4" }
                });

            var calculator = new Mock<ICalculator>();
            calculator.Setup(c => c.Map(It.IsAny<IList<object>>()));
            calculator.Setup(c => c.Calculate()).Returns(result.Object);
            
            var calculateFunction = new CalculateFunction(calculator: calculator.Object);

            var functionArgs = new NCalc.FunctionArgs() { Parameters = parameters };

            Assert.That((bool)calculateFunction.Function(functionArgs), Is.EqualTo(true));
            calculator.Verify(c => c.Map(It.IsAny<IList<object>>()), Times.Once);
            calculator.Verify(c => c.Calculate(), Times.Once);

            Assert.That(functionArgs.Parameters[0].Parameters.ContainsKey("#result"));
            Assert.That(functionArgs.Parameters[0].Parameters["#result"], Is.EqualTo("4"));
        }
    }
}
