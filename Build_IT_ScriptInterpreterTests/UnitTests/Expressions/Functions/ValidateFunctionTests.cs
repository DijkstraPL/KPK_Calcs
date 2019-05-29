using Build_IT_ScriptInterpreter.Expressions.Functions;
using NUnit.Framework;

namespace Build_IT_ScriptInterpreterTests.UnitTests.Expressions.Functions
{
    [TestFixture]
    public class ValidateFunctionTests
    {
        private ValidateFunction _validateFunction;

        [SetUp]
        public void SetUp()
        {
            _validateFunction = new ValidateFunction();
        }

        [Test]
        public void ValidateFunctionTest_Name_Success()
        {
            Assert.That(_validateFunction.Name, Is.EqualTo("VALIDATE"));
        }

        [Test]
        public void MaxxFunctionTest_FunctionWithOneParameter_Success()
        {
            var parameters = new NCalc.Expression[1];
            parameters[0] = new NCalc.Expression("5>10");

            Assert.That(_validateFunction.Function(new NCalc.FunctionArgs() { Parameters = parameters }),
                Is.EqualTo(false));
        }

        [Test]
        public void MaxxFunctionTest_FunctionWithManyParameters_Success()
        {
            var parameters = new NCalc.Expression[3];
            parameters[0] = new NCalc.Expression("5<10");
            parameters[1] = new NCalc.Expression("1>2");
            parameters[2] = new NCalc.Expression("1<0");

            Assert.That(_validateFunction.Function(new NCalc.FunctionArgs() { Parameters = parameters }),
              Is.EqualTo(true));
        }
    }
}
