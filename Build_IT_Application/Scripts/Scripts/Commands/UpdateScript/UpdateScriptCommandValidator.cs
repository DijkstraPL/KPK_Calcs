using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.Scripts.Scripts.Commands.UpdateScript
{
    public class UpdateScriptCommandValidator : AbstractValidator<UpdateScriptCommand>
    {
        #region Constructors
        
        public UpdateScriptCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty().MaximumLength(150);
            RuleFor(v => v.Description).NotEmpty().MaximumLength(1000);
            RuleFor(v => v.GroupName).MaximumLength(150);
            RuleFor(v => v.Author).MaximumLength(150);
            RuleFor(v => v.AccordingTo).MaximumLength(150);
            RuleFor(v => v.Notes).MaximumLength(1000);
            RuleFor(v => v.DefaultLanguage).NotEmpty();
        }

        #endregion // Constructors
    }
}
