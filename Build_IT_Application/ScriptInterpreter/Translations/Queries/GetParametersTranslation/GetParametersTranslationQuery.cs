using AutoMapper;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_Data.Entities.Scripts.Translations;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Translations.Queries.GetParametersTranslation
{
    public class GetParametersTranslationQuery : IRequest<IEnumerable<ParameterTranslationResource>>
    {
        #region Properties
        
        public long ScriptId { get; set; }
        public Language Language { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<GetParametersTranslationQuery, IEnumerable<ParameterTranslationResource>>
        {
            #region Fields

            private readonly IParameterTranslationRepository _translationRepository;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(
            IParameterTranslationRepository translationRepository,
            IMapper mapper)
            {
                _mapper = mapper;
                _translationRepository = translationRepository;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<IEnumerable<ParameterTranslationResource>> Handle(GetParametersTranslationQuery request, CancellationToken cancellationToken)
            {
                var parameterTranslations = await _translationRepository.GetParametersTranslations(request.ScriptId, request.Language);
                var parameterTranslationsResources = _mapper.Map<IEnumerable<ParameterTranslation>, IEnumerable<ParameterTranslationResource>>(parameterTranslations);

                return parameterTranslationsResources;
            }

            #endregion // Public_Methods
        }
    }
}
