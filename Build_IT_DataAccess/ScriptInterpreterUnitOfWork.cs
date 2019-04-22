using Build_IT_DataAccess.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Build_IT_DataAccess
{
    public class ScriptInterpreterUnitOfWork : DbContext, IUnitOfWork
    {
        private readonly ScriptInterpreterDbContext _context;

        public ScriptInterpreterUnitOfWork(ScriptInterpreterDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
