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
    [Route("api/parametersTranslations")]
    [ApiController]
    public class ParametersTranslationsController : ControllerBase
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IParameterTranslationRepository _translationRepository;
        private readonly IScriptInterpreterUnitOfWork _unitOfWork;

        #endregion // Fields

        #region Constructors

        public ParametersTranslationsController(
            IMapper mapper,
            IParameterTranslationRepository translationRepository,
            IScriptInterpreterUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _translationRepository = translationRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion // Constructors

        #region Public_Methods

        [HttpGet("{scriptId}/{lang}")]
        public async Task<IActionResult> GetParametersTranslation(long scriptId, Language lang)
        {  
            var parametersTranslations = await _translationRepository.GetParametersTranslations(scriptId, lang);
            
            var parametersTranslationsResources = _mapper.Map<IEnumerable<ParameterTranslation>, IEnumerable< ParameterTranslationResource>>(parametersTranslations);

            return Ok(parametersTranslationsResources);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateParameterTranslation([FromBody] ParameterTranslationResource parameterTranslationResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var parameterTranslation = _mapper.Map<ParameterTranslationResource, ParameterTranslation>(parameterTranslationResource);

            await _translationRepository.AddParameterTranslationAsync(parameterTranslation);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<ParameterTranslation, ParameterTranslationResource>(parameterTranslation);
            return Ok(result);
        }

        [HttpPut("{parameterTranslationId}")]
        public async Task<IActionResult> UpdateParameterTranslation(long parameterTranslationId, [FromBody] ParameterTranslationResource parameterTranslationResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var parameterTranslation = await _translationRepository.GetParameterTranslation(parameterTranslationId);

            if (parameterTranslation == null)
                return NotFound();

            _mapper.Map<ParameterTranslationResource, ParameterTranslation>(parameterTranslationResource, parameterTranslation);

            await _unitOfWork.CompleteAsync();

            parameterTranslation = await _translationRepository.GetParameterTranslation(parameterTranslationId);

            var result = _mapper.Map<ParameterTranslation, ParameterTranslationResource>(parameterTranslation);
            return Ok(result);
        }

        [HttpDelete("{parameterTranslationId}")]
        public async Task<IActionResult> DeleteParameterTranslation(long parameterTranslationId)
        {
            var parameterTranslation = await _translationRepository.GetParameterTranslation(parameterTranslationId);

            if (parameterTranslation == null)
                return NotFound();

            _translationRepository.RemoveParameterTranslation(parameterTranslation);
            await _unitOfWork.CompleteAsync();

            return Ok(parameterTranslationId);
        }
        #endregion // Public_Methods
    }
}