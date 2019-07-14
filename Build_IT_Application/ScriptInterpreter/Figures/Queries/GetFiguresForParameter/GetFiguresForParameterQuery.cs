using AutoMapper;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Figures.Queries.GetFiguresForParameter
{
    public class GetFiguresForParameterQuery : IRequest<IEnumerable<FigureResource>>
    {
        #region Properties
               
        public long ParameterId { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<GetFiguresForParameterQuery, IEnumerable<FigureResource>>
        {
            #region Fields

            private readonly IParameterRepository _parameterRepository;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(IParameterRepository parameterRepository,
                IMapper mapper)
            {
                _parameterRepository = parameterRepository;
                _mapper = mapper;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<IEnumerable<FigureResource>> Handle(GetFiguresForParameterQuery request, CancellationToken cancellationToken)
            {
                var figures = await _parameterRepository.GetFiguresAsync(request.ParameterId);

                return _mapper.Map<IEnumerable<Figure>, IEnumerable<FigureResource>>(figures);
            }

            #endregion // Public_Methods
        }
    }
}
