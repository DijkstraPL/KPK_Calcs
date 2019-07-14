using Build_IT_Application.Exceptions;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Parameters.Commands.DeleteParameter
{
    public class DeleteParameterCommand : IRequest
    {
        #region Properties

        public long Id { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<DeleteParameterCommand>
        {
            #region Fields

            private readonly IParameterRepository _parameterRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
                IParameterRepository parameterRepository,
                IScriptInterpreterUnitOfWork unitOfWork)
            {
                _parameterRepository = parameterRepository;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(DeleteParameterCommand request, CancellationToken cancellationToken)
            {
                var parameter = await _parameterRepository.GetAsync(request.Id);

                if (parameter == null)
                    throw new NotFoundException(nameof(Parameter), request.Id);

                _parameterRepository.Remove(parameter);
                await _unitOfWork.CompleteAsync(cancellationToken);

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
