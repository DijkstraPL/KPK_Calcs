using AutoMapper;
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

namespace Build_IT_Application.ScriptInterpreter.Translations.Commands.UpdateParameterTranslation
{
    public class UpdateParameterTranslationCommand : IRequest
    {
        #region Properties

        public long Id { get; set; }
        public long ParameterId { get; set; }
        public Language Language { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string GroupName { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<UpdateParameterTranslationCommand, Unit>
        {
            #region Fields

            private readonly IParameterTranslationRepository _translationRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
            IParameterTranslationRepository translationRepository,
            IScriptInterpreterUnitOfWork unitOfWork)
            {
                _translationRepository = translationRepository;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(UpdateParameterTranslationCommand request, CancellationToken cancellationToken)
            {
                var parameterTranslation = await _translationRepository.GetParameterTranslation(request.Id);

                if (parameterTranslation == null)
                    throw new NotFoundException(nameof(UpdateParameterTranslationCommand), request.Id);

                parameterTranslation.Description = request.Description;
                parameterTranslation.GroupName = request.GroupName;
                parameterTranslation.Language = request.Language;
                parameterTranslation.Notes = request.Notes;
                parameterTranslation.ParameterId = request.ParameterId;

                await _unitOfWork.CompleteAsync();

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
