using AutoMapper;
using Build_IT_Application.Exceptions;
using Build_IT_Data.Entities.Scripts.Translations;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Translations.Queries.GetScriptTranslations
{
    public class GetScriptTranslationsQuery : IRequest<IEnumerable<ScriptTranslationResource>>
    {
        #region Properties
        
        public long ScriptId { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<GetScriptTranslationsQuery, IEnumerable<ScriptTranslationResource>>
        {
            #region Fields

            private readonly IMapper _mapper;
            private readonly IScriptTranslationRepository _translationRepository;

            #endregion // Fields

            #region Constructors

            public Handler(   
            IScriptTranslationRepository translationRepository,
            IMapper mapper)
            {
                _mapper = mapper;
                _translationRepository = translationRepository;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<IEnumerable<ScriptTranslationResource>> Handle(GetScriptTranslationsQuery request, CancellationToken cancellationToken)
            {
                var scriptTranslations = await _translationRepository.GetScriptTranslations(request.ScriptId);
                var scriptTranslationsResources = _mapper.Map<IEnumerable<ScriptTranslation>, IEnumerable<ScriptTranslationResource>>(scriptTranslations);

                return scriptTranslationsResources;
            }

            #endregion // Public_Methods
        }
    }
}
