using AutoMapper;
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

namespace Build_IT_Application.ScriptInterpreter.Scripts.Commands.DeleteScript
{
    public class DeleteScriptCommand : IRequest
    {
        #region Properties

        public long Id { get; set; }
        public string CurrentUserId { get; set; }

        #endregion // Properties        
        public class Handler : IRequestHandler<DeleteScriptCommand>
        {
            #region Fields

            private readonly IScriptRepository _scriptRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
                IScriptRepository scriptRepository,
                IScriptInterpreterUnitOfWork unitOfWork)
            {
                _scriptRepository = scriptRepository;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(DeleteScriptCommand request, CancellationToken cancellationToken)
            {
                var script = await _scriptRepository.GetAsync(request.Id);

                if (script.Author != request.CurrentUserId)
                    throw new ValidationException();

                if (script == null)
                    throw new NotFoundException(nameof(Script), request.Id);

                _scriptRepository.Remove(script);
                await _unitOfWork.CompleteAsync(cancellationToken);
                
                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
