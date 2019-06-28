using Build_IT_DataAccess.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Models.Translations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces
{
    public interface IScriptRepository : IRepository<Script>
    {
        #region Public_Methods
        
        Task<IEnumerable<Script>> GetAllScriptsWithTagsAsync();
        Task<Script> GetScriptWithTagsAsync(long id);
        Task<Script> GetScriptBaseOnNameAsync(string name);

        Task<ICollection<ScriptTranslation>> GetScriptTranslations(long id);

        #endregion // Public_Methods
    }
}