using AutoMapper;
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

namespace Build_IT_Application.ScriptInterpreter.Translations.Commands.CreateGroupTranslationCommand
{
    public class CreateGroupTranslationCommand : IRequest
    {
        #region Properties

        public long Id { get; set; }
        public long GroupId { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<CreateGroupTranslationCommand, Unit>
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

            public async Task<Unit> Handle(CreateGroupTranslationCommand request, CancellationToken cancellationToken)
            {
                var groupTranslation = new GroupTranslation
                {
                    Id = 0,
                    GroupId = request.GroupId,
                    Name = request.Name,
                    Language = request.Language
                };

                await _translationRepository.AddGroupTranslationAsync(groupTranslation);
                await _unitOfWork.CompleteAsync();

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
