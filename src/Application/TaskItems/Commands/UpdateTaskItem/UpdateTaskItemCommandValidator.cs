using FluentValidation;

namespace Application.TaskItems.Commands.UpdateTaskItem;

public class UpdateTaskItemCommandValidator : AbstractValidator<UpdateTaskItemCommand>
{
    public UpdateTaskItemCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(256)
            .NotEmpty();
    }
}