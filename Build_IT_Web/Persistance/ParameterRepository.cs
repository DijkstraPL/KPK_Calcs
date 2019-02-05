using Build_IT_Web.Core;
using Build_IT_Web.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SI = Build_IT_ScriptInterpreter.Parameters;

namespace Build_IT_Web.Persistance
{
    public class ParameterRepository : IParameterRepository
    {
        private readonly BuildItDbContext _context;

        public ParameterRepository(BuildItDbContext context)
        {
            _context = context;
        }

        public async Task<List<Parameter>> GetAllParameters(long id)
        {
            return await _context.Parameters
                .Where(p => p.ScriptId == id)
                .Include(p => p.ValueOptions)
                .Include(p => p.NestedScripts)
                .ToListAsync();
        }

        public async Task<List<Parameter>> GetEditableParameters(long id)
        {
          return await _context.Parameters
                .Where(p => p.ScriptId == id && (p.Context & SI.ParameterOptions.Editable) != 0)
                .Include(p => p.ValueOptions)
                .Include(p => p.NestedScripts)
                .ToListAsync();
        }
    }
}
