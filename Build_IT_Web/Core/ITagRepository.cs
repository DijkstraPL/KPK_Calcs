using System.Collections.Generic;
using System.Threading.Tasks;
using Build_IT_Web.Core.Models;

namespace Build_IT_Web.Core
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetTags();
        Task<Tag> GetTag(long id);
        void Add(Tag tag);
        void Remove(Tag tag);
    }
}