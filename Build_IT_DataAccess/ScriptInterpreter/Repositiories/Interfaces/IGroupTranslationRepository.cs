using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_Data.Entities.Scripts.Translations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces
{
    public interface IGroupTranslationRepository
    {
        #region Public_Methods
        
        Task<IEnumerable<GroupTranslation>> GetGroupTranslations(long scriptId, Language language);
        Task<GroupTranslation> GetGroupTranslation(long id);
        Task<GroupTranslation> GetGroupTranslation(long id, Language language);
        Task AddGroupTranslationAsync(GroupTranslation groupTranslation);
        void RemoveGroupTranslation(GroupTranslation groupTranslation);

        #endregion // Public_Methods
    }
}
