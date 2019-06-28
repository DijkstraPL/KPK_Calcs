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
    public class ScriptRepository : Repository<Script>, IScriptRepository
    {
        #region Properties

        public ScriptInterpreterDbContext ScriptInterpreterContext 
            => Context as ScriptInterpreterDbContext;

        #endregion // Properties

        #region Constructors

        public ScriptRepository(ScriptInterpreterDbContext context)
            : base(context)
        {
        }

        #endregion // Constructors

        #region Public_Methods
        
        public async Task<IEnumerable<Script>> GetAllScriptsWithTagsAsync()
        {
            return await ScriptInterpreterContext.Scripts
                .Include(s => s.Tags)
                .ThenInclude(t => t.Tag)
                .ToListAsync();
        }

        public async Task<Script> GetScriptWithTagsAsync(long id)
        {
            return await ScriptInterpreterContext.Scripts
                .Include(s => s.Tags)
                .ThenInclude(s => s.Tag)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Script> GetScriptBaseOnNameAsync(string name)
        {
            return await ScriptInterpreterContext.Scripts
                .FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<ICollection<ScriptTranslation>> GetScriptTranslations(long scriptId)
        {
            return await ScriptInterpreterContext.ScriptsTranslations
                .Where(st => st.ScriptId == scriptId)
                .ToListAsync();
        }

        #endregion // Public_Methods
    }
}
