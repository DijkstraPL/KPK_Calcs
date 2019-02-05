using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreter.Scripts.Interfaces
{
    public interface ICalculatable
    {
        List<IParameter> Parameters { get; set; } // TODO: Remove setter

        IParameter GetParameterByName(string name);
    }
}
