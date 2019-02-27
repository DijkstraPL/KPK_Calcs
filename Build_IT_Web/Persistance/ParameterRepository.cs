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

        public async Task<List<Parameter>> GetAllParameters(long scriptId)
        {
            return await _context.Parameters
                .Where(p => p.ScriptId == scriptId)
                .Include(p => p.ValueOptions)
                .Include(p => p.NestedScripts)
                .OrderBy(p => p.Number)
                .ToListAsync();
        }
        
        public async Task<Parameter> GetParameter(long parameterId)
        {
            return await _context.Parameters
                .Include(p => p.ValueOptions)
                .Include(p => p.NestedScripts)
                .SingleOrDefaultAsync(p => p.Id == parameterId);
        }

        public void Add(Parameter parameter)
        {
            _context.Parameters.Add(parameter);
        }

        public void Remove(Parameter parameter)
        {
            _context.Remove(parameter);
        }
    }
}
