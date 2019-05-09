using Build_IT_DataAccess.DeadLoads.Models;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.DeadLoads.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        #region Properties
        
        public DeadLoadsDbContext DeadLoadsContext
             => Context as DeadLoadsDbContext;

        #endregion // Properties

        #region Constructors
        
        public CategoryRepository(DeadLoadsDbContext context)
     : base(context)
        {
        }

        #endregion // Constructors
    }
}
