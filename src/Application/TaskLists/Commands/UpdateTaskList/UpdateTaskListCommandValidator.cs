using Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.TaskLists.Commands.UpdateTaskList;

public class UpdateTaskListCommandValidator : AbstractValidator<UpdateTaskListCommand>
{
    private readonly ITaskDbContext _context;

    public UpdateTaskListCommandValidator(ITaskDbContext context)
    {
        _context = context;

        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title é obrigatório.")
            .MaximumLength(256).WithMessage("Title pode ter no máximo 256 caracteres.")
            .MustAsync(BeUniqueTitle).WithMessage("Já existe uma task com este nome.");
    }

    public async Task<bool> BeUniqueTitle(UpdateTaskListCommand model, string title, CancellationToken cancellationToken)
    {
        return await _context.TaskLists
            .Where(l => l.Id != model.Id)
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}