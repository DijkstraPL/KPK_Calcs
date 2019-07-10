using AutoMapper;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_Data.Entities.Scripts.Translations;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources.Translations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers.Translations
{
    [Route("api/valueOptionsTranslations")]
    [ApiController]
    public class ValueOptionsTranslationsController : ControllerBase
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IValueOptionTranslationRepository _translationRepository;
        private readonly IScriptInterpreterUnitOfWork _unitOfWork;

        #endregion // Fields

        #region Constructors

        public ValueOptionsTranslationsController(
            IMapper mapper,
            IValueOptionTranslationRepository translationRepository,
            IScriptInterpreterUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _translationRepository = translationRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion // Constructors

        #region Public_Methods

        [HttpGet("{parameterId}/{lang}")]
        public async Task<IActionResult> GetValueOptionsTranslations(long parameterId, Language lang)
        {
            var valueOptionsTranslations = await _translationRepository.GetValueOptionsTranslations(parameterId, lang);

            var valueOptionsTranslationsResources = _mapper.Map<IEnumerable<ValueOptionTranslation>, IEnumerable<ValueOptionTranslationResource>>(valueOptionsTranslations);

            return Ok(valueOptionsTranslationsResources);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateValueOptionTranslation([FromBody] ValueOptionTranslationResource valueOptionTranslationResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var valueOptionTranslation = _mapper.Map<ValueOptionTranslationResource, ValueOptionTranslation>(valueOptionTranslationResource);

            await _translationRepository.AddValueOptionTranslationAsync(valueOptionTranslation);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<ValueOptionTranslation, ValueOptionTranslationResource>(valueOptionTranslation);
            return Ok(result);
        }

        [HttpPut("{valueOptionTranslationId}")]
        public async Task<IActionResult> UpdateValueOptionTranslation(long valueOptionTranslationId, [FromBody] ValueOptionTranslationResource valueOptionTranslationResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var valueOptionTranslation = await _translationRepository.GetValueOptionTranslation(valueOptionTranslationId);

            if (valueOptionTranslation == null)
                return NotFound();

            _mapper.Map<ValueOptionTranslationResource, ValueOptionTranslation>(valueOptionTranslationResource, valueOptionTranslation);

            await _unitOfWork.CompleteAsync();

            valueOptionTranslation = await _translationRepository.GetValueOptionTranslation(valueOptionTranslationId);

            var result = _mapper.Map<ValueOptionTranslation, ValueOptionTranslationResource>(valueOptionTranslation);
            return Ok(result);
        }

        [HttpDelete("{valueOptionTranslationId}")]
        public async Task<IActionResult> DeleteValueOptionTranslation(long valueOptionTranslationId)
        {
            var valueOptionTranslation = await _translationRepository.GetValueOptionTranslation(valueOptionTranslationId);

            if (valueOptionTranslation == null)
                return NotFound();

            _translationRepository.RemoveValueOptionTranslation(valueOptionTranslation);
            await _unitOfWork.CompleteAsync();

            return Ok(valueOptionTranslationId);
        }
        #endregion // Public_Methods
    }
}