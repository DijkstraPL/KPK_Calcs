using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories
{
    public class ParameterRepository : Repository<Parameter>, IParameterRepository
    {
        #region Public_Methods
        
        public ScriptInterpreterDbContext ScriptInterpreterContext
        => Context as ScriptInterpreterDbContext;

        #endregion // Public_Methods

        #region Constructors
        
        public ParameterRepository(ScriptInterpreterDbContext context)
            : base(context)
        {
        }

        #endregion // Constructors

        #region Public_Methods
        
        public async Task<IEnumerable<Parameter>> GetAllParametersForScriptAsync(long scriptId)
        {
            return await ScriptInterpreterContext.Parameters
                .Where(p => p.ScriptId == scriptId)
                .Include(p => p.ValueOptions)
                .OrderBy(p => p.Number)
                .ToListAsync();
        }

        public async Task<Parameter> GetParameterWithAllDependanciesAsync(long parameterId)
        {
            return await ScriptInterpreterContext.Parameters
                .Include(p => p.ValueOptions)
                .SingleOrDefaultAsync(p => p.Id == parameterId);
        }

        #endregion // Public_Methods
    }
}
