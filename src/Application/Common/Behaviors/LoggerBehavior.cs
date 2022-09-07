using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviors;

public class LoggerBehavior<TRequest> : MediatR.Pipeline.IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;

    public LoggerBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        _logger.LogInformation($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} Request: {requestName}", request);
    }
}