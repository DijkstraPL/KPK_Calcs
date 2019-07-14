using AutoMapper;
using Build_IT_Application.Exceptions;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Figures.Commands.DetachFigure
{
    public class DetachFigureCommand : IRequest
    {
        #region Properites
        
        public long ParameterId { get; set; }
        public long FigureId { get; set; }

        #endregion // Properites

        public class  Handler : IRequestHandler<DetachFigureCommand, Unit>
        {
            #region Fields

            private readonly IParameterRepository _parameterRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
                IParameterRepository parameterRepository,
                IScriptInterpreterUnitOfWork unitOfWork)
            {
                _parameterRepository = parameterRepository;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(DetachFigureCommand request, CancellationToken cancellationToken)
            {
                var parameter = await _parameterRepository.GetParameterWithAllDependanciesAsync(request.ParameterId);
                if (parameter == null)
                    throw new NotFoundException(nameof(Parameter), request.ParameterId);

                var parameterFigure = parameter.ParameterFigures.FirstOrDefault(pf => pf.FigureId == request.FigureId);

                if (parameterFigure == null)
                    throw new NotFoundException(nameof(ParameterFigure), request.FigureId);

                parameter.ParameterFigures.Remove(parameterFigure);

                await _unitOfWork.CompleteAsync();

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
