using AutoMapper;
using Build_IT_Web.Controllers.Resources;
using Build_IT_Web.Core;
using Build_IT_Web.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers
{
    [Route("api/scripts")]
    [ApiController]
    public class ParametersController : ControllerBase
    {
        private readonly IScriptRepository _scriptRepository;
        private readonly IParameterRepository _parameterRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ParametersController(
            IScriptRepository scriptRepository,
            IParameterRepository parameterRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _scriptRepository = scriptRepository;
            _parameterRepository = parameterRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}/parameters")]
        public async Task<IEnumerable<ParameterResource>> GetAllParameters(long id)
        {
            var parameters = await _parameterRepository.GetAllParameters(id);

            return _mapper.Map<List<Parameter>, List<ParameterResource>>(parameters);
        }

        [HttpPost("{id}/parameters")]
        public async Task<IActionResult> CreateParameter(long id, [FromBody] ParameterResource parameterResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var script = await _scriptRepository.GetScript(id);
            if (script == null)
                return NotFound();

            var parameter = _mapper.Map<ParameterResource, Parameter>(parameterResource);

            script.Modified = DateTime.Now;
            parameter.Script = script;

            _parameterRepository.Add(parameter);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Parameter, ParameterResource>(parameter);
            return Ok(result);
        }

        [HttpPut("{id}/parameters/{parId}")]
        public async Task<IActionResult> UpdateParameter(long id, long parId, [FromBody] ParameterResource parameterResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var script = await _scriptRepository.GetScript(id);
            var parameter = await _parameterRepository.GetParameter(parId);

            if (script == null || parameter == null)
                return NotFound();

            _mapper.Map<ParameterResource, Parameter>(parameterResource, parameter);

            script.Modified = DateTime.Now;

            await _unitOfWork.CompleteAsync();

            parameter = await _parameterRepository.GetParameter(parId);

            var result = _mapper.Map<Parameter, ParameterResource>(parameter);
            return Ok(result);
        }

        [HttpDelete("{id}/parameters/{parId}")]
        public async Task<IActionResult> DeleteParameter(long parId)
        {
            var parameter = await _parameterRepository.GetParameter(parId);

            if (parameter == null)
                return NotFound();

            _parameterRepository.Remove(parameter);
            await _unitOfWork.CompleteAsync();

            return Ok(parId);
        }
    }
}
