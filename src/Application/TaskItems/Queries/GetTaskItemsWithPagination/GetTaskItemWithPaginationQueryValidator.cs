using FluentValidation;

namespace Application.TaskItems.Queries.GetTaskItemsWithPagination;

public class GetTaskItemWithPaginationQueryValidator : AbstractValidator<GetTaskItemsWithPaginationQuery>
{
    public GetTaskItemWithPaginationQueryValidator()
    {
        RuleFor(x => x.TaskListId)
            .NotEmpty().WithMessage("TaskListId é obrigatório.");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber precisa ser maior que 0 (zero).");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize precisa ser maior que 0 (zero).");
    }
}