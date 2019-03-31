using Build_IT_ScriptInterpreter.Expressions.Functions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreterTests.Expressions.Functions
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
            //var parameters = new NCalc.Expression[1];
            //parameters[0] = new NCalc.Expression("5");


            //Assert.That(_setFunction.Function(new NCalc.FunctionArgs() { Parameters = parameters }), 
            //    Is.EqualTo(5));
        }

        [Test]
        public void SetFunctionTest_FunctionWithManyParameters_Success()
        {
            //var parameters = new NCalc.Expression[3];
            //parameters[0] = new NCalc.Expression("5");
            //parameters[1] = new NCalc.Expression("10");
            //parameters[2] = new NCalc.Expression("7");

            //Assert.That(_setFunction.Function(new NCalc.FunctionArgs() { Parameters = parameters }),
            //  Is.EqualTo(10));
        }
    }
}
