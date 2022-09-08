# Tasks API

Projeto de Web API construída em .NET 6 seguindo os princípios do [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html). Esta solução serve de exemplo para demonstrar a integração de CI/CD com Azure.

![The Clean Architecture](https://blog.cleancoder.com/uncle-bob/images/2012-08-13-the-clean-architecture/CleanArchitecture.jpg)

## Tecnologias utilizadas
- [ASP.NET Core 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
- [Entity Framework Core 6](https://docs.microsoft.com/en-us/ef/core/)
- [MediatR](https://github.com/jbogard/MediatR)
- [Fluent Validation](https://docs.fluentvalidation.net/en/latest/)
- [XUnit](https://xunit.net/)
- [Swagger / Open API](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-6.0)

## Como utilizar

**Visual Studio support**
- Visual Studio 2022 (v17.3)
- Visual Studio 2022 for Mac (v17.0 latest preview)

**.NET 6**
- Última versão do SDK do [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

Você também pode rodar esta solução no [VS Code (Windows, Linux ou MacOS)](https://code.visualstudio.com/).

Para saber mais sobre como realizar a configuração do ambiente de desenvolvimento, por gentileza visite [Microsoft .NET Download Guide](https://www.microsoft.com/net/download).

## Arquitetura

### API
Projeto do tipo Web API que expõe os endpoints para que usuários/sistemas possam utilizar as operações da aplicação. Depende do projeto de Application e Infrastructure, porém a referência a Infrastructure é somente para suporte a injeção de dependência.

### Application
Projeto do tipo Class Library que possui a lógica da aplicação e interfaces que são implementadas por camadas externas. Tem referência da camada de Domain mas não depende de nenhuma outra camada do projeto.

### Domain
Projeto do tipo Class Library. Responsável por centralizar o core do projeto com entidades que representam o nosso negócio, enums, exceptions, interfaces e regras de domínio.

### Infrastucture
Projeto do tipo Calss Library responsável por acessar recursos extenos a aplicação, persistência de dados e integração com outros sistemas.

## Give a Star! :star:

Se você gostou deste projeto ou se de alguma forma te ajudou ou inspirou, por favor dê uma estrela ok?
