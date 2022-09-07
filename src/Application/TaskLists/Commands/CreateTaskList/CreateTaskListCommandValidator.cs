using Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.TaskLists.Commands.CreateTaskList;

public class CreateTaskListCommandValidator : AbstractValidator<CreateTaskListCommand>
{
    public CreateTaskListCommandValidator()
    {
        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title é obrigatório.")
            .MaximumLength(256).WithMessage("Title pode ter até 256 caracteres.");
    }
}
