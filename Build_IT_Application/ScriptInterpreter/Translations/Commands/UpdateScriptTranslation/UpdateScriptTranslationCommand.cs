using AutoMapper;
using Build_IT_Application.Exceptions;
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

namespace Build_IT_Application.ScriptInterpreter.Translations.Commands.UpdateScriptTranslation
{
    public class UpdateScriptTranslationCommand : IRequest
    {
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ScriptId { get; set; }
        public string Notes { get; set; }
        public Language Language { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<UpdateScriptTranslationCommand, Unit>
        {
            #region Fields

            private readonly IScriptTranslationRepository _translationRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
            IScriptTranslationRepository translationRepository,
            IScriptInterpreterUnitOfWork unitOfWork)
            {
                _translationRepository = translationRepository;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(UpdateScriptTranslationCommand request, CancellationToken cancellationToken)
            {
                var scriptTranslation = await _translationRepository.GetScriptTranslation(request.Id);

                if (scriptTranslation == null)
                    throw new NotFoundException(nameof(UpdateScriptTranslationCommand), request.Id);

                scriptTranslation.Name = request.Name;
                scriptTranslation.Description = request.Description;
                scriptTranslation.ScriptId = request.ScriptId;
                scriptTranslation.Notes = request.Notes;
                scriptTranslation.Language = request.Language;

                await _unitOfWork.CompleteAsync();

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
