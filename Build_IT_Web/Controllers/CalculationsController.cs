using AutoMapper;
using Build_IT_Web.Controllers.Resources;
using Build_IT_Web.Core;
using Build_IT_Web.Core.Models;
using Build_IT_Web.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers
{
    [Route("api/scripts")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly IScriptRepository _scriptRepository;
        private readonly IParameterRepository _parameterRepository;
        private readonly IMapper _mapper;

        public CalculationsController(
            IScriptRepository scriptRepository,
            IParameterRepository parameterRepository,
            IMapper mapper)
        {
            _scriptRepository = scriptRepository;
            _parameterRepository = parameterRepository;
            _mapper = mapper;
        }

        [HttpPut("{id}/calculate")]
        public async Task<IEnumerable<ParameterResource>> Calculate(long id, [FromBody] List<ParameterResource> userParameters)
        {
            var script = await _scriptRepository.GetScript(id, includeRelated: true);
            var parameters = await _parameterRepository.GetAllParameters(id);
            
            var scriptCalculator = new ScriptCalculator(script, parameters);

            await scriptCalculator.CalculateAsync(userParameters);

            return _mapper.Map<List<Parameter>, List<ParameterResource>>(scriptCalculator.GetResult().ToList()); 
        }
    }
}
