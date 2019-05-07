using Build_IT_DataAccess.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces
{
    public interface IScriptRepository : IRepository<Script>
    {
        #region Public_Methods
        
        Task<Script> GetScriptWithTagsAsync(long id);
        Task<IEnumerable<Script>> GetAllScriptsWithTagsAsync();

        #endregion // Public_Methods
    }
}