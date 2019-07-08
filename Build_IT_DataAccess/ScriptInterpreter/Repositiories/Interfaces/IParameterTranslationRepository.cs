using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Models.Translations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces
{
    public interface IParameterTranslationRepository
    {
        #region Public_Methods
        
        Task<IEnumerable<ParameterTranslation>> GetParametersTranslations(long parameterId, Language language);
        Task<ParameterTranslation> GetParameterTranslation(long id);
        Task<ParameterTranslation> GetParameterTranslation(long parameterId, Language language);
        Task AddParameterTranslationAsync(ParameterTranslation parameterTranslation);
        void RemoveParameterTranslation(ParameterTranslation parameterTranslation);

        #endregion // Public_Methods
    }
}
