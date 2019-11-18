using Build_IT_Application.ScriptInterpreter.Groups.Commands.UpdateGroup;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.ScriptInterpreter.Groups.Commands.UpdateGroup
{
    class UpdateGroupValidator : AbstractValidator<UpdateGroupCommand>
    {
        #region Constructors

        public UpdateGroupValidator()
        {
            RuleFor(v => v.Id).Equal(0);
            RuleFor(v => v.Name).NotEmpty().MaximumLength(150);
            RuleFor(v => v.ScriptId).GreaterThan(0);
        }

        #endregion // Constructors
    }
}
