using FluentValidation;

namespace Application.TaskItems.Queries.GetTaskItems;

public class GetTaskItemQueryValidator : AbstractValidator<GetTaskItemsQuery>
{
    public GetTaskItemQueryValidator()
    {
        RuleFor(x => x.TaskListId)
            .NotEmpty().WithMessage("TaskListId é obrigatório.");
    }
}