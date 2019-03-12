using Build_IT_ScriptInterpreter.Expressions.Functions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreterTests.Expressions.Functions
{
    [TestFixture]
    public class ErrorFunctionTests
    {
        private ErrorFunction _errorFunction;

        [SetUp]
        public void SetUp()
        {
           _errorFunction = new ErrorFunction();
        }

        [Test]
        public void ErrorFunctionTest_Name_Success()
        {

            Assert.That(_errorFunction.Name, Is.EqualTo("ERROR"));
        }

        [Test]
        public void ErrorFunctionTest_FunctionWithOneParameter_Success()
        {
            var parameters = new NCalc.Expression[1];
            parameters[0] = new NCalc.Expression("5");

            Assert.Throws<ArgumentException>(
                () => _errorFunction.Function(new NCalc.FunctionArgs() { Parameters = parameters }), "5");
        }

        [Test]
        public void ErrorFunctionTest_FunctionWithManyParameters_Success()
        {
            var parameters = new NCalc.Expression[2];
            parameters[0] = new NCalc.Expression("5");
            parameters[1] = new NCalc.Expression("2");

            Assert.Throws<ArgumentException>(
                () => _errorFunction.Function(new NCalc.FunctionArgs() { Parameters = parameters }), "Wrong number of parameters.");
        }
    }
}
