using Build_IT_Application.Exceptions;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Groups.Commands.DeleteGroup
{
    public class DeleteGroupCommand : IRequest
    {
        #region Properties

        public long Id { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<DeleteGroupCommand>
        {
            #region Fields

            private readonly IGroupRepository _groupRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
                IGroupRepository groupRepository,
                IScriptInterpreterUnitOfWork unitOfWork)
            {
                _groupRepository = groupRepository;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
            {
                var group = await _groupRepository.GetAsync(request.Id);

                if (group == null)
                    throw new NotFoundException(nameof(Group), request.Id);

                _groupRepository.Remove(group);
                await _unitOfWork.CompleteAsync(cancellationToken);

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
