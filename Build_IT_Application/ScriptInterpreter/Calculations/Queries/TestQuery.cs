using AutoMapper;
using Build_IT_Application.ScriptInterpreter.Calculations.Commands;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Applications.ScriptInterpreter.Services;
using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_ScriptInterpreter.Expressions;
using Build_IT_ScriptInterpreter.Scripts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Calculations.Queries
{
    public class TestQuery : IRequest<bool>
    {
        #region Properties

        public long TestId { get; set; }
        public long? AssertionId { get; set; }
        public string LanguageCode { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<TestQuery, bool>
        {
            #region Fields

            private readonly ITestDataRepository _testDataRepository;
            private readonly IScriptRepository _scriptRepository;
            private readonly IParameterRepository _parameterRepository;
            private readonly IMapper _mapper;
            private readonly IMediator _mediator;

            #endregion // Fields

            #region Constructors

            public Handler(
                ITestDataRepository testDataRepository,
                IScriptRepository scriptRepository,
                IParameterRepository parameterRepository,
                IMapper mapper,
                IMediator mediator)
            {
                _testDataRepository = testDataRepository;
                _scriptRepository = scriptRepository;
                _parameterRepository = parameterRepository;
                _mapper = mapper;
                _mediator = mediator;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<bool> Handle(
                TestQuery request, CancellationToken cancellationToken)
            {
                var testData = await _testDataRepository.GetTestDataWithAllDependanciesAsync(request.TestId)
                    .ConfigureAwait(false);
                var parameters = await _parameterRepository.GetAllParametersForScriptAsync(testData.ScriptId)
                    .ConfigureAwait(false);
                var parametersResource = _mapper.Map<IList<Parameter>, IList<ParameterResource>>(parameters.ToList());

                var editableParameters = parametersResource.Where(p => (p.Context & ParameterOptions.Editable) != 0);

                foreach (var editableParameter in editableParameters)
                    editableParameter.Value = testData.TestParameters
                        .First(p => p.ParameterId == editableParameter.Id)?.Value;

                var scriptCalculator = new ScriptCalculator(parameters.ToList());
                if (request.AssertionId == null)
                {
                    var assertions = testData.Assertions;
                    var assertionsValues = assertions.Select(a => a.Value).ToArray();
                    return await scriptCalculator.ValidateResults(editableParameters, assertionsValues).ConfigureAwait(false);
                }
                else
                {
                    var assertion = testData.Assertions.First(a => a.Id == request.AssertionId);
                    return await scriptCalculator.ValidateResults(editableParameters, assertion.Value).ConfigureAwait(false);
                }
            }

            #endregion // Public_Methods

            #region Private_Methods

            #endregion // Private_Methods                       
        }
    }
}
