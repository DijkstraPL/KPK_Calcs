using AutoMapper;
using Build_IT_Web.Controllers.Resources;
using Build_IT_Web.Core.Models;
using Build_IT_Web.Core.Models.Enums;
using Build_IT_Web.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers
{
    [Route("api/scripts")]
    [ApiController]
    public class ParametersController : ControllerBase
    {
        private readonly BuildItDbContext _context;
        private readonly IMapper _mapper;

        public ParametersController(BuildItDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}/parameters")]
        public async Task<IEnumerable<ParameterResource>> GetParameters(int id)
        {
            var parameters = await _context.Parameters
                .Where(p => p.ScriptId == id && (p.Context & ParameterOptions.Editable) != 0)
                .Include(p => p.ValueOptions)
                .Include(p => p.NestedScripts)
                .ToListAsync();

            return _mapper.Map<List<Parameter>, List<ParameterResource>>(parameters);
        }

    }
}
