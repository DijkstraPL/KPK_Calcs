using Build_IT_ScriptInterpreter;
using Build_IT_ScriptInterpreter.Expressions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreterTests
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
    }
}
