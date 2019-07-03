using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Models.Translations;
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

        public void Remove(ScriptTranslation scriptTranslation)
        {
            ScriptInterpreterContext.Remove(scriptTranslation);
        }
        
        public async Task<ParameterTranslation> GetParameterTranslation(long parameterId, Language language)
        {
            return await ScriptInterpreterContext.ParametersTranslations
                .SingleOrDefaultAsync(pt => pt.ParameterId == parameterId && pt.Language == language);
        }

        public async Task<ValueOptionTranslation> GetValueOptionTranslation(long valueOptionId, Language language)
        {
            return await ScriptInterpreterContext.ValueOptionsTranslations
                .SingleOrDefaultAsync(pt => pt.ValueOptionId == valueOptionId && pt.Language == language);
        }

        #endregion // Public_Methods
    }
}
