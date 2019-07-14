using Build_IT_Application.ScriptInterpreter.Parameters.Commands.CreateParameter;
using Build_IT_Application.ScriptInterpreter.Parameters.Commands.DeleteParameter;
using Build_IT_Application.ScriptInterpreter.Parameters.Commands.UpdateParameter;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries.GetAllParametersForScript;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using Build_IT_Web.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers
{
    [Route("api/scripts")]
    [ApiController]
    public class ParametersController : BaseController
    {
        [HttpGet("{scriptId}/parameters/{lang?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ParameterResource>>> GetAllParameters(long scriptId, string lang = TranslationService.DefaultLanguageCode)
        {
            return Ok(await Mediator.Send(new GetAllParametersForScriptQuery { ScriptId = scriptId }));
        }

        [HttpPost("{scriptId}/parameters")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateParameter(long scriptId, [FromBody] CreateParameterCommand command)
        {
            var createdParameter = await Mediator.Send(command);

            return CreatedAtAction(nameof(UpdateParameter), createdParameter);
        }

        [HttpPut("{scriptId}/parameters/{parId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateParameter(long scriptId, long parId, [FromBody] UpdateParameterCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{scriptId}/parameters/{parId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteParameter(long parId)
        {
            await Mediator.Send(new DeleteParameterCommand { Id = parId });

            return NoContent();
        }

        //#region Fields

        //private readonly IScriptRepository _scriptRepository;
        //private readonly IParameterRepository _parameterRepository;
        //private readonly ITranslationService _translationService;
        //private readonly IScriptInterpreterUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;

        //#endregion // Fields

        //#region Constructors

        //public ParametersController(
        //    IScriptRepository scriptRepository,
        //    IParameterRepository parameterRepository,
        //    ITranslationService translationService,
        //    IScriptInterpreterUnitOfWork unitOfWork,
        //    IMapper mapper)
        //{
        //    _scriptRepository = scriptRepository;
        //    _parameterRepository = parameterRepository;
        //    _translationService = translationService;
        //    _unitOfWork = unitOfWork;
        //    _mapper = mapper;
        //}

        //#endregion // Constructors

        //#region Public_Methods

        //[HttpGet("{scriptId}/parameters/{lang?}")]
        //public async Task<IEnumerable<ParameterResource>> GetAllParameters(long scriptId, string lang = TranslationService.DefaultLanguageCode)
        //{
        //    var script = await _scriptRepository.GetAsync(scriptId);
        //    var parameters = await _parameterRepository.GetAllParametersForScriptAsync(scriptId);

        //    var parametersResource = _mapper.Map<List<Parameter>, List<ParameterResource>>(parameters.ToList());

        //    await _translationService.SetParametersTranslation(lang, parametersResource, script.DefaultLanguage);

        //    return parametersResource;
        //}

        //[HttpPost("{scriptId}/parameters")]
        //public async Task<IActionResult> CreateParameter(long scriptId, [FromBody] ParameterResource parameterResource)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var script = await _scriptRepository.GetAsync(scriptId);
        //    if (script == null)
        //        return NotFound();

        //    var parameter = _mapper.Map<ParameterResource, Parameter>(parameterResource);

        //    script.Modified = DateTime.Now;
        //    parameter.Script = script;

        //    await _parameterRepository.AddAsync(parameter);
        //    await _unitOfWork.CompleteAsync();

        //    var result = _mapper.Map<Parameter, ParameterResource>(parameter);
        //    return Ok(result);
        //}

        //[HttpPut("{scriptId}/parameters/{parId}")]
        //public async Task<IActionResult> UpdateParameter(long scriptId, long parId, [FromBody] ParameterResource parameterResource)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var script = await _scriptRepository.GetAsync(scriptId);
        //    var parameter = await _parameterRepository.GetParameterWithAllDependanciesAsync(parId);

        //    if (script == null || parameter == null)
        //        return NotFound();

        //    _mapper.Map<ParameterResource, Parameter>(parameterResource, parameter);

        //    script.Modified = DateTime.Now;

        //    await _unitOfWork.CompleteAsync();

        //    parameter = await _parameterRepository.GetParameterWithAllDependanciesAsync(parId);

        //    var result = _mapper.Map<Parameter, ParameterResource>(parameter);
        //    return Ok(result);
        //}

        //[HttpDelete("{scriptId}/parameters/{parId}")]
        //public async Task<IActionResult> DeleteParameter(long parId)
        //{
        //    var parameter = await _parameterRepository.GetParameterWithAllDependanciesAsync(parId);

        //    if (parameter == null)
        //        return NotFound();

        //    _parameterRepository.Remove(parameter);
        //    await _unitOfWork.CompleteAsync();

        //    return Ok(parId);
        //}

        //[HttpGet("{oldScriptId}/copyto/{newScriptId}")]
        //public async Task<IActionResult> CopyParametersTo(long oldScriptId, long newScriptId)
        //{
        //    var parameters = await _parameterRepository.GetAllParametersForScriptAsync(oldScriptId);

        //    var parametersResource = _mapper.Map<List<Parameter>, List<ParameterResource>>(parameters.ToList());
        //    var copiedParameters = _mapper.Map<List<ParameterResource>, List<Parameter>>(parametersResource);

        //    var script = await _scriptRepository.GetAsync(newScriptId);
        //    if (script == null)
        //        return NotFound();

        //    script.Modified = DateTime.Now;
        //    copiedParameters.ForEach(p =>
        //    {
        //        p.Id = 0;
        //        p.Script = script;
        //        _parameterRepository.AddAsync(p);
        //    });

        //    await _unitOfWork.CompleteAsync();

        //    return Ok(newScriptId);
        //}

        //#endregion // Public_Methods
    }
}
