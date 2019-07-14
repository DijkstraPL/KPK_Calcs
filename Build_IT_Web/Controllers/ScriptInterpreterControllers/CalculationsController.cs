using AutoMapper;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Services;
using Build_IT_Web.Services.Interfaces;
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
        #region Fields
        
        private readonly IScriptRepository _scriptRepository;
        private readonly IParameterRepository _parameterRepository;
        private readonly ITranslationService _translationService;
        private readonly IMapper _mapper;

        #endregion // Fields

        #region Constructors
        
        public CalculationsController(
            IScriptRepository scriptRepository,
            IParameterRepository parameterRepository,
            ITranslationService translationService,
            IMapper mapper)
        {
            _scriptRepository = scriptRepository;
            _parameterRepository = parameterRepository;
            _translationService = translationService;
            _mapper = mapper;
        }

        #endregion // Constructors

        #region Public_Methods
        
        [HttpPut("{scriptId}/calculate/{lang?}")]
        public async Task<IEnumerable<ParameterResource>> Calculate(long scriptId, [FromBody] List<ParameterResource> userParameters, string lang = TranslationService.DefaultLanguageCode)
        {
            var script = await _scriptRepository.GetAsync(scriptId);
            var parameters = await _parameterRepository.GetAllParametersForScriptAsync(scriptId);

            var equations = new Dictionary<long, string>(parameters.ToDictionary(p => p.Id, p => p.Value));

            var scriptCalculator = new ScriptCalculator(script, parameters.ToList());

            await scriptCalculator.CalculateAsync(userParameters.Where(v => v.Value != null));

            var calculatedParameters = _mapper.Map<List<Parameter>, List<ParameterResource>>(scriptCalculator.GetResult().ToList());
            calculatedParameters.ForEach(cp => cp.Equation = equations.SingleOrDefault(p => p.Key == cp.Id).Value);

            await _translationService.SetParametersTranslation(lang, calculatedParameters, script.DefaultLanguage);
            return calculatedParameters;
        }

        #endregion // Public_Methods
    }
}
