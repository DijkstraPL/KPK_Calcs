using AutoMapper;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using Build_IT_Web.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers
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

        [HttpPut("{scriptId}/calculate")]
        public async Task<IEnumerable<ParameterResource>> Calculate(long scriptId, [FromBody] List<ParameterResource> userParameters)
        {
            var script = await _scriptRepository.GetAsync(scriptId);
            var parameters = await _parameterRepository.GetAllParametersForScriptAsync(scriptId);

            var equations = new Dictionary<long,string> (parameters.ToDictionary(p => p.Id, p => p.Value));
            
            var scriptCalculator = new ScriptCalculator(script, parameters.ToList());

            await scriptCalculator.CalculateAsync(userParameters.Where(v => v.Value != null));

            var calculatedParameters =  _mapper.Map<List<Parameter>, List<ParameterResource>>(scriptCalculator.GetResult().ToList());
            calculatedParameters.ForEach(cp => cp.Equation = equations.SingleOrDefault(p => p.Key == cp.Id).Value);
            return calculatedParameters;
        }
    }
}
