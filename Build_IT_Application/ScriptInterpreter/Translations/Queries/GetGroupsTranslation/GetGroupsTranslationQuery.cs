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

namespace Build_IT_Application.ScriptInterpreter.Translations.Queries.GetGroupsTranslation
{
    public class GetGroupsTranslationQuery : IRequest<IEnumerable<GroupTranslationResource>>
    {
        #region Properties
        
        public long ScriptId { get; set; }
        public Language Language { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<GetGroupsTranslationQuery, IEnumerable<GroupTranslationResource>>
        {
            #region Fields

            private readonly IGroupTranslationRepository _translationRepository;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(
            IGroupTranslationRepository translationRepository,
            IMapper mapper)
            {
                _mapper = mapper;
                _translationRepository = translationRepository;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<IEnumerable<GroupTranslationResource>> Handle(GetGroupsTranslationQuery request, CancellationToken cancellationToken)
            {
                var groupTranslations = await _translationRepository.GetGroupTranslations(request.ScriptId, request.Language);
                var groupTranslationsResources = _mapper.Map<IEnumerable<GroupTranslation>, IEnumerable<GroupTranslationResource>>(groupTranslations);

                return groupTranslationsResources;
            }

            #endregion // Public_Methods
        }
    }
}
