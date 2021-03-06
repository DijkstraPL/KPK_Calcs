﻿using Build_IT_Data.Entities.DeadLoads;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.DeadLoads.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        #region Properties
        
        public DeadLoadsDbContext DeadLoadsContext
            => Context as DeadLoadsDbContext;

        #endregion // Properties

        #region Constructors
        
        public MaterialRepository(DeadLoadsDbContext context)
            : base(context)
        {
        }

        #endregion // Constructors

        #region Public_Methods
        
        public async Task<List<Material>> GetAllMaterialsForSubcategoryAsync(
            long subcategoryId, CancellationToken cancellationToken)
        {
            return await DeadLoadsContext.Materials
                .Where(m => m.Subcategory.Id == subcategoryId)
                .OrderBy(m => m.Name)
                .Include(m => m.MaterialAdditions)
                .ThenInclude(ma => ma.Addition)
                .ToListAsync(cancellationToken);
        }

        #endregion // Public_Methods
    }
}
