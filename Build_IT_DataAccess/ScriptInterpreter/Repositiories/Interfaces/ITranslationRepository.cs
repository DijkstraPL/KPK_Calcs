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
        
        Task<ScriptTranslation> GetScriptTranslation(long id, Language language);
        Task<ParameterTranslation> GetParameterTranslation(long parameterId, Language language);
        Task<ValueOptionTranslation> GetValueOptionTranslation(long valueOptionId, Language language);

        #endregion // Public_Methods
    }
}
