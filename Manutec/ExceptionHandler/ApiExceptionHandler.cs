using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Manutec.Api.ExceptionHandler;

public class ApiExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var detailsDefault = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Server Error"
        };

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(detailsDefault, cancellationToken);

        return true;
    }
}
