using Build_IT_DataAccess.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using System;
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
        
        public ScriptInterpreterUnitOfWork(
            ScriptInterpreterDbContext context,
            IScriptRepository scriptRepository,
            IParameterRepository parameterRepository,
            ITagRepository tagRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Scripts = scriptRepository ?? throw new ArgumentNullException(nameof(scriptRepository));
            Parameters = parameterRepository ?? throw new ArgumentNullException(nameof(parameterRepository));
            Tags = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
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
