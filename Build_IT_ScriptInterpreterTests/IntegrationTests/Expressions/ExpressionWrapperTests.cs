using Build_IT_ScriptInterpreter.Expressions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_ScriptInterpreterTests.IntegrationTests.Expressions
{
        [TestFixture]
    public class ExpressionWrapperTests
    {
        [Test]
        public void EvaluateTest_Success()
        {
            var expression = new ExpressionWrapper("2+2*2");

            var result = expression.Evaluate().ToString();

            Assert.That(result, Is.EqualTo("6"));
        }

        [Test]
        public void EvaluateWithParametersTest_Success()
        {
            var expression = new ExpressionWrapper("[a]+[b]*[c]");

            expression.SetParameters(new Dictionary<string, object>
            {
                {"a", 1 },
                {"b", 2 },
                {"c", 3 }
            });
            var result = expression.Evaluate().ToString();

            Assert.That(result, Is.EqualTo("7"));
        }

        [Test]
        public void EvaluateWithAdditionalFunctionTest_Success()
        {
            var expression = new ExpressionWrapper("Test(1,2,3)");

            expression.SetAdditionalFunction("Test", fa => 
                (int)fa.Parameters[0].Evaluate() + (int)fa.Parameters[1].Evaluate() * (int)fa.Parameters[2].Evaluate()
            );
            var result = expression.Evaluate().ToString();

            Assert.That(result, Is.EqualTo("7"));
        }
    }
}
