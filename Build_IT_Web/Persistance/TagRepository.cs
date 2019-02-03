using Build_IT_Web.Core;
using Build_IT_Web.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Persistance
{
    public class TagRepository : ITagRepository
    {
        private readonly BuildItDbContext _context;

        public TagRepository(BuildItDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tag>> GetTags()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag> GetTag(long id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public void Add(Tag tag)
        {
            _context.Tags.Add(tag);
        }

        public void Remove(Tag tag)
        {
            _context.Remove(tag);
        }
    }
}
