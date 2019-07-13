using AutoMapper;
using Build_IT_Application.Exceptions;
using Build_IT_CommonTools.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Enums;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.Scripts.Scripts.Commands.UpdateScript
{
    public class UpdateScriptCommand : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }
        public string Author { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public Language DefaultLanguage { get; set; }

        public class Handler : IRequestHandler<UpdateScriptCommand, Unit>
        {
            #region Fields

            private readonly IDateTime _dateTime;
            private readonly IScriptRepository _scriptRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly IMediator _mediator;

            #endregion // Fields

            #region Constructors

            public Handler(
                IDateTime dateTime,
                IScriptRepository scriptRepository,
                IScriptInterpreterUnitOfWork unitOfWork,
                IMapper mapper,
                IMediator mediator)
            {
                _dateTime = dateTime;
                _scriptRepository = scriptRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _mediator = mediator;
            }

            #endregion // Constructors
          
            #region Public_Methods
            
            public async Task<Unit> Handle(UpdateScriptCommand request, CancellationToken cancellationToken)
            {
                var script = await _scriptRepository.GetScriptWithTagsAsync(request.Id);

                if (script == null)
                    throw new NotFoundException(nameof(Script), request.Id);

                _mapper.Map<UpdateScriptCommand, Script>(request, script);
                script.Modified = _dateTime.Now;

                await _unitOfWork.CompleteAsync();

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
