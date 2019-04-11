using Build_IT_DataAccess.DeadLoads.Models;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.DeadLoads.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly DeadLoadsDbContext _context;

        public MaterialRepository(DeadLoadsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Material>> GetAllMaterials(long subcategoryId)
        {
            return await _context.Materials
                .Where(m => m.Subcategory.Id == subcategoryId)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<Material> GetMaterial(long materialId)
        {
            return await _context.Materials
                .SingleOrDefaultAsync(m => m.Id == materialId);
        }
    }
}
