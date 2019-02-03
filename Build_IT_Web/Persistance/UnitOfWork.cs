using Build_IT_Web.Core;
using System.Threading.Tasks;

namespace Build_IT_Web.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BuildItDbContext _context;

        public UnitOfWork(BuildItDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
