using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories
{
    public class TagRepository : ITagRepository
    {
        private readonly ScriptInterpreterDbContext _context;

        public TagRepository(ScriptInterpreterDbContext context)
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
