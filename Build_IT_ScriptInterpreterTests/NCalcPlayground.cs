using NCalc;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreterTests
{
    [TestFixture]
    [Ignore("Playground")]
    public class NCalcPlayground
    {
        [Test]
        public void EquationOrderTest()
        {
            var expression = new Expression("2+2*2");
            Assert.That(expression.Evaluate(), Is.EqualTo(6));
        }

        [Test]
        public void BracketsTest()
        {
            var expression = new Expression("(2+2)*2");
            Assert.That(expression.Evaluate(), Is.EqualTo(8));
        }

        [Test]
        public void SinusTest()
        {
            var pi = Math.PI / 2;
            var expression = new Expression("Sin("+ pi.ToString().Replace(',','.')+")");
            Assert.That(expression.Evaluate(), Is.EqualTo(1));
        }

        [Test]
        public void AdditionalParameterDefinedTest()
        {            
            var expression = new Expression("Cos([angle]*[Pi]/180)");

            expression.Parameters["Pi"] = Math.PI;

            expression.EvaluateParameter += (n, e) =>
            {
                if (n == "angle")
                    e.Result = 30;
            };

            Assert.That(expression.Evaluate(), Is.EqualTo(0.8660254038).Within(0.0000000001));
        }

        [Test]
        public void AdditionalParametersDefinedTest()
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("a", 5);
            parameters.Add("b", 3);
            parameters.Add("c", 2);

            var expression = new Expression("[a]+[b]*[c]");
            expression.Parameters = parameters;
            
            Assert.That(expression.Evaluate(), Is.EqualTo(11));
        }

        [Test]
        public void OwnFunctionDefinedTest()
        {
            var expression = new Expression("SecretOperation(3, 6)");
            expression.EvaluateFunction += delegate (string name, FunctionArgs args)
            {
                if (name == "SecretOperation")
                    args.Result = (int)args.Parameters[0].Evaluate() + Math.Sign((int)args.Parameters[1].Evaluate());
            };

            Assert.That(expression.Evaluate(), Is.EqualTo(4));
        }

        [Test]
        public void IfFunctionTest()
        {
            var expression = new Expression("IF([a]=[b], 1, -1)", EvaluateOptions.IgnoreCase);
            expression.Parameters["a"] = 5;
            expression.Parameters["b"] = 6;

            Assert.That(expression.Evaluate(), Is.EqualTo(-1));
        }

        [Test]
        public void InFunctionTest()
        {
            var expression = new Expression("in([a], 1, 2, 3, 5)");
            expression.Parameters["a"] = 5;

            Assert.That(expression.Evaluate(), Is.EqualTo(true));
        }

        [Test]
        public void PowerTest()
        {
            var expression = new Expression("Pow(2,3)");

            Assert.That(expression.Evaluate(), Is.EqualTo(8));
        }


        [Test]
        public void MultValuedParameters()
        {
            Expression expression = new Expression("Pow(a*b,c)", EvaluateOptions.IterateParameters);
            expression.Parameters["a"] = new int[] { 1, 2, 3, 4, 5 };
            expression.Parameters["b"] = new int[] { 6, 7, 8, 9, 0 };
            expression.Parameters["c"] = 3;

            var results = (IList)expression.Evaluate();

            Assert.That(results[0], Is.EqualTo(216));
            Assert.That(results[1], Is.EqualTo(2744));
            Assert.That(results[2], Is.EqualTo(13824));
            Assert.That(results[3], Is.EqualTo(46656));
            Assert.That(results[4], Is.EqualTo(0));
        }
    }
}
