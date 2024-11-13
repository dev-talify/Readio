using Microsoft.AspNetCore.Diagnostics;
using Readio.Core.Exceptions;
using Readio.Core.Model.Response;
using System.Net;

namespace Readio.Api.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var response = GetResponseForException(exception);

        httpContext.Response.StatusCode = (int)response.StatusCode;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }

    private OperationResponse GetResponseForException(Exception exception)
    {
        return exception switch
        {
            BusinessException businessException => CreateResponse(HttpStatusCode.BadRequest, businessException.Message),
            NotFoundException notFoundException => CreateResponse(HttpStatusCode.NotFound, notFoundException.Message),
            _ => CreateResponse(HttpStatusCode.InternalServerError, "Beklenmedik bir hata oluştu")
        };
    }

    
    private OperationResponse CreateResponse(HttpStatusCode statusCode, string message)
    {
        return new OperationResponse
        {
            StatusCode = statusCode,
            Message = message
        };
    }
}
