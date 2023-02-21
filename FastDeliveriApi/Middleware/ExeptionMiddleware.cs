using FastDeliveriApi.Exceptions;
using Newtonsoft.Json;

namespace FastDeliveriApi.Middleware;

public class ExeptionMiddleware
{
    private readonly RequestDelegate _next;

    private readonly ILogger<ExeptionMiddleware> _logger;

    public ExeptionMiddleware(RequestDelegate next, ILogger<ExeptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContent context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Somenting went grong while processing {context.Request.Path}");
            await HandleExeptionAsync(context, ex);
        }
    }

    private Task HandleExeptionAsync(HttpContext Context, Exception ex)
    {
        Context.Response.ContentType = "application/json";
        HttpStatusCode statusCode = HttpStatuCode.InternalServerError;
        var errorDetails = new ErrorDetails
        {
            ErrorType = "Failure",
            ErrorMessage = ex.Message
        };

        switch (ex)
        {
            case NotFoundException notFoundException:
            statusCode = HttpStatusCode.NotFound;
            errorDetails.ErrorType = "Not Faund";
            break;

            case BadRequestException badRequestException:
            statusCode = HttpStatusCode.BadRequest;
            errorDetails.ErrorType = "Bad Request";
            break;

            case CreditLimitException creditLimitException:
            statusCode = HttpStatusCode.BadRequest;
            errorDetails.ErrorType = "Bad Request";
            break;

            default:
            break;
        }

        string response = JsonConvert.SerializeObject(errorDetails);
        context.Response.statusCode = (int)statusCode;
        return context.Response.WriteAsync(response);

    }
    public class ErrorDetails
    {
        public string? ErrorType { get; set;}
        public string? ErrorMessage { get; set;}
    }
}