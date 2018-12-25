using Build_IT_ScriptInterpreter.Expressions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreterTests.Expressions
{
    [TestFixture]
    public class ExpressionEvaluatorTests
    {
        [Test]
        public void AdditionalFunctionsTest_Success()
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("a", 5);
            parameters.Add("b", 8);

            var expression = ExpressionEvaluator.Create("MAXX(1, 2, [a], [b], MINN(5,1,10))", parameters);

            Assert.That(expression.Evaluate(), Is.EqualTo(8));
        }

        [Test]
        public void MatrixFunctionsTest_Success()
        {
            var parameters = new Dictionary<string, object>();

            var matrixExpression = ExpressionEvaluator.Create("MATRIX(3,3,1,2,3,4,5,6,7,8,9)", parameters);
            parameters.Add("m", matrixExpression.Evaluate());

            var positionExpression = ExpressionEvaluator.Create("GETPOSITION([m],2,1)", parameters);            
            Assert.That(positionExpression.Evaluate(), Is.EqualTo(8));
        }
    }
}
