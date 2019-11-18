using Build_IT_Application.Exceptions;
using Build_IT_Application.Mapping;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_CommonTools.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommand : IRequest
    {
        #region Properties

        public long ScriptId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string VisibilityValidator { get; set; }
       
        #endregion // Properties

        public class Handler : IRequestHandler<UpdateGroupCommand, Unit>
        {
            #region Fields

            private readonly IScriptRepository _scriptRepository;
            private readonly IGroupRepository _groupRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;
            private readonly IScriptMappingProfile _scriptMappingProfile;
            private readonly IDateTime _dateTime;

            #endregion // Fields

            #region Constructors

            public Handler(
                IScriptRepository scriptRepository,
                IGroupRepository groupRepository,
                IScriptInterpreterUnitOfWork unitOfWork,
                IScriptMappingProfile scriptMappingProfile,
                IDateTime dateTime)
            {
                _scriptRepository = scriptRepository;
                _groupRepository = groupRepository;
                _unitOfWork = unitOfWork;
                _dateTime = dateTime;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
            {
                var script = await _scriptRepository.GetAsync(request.ScriptId);
                var group = await _groupRepository.GetAsync(request.Id);

                if (script == null || group == null)
                    throw new NotFoundException(nameof(Group), request.Id);

                group.Name = request.Name;
                group.VisibilityValidator = request.VisibilityValidator;
                group.ScriptId = request.ScriptId;

                script.Modified = _dateTime.Now;

                await _unitOfWork.CompleteAsync();

                return MediatR.Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
