using Build_IT_Data.Entities.DeadLoads;
using Microsoft.EntityFrameworkCore;

namespace Build_IT_DataAccess.DeadLoads.Interfaces
{
    public interface IDeadLoadsDbContext
    {
        #region Properties
        
        DbSet<Category> Categories { get; set; }
        DbSet<Subcategory> Subcategories { get; set; }
        DbSet<Material> Materials { get; set; }
        DbSet<Addition> Additions { get; set; }
        DbSet<MaterialAddition> MaterialAdditions { get; set; }

        #endregion // Properties
    }
}
