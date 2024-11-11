using Microsoft.AspNetCore.Diagnostics;

namespace Readio.Api.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        // if gettype exceptions
        // return true
        throw new NotImplementedException();
    }
}
