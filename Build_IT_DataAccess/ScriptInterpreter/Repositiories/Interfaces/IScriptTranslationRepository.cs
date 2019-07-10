using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_Data.Entities.Scripts.Translations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces
{
    public interface IScriptTranslationRepository
    {
        #region Public_Methods

        Task<IEnumerable<ScriptTranslation>> GetScriptTranslations(long scriptId);
        Task<ScriptTranslation> GetScriptTranslation(long scriptId, Language language);
        Task<ScriptTranslation> GetScriptTranslation(long id);
        Task AddScriptTranslationAsync(ScriptTranslation scriptTranslation);
        void RemoveScriptTranslation(ScriptTranslation scriptTranslation);

        #endregion // Public_Methods
    }
}
