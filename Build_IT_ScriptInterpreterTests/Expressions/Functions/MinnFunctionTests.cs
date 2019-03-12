using Build_IT_ScriptInterpreter.Expressions.Functions;
using NUnit.Framework;

namespace Build_IT_ScriptInterpreterTests.Expressions.Functions
{
    [TestFixture]
    public class MinnFunctionTests
    {
        private MinnFunction _minnFunction;

        [SetUp]
        public void SetUp()
        {
            _minnFunction = new MinnFunction();
        }

        [Test]
        public void MinnFunctionTest_Name_Success()
        {
            Assert.That(_minnFunction.Name, Is.EqualTo("MINN"));
        }

        [Test]
        public void MaxxFunctionTest_FunctionWithOneParameter_Success()
        {
            var parameters = new NCalc.Expression[1];
            parameters[0] = new NCalc.Expression("5");

            Assert.That(_minnFunction.Function(new NCalc.FunctionArgs() { Parameters = parameters }),
                Is.EqualTo(5));
        }

        [Test]
        public void MaxxFunctionTest_FunctionWithManyParameters_Success()
        {
            var parameters = new NCalc.Expression[3];
            parameters[0] = new NCalc.Expression("5");
            parameters[1] = new NCalc.Expression("10");
            parameters[2] = new NCalc.Expression("7");

            Assert.That(_minnFunction.Function(new NCalc.FunctionArgs() { Parameters = parameters }),
              Is.EqualTo(5));
        }
    }
}
