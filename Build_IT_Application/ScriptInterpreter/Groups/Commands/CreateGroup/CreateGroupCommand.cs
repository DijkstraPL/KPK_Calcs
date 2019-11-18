using Build_IT_Application.Exceptions;
using Build_IT_Application.Mapping;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_CommonTools.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Groups.Commands.CreateGroup
{
    public class CreateGroupCommand : IRequest
    {
        #region Properties
        
        public long Id { get; set; }
        public long ScriptId { get; set; }
        public string Name { get; set; }
        public string VisibilityValidator { get; set; }
        public ICollection<ParameterResource> Parameters { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<CreateGroupCommand, Unit>
        {
            #region Fields

            private readonly IGroupRepository _groupRepository;
            private readonly IScriptRepository _scriptRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;
            private readonly IDateTime _dateTime;

            #endregion // Fields

            #region Constructors

            public Handler(
                IGroupRepository groupRepository,
                IScriptRepository scriptRepository,
                IScriptInterpreterUnitOfWork unitOfWork,
                IDateTime dateTime)
            {
                _groupRepository = groupRepository;
                _scriptRepository = scriptRepository;
                _unitOfWork = unitOfWork;
                _dateTime = dateTime;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
            {
                var group = new Group
                {
                    Id = 0,
                    ScriptId = request.ScriptId,
                    Name = request.Name,
                    VisibilityValidator = request.VisibilityValidator                  
                };

                var script = await _scriptRepository.GetAsync(request.ScriptId);
                if (script == null)
                    throw new NotFoundException(nameof(CreateGroupCommand), request.ScriptId);
                script.Modified = _dateTime.Now;

                await _groupRepository.AddAsync(group);

                await _unitOfWork.CompleteAsync(cancellationToken);

                return MediatR.Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
