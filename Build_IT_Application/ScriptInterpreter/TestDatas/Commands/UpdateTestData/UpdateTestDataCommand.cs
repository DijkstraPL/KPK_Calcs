using Build_IT_Application.Exceptions;
using Build_IT_Application.Mapping;
using Build_IT_Application.ScriptInterpreter.TestDatas.Queries;
using Build_IT_CommonTools.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.TestDatas.Commands.UpdateTestData
{
    public class UpdateTestDataCommand: IRequest
    {
        #region Properties

        public long Id { get; set; }
        public long ScriptId { get; set; }
        public string Name { get; set; }
        public ICollection<TestParameterResource> TestParameters { get; set; }
        public ICollection<AssertionResource> Assertions { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<UpdateTestDataCommand, Unit>
        {
            #region Fields

            private readonly IDateTime _dateTime;
            private readonly IScriptRepository _scriptRepository;
            private readonly ITestDataRepository _testDataRepository;
            private readonly IScriptMappingProfile _scriptMappingProfile;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
                IDateTime dateTime,
                IScriptRepository scriptRepository,
                ITestDataRepository testDataRepository,
                IScriptMappingProfile scriptMappingProfile,
                IScriptInterpreterUnitOfWork unitOfWork)
            {
                _dateTime = dateTime;
                _scriptRepository = scriptRepository;
                _testDataRepository = testDataRepository;
                _scriptMappingProfile = scriptMappingProfile;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(UpdateTestDataCommand request, CancellationToken cancellationToken)
            {
                var script = await _scriptRepository.GetAsync(request.ScriptId).ConfigureAwait(false);
                var testData = await _testDataRepository.GetTestDataWithAllDependanciesAsync(request.Id).ConfigureAwait(false);

                if (script == null || testData == null)
                    throw new NotFoundException(nameof(UpdateTestDataCommand), request.Id);

                testData.Name = request.Name;
                
                _scriptMappingProfile.UpdateAssertions(request.Assertions, testData);
                _scriptMappingProfile.RemoveNotAddedAssertions(request.Assertions, testData);
                _scriptMappingProfile.AddNewAssertions(request.Assertions, testData);

                _scriptMappingProfile.UpdateTestParameters(request.TestParameters, testData);
                _scriptMappingProfile.RemoveNotAddedTestParameters(request.TestParameters, testData);
                _scriptMappingProfile.AddNewTestParameters(request.TestParameters, testData);

                script.Modified = _dateTime.Now;

                await _unitOfWork.CompleteAsync().ConfigureAwait(false);

                return MediatR.Unit.Value;
            }

            #endregion // Public_Methods        
        }
    }
}
