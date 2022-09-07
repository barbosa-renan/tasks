using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;

public class TaskDbContextInitializer
{
    private readonly ILogger<TaskDbContextInitializer> _logger;
    private readonly TaskDbContext _context;

    public TaskDbContextInitializer(ILogger<TaskDbContextInitializer> logger, 
                                    TaskDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitializeAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro ao inicializar o database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro ao realizar o processo de seeding no database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Seed, if necessary
        if (!_context.TaskLists.Any())
        {
            _context.TaskLists.Add(new TaskList
            {
                Title = "Task List",
                Items =
                {
                    new TaskItem { Title = "Criar uma lista de tarefas 📃" },
                    new TaskItem { Title = "Concluir a primeira tarefa ✅" },
                    new TaskItem { Title = "Você já fez duas coisas na sua lista! 🤯"},
                    new TaskItem { Title = "Uau! Você foi longe, faça uam pausa para descanso agora! 🏆" },
                }
            });

            await _context.SaveChangesAsync();
        }
    }
}