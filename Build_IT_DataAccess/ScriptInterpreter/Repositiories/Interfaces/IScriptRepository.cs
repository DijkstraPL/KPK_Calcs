using Build_IT_DataAccess.ScriptInterpreter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces
{
    public interface IScriptRepository
    {
        Task<List<Script>> GetScripts();
        Task<Script> GetScript(long id, bool includeRelated = true);
        void Add(Script script);
        void Remove(Script script);
    }
}