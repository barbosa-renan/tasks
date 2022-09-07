using Application.TaskLists.Commands.CreateTaskList;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Application.IntegrationTests.TaskLists.Commands;

public class CreateTaskListTests
{
    [Fact(DisplayName = "DADO um comando vazio, QUANDO validar, DEVE retornar erro de campo obrigatório")]
    [Trait("Application", "Create - TaskList")]
    public async Task InvalidCreateCommand_TryValidate_ShouldReturnErrors()
    {
        // Arrange
        var command = new CreateTaskListCommand();

        // Act
        var result = new CreateTaskListCommandValidator().Validate(command);

        // Assert
        Assert.Equal(1, result.Errors.Count);
        Assert.Equal("Title é obrigatório.", result.Errors.FirstOrDefault().ErrorMessage);
    }

    [Fact(DisplayName = "DADO um comando com título inválido, QUANDO validar o comando, DEVE retornar erro de 256 caracteres")]
    [Trait("Application", "Create - TaskList")]
    public async Task InvalidCreateCommand_TryValidateTitle_ShouldReturnErrors()
    {
        // Arrange
        var command = new CreateTaskListCommand
        {
            //286 caracteres
            Title = "Mussum Ipsum, cacilds vidis litro abertis. Mé faiz elementum girarzis, " +
                    "nisi eros vermeio.Praesent malesuada urna nisi, quis volutpat erat hendrerit non. " +
                    "Nam vulputate dapibus.Si u mundo tá muito paradis? " +
                    "Toma um mé que o mundo vai girarzis!In elementis mé pra quem é amistosis quis leo."
        };

        // Act
        var result = new CreateTaskListCommandValidator().Validate(command);

        // Assert
        Assert.Equal(1, result.Errors.Count);
        Assert.Equal("Title pode ter até 256 caracteres.", result.Errors.FirstOrDefault().ErrorMessage);
    }
}