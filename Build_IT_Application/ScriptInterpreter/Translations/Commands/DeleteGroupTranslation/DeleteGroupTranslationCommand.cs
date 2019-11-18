using Build_IT_Application.Exceptions;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Translations.Commands.DeleteGroupTranslation
{
    public class DeleteGroupTranslationCommand : IRequest
    {
        #region Properties

        public long Id { get; set; }

        #endregion // Properties  

        public class Handler : IRequestHandler<DeleteGroupTranslationCommand>
        {
            #region Fields

            private readonly IGroupTranslationRepository _groupTranslationRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
                IGroupTranslationRepository groupTranslationRepository,
                IScriptInterpreterUnitOfWork unitOfWork)
            {
                _groupTranslationRepository = groupTranslationRepository;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(DeleteGroupTranslationCommand request, CancellationToken cancellationToken)
            {
                var groupTranslation = await _groupTranslationRepository.GetGroupTranslation(request.Id);

                if (groupTranslation == null)
                    throw new NotFoundException(nameof(DeleteGroupTranslationCommand), request.Id);

                _groupTranslationRepository.RemoveGroupTranslation(groupTranslation);
                await _unitOfWork.CompleteAsync(cancellationToken);

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
