using AutoMapper;
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

        #endregion // Properties

        public class Handler : IRequestHandler<GetAllParametersForScriptQuery, IEnumerable<ParameterResource>>
        {
            #region Fields

            private readonly IParameterRepository _parameterRepository;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(IParameterRepository parameterRepository,
                IMapper mapper)
            {
                _parameterRepository =  parameterRepository;
                _mapper = mapper;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<IEnumerable<ParameterResource>> Handle(GetAllParametersForScriptQuery request, CancellationToken cancellationToken)
            {
                var parameters = await _parameterRepository.GetAllParametersForScriptAsync(request.ScriptId);

                return _mapper.Map<IEnumerable<Parameter>, IEnumerable<ParameterResource>>(parameters);
            }

            #endregion // Public_Methods
        }
    }
}
