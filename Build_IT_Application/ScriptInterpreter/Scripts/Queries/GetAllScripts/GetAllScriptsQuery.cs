using AutoMapper;
using Build_IT_Application.Infrastructures.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Scripts.Queries.GetAllScripts
{
    public class GetAllScriptsQuery : IRequest<IEnumerable<ScriptResource>>
    {
        #region Properties

        public string Language { get; set; }
        public string CurrentUserId { get; set; }
        public bool IsAdmin { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<GetAllScriptsQuery, IEnumerable<ScriptResource>>
        {
            #region Fields

            private readonly IScriptRepository _scriptRepository;
            private readonly ITranslationService _translationService;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(IScriptRepository scriptRepository,
                ITranslationService translationService,
                IMapper mapper)
            {
                _scriptRepository = scriptRepository;
                _translationService = translationService;
                _mapper = mapper;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<IEnumerable<ScriptResource>> Handle(GetAllScriptsQuery request, CancellationToken cancellationToken)
            {
                var scripts = await _scriptRepository.GetAllScriptsWithTagsAsync();

                var scriptResources = scripts
                    .Select(s =>
                    {
                        ScriptResource scriptResource = null;
                        if (s.IsPublic || s.Author == request.CurrentUserId || request.IsAdmin)
                        {
                            scriptResource = _mapper.Map<Script, ScriptResource>(s);
                            scriptResource.IsEditable = s.Author == request.CurrentUserId || request.IsAdmin;
                        }
                        return scriptResource;
                    })
                    .Where(sr => sr != null);

                await _translationService.SetScriptsTranslation(request.Language, scriptResources);

                return scriptResources;
            }

            #endregion // Public_Methods
        }
    }
}
