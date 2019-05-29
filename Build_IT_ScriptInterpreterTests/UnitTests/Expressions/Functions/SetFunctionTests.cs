using Build_IT_ScriptInterpreter.Expressions.Functions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreterTests.UnitTests.Expressions.Functions
{
    [TestFixture]
    public class SetFunctionTests
    {
        private SetFunction _setFunction;

        [SetUp]
        public void SetUp()
        {
            _setFunction = new SetFunction();
        }

        [Test]
        public void SetFunctionTest_Name_Success()
        {

            Assert.That(_setFunction.Name, Is.EqualTo("SET"));
        }
        
        [Test]
        public void SetFunctionTest_FunctionWithOneParameter_Success()
        {
            var parameters = new NCalc.Expression[2];
            parameters[0] = new NCalc.Expression("'a'");
            parameters[1] = new NCalc.Expression("8");

            var functionArgs = new NCalc.FunctionArgs() { Parameters = parameters };

            Assert.That(_setFunction.Function(functionArgs), Is.EqualTo(true));
            Assert.That(functionArgs.Parameters[0].Parameters.ContainsKey("a"));
            Assert.That(functionArgs.Parameters[0].Parameters["a"], Is.EqualTo(8));
        }

        [Test]
        public void SetFunctionTest_FunctionWithManyParameters_Success()
        {
            var parameters = new NCalc.Expression[4];
            parameters[0] = new NCalc.Expression("'a'");
            parameters[1] = new NCalc.Expression("8");
            parameters[2] = new NCalc.Expression("'b'");
            parameters[3] = new NCalc.Expression("1");

            var functionArgs = new NCalc.FunctionArgs() { Parameters = parameters };

            Assert.That(_setFunction.Function(functionArgs), Is.EqualTo(true));
            Assert.That(functionArgs.Parameters[0].Parameters.ContainsKey("a"));
            Assert.That(functionArgs.Parameters[0].Parameters["a"], Is.EqualTo(8));
            Assert.That(functionArgs.Parameters[0].Parameters.ContainsKey("b"));
            Assert.That(functionArgs.Parameters[0].Parameters["b"], Is.EqualTo(1));
        }

        [Test]
        public void SetFunctionTest_FunctionWithTextParameter_Success()
        {
            var parameters = new NCalc.Expression[2];
            parameters[0] = new NCalc.Expression("'a'");
            parameters[1] = new NCalc.Expression("'par'");

            var functionArgs = new NCalc.FunctionArgs() { Parameters = parameters };

            Assert.That(_setFunction.Function(functionArgs), Is.EqualTo(true));
            Assert.That(functionArgs.Parameters[0].Parameters.ContainsKey("a"));
            Assert.That(functionArgs.Parameters[0].Parameters["a"], Is.EqualTo("par"));
        }
    }
}
