using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            return await ScriptInterpreterContext.Scripts.Include(s => s.Tags).ThenInclude(t => t.Tag).ToListAsync();
        }

        public async Task<Script> GetScriptWithTagsAsync(long id)
        {
            return await ScriptInterpreterContext.Scripts
                .Include(s => s.Tags)
                .ThenInclude(s => s.Tag)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        #endregion // Public_Methods
    }
}
