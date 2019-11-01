using Build_IT_Application.Exceptions;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.TestDatas.Commands.DeleteTestData
{
    public class DeleteTestDataCommand : IRequest
    {
        #region Properties

        public long Id { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<DeleteTestDataCommand>
        {
            #region Fields

            private readonly ITestDataRepository _testDataRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
                ITestDataRepository testDataRepository,
                IScriptInterpreterUnitOfWork unitOfWork)
            {
                _testDataRepository = testDataRepository;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(DeleteTestDataCommand request, CancellationToken cancellationToken)
            {
                var testData = await _testDataRepository.GetAsync(request.Id);

                if (testData == null)
                    throw new NotFoundException(nameof(testData), request.Id);

                _testDataRepository.Remove(testData);
                await _unitOfWork.CompleteAsync(cancellationToken).ConfigureAwait(false);

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
