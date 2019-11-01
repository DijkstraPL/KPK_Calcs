using AutoMapper;
using Build_IT_Application.Infrastructures.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.TestDatas.Queries.GetTestDatasForScript
{
    public class GetTestDatasForScriptQuery : IRequest<IEnumerable<TestDataResource>>
    {
        #region Properties

        public string Language { get; set; }
        public long ScriptId { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<GetTestDatasForScriptQuery, IEnumerable<TestDataResource>>
        {
            #region Fields

            private readonly ITestDataRepository _testDataRepository;
            private readonly ITranslationService _translationService;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(ITestDataRepository testDataRepository,
                ITranslationService translationService,
                IMapper mapper)
            {
                _testDataRepository = testDataRepository;
                _translationService = translationService;
                _mapper = mapper;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<IEnumerable<TestDataResource>> Handle(GetTestDatasForScriptQuery request, CancellationToken cancellationToken)
            {
                var testDatas = await _testDataRepository.GetAllTestDataForScriptAsync(request.ScriptId).ConfigureAwait(false);
                var testDatasResources = _mapper.Map<IEnumerable<TestData>, IEnumerable<TestDataResource>>(testDatas);

                return testDatasResources;
            }

            #endregion // Public_Methods
        }
    }
}
