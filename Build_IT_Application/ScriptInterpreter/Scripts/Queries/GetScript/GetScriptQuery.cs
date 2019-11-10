using AutoMapper;
using Build_IT_Application.Exceptions;
using Build_IT_Application.Infrastructures.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Scripts.Queries.GetScript
{
    public class GetScriptQuery : IRequest<ScriptResource>
    {
        #region Properties

        public long Id { get; set; }
        public string Language { get; set; }
        public string CurrentUserId { get; set; }
        public bool IsAdmin { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<GetScriptQuery, ScriptResource>
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

            public async Task<ScriptResource> Handle(GetScriptQuery request, CancellationToken cancellationToken)
            {
                var script = await _scriptRepository.GetScriptWithTagsAsync(request.Id);

                if (!script.IsPublic && script.Author != request.CurrentUserId && !request.IsAdmin)
                    throw new ValidationException();
                if (script == null)
                    throw new NotFoundException(nameof(Script), request.Id);

                var scriptResource = _mapper.Map<Script, ScriptResource>(script);
                await _translationService.SetScriptTranslation(request.Language, scriptResource);

                return scriptResource;
            }

            #endregion // Public_Methods
        }
    }
}
