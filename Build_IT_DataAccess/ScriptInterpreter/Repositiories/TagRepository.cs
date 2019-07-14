using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        #region Properties
        
        public ScriptInterpreterDbContext ScriptInterpreterContext
            => Context as ScriptInterpreterDbContext;

        #endregion // Properties

        #region Constructors
        
        public TagRepository(ScriptInterpreterDbContext context)
            : base(context)
        {
        }

        #endregion // Constructors

        #region Public_Methods

        public async Task<IEnumerable<Tag>> GetTagsForScriptAsync(long scriptId)
        {
            var script = await ScriptInterpreterContext.Scripts.FindAsync(scriptId);
            var tagsIds = script.Tags.Select(st => st.TagId);
            return await ScriptInterpreterContext.Tags.Where(t => tagsIds.Contains(t.Id)).ToListAsync();
        }

        #endregion // Public_Methods
    }
}
