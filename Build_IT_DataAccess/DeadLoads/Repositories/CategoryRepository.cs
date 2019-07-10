using Build_IT_Data.Entities.DeadLoads;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;

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
