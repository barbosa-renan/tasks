using Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.TaskLists.Commands.CreateTaskList;

public class CreateTaskListCommandValidator : AbstractValidator<CreateTaskListCommand>
{
    private readonly ITaskDbContext _context;

    public CreateTaskListCommandValidator(ITaskDbContext context)
    {
        _context = context;

        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title é obrigatório.")
            .MaximumLength(256).WithMessage("Title pode ter até 256 caracteres.")
            .MustAsync(BeUniqueTitle).WithMessage("Já existe uma task com o mesmo nome");
    }

    public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
    {
        return await _context.TaskLists
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
