using AutoMapper;
using Build_IT_Application.Exceptions;
using Build_IT_Application.Mapping;
using Build_IT_Application.ScriptInterpreter.Parameters.Commands.CreateParameter;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_CommonTools.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Parameters.Commands.CopyParameters
{
    public class CopyParametersCommand : IRequest
    {
        #region Properties

        public long NewScriptId { get; set; }
        public long OldScriptId { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<CopyParametersCommand, Unit>
        {
            #region Fields

            private readonly IScriptRepository _scriptRepository;
            private readonly IParameterRepository _parameterRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            #endregion // Fields

            #region Constructors

            public Handler(
            IScriptRepository scriptRepository,
                IParameterRepository parameterRepository,
                IScriptInterpreterUnitOfWork unitOfWork,
                IMapper mapper)
            {
                _scriptRepository = scriptRepository;
                _parameterRepository = parameterRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(CopyParametersCommand request, CancellationToken cancellationToken)
            {
                var parameters = await _parameterRepository.GetAllParametersForScriptAsync(request.OldScriptId);

                var parametersResource = _mapper.Map<List<Parameter>, List<ParameterResource>>(parameters.ToList());
                var copiedParameters = _mapper.Map<List<ParameterResource>, List<Parameter>>(parametersResource);

                var script = await _scriptRepository.GetAsync(request.NewScriptId);
                if (script == null)
                    throw new NotFoundException(nameof(CopyParametersCommand), request.NewScriptId);

                script.Modified = DateTime.Now;
                copiedParameters.ForEach(p =>
                {
                    p.Id = 0;
                    p.Script = script;
                    _parameterRepository.AddAsync(p);
                });

                await _unitOfWork.CompleteAsync();

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
