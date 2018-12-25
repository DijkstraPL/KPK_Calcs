using Build_IT_ScriptInterpreter.Expressions.Interfaces;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using MathNet.Numerics.LinearAlgebra;
using NCalc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Build_IT_ScriptInterpreter.Expressions
{
    public class ExpressionEvaluator : IExpressionEvaluator
    {
        public ICollection<string> Functions { get; private set; }

        private readonly IExpression _expression;

        public static ExpressionEvaluator Create(
            string expression, IDictionary<string, object> parameters = null)
            => new ExpressionEvaluator(expression, parameters);

        public static ExpressionEvaluator Create(
            string expression, IEnumerable<IParameter> parameters)
        {
            var parametersDict = new Dictionary<string, object>();
            parametersDict = parameters.ToDictionary(p => p.Name, p => (object)p.Value);
            return new ExpressionEvaluator(expression, parametersDict);
        }

        private ExpressionEvaluator(string expression, IDictionary<string, object> parameters = null)
        {
            Functions = new List<string>();

            _expression = new ExpressionWrapper(expression);
            if (parameters != null)
                _expression.SetParameters(parameters);

            SetAdditionalFunctions();
        }

        public object Evaluate()
        {
            try
            {
                return _expression.Evaluate();
            }
            catch (EvaluationException ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }

        private void SetAdditionalFunctions()
        {
            SetErrorFunction();
            SetMaxxFunction();
            SetMinnFunction();
            SetMatrixFunction();
            SetGetPositionFunction();
        }

        private void SetErrorFunction()
        {
            string name = "ERROR";
            Func<FunctionArgs, object> function = (e) =>
            {
                throw new ArgumentException(e.Parameters[0].Evaluate().ToString());
            };
            _expression.SetAdditionalFunction(name, function);
            Functions.Add(name);
        }

        private void SetMaxxFunction()
        {
            string name = "MAXX";
            Func<FunctionArgs, object> function = (e) =>
            {
                return e.Parameters.Select(p => p.Evaluate()).Max();
            };
            _expression.SetAdditionalFunction(name, function);
            Functions.Add(name);
        }

        private void SetMinnFunction()
        {
            string name = "MINN";
            Func<FunctionArgs, object> function = (e) =>
            {
                return e.Parameters.Select(p => p.Evaluate()).Min();
            };
            _expression.SetAdditionalFunction(name, function);
            Functions.Add(name);
        }

        /// <summary>
        /// Matrix function.
        /// </summary>
        /// <remarks>
        /// par1 - rows
        /// par2 - columns
        /// "MATRIX(3,3,1,2,3,4,5,6,7,8,9)"
        /// 1, 2, 3
        /// 4, 5, 6
        /// 7, 8, 9
        /// </remarks>
        private void SetMatrixFunction()
        {
            string name = "MATRIX";
            Func<FunctionArgs, object> function = (e) =>
            {
                int rows = (int)e.Parameters[0].Evaluate();
                int columns = (int)e.Parameters[1].Evaluate();
                var matrix = Matrix<double>.Build.Dense(rows, columns);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                        matrix[i, j] = Convert.ToDouble(e.Parameters[i * columns + j + 2].Evaluate());
                }
                return matrix;
            };
            _expression.SetAdditionalFunction(name, function);
            Functions.Add(name);
        }

        private void SetGetPositionFunction()
        {
            string name = "GETPOSITION";
            Func<FunctionArgs, object> function = (e) =>
            {
                Matrix<double> matrix = (Matrix<double>)(e.Parameters[0].Evaluate());

                return matrix[(int)e.Parameters[1].Evaluate(), (int)e.Parameters[2].Evaluate()];
            };
            _expression.SetAdditionalFunction(name, function);
            Functions.Add(name);
        }
    }
}
