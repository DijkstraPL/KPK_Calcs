using Build_IT_DataAccess.ScriptInterpreter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetTags();
        Task<Tag> GetTag(long id);
        void Add(Tag tag);
        void Remove(Tag tag);
    }
}