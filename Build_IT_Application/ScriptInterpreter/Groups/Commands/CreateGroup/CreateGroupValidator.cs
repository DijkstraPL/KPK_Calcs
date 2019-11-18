using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.ScriptInterpreter.Groups.Commands.CreateGroup
{
    public class CreateGroupValidator : AbstractValidator<CreateGroupCommand>
    {
        #region Constructors

        public CreateGroupValidator()
        {
            RuleFor(v => v.Id).Equal(0);
            RuleFor(v => v.Name).NotEmpty().MaximumLength(150);
            RuleFor(v => v.ScriptId).GreaterThan(0);
        }

        #endregion // Constructors
    }
}
