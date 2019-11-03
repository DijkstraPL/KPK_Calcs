using Build_IT_Application.Exceptions;
using Build_IT_Application.Mapping;
using Build_IT_Application.ScriptInterpreter.TestDatas.Queries;
using Build_IT_CommonTools.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.TestDatas.Commands.CreateTestData
{
    public class CreateTestDataCommand : IRequest
    {
        #region Properties

        public long Id { get; set; }
        public long ScriptId { get; set; }
        public string Name { get; set; }
        public ICollection<TestParameterResource> TestParameters { get; set; }
        public ICollection<AssertionResource> Assertions { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<CreateTestDataCommand, Unit>
        {
            #region Fields

            private readonly IScriptRepository _scriptRepository;
            private readonly ITestDataRepository _testDataRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;
            private readonly IScriptMappingProfile _scriptMappingProfile;
            private readonly IDateTime _dateTime;

            #endregion // Fields

            #region Constructors

            public Handler(
            IScriptRepository scriptRepository,
                ITestDataRepository testDataRepository,
                IScriptInterpreterUnitOfWork unitOfWork,
                IScriptMappingProfile scriptMappingProfile,
            IDateTime dateTime)
            {
                _scriptRepository = scriptRepository;
                _testDataRepository = testDataRepository;
                _unitOfWork = unitOfWork;
                _scriptMappingProfile = scriptMappingProfile;
                _dateTime = dateTime;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(CreateTestDataCommand request, CancellationToken cancellationToken)
            {
                var testData = new TestData
                {
                    Id = 0,
                    ScriptId = request.ScriptId,
                    Name = request.Name,
                };

                _scriptMappingProfile.UpdateAssertions(request.Assertions, testData);
                _scriptMappingProfile.RemoveNotAddedAssertions(request.Assertions, testData);
                _scriptMappingProfile.AddNewAssertions(request.Assertions, testData);
                
                var testParameters = request.TestParameters
                    .Where(tp => !string.IsNullOrWhiteSpace(tp.Value))
                    .ToList();

                _scriptMappingProfile.UpdateTestParameters(testParameters, testData);
                _scriptMappingProfile.RemoveNotAddedTestParameters(testParameters, testData);
                _scriptMappingProfile.AddNewTestParameters(testParameters, testData);

                var script = await _scriptRepository.GetAsync(request.ScriptId);
                if (script == null)
                    throw new NotFoundException(nameof(CreateTestDataCommand), request.ScriptId);
                script.Modified = _dateTime.Now;

                await _testDataRepository.AddAsync(testData).ConfigureAwait(false);

                await _unitOfWork.CompleteAsync(cancellationToken).ConfigureAwait(false);

                return MediatR.Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
