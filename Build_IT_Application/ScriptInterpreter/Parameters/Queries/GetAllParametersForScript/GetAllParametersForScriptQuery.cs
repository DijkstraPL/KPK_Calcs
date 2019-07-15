using AutoMapper;
using Build_IT_Application.Infrastructures.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Parameters.Queries.GetAllParametersForScript
{
    public class GetAllParametersForScriptQuery : IRequest<IEnumerable<ParameterResource>>
    {
        #region Properties

        public long ScriptId { get; set; }
        public string Language { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<GetAllParametersForScriptQuery, IEnumerable<ParameterResource>>
        {
            #region Fields

            private readonly IParameterRepository _parameterRepository;
            private readonly IScriptRepository _scriptRepository;
            private readonly ITranslationService _translationService;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(IParameterRepository parameterRepository,
                IScriptRepository scriptRepository,
                ITranslationService translationService,
                IMapper mapper)
            {
                _parameterRepository =  parameterRepository;
                _scriptRepository = scriptRepository;
                _translationService = translationService;
                _mapper = mapper;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<IEnumerable<ParameterResource>> Handle(GetAllParametersForScriptQuery request, CancellationToken cancellationToken)
            {
                var parameters = await _parameterRepository.GetAllParametersForScriptAsync(request.ScriptId);
                var defaultLanguage = await _scriptRepository.GetDefaultLanguageForScriptAsync(request.ScriptId);

                var parametersResources = _mapper.Map<IEnumerable<Parameter>, IEnumerable<ParameterResource>>(parameters);
                await _translationService.SetParametersTranslation(request.Language, parametersResources, defaultLanguage);

                return parametersResources;
            }

            #endregion // Public_Methods
        }
    }
}
