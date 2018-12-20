using NCalc;
using System;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreter.Expressions.Interfaces
{
    public interface IExpression
    {
        void SetParameters(IDictionary<string, object> parameters);
        void SetAdditionalFunction(string fuctionName, Func<FunctionArgs, object> function);
        object Evaluate();
    }
}
