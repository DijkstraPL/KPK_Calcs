using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        #region Public_Methods
        
        public ScriptInterpreterDbContext ScriptInterpreterContext
        => Context as ScriptInterpreterDbContext;

        #endregion // Public_Methods

        #region Constructors
        
        public GroupRepository(ScriptInterpreterDbContext context)
            : base(context)
        {
        }

        #endregion // Constructors

        #region Public_Methods

        #endregion // Public_Methods
    }
}
