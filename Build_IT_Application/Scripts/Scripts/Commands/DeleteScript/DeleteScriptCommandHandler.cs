using AutoMapper;
using Build_IT_Application.Exceptions;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.Scripts.Scripts.Commands.DeleteScript
{
    public class DeleteScriptCommandHandler : IRequestHandler<DeleteScriptCommand>
    {
        #region Fields

        private readonly IScriptInterpreterDbContext _context;
        private readonly IScriptInterpreterUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion // Fields

        #region Constructors

        public DeleteScriptCommandHandler(IScriptInterpreterDbContext context,
            IScriptInterpreterUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion // Constructors

        #region Public_Methods
        
        public async Task<Unit> Handle(DeleteScriptCommand request, CancellationToken cancellationToken)
        {
            var script = await _context.Scripts.FindAsync(request.Id);

            if (script == null)
                throw new NotFoundException(nameof(Script), request.Id);

            _context.Scripts.Remove(script);
            await _unitOfWork.CompleteAsync(cancellationToken);

            return Unit.Value;
        }

        #endregion // Public_Methods
    }
}
