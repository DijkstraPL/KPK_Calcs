using System;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Public_Methods

        Task<int> CompleteAsync();

        #endregion // Public_Methods
    }
}
