using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Models.Translations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces
{
    public interface IValueOptionTranslationRepository
    {
        #region Public_Methods

        Task<IEnumerable<ValueOptionTranslation>> GetValueOptionsTranslations(long parameterId, Language language);
        Task<ValueOptionTranslation> GetValueOptionTranslation(long valueOptionId, Language language);
        Task<ValueOptionTranslation> GetValueOptionTranslation(long id);
        Task AddValueOptionTranslationAsync(ValueOptionTranslation valueOptionTranslation);
        void RemoveValueOptionTranslation(ValueOptionTranslation valueOptionTranslation);

        #endregion // Public_Methods
    }
}
