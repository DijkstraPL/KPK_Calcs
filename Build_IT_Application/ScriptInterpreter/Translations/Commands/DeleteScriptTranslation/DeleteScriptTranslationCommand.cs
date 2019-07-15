using Build_IT_Application.Exceptions;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Translations.Commands.DeleteScriptTranslation
{
    public class DeleteScriptTranslationCommand : IRequest
    {
        #region Properties

        public long Id { get; set; }

        #endregion // Properties  
        public class Handler : IRequestHandler<DeleteScriptTranslationCommand>
        {
            #region Fields

            private readonly IScriptTranslationRepository _scriptTranslationRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
                IScriptTranslationRepository scriptTranslationRepository,
                IScriptInterpreterUnitOfWork unitOfWork)
            {
                _scriptTranslationRepository = scriptTranslationRepository;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(DeleteScriptTranslationCommand request, CancellationToken cancellationToken)
            {
                var scriptTranslation = await _scriptTranslationRepository.GetScriptTranslation(request.Id);

                if (scriptTranslation == null)
                    throw new NotFoundException(nameof(DeleteScriptTranslationCommand), request.Id);

                _scriptTranslationRepository.RemoveScriptTranslation(scriptTranslation);
                await _unitOfWork.CompleteAsync(cancellationToken);

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
