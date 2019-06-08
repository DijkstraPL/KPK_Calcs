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
                .Include(p => p.ParameterFigures)
                .ThenInclude(p => p.Figure)
                .OrderBy(p => p.Number)
                .ToListAsync();
        }

        public async Task<Parameter> GetParameterWithAllDependanciesAsync(long parameterId)
        {
            return await ScriptInterpreterContext.Parameters
                .Include(p => p.ValueOptions)
                .Include(p => p.ParameterFigures)
                .ThenInclude(p => p.Figure)
                .SingleOrDefaultAsync(p => p.Id == parameterId);
        }

        public async Task<IEnumerable<Figure>> GetFiguresAsync(long parameterId)
        {
            var parameter = await ScriptInterpreterContext.Parameters
                .Include(p => p.ParameterFigures)
                .SingleOrDefaultAsync(p => p.Id == parameterId);
            return await ScriptInterpreterContext.Figures
                  .Where(f => parameter.ParameterFigures.Any(pf => pf.FigureId == f.Id))
                  .ToListAsync();
        }

        #endregion // Public_Methods
    }
}
