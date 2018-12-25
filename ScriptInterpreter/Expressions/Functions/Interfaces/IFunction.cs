using NCalc;
using System;

namespace Build_IT_ScriptInterpreter.Expressions.Functions.Interfaces
{
    public interface IFunction
    {
        string Name { get; }
        Func<FunctionArgs, object> Function { get; }
    }
}
