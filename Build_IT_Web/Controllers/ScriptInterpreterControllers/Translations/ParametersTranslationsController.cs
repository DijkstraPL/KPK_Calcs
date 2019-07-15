using AutoMapper;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.CreateParameterTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.DeleteParameterTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.UpdateParameterTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Queries.GetParametersTranslation;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_Data.Entities.Scripts.Translations;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources.Translations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers.Translations
{
    [Route("api/parametersTranslations")]
    [ApiController]
    public class ParametersTranslationsController : BaseController
    {
        [HttpGet("{scriptId}/{lang}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetParametersTranslation(long scriptId, Language lang)
        {
            return Ok(await Mediator.Send(new GetParametersTranslationQuery { ScriptId = scriptId, Language = lang }));
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateParameterTranslation([FromBody] CreateParameterTranslationCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{parameterTranslationId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateParameterTranslation(long parameterTranslationId, [FromBody] UpdateParameterTranslationCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{parameterTranslationId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteParameterTranslation(long parameterTranslationId)
        {
            await Mediator.Send(new DeleteParameterTranslationCommand { Id = parameterTranslationId });

            return NoContent();
        }

        //#region Fields

        //private readonly IMapper _mapper;
        //private readonly IParameterTranslationRepository _translationRepository;
        //private readonly IScriptInterpreterUnitOfWork _unitOfWork;

        //#endregion // Fields

        //#region Constructors

        //public ParametersTranslationsController(
        //    IMapper mapper,
        //    IParameterTranslationRepository translationRepository,
        //    IScriptInterpreterUnitOfWork unitOfWork)
        //{
        //    _mapper = mapper;
        //    _translationRepository = translationRepository;
        //    _unitOfWork = unitOfWork;
        //}

        //#endregion // Constructors

        //#region Public_Methods

        //[HttpGet("{scriptId}/{lang}")]
        //public async Task<IActionResult> GetParametersTranslation(long scriptId, Language lang)
        //{  
        //    var parametersTranslations = await _translationRepository.GetParametersTranslations(scriptId, lang);

        //    var parametersTranslationsResources = _mapper.Map<IEnumerable<ParameterTranslation>, IEnumerable< ParameterTranslationResource>>(parametersTranslations);

        //    return Ok(parametersTranslationsResources);
        //}

        //[HttpPost()]
        //public async Task<IActionResult> CreateParameterTranslation([FromBody] ParameterTranslationResource parameterTranslationResource)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var parameterTranslation = _mapper.Map<ParameterTranslationResource, ParameterTranslation>(parameterTranslationResource);

        //    await _translationRepository.AddParameterTranslationAsync(parameterTranslation);
        //    await _unitOfWork.CompleteAsync();

        //    var result = _mapper.Map<ParameterTranslation, ParameterTranslationResource>(parameterTranslation);
        //    return Ok(result);
        //}

        //[HttpPut("{parameterTranslationId}")]
        //public async Task<IActionResult> UpdateParameterTranslation(long parameterTranslationId, [FromBody] ParameterTranslationResource parameterTranslationResource)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var parameterTranslation = await _translationRepository.GetParameterTranslation(parameterTranslationId);

        //    if (parameterTranslation == null)
        //        return NotFound();

        //    _mapper.Map<ParameterTranslationResource, ParameterTranslation>(parameterTranslationResource, parameterTranslation);

        //    await _unitOfWork.CompleteAsync();

        //    parameterTranslation = await _translationRepository.GetParameterTranslation(parameterTranslationId);

        //    var result = _mapper.Map<ParameterTranslation, ParameterTranslationResource>(parameterTranslation);
        //    return Ok(result);
        //}

        //[HttpDelete("{parameterTranslationId}")]
        //public async Task<IActionResult> DeleteParameterTranslation(long parameterTranslationId)
        //{
        //    var parameterTranslation = await _translationRepository.GetParameterTranslation(parameterTranslationId);

        //    if (parameterTranslation == null)
        //        return NotFound();

        //    _translationRepository.RemoveParameterTranslation(parameterTranslation);
        //    await _unitOfWork.CompleteAsync();

        //    return Ok(parameterTranslationId);
        //}
        //#endregion // Public_Methods
    }
}