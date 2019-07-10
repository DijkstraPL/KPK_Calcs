using AutoMapper;
using Build_IT_CommonTools.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.Scripts.Scripts.Commands.CreateScript
{
    //public class CreateScriptCommandHandler : IRequestHandler<CreateScriptCommand, Unit>
    //{
    //    #region Fields

    //    private readonly IDateTime _dateTime;
    //    private readonly IScriptInterpreterDbContext _context;
    //    private readonly IScriptInterpreterUnitOfWork _unitOfWork;
    //    private readonly IMapper _mapper;
    //    private readonly IMediator _mediator;

    //    #endregion // Fields

    //    #region Constructors

    //    public CreateScriptCommandHandler(IDateTime  dateTime,IScriptInterpreterDbContext context,
    //        IScriptInterpreterUnitOfWork unitOfWork,
    //        IMapper mapper, IMediator mediator)
    //    {
    //        _dateTime = dateTime;
    //        _context = context;
    //        _unitOfWork = unitOfWork;
    //        _mapper = mapper;
    //        _mediator = mediator;
    //    }

    //    #endregion // Constructors

    //    #region Public_Methods
        
    //    public async Task<Unit> Handle(CreateScriptCommand request, CancellationToken cancellationToken)
    //    {
    //        var script = _mapper.Map<CreateScriptCommand, Script>(request);
    //        script.Added = _dateTime.Now;
    //        script.Modified = _dateTime.Now;
    //        script.Version = "1";
    //        _context.Scripts.Add(script);

    //        await _unitOfWork.CompleteAsync(cancellationToken);

    //        await _mediator.Publish(new ScriptCreated { Id = script.Id }, cancellationToken);

    //        return Unit.Value;
    //    }

    //    #endregion // Public_Methods
    //}
}
