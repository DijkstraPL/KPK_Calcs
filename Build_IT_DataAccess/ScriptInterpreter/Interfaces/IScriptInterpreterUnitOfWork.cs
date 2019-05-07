using Build_IT_DataAccess.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Interfaces
{
    public interface IScriptInterpreterUnitOfWork : IUnitOfWork
    {
        #region Properties

        IScriptRepository Scripts { get; }
        IParameterRepository Parameters { get; }
        ITagRepository Tags { get; }

        #endregion // Properties
    }
}
