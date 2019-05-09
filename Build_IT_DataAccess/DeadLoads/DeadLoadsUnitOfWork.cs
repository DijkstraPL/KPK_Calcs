using Build_IT_DataAccess.DeadLoads.Interfaces;
using Build_IT_DataAccess.DeadLoads.Repositories;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.DeadLoads
{
    public class DeadLoadsUnitOfWork : IDeadLoadsUnitOfWork
    {
        #region Properties

        public ICategoryRepository Categories { get; }
        public ISubcategoryRepository Subcategories { get; }
        public IMaterialRepository Materials { get; }

        #endregion // Properties

        #region Fields

        private readonly DeadLoadsDbContext _context;

        #endregion // Fields

        #region Constructors

        public DeadLoadsUnitOfWork(
            DeadLoadsDbContext context,
            ICategoryRepository categoryRepository,
            ISubcategoryRepository subcategoryRepository,
            IMaterialRepository materialRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); 
            Categories = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            Subcategories = subcategoryRepository ?? throw new ArgumentNullException(nameof(subcategoryRepository));
            Materials = materialRepository ?? throw new ArgumentNullException(nameof(materialRepository));
        }

        #endregion // Constructors

        #region Public_Methods

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
