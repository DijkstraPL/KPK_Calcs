using Build_IT_DataAccess.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.Application
{
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
        #region Fields

        private readonly ApplicationDbContext _context;

        #endregion // Fields

        #region Constructors

        public ApplicationUnitOfWork(
            ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion // Constructors

        #region Public_Methods

        public async Task<int> CompleteAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        #endregion // Public_Methods
    }
}
