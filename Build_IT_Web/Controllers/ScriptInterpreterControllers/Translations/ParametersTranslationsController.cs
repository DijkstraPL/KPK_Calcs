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
        private readonly ITranslationRepository _translationRepository;
        private readonly IScriptInterpreterUnitOfWork _unitOfWork;

        #endregion // Fields

        #region Constructors

        public ParametersTranslationsController(
            IMapper mapper,
            ITranslationRepository translationRepository,
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

        #endregion // Public_Methods
    }
}