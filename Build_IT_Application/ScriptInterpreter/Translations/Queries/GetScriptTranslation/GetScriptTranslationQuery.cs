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

namespace Build_IT_Application.ScriptInterpreter.Translations.Queries.GetScriptTranslation
{
    public class GetScriptTranslationQuery : IRequest<ScriptTranslationResource>
    {
        #region Properties
        
        public long ScriptId { get; set; }
        public Language Language { get; set; }

        #endregion // Properties
        
        public class Handler : IRequestHandler<GetScriptTranslationQuery, ScriptTranslationResource>
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

            public async Task<ScriptTranslationResource> Handle(GetScriptTranslationQuery request, CancellationToken cancellationToken)
            {
                var scriptTranslation = await _translationRepository.GetScriptTranslation(request.ScriptId, request.Language);
                var scriptTranslationResource = _mapper.Map<ScriptTranslation, ScriptTranslationResource>(scriptTranslation);

                return scriptTranslationResource;
            }

            #endregion // Public_Methods
        }
    }
}
