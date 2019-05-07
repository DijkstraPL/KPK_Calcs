using Build_IT_DataAccess.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using System.Threading.Tasks;

namespace Build_IT_DataAccess
{
    public class ScriptInterpreterUnitOfWork : IScriptInterpreterUnitOfWork
    {
        #region Properties

        public IScriptRepository Scripts { get; }
        public IParameterRepository Parameters { get; }
        public ITagRepository Tags { get; }

        #endregion // Properties

        #region Fields

        private readonly ScriptInterpreterDbContext _context;

        #endregion // Fields

        #region Constructors
        
        public ScriptInterpreterUnitOfWork(ScriptInterpreterDbContext context)
        {
            _context = context;
            Scripts = new ScriptRepository(_context);
            Parameters = new ParameterRepository(_context);
            Tags = new TagRepository(_context);
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
