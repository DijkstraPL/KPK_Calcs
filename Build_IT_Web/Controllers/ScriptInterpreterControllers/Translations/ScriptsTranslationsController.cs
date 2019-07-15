using Build_IT_Application.ScriptInterpreter.Translations.Commands.CreateScriptTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.DeleteScriptTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Commands.UpdateScriptTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Queries.GetScriptTranslation;
using Build_IT_Application.ScriptInterpreter.Translations.Queries.GetScriptTranslations;
using Build_IT_Data.Entities.Scripts.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers.Translations
{
    [Route("api/scriptsTranslations")]
    [ApiController]
    public class ScriptsTranslationsController : BaseController
    {
        [HttpGet("{scriptId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetScriptTranslations(long scriptId)
        {
            return Ok(await Mediator.Send(new GetScriptTranslationsQuery { ScriptId = scriptId }));
        }

        [HttpGet("{scriptId}/{lang}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetScriptTranslation(long scriptId, Language lang)
        {
            return Ok(await Mediator.Send(new GetScriptTranslationQuery { ScriptId = scriptId, Language = lang }));
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateScriptTranslation([FromBody] CreateScriptTranslationCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{scriptId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateScriptTranslation(long scriptId, [FromBody] UpdateScriptTranslationCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{scriptId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteParameterTranslation(long scriptId)
        {
            await Mediator.Send(new DeleteScriptTranslationCommand { Id = scriptId });

            return NoContent();
        }

        //#region Fields

        //private readonly IMapper _mapper;
        //private readonly IScriptTranslationRepository _translationRepository;
        //private readonly IScriptInterpreterUnitOfWork _unitOfWork;

        //#endregion // Fields

        //#region Constructors

        //public ScriptsTranslationsController(
        //    IMapper mapper,
        //    IScriptTranslationRepository translationRepository,
        //    IScriptInterpreterUnitOfWork unitOfWork)
        //{
        //    _mapper = mapper;
        //    _translationRepository = translationRepository;
        //    _unitOfWork = unitOfWork;
        //}

        //#endregion // Constructors

        //#region Public_Methods

        //[HttpGet("{scriptId}")]
        //public async Task<IActionResult> GetScriptTranslations(long scriptId)
        //{
        //    var scriptTranslations = await _translationRepository.GetScriptTranslations(scriptId);

        //    if (scriptTranslations?.Count() == 0)
        //        return NotFound();

        //    var scriptTranslationsResources = _mapper.Map<List<ScriptTranslation>, List<ScriptTranslationResource>>(scriptTranslations.ToList());
            
        //    return Ok(scriptTranslationsResources);
        //}

        //[HttpGet("{scriptId}/{lang}")]
        //public async Task<IActionResult> GetScriptTranslation(long scriptId, Language lang)
        //{  
        //    var scriptTranslation = await _translationRepository.GetScriptTranslation(scriptId, lang);

        //    if (scriptTranslation == null)
        //        return NotFound();

        //    var scriptTranslationResource = _mapper.Map<ScriptTranslation, ScriptTranslationResource>(scriptTranslation);

        //    return Ok(scriptTranslationResource);
        //}

        //[HttpPost()]
        //public async Task<IActionResult> CreateScriptTranslation([FromBody] ScriptTranslationResource scriptTranslationResource)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var scriptTranslation = _mapper.Map<ScriptTranslationResource, ScriptTranslation>(scriptTranslationResource);

        //    await _translationRepository.AddScriptTranslationAsync(scriptTranslation);
        //    await _unitOfWork.CompleteAsync();

        //    var result = _mapper.Map<ScriptTranslation, ScriptTranslationResource>(scriptTranslation);
        //    return Ok(result);
        //}

        //[HttpPut("{scriptTranslationId}")]
        //public async Task<IActionResult> UpdateScriptTranslation(long scriptTranslationId, [FromBody] ScriptTranslationResource scriptTranslationResource)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var scriptTranslation = await _translationRepository.GetScriptTranslation(scriptTranslationId);

        //    if (scriptTranslation == null)
        //        return NotFound();

        //    _mapper.Map<ScriptTranslationResource, ScriptTranslation>(scriptTranslationResource, scriptTranslation);

        //    await _unitOfWork.CompleteAsync();

        //    scriptTranslation = await _translationRepository.GetScriptTranslation(scriptTranslationId);

        //    var result = _mapper.Map<ScriptTranslation, ScriptTranslationResource>(scriptTranslation);
        //    return Ok(result);
        //}

        //[HttpDelete("{scriptTranslationId}")]
        //public async Task<IActionResult> DeleteScriptTranslation(long scriptTranslationId)
        //{
        //    var scriptTranslation = await _translationRepository.GetScriptTranslation(scriptTranslationId);

        //    if (scriptTranslation == null)
        //        return NotFound();

        //    _translationRepository.RemoveScriptTranslation(scriptTranslation);
        //    await _unitOfWork.CompleteAsync();

        //    return Ok(scriptTranslationId);
        //}

        //#endregion // Public_Methods
    }
}