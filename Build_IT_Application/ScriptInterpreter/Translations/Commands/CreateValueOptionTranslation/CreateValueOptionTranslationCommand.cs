using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_Data.Entities.Scripts.Translations;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Translations.Commands.CreateValueOptionTranslation
{
    public class CreateValueOptionTranslationCommand : IRequest
    {
        #region Properties

        public long Id { get; set; }
        public long ValueOptionId { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #endregion // Properties
        public class Handler : IRequestHandler<CreateValueOptionTranslationCommand, Unit>
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

            public async Task<Unit> Handle(CreateValueOptionTranslationCommand request, CancellationToken cancellationToken)
            {
                var valueOptionTranslation = new ValueOptionTranslation
                {
                    Id = 0,
                    ValueOptionId = request.ValueOptionId,
                    Description = request.Description,
                    Language = request.Language,
                    Name = request.Name
                };

                await _translationRepository.AddValueOptionTranslationAsync(valueOptionTranslation);
                await _unitOfWork.CompleteAsync();

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
