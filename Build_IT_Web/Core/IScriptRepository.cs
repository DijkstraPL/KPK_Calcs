using System.Collections.Generic;
using System.Threading.Tasks;
using Build_IT_Web.Core.Models;

namespace Build_IT_Web.Core
{
    public interface IScriptRepository
    {
        Task<List<Script>> GetScripts();
        Task<Script> GetScript(long id, bool includeRelated = true);
        void Add(Script script);
        void Remove(Script script);
    }
}