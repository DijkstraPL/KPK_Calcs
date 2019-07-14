using Build_IT_Data.Entities.Scripts.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.ScriptInterpreter.Scripts.Commands.CreateScript
{
    public class CreateScriptCommandValidator : AbstractValidator<CreateScriptCommand>
    {
        #region Constructors
        
        public CreateScriptCommandValidator()
        {
            RuleFor(v => v.Id).Equal(0);
            RuleFor(v => v.Name).NotEmpty().MaximumLength(150);
            RuleFor(v => v.Description).NotEmpty().MaximumLength(1000);
            RuleFor(v => v.GroupName).MaximumLength(150);
            RuleFor(v => v.Author).MaximumLength(150);
            RuleFor(v => v.AccordingTo).MaximumLength(150);
            RuleFor(v => v.Notes).MaximumLength(1000);
            RuleFor(v => v.DefaultLanguage).Must(language => language >= 0);
        }

        #endregion // Constructors
    }
}
