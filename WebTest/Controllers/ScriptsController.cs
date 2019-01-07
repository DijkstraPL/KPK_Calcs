using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTest.Controllers.Resources;
using WebTest.Models;
using WebTest.Persistance;

namespace WebTest.Controllers
{
    public class ScriptsController : Controller
    {
        private readonly BuildItDbContext _context;
        private readonly IMapper _mapper;

        public ScriptsController(BuildItDbContext context, IMapper mapper)
        {
            _context = context;
           _mapper = mapper;
        }

        [HttpGet("/api/scripts")]
        public async Task<IEnumerable<ScriptResource>> GetScripts()
        {
            var scripts = await _context.Scripts.Include(s => s.Tags).ToListAsync();

            return _mapper.Map<List<Script>, List<ScriptResource>>(scripts);
        }
    }
}