using FluentValidation;

namespace Application.TaskItems.Commands.CreateTaskItem;

public class CreateTaskItemCommandValidator : AbstractValidator<CreateTaskItemCommand>
{
    public CreateTaskItemCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(256)
            .NotEmpty();
    }
}