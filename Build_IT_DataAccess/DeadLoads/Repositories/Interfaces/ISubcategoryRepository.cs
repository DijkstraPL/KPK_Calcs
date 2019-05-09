using Build_IT_DataAccess.DeadLoads.Models;
using Build_IT_DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.DeadLoads.Repositories.Interfaces
{
    public interface ISubcategoryRepository : IRepository<Subcategory>
    {
        #region Public_Methods

        Task<List<Subcategory>> GetAllSubcategoriesForCategoryAsync(long categoryId);

        #endregion // Public_Methods
    }
}
