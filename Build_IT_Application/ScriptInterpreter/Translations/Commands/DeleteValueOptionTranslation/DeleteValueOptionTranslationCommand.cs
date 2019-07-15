using Build_IT_Application.Exceptions;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Translations.Commands.DeleteValueOptionTranslation
{
    public class DeleteValueOptionTranslationCommand : IRequest
    {
        #region Properties
        
        public long Id { get; set; }

        #endregion // Properties
        public class Handler : IRequestHandler<DeleteValueOptionTranslationCommand>
        {
            #region Fields

            private readonly IValueOptionTranslationRepository _valueOptionTranslationRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
                IValueOptionTranslationRepository valueOptionTranslationRepository,
                IScriptInterpreterUnitOfWork unitOfWork)
            {
                _valueOptionTranslationRepository =  valueOptionTranslationRepository;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(DeleteValueOptionTranslationCommand request, CancellationToken cancellationToken)
            {
                var valueOptionTranslation = await _valueOptionTranslationRepository.GetValueOptionTranslation(request.Id);

                if (valueOptionTranslation == null)
                    throw new NotFoundException(nameof(DeleteValueOptionTranslationCommand), request.Id);

                _valueOptionTranslationRepository.RemoveValueOptionTranslation(valueOptionTranslation);
                await _unitOfWork.CompleteAsync(cancellationToken);

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
