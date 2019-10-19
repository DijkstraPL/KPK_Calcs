using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_Data.Entities.Scripts.Translations;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories
{
    public class TranslationRepository : ITranslationRepository
    {
        #region Properties

        public ScriptInterpreterDbContext ScriptInterpreterContext { get; }

        #endregion // Properties

        #region Constructors

        public TranslationRepository(ScriptInterpreterDbContext context)
        {
            ScriptInterpreterContext = context;
        }

        #endregion // Constructors

        #region Public_Methods

        public async Task<IEnumerable<ScriptTranslation>> GetScriptTranslations(long scriptId)
        {
            return await ScriptInterpreterContext.ScriptsTranslations
                .Where(st => st.ScriptId == scriptId)
                .ToListAsync();
        }
        public async Task<ScriptTranslation> GetScriptTranslation(long scriptId, Language language)
        {
            return await ScriptInterpreterContext.ScriptsTranslations
                 .SingleOrDefaultAsync(st => st.ScriptId == scriptId && st.Language == language);
        }
        public async Task<ScriptTranslation> GetScriptTranslation(long id)
        {
            return await ScriptInterpreterContext.ScriptsTranslations
                .SingleOrDefaultAsync(st => st.Id == id);
        }
        public async Task AddScriptTranslationAsync(ScriptTranslation scriptTranslation)
        {
            await ScriptInterpreterContext.AddAsync(scriptTranslation);
        }
        public void RemoveScriptTranslation(ScriptTranslation scriptTranslation)
        {
            ScriptInterpreterContext.Remove(scriptTranslation);
        }


        public async Task<IEnumerable<ParameterTranslation>> GetParametersTranslations(long scriptId, Language language)
        {
            var parametersIds = await ScriptInterpreterContext.Parameters.Where(p => p.ScriptId == scriptId).Select(p => p.Id).ToListAsync();
            return await ScriptInterpreterContext.ParametersTranslations
                .Where(pt => parametersIds.Contains(pt.ParameterId) && pt.Language == language).ToListAsync();
        }
        public async Task<ParameterTranslation> GetParameterTranslation(long parameterId, Language language)
        {
            return await ScriptInterpreterContext.ParametersTranslations
                .SingleOrDefaultAsync(pt => pt.ParameterId == parameterId && pt.Language == language);
        }
        public async Task<ParameterTranslation> GetParameterTranslation(long id)
        {
            return await ScriptInterpreterContext.ParametersTranslations.FindAsync(id);
        }
        public async Task AddParameterTranslationAsync(ParameterTranslation parameterTranslation)
        {
            await ScriptInterpreterContext.AddAsync(parameterTranslation);
        }

        public void RemoveParameterTranslation(ParameterTranslation parameterTranslation)
        {
            ScriptInterpreterContext.Remove(parameterTranslation);
        }


        public async Task<IEnumerable<ValueOptionTranslation>> GetValueOptionsTranslations(long parameterId, Language language)
        {
            var parameter = await ScriptInterpreterContext.Parameters
                .Include(p => p.ValueOptions)
                .FirstOrDefaultAsync(p => p.Id == parameterId);
            var valueOptionsIds = parameter.ValueOptions.Select(vo => vo.Id);
            return await ScriptInterpreterContext.ValueOptionsTranslations
                .Where(vot => valueOptionsIds.Contains(vot.ValueOptionId) && vot.Language == language).ToListAsync();
        }
        public async Task<ValueOptionTranslation> GetValueOptionTranslation(long valueOptionId, Language language)
        {
            return await ScriptInterpreterContext.ValueOptionsTranslations
                .SingleOrDefaultAsync(pt => pt.ValueOptionId == valueOptionId && pt.Language == language);
        }
        public async Task<ValueOptionTranslation> GetValueOptionTranslation(long id)
        {
            return await ScriptInterpreterContext.ValueOptionsTranslations.FindAsync(id);
        }
        public async Task AddValueOptionTranslationAsync(ValueOptionTranslation valueOptionTranslation)
        {
            await ScriptInterpreterContext.AddAsync(valueOptionTranslation);
        }
        public void RemoveValueOptionTranslation(ValueOptionTranslation valueOptionTranslation)
        {
            ScriptInterpreterContext.Remove(valueOptionTranslation);
        }

        public async Task<IEnumerable<GroupTranslation>> GetGroupTranslations(long scriptId, Language language)
        {
            var groupsIds = ScriptInterpreterContext.Groups
                .Where(g => g.ScriptId == scriptId)
                .Select(g => g.Id);
            return await ScriptInterpreterContext.GroupsTranslations
                          .Where(gt => groupsIds.Contains(gt.GroupId) && gt.Language == language)
                          .ToListAsync();
        }

        public async Task<GroupTranslation> GetGroupTranslation(long groupId)
        {
            return await ScriptInterpreterContext.GroupsTranslations
                .FirstOrDefaultAsync(gt => gt.GroupId == groupId);
        }
        public async Task<GroupTranslation> GetGroupTranslation(long groupId, Language language)
        {
            return await ScriptInterpreterContext.GroupsTranslations
                .FirstOrDefaultAsync(gt => gt.GroupId == groupId && gt.Language == language);
        }

        public async Task AddGroupTranslationAsync(GroupTranslation groupTranslation)
        {
            await ScriptInterpreterContext.AddAsync(groupTranslation);
        }

        public void RemoveGroupTranslation(GroupTranslation groupTranslation)
        {
            ScriptInterpreterContext.Remove(groupTranslation);
        }
               
        #endregion // Public_Methods
    }
}
