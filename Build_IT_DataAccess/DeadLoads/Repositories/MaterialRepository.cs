using Build_IT_DataAccess.DeadLoads.Models;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.DeadLoads.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public DeadLoadsDbContext DeadLoadsContext
            => Context as DeadLoadsDbContext;

        public MaterialRepository(DeadLoadsDbContext context)
            :base(context)
        {
        }

        public async Task<List<Material>> GetAllMaterialsForSubcategoryAsync(long subcategoryId)
        {
            return await DeadLoadsContext.Materials
                .Where(m => m.Subcategory.Id == subcategoryId)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }
    }
}
