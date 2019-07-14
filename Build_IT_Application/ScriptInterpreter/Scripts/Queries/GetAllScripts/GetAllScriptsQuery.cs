using AutoMapper;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Scripts.Queries.GetAllScripts
{
    public class GetAllScriptsQuery : IRequest<IEnumerable<ScriptResource>>
    {
        public class Handler : IRequestHandler<GetAllScriptsQuery, IEnumerable<ScriptResource>>
        {
            #region Fields

            private readonly IScriptRepository _scriptRepository;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(IScriptRepository scriptRepository,
                IMapper mapper)
            {
                _scriptRepository =  scriptRepository;
                _mapper = mapper;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<IEnumerable<ScriptResource>> Handle(GetAllScriptsQuery request, CancellationToken cancellationToken)
            {
                var scripts = await _scriptRepository.GetAllScriptsWithTagsAsync();

                return _mapper.Map<IEnumerable<Script>, IEnumerable<ScriptResource>>(scripts);
            }

            #endregion // Public_Methods
        }
    }
}
