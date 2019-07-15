using Build_IT_Application.Exceptions;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Translations.Commands.DeleteParameterTranslation
{
    public class DeleteParameterTranslationCommand : IRequest
    {
        #region Properties

        public long Id { get; set; }

        #endregion // Properties  
        public class Handler : IRequestHandler<DeleteParameterTranslationCommand>
        {
            #region Fields

            private readonly IParameterTranslationRepository _parameterTranslationRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
                IParameterTranslationRepository parameterTranslationRepository,
                IScriptInterpreterUnitOfWork unitOfWork)
            {
                _parameterTranslationRepository = parameterTranslationRepository;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(DeleteParameterTranslationCommand request, CancellationToken cancellationToken)
            {
                var parameterTranslation = await _parameterTranslationRepository.GetParameterTranslation(request.Id);

                if (parameterTranslation == null)
                    throw new NotFoundException(nameof(DeleteParameterTranslationCommand), request.Id);

                _parameterTranslationRepository.RemoveParameterTranslation(parameterTranslation);
                await _unitOfWork.CompleteAsync(cancellationToken);

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
