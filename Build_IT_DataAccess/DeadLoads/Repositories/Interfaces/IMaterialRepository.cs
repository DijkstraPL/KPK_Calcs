﻿using Build_IT_DataAccess.DeadLoads.Models;
using Build_IT_DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.DeadLoads.Repositories.Interfaces
{
    public interface IMaterialRepository : IRepository<Material>
    {
        #region Public_Methods
        
        Task<List<Material>> GetAllMaterialsForSubcategoryAsync(long subcategoryId);

        #endregion // Public_Methods
    }
}
