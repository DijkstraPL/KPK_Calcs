﻿using Build_IT_DataAccess.DeadLoads.Models;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.DeadLoads.Repositories
{
    public class SubcategoryRepository : Repository<Subcategory>, ISubcategoryRepository
    {
        #region Properties
        
        public DeadLoadsDbContext DeadLoadsContext
            => Context as DeadLoadsDbContext;

        #endregion // Properties

        #region Constructors
        
        public SubcategoryRepository(DeadLoadsDbContext context)
            : base(context)
        {
        }

        #endregion // Constructors

        #region Public_Methods
        
        public async Task<List<Subcategory>> GetAllSubcategoriesForCategoryAsync(long categoryId)
        {
            return await DeadLoadsContext.Subcategories
                .Where(sc => sc.Category.Id == categoryId)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        #endregion // Public_Methods
    }
}
