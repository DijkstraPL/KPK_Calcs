using AutoMapper;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers
{
    [Route("api/scripts")]
    [ApiController]
    public class ParametersController : ControllerBase
    {
        #region Fields
        
        private readonly IScriptRepository _scriptRepository;
        private readonly IParameterRepository _parameterRepository;
        private readonly IScriptInterpreterUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion // Fields

        #region Constructors
        
        public ParametersController(
            IScriptRepository scriptRepository,
            IParameterRepository parameterRepository,
            IScriptInterpreterUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _scriptRepository = scriptRepository;
            _parameterRepository = parameterRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion // Constructors

        #region Public_Methods
        
        [HttpGet("{scriptId}/parameters")]
        public async Task<IEnumerable<ParameterResource>> GetAllParameters(long scriptId)
        {
            var parameters = await _parameterRepository.GetAllParametersForScriptAsync(scriptId);

            return _mapper.Map<List<Parameter>, List<ParameterResource>>(parameters.ToList());
        }

        [HttpPost("{scriptId}/parameters")]
        public async Task<IActionResult> CreateParameter(long scriptId, [FromBody] ParameterResource parameterResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var script = await _scriptRepository.GetAsync(scriptId);
            if (script == null)
                return NotFound();

            var parameter = _mapper.Map<ParameterResource, Parameter>(parameterResource);

            script.Modified = DateTime.Now;
            parameter.Script = script;

            _parameterRepository.AddAsync(parameter);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Parameter, ParameterResource>(parameter);
            return Ok(result);
        }

        [HttpPut("{scriptId}/parameters/{parId}")]
        public async Task<IActionResult> UpdateParameter(long scriptId, long parId, [FromBody] ParameterResource parameterResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var script = await _scriptRepository.GetAsync(scriptId);
            var parameter = await _parameterRepository.GetParameterWithAllDependanciesAsync(parId);

            if (script == null || parameter == null)
                return NotFound();

            _mapper.Map<ParameterResource, Parameter>(parameterResource, parameter);

            script.Modified = DateTime.Now;

            await _unitOfWork.CompleteAsync();

            parameter = await _parameterRepository.GetParameterWithAllDependanciesAsync(parId);

            var result = _mapper.Map<Parameter, ParameterResource>(parameter);
            return Ok(result);
        }

        [HttpDelete("{scriptId}/parameters/{parId}")]
        public async Task<IActionResult> DeleteParameter(long parId)
        {
            var parameter = await _parameterRepository.GetParameterWithAllDependanciesAsync(parId);

            if (parameter == null)
                return NotFound();

            _parameterRepository.Remove(parameter);
            await _unitOfWork.CompleteAsync();

            return Ok(parId);
        }

        [HttpGet("{oldScriptId}/copyto/{newScriptId}")]
        public async Task<IActionResult> CopyParametersTo(long oldScriptId, long newScriptId)
        {
            var parameters = await _parameterRepository.GetAllParametersForScriptAsync(oldScriptId);

            var parametersResource = _mapper.Map<List<Parameter>, List<ParameterResource>>(parameters.ToList());
            var copiedParameters = _mapper.Map<List<ParameterResource>, List<Parameter>>(parametersResource);

            var script = await _scriptRepository.GetAsync(newScriptId);
            if (script == null)
                return NotFound();

            script.Modified = DateTime.Now;
            copiedParameters.ForEach(p =>
            {
                p.Id = 0;
                p.Script = script;
                _parameterRepository.AddAsync(p);
            });

            await _unitOfWork.CompleteAsync();

            return Ok(newScriptId);
        }

        #endregion // Public_Methods
    }
}
