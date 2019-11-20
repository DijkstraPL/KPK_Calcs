using Build_IT_ScriptInterpreter.Expressions.Functions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreterTests.UnitTests.Expressions.Functions
{
    [TestFixture]
    public class AbsFunctionTests
    {
        private AbsFunction _absFunction;

        [SetUp]
        public void SetUp()
        {
            _absFunction = new AbsFunction();
        }

        [Test]
        public void AbsFunction_Name_Success()
        {

            Assert.That(_absFunction.Name, Is.EqualTo("ABS"));
        }

        [Test]
        public void AbsFunction_PositiveParameter_Success()
        {
            var parameters = new NCalc.Expression[1];
            parameters[0] = new NCalc.Expression("5");

            Assert.That(_absFunction.Function(new NCalc.FunctionArgs() { Parameters = parameters }),
                Is.EqualTo(5));
        }

        [Test]
        public void AbsFunction_NegativeParameter_Success()
        {
            var parameters = new NCalc.Expression[1];
            parameters[0] = new NCalc.Expression("-5");
            
            Assert.That(_absFunction.Function(new NCalc.FunctionArgs() { Parameters = parameters }),
                Is.EqualTo(5));
        }
    }
}
