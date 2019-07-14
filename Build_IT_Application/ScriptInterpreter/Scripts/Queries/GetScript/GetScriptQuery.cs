using AutoMapper;
using Build_IT_Application.Exceptions;
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

        #endregion // Properties

        public class Handler : IRequestHandler<GetScriptQuery, ScriptResource>
        {
            #region Fields

            private readonly IScriptRepository _scriptRepository;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(IScriptRepository scriptRepository,
                IMapper mapper)
            {
                _scriptRepository = scriptRepository;
                _mapper = mapper;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<ScriptResource> Handle(GetScriptQuery request, CancellationToken cancellationToken)
            {
                var script = await _scriptRepository.GetScriptWithTagsAsync(request.Id);

                if (script == null)
                    throw new NotFoundException(nameof(Script), request.Id);

                return _mapper.Map<Script, ScriptResource>(script);
            }

            #endregion // Public_Methods
        }
    }
}
