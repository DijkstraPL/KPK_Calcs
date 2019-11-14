using AutoMapper;
using Build_IT_Application.Infrastructures.Interfaces;
using Build_IT_Application.ScriptInterpreter.Calculations.Queries.Calculate;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Applications.ScriptInterpreter.Services;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Calculations.Queries.CalculateRange
{
    public class CalculateRangeQuery : IRequest<IEnumerable<IEnumerable<ParameterResource>>>
    {
        #region Properties

        public long ScriptId { get; set; }
        public RangeCalculationResource InputData { get; set; }
        public string LanguageCode { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<CalculateRangeQuery, IEnumerable<IEnumerable<ParameterResource>>>
        {
            #region Fields

            private readonly IScriptRepository _scriptRepository;
            private readonly IParameterRepository _parameterRepository;
            private readonly ITranslationService _translationService;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(
                IScriptRepository scriptRepository,
                IParameterRepository parameterRepository,
                ITranslationService translationService,
                IMapper mapper)
            {
                _scriptRepository = scriptRepository;
                _parameterRepository = parameterRepository;
                _translationService = translationService;
                _mapper = mapper;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<IEnumerable<IEnumerable<ParameterResource>>> Handle(
                CalculateRangeQuery request, CancellationToken cancellationToken)
            {
                var calculatedParameters = new List<IEnumerable<ParameterResource>>();
                var parameter = request.InputData.Parameters.FirstOrDefault(p => p.Id == request.InputData.ParameterId);

                var currentValue = request.InputData.MinValue;
                while (currentValue < request.InputData.MaxValue)
                {
                    parameter.Value = currentValue.ToString(CultureInfo.InvariantCulture);
                    var calculator = new CalculateQuery()
                    {
                        LanguageCode = request.LanguageCode,
                        ScriptId = request.ScriptId,
                        InputData = request.InputData.Parameters.ToList()
                    };

                    var handler = new CalculateQuery.Handler(
                        _scriptRepository, _parameterRepository, 
                        _translationService, _mapper);

                    var results = await handler.Handle(calculator, CancellationToken.None)
                       .ConfigureAwait(false);
                   calculatedParameters.Add(results);

                    currentValue += request.InputData.Tick;
                }

                return calculatedParameters;
            }

            #endregion // Public_Methods                          
        }
    }
}
