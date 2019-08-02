using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.ScriptInterpreter.Parameters.Commands.CreateParameter
{
    public class CreateParameterValidator : AbstractValidator<CreateParameterCommand>
    {
        #region Constructors

        public CreateParameterValidator()
        {
            RuleFor(v => v.Id).Equal(0);
            RuleFor(v => v.Name).NotEmpty().MaximumLength(20);
            RuleFor(v => v.Number).GreaterThanOrEqualTo(0);
            RuleFor(v => v.ValueType).Must(vt => vt >= 0);
            RuleFor(v => v.Description).MaximumLength(1000);
            RuleFor(v => v.GroupName).MaximumLength(150);
            RuleFor(v => v.Context).NotEmpty();
            RuleFor(v => v.AccordingTo).MaximumLength(150);
            RuleFor(v => v.Notes).MaximumLength(1000);
        }

        #endregion // Constructors
    }
}
