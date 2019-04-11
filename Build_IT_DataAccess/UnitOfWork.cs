using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Build_IT_DataAccess
{
    public class UnitOfWork<T> where T: DbContext
    {
        private readonly T _context;

        public UnitOfWork(T context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
