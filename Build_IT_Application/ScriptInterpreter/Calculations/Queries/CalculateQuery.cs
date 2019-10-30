using AutoMapper;
using Build_IT_Application.Infrastructures.Interfaces;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Applications.ScriptInterpreter.Services;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Calculations.Commands
{
    public class CalculateQuery : IRequest<IEnumerable<ParameterResource>>
    {
        #region Properties
        
        public long ScriptId { get; set; }
        public ICollection<ParameterResource> InputData { get; set; }
        public string LanguageCode { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<CalculateQuery, IEnumerable<ParameterResource>>
        {
            #region Fields

            private readonly IScriptRepository _scriptRepository;
            private readonly IParameterRepository _parameterRepository;
            private readonly ITranslationService _translationService;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(
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
            
            public async Task<IEnumerable<ParameterResource>> Handle(
                CalculateQuery request, CancellationToken cancellationToken)
            {
                var script = await _scriptRepository.GetAsync(request.ScriptId);
                var parameters = await _parameterRepository
                    .GetAllParametersForScriptAsync(request.ScriptId)
                    .ConfigureAwait(false);

                var equations = new Dictionary<long, string>(parameters.ToDictionary(p => p.Id, p => p.Value));

                var scriptCalculator = new ScriptCalculator(parameters.ToList());

                await scriptCalculator
                    .CalculateAsync(request.InputData.Where(v => v.Value != null))
                    .ConfigureAwait(false);

                var calculatedParameters = _mapper
                    .Map<List<Parameter>, List<ParameterResource>>(scriptCalculator.GetResult().ToList());
                calculatedParameters.ForEach(cp => cp.Equation = equations
                    .SingleOrDefault(p => p.Key == cp.Id).Value);

                await _translationService.SetParametersTranslation(
                    request.LanguageCode, calculatedParameters, script.DefaultLanguage)
                    .ConfigureAwait(false);
                return calculatedParameters;
            }

            #endregion // Public_Methods                          
        }
    }
}
