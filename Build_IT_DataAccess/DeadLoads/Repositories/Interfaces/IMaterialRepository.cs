using Build_IT_Data.Entities.DeadLoads;
using Build_IT_DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.DeadLoads.Repositories.Interfaces
{
    public interface IMaterialRepository : IRepository<Material>
    {
        #region Public_Methods
        
        Task<List<Material>> GetAllMaterialsForSubcategoryAsync(long subcategoryId, CancellationToken cancellationToken);

        #endregion // Public_Methods
    }
}
