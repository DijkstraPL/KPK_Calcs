using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories
{
    public class ParameterRepository : IParameterRepository
    {
        private readonly ScriptInterpreterDbContext _context;

        public ParameterRepository(ScriptInterpreterDbContext context)
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
