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

namespace Build_IT_Application.ScriptInterpreter.Parameters.Commands.CreateParameter
{
    public class CreateParameterCommand : IRequest
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
        public ICollection<ValueOptionResource> ValueOptions { get; set; }
        public ValueOptionSettings ValueOptionSetting { get; set; }
        public ParameterOptions Context { get; set; }
        public long? GroupId { get; set; }
        public string AccordingTo { get; set; }
        public string Notes { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<CreateParameterCommand, Unit>
        {
            #region Fields

            private readonly IScriptRepository _scriptRepository;
            private readonly IParameterRepository _parameterRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;
            private readonly IScriptMappingProfile _scriptMappingProfile;
            private readonly IDateTime _dateTime;

            #endregion // Fields

            #region Constructors

            public Handler(
            IScriptRepository scriptRepository,
                IParameterRepository parameterRepository,
                IScriptInterpreterUnitOfWork unitOfWork,
                IScriptMappingProfile scriptMappingProfile,
                IDateTime dateTime)
            {
                _scriptRepository = scriptRepository;
                _parameterRepository =  parameterRepository;
                _unitOfWork = unitOfWork;
                _scriptMappingProfile = scriptMappingProfile;
                _dateTime = dateTime;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(CreateParameterCommand request, CancellationToken cancellationToken)
            {
                var parameter = new Parameter
                {
                    Id = 0,
                    ScriptId = request.ScriptId,
                    Name = request.Name,
                    Number = request.Number,
                    Description = request.Description,
                    ValueType = request.ValueType,
                    Value = request.Value,
                    VisibilityValidator = request.VisibilityValidator,
                    DataValidator = request.DataValidator,
                    Unit = request.Unit,
                    ValueOptionSetting = request.ValueOptionSetting,
                    Context = request.Context,
                    AccordingTo = request.AccordingTo,
                    Notes = request.Notes,
                    GroupId = request.GroupId,
                };

                _scriptMappingProfile.UpdateValueOptions(request.ValueOptions, parameter);
                _scriptMappingProfile.RemoveNotAddedValueOptions(request.ValueOptions, parameter);
                _scriptMappingProfile.AddNewValueOptions(request.ValueOptions, parameter);

                var script = await _scriptRepository.GetAsync(request.ScriptId);
                if (script == null)
                    throw new NotFoundException(nameof(CreateParameterCommand), request.ScriptId);
                script.Modified = _dateTime.Now;

                await _parameterRepository.AddAsync(parameter);

                await _unitOfWork.CompleteAsync(cancellationToken);

                return MediatR.Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
