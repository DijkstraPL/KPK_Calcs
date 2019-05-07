using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
    }
}
