using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_Data.Entities.Scripts.Translations;
using Build_IT_DataAccess.Interfaces;
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

        Task<Language> GetDefaultLanguageForScriptAsync(long id);
        Task<ICollection<ScriptTranslation>> GetScriptTranslations(long id);

        #endregion // Public_Methods
    }
}