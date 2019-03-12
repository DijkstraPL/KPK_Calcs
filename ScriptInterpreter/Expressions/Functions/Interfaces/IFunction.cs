using NCalc;
using System;

namespace Build_IT_ScriptInterpreter.Expressions.Functions.Interfaces
{
    //public interface IFunction<T> : IFunction
    //{
    //    #region Properties

    //    new Func<FunctionArgs, T> Function { get; }

    //    #endregion // Properties
    //}

    public interface IFunction
    {
        #region Properties

        string Name { get; }
        Func<FunctionArgs, object> Function { get; }

        #endregion // Properties
    }
}
