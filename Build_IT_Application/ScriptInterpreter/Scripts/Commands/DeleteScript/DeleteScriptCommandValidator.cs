using FluentValidation;

namespace Build_IT_Application.ScriptInterpreter.Scripts.Commands.DeleteScript
{
    public class DeleteScriptCommandValidator : AbstractValidator<DeleteScriptCommand>
    {
        #region Constructors

        public DeleteScriptCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0);
        }

        #endregion // Constructors
    }
}
