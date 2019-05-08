using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Build_IT_DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.DeadLoads.Interfaces
{
    public interface IDeadLoadsUnitOfWork : IUnitOfWork
    {
        #region Properties

        IMaterialRepository Materials { get; }

        #endregion // Properties
    }
}
