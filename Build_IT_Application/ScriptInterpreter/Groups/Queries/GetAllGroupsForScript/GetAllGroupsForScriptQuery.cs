using AutoMapper;
using Build_IT_Application.Infrastructures.Interfaces;
using Build_IT_Application.ScriptInterpreter.Groups.Queries;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Parameters.Queries.GetAllParametersForScript
{
    public class GetAllGroupsForScriptQuery : IRequest<IEnumerable<GroupResource>>
    {
        #region Properties

        public long ScriptId { get; set; }
        public string Language { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<GetAllGroupsForScriptQuery, IEnumerable<GroupResource>>
        {
            #region Fields

            private readonly IGroupRepository _groupRepository;
            private readonly IScriptRepository _scriptRepository;
            private readonly ITranslationService _translationService;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(IGroupRepository groupRepository,
                IScriptRepository scriptRepository,
                ITranslationService translationService,
                IMapper mapper)
            {
                _groupRepository = groupRepository;
                _scriptRepository = scriptRepository;
                _translationService = translationService;
                _mapper = mapper;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<IEnumerable<GroupResource>> Handle(GetAllGroupsForScriptQuery request, CancellationToken cancellationToken)
            {
                var groups = await _groupRepository.GetAllAsync(cancellationToken);
                var filteredGroups = groups.Where(g => g.ScriptId == request.ScriptId);
                var defaultLanguage = await _scriptRepository.GetDefaultLanguageForScriptAsync(request.ScriptId);

                var groupsResources = _mapper.Map<IEnumerable<Group>, IEnumerable<GroupResource>>(filteredGroups);
                await _translationService.SetGroupsTranslation(request.Language, groupsResources, defaultLanguage);

                return groupsResources;
            }

            #endregion // Public_Methods
        }
    }
}
