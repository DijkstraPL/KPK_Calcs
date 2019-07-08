using AutoMapper;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Models.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Models.Translations;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources.Translations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers.Translations
{
    [Route("api/scriptsTranslations")]
    [ApiController]
    public class ScriptsTranslationsController : ControllerBase
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IScriptTranslationRepository _translationRepository;
        private readonly IScriptInterpreterUnitOfWork _unitOfWork;

        #endregion // Fields

        #region Constructors

        public ScriptsTranslationsController(
            IMapper mapper,
            IScriptTranslationRepository translationRepository,
            IScriptInterpreterUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _translationRepository = translationRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion // Constructors

        #region Public_Methods

        [HttpGet("{scriptTranslationId}")]
        public async Task<IActionResult> GetScriptTranslations(long scriptTranslationId)
        {
            var scriptTranslations = await _translationRepository.GetScriptTranslations(scriptTranslationId);

            if (scriptTranslations?.Count() == 0)
                return NotFound();

            var scriptTranslationsResources = _mapper.Map<List<ScriptTranslation>, List<ScriptTranslationResource>>(scriptTranslations.ToList());
            
            return Ok(scriptTranslationsResources);
        }

        [HttpGet("{scriptId}/{lang}")]
        public async Task<IActionResult> GetScriptTranslation(long scriptId, Language lang)
        {  
            var scriptTranslation = await _translationRepository.GetScriptTranslation(scriptId, lang);

            if (scriptTranslation == null)
                return NotFound();

            var scriptTranslationResource = _mapper.Map<ScriptTranslation, ScriptTranslationResource>(scriptTranslation);

            return Ok(scriptTranslationResource);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateScriptTranslation([FromBody] ScriptTranslationResource scriptTranslationResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var scriptTranslation = _mapper.Map<ScriptTranslationResource, ScriptTranslation>(scriptTranslationResource);

            await _translationRepository.AddScriptTranslationAsync(scriptTranslation);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<ScriptTranslation, ScriptTranslationResource>(scriptTranslation);
            return Ok(result);
        }

        [HttpPut("{scriptTranslationId}")]
        public async Task<IActionResult> UpdateScriptTranslation(long scriptTranslationId, [FromBody] ScriptTranslationResource scriptTranslationResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var scriptTranslation = await _translationRepository.GetScriptTranslation(scriptTranslationId);

            if (scriptTranslation == null)
                return NotFound();

            _mapper.Map<ScriptTranslationResource, ScriptTranslation>(scriptTranslationResource, scriptTranslation);

            await _unitOfWork.CompleteAsync();

            scriptTranslation = await _translationRepository.GetScriptTranslation(scriptTranslationId);

            var result = _mapper.Map<ScriptTranslation, ScriptTranslationResource>(scriptTranslation);
            return Ok(result);
        }

        [HttpDelete("{scriptTranslationId}")]
        public async Task<IActionResult> DeleteScriptTranslation(long scriptTranslationId)
        {
            var scriptTranslation = await _translationRepository.GetScriptTranslation(scriptTranslationId);

            if (scriptTranslation == null)
                return NotFound();

            _translationRepository.RemoveScriptTranslation(scriptTranslation);
            await _unitOfWork.CompleteAsync();

            return Ok(scriptTranslationId);
        }

        #endregion // Public_Methods
    }
}