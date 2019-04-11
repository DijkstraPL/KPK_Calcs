﻿using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_DataAccess.ScriptInterpreter.Repositiories
{
    public class ScriptRepository : IScriptRepository
    {
        private readonly ScriptInterpreterDbContext _context;

        public ScriptRepository(ScriptInterpreterDbContext context)
        {
            _context = context;
        }

        public async Task<List<Script>> GetScripts()
        {
            return await _context.Scripts.Include(s => s.Tags).ThenInclude(t => t.Tag).ToListAsync();
        }

        public async Task<Script> GetScript(long id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await _context.Scripts.FindAsync(id);
            return await _context.Scripts
                .Include(s => s.Tags)
                .ThenInclude(s => s.Tag)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public void Add(Script script)
        {
            _context.Scripts.Add(script);
        }

        public void Remove(Script script)
        {
            _context.Remove(script);
        }
    }
}
