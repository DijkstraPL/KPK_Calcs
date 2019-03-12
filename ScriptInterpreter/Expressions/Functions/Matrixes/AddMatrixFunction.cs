﻿using Build_IT_ScriptInterpreter.Expressions.Functions.Interfaces;
using MathNet.Numerics.LinearAlgebra;
using NCalc;
using System;
using System.Linq;

namespace Build_IT_ScriptInterpreter.Expressions.Functions.Matrixes
{
    public class AddMatrixFunction : IFunction
    {
        #region Properties

        public string Name { get; private set; }
        public Func<FunctionArgs, object> Function { get; private set; }

        #endregion // Properties

        #region Constructors
        
        public AddMatrixFunction()
        {
            SetFunction();
        }

        #endregion // Constructors

        #region Private_Methods
        
        private void SetFunction()
        {
            Name = "ADDMATRIX";
            Function = (e) =>
            {
                if (e.Parameters.Count() != 2)
                    throw new ArgumentException("Wrong number of parameters.");

                Matrix<double> matrix1 = (Matrix<double>)(e.Parameters[0].Evaluate());
                Matrix<double> matrix2 = (Matrix<double>)(e.Parameters[1].Evaluate());

                if (matrix1 == null || matrix2 == null)
                    throw new ArgumentException("Wrong data type.");

               return matrix1.Add(matrix2);
            };
        }

        #endregion // Private_Methods
    }
}
