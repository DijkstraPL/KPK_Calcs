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

namespace Build_IT_Application.ScriptInterpreter.Translations.Commands.UpdateGroupTranslation
{
    public class UpdateGroupTranslationCommand : IRequest
    {
        #region Properties

        public long Id { get; set; }
        public long GroupId { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<UpdateGroupTranslationCommand, Unit>
        {
            #region Fields

            private readonly IGroupTranslationRepository _translationRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
            IGroupTranslationRepository translationRepository,
            IScriptInterpreterUnitOfWork unitOfWork)
            {
                _translationRepository = translationRepository;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(UpdateGroupTranslationCommand request, CancellationToken cancellationToken)
            {
                var groupTranslation = await _translationRepository.GetGroupTranslation(request.Id);

                if (groupTranslation == null)
                    throw new NotFoundException(nameof(UpdateGroupTranslationCommand), request.Id);

                groupTranslation.Name = request.Name;
                groupTranslation.Language = request.Language;
                groupTranslation.GroupId = request.GroupId;

                await _unitOfWork.CompleteAsync();

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
