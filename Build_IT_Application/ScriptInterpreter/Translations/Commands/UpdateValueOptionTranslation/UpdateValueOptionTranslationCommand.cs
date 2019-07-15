using Build_IT_Application.Exceptions;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Translations.Commands.UpdateValueOptionTranslation
{
    public class UpdateValueOptionTranslationCommand : IRequest
    {
        #region Properties

        public long Id { get; set; }
        public long ValueOptionId { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #endregion // Properties
        public class Handler : IRequestHandler<UpdateValueOptionTranslationCommand, Unit>
        {
            #region Fields

            private readonly IValueOptionTranslationRepository _translationRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
            IValueOptionTranslationRepository translationRepository,
            IScriptInterpreterUnitOfWork unitOfWork)
            {
                _translationRepository = translationRepository;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(UpdateValueOptionTranslationCommand request, CancellationToken cancellationToken)
            {
                var valueOptionTranslation = await _translationRepository.GetValueOptionTranslation(request.Id);

                if (valueOptionTranslation == null)
                    throw new NotFoundException(nameof(UpdateValueOptionTranslationCommand), request.Id);

                valueOptionTranslation.ValueOptionId = request.ValueOptionId;
                valueOptionTranslation.Description = request.Description;
                valueOptionTranslation.Language = request.Language;
                valueOptionTranslation.Name = request.Name;

                await _unitOfWork.CompleteAsync();

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
