using AutoMapper;
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

namespace Build_IT_Application.Scripts.Scripts.Commands.CreateScript
{
    public class CreateScriptCommand : IRequest
    {
        #region Properties
        
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }
        public string Author { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }
        public Language DefaultLanguage { get; set; }

        #endregion // Properties
    }

    public class CreateScriptCommandHandler : IRequestHandler<CreateScriptCommand, Unit>
    {
        #region Fields

        private readonly IDateTime _dateTime;
        private readonly IScriptRepository _scriptRepository;
        private readonly IScriptInterpreterUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        #endregion // Fields

        #region Constructors

        public CreateScriptCommandHandler(
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

        public async Task<Unit> Handle(CreateScriptCommand request, CancellationToken cancellationToken)
        {
            var script = _mapper.Map<CreateScriptCommand, Script>(request);
            script.Added = _dateTime.Now;
            script.Modified = _dateTime.Now;
            script.Version = "1";
            await _scriptRepository.AddAsync(script);

            await _unitOfWork.CompleteAsync(cancellationToken);

            await _mediator.Publish(new ScriptCreated { Id = script.Id }, cancellationToken);

            return Unit.Value;
        }

        #endregion // Public_Methods
    }
}
