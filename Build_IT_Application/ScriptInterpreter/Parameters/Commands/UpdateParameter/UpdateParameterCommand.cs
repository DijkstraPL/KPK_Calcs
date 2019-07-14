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

namespace Build_IT_Application.ScriptInterpreter.Parameters.Commands.UpdateParameter
{
    public class UpdateParameterCommand : IRequest
    {
        #region Properties

        public long Id { get; set; }
        public long ScriptId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public ValueTypes ValueType { get; set; }
        public string Value { get; set; }
        public string VisibilityValidator { get; set; }
        public string DataValidator { get; set; }
        public string Unit { get; set; }
        public ICollection<UpdateValueOptionsCommand> ValueOptions { get; set; }
        public ValueOptionSettings ValueOptionSetting { get; set; }
        public ParameterOptions Context { get; set; }
        public string GroupName { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<UpdateParameterCommand, Unit>
        {
            #region Fields

            private readonly IScriptRepository _scriptRepository;
            private readonly IParameterRepository _parameterRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;
            private readonly IDateTime _dateTime;

            #endregion // Fields

            #region Constructors

            public Handler(
            IScriptRepository scriptRepository,
                IParameterRepository parameterRepository,
                IScriptInterpreterUnitOfWork unitOfWork,
                IDateTime dateTime)
            {
                _scriptRepository = scriptRepository;
                _parameterRepository = parameterRepository;
                _unitOfWork = unitOfWork;
                _dateTime = dateTime;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(UpdateParameterCommand request, CancellationToken cancellationToken)
            {
                var script = await _scriptRepository.GetAsync(request.ScriptId);
                var parameter = await _parameterRepository.GetParameterWithAllDependanciesAsync(request.Id);

                if (script == null || parameter == null)
                    throw new NotFoundException(nameof(Parameter), request.Id);

                parameter.Name = request.Name;
                parameter.Number = request.Number;
                parameter.Description = request.Description;
                parameter.ValueType = request.ValueType;
                parameter.Value = request.Value;
                parameter.VisibilityValidator = request.VisibilityValidator;
                parameter.DataValidator = request.DataValidator;
                parameter.Unit = request.Unit;
                parameter.ValueOptionSetting = request.ValueOptionSetting;
                parameter.Context = request.Context;
                parameter.GroupName = request.GroupName;
                parameter.AccordingTo = request.AccordingTo;
                parameter.Notes = request.Notes;

                script.Modified = DateTime.Now;

                await _unitOfWork.CompleteAsync();

                return MediatR.Unit.Value;
            }

            #endregion // Public_Methods
        }
    }

    public class UpdateValueOptionsCommand
    {
        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        #endregion // Properties
    }
}
