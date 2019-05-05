using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using System.Collections.Generic;

namespace Build_IT_ScriptInterpreter.Scripts.Interfaces
{
    public interface ICalculatable
    {
        #region Properties

        List<IParameter> Parameters { get; set; } // TODO: Remove setter

        #endregion // Properties

        #region Public_Methods

        IParameter GetParameterByName(string name);

        #endregion // Public_Methods
    }
}
