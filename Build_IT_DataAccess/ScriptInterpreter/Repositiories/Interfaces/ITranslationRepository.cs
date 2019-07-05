using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Models.Translations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces
{
    public interface ITranslationRepository
    {
        #region Public_Methods
        
        Task<IEnumerable<ScriptTranslation>> GetScriptTranslations(long scriptId);
        Task<ScriptTranslation> GetScriptTranslation(long scriptId, Language language);
        Task<ScriptTranslation> GetScriptTranslation(long id);
        Task<IEnumerable<ParameterTranslation>> GetParametersTranslations(long parameterId, Language language);
        Task<ParameterTranslation> GetParameterTranslation(long parameterId, Language language);
        Task<ValueOptionTranslation> GetValueOptionTranslation(long valueOptionId, Language language);
        Task AddScriptTranslationAsync(ScriptTranslation scriptTranslation);
        void RemoveScriptTranslation(ScriptTranslation scriptTranslation);

        #endregion // Public_Methods
    }
}
