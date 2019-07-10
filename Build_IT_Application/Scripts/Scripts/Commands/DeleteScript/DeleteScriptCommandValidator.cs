using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.Scripts.Scripts.Commands.DeleteScript
{
    public class DeleteScriptCommandValidator : AbstractValidator<DeleteScriptCommand>
    {
        #region Constructors

        public DeleteScriptCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .GreaterThan(0);
        }

        #endregion // Constructors
    }
}
