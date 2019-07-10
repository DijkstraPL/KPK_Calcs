using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
        #region Public_Methods

        Task<IEnumerable<Tag>> GetTagsForScript(long scriptId);

        #endregion // Public_Methods
    }
}