using CustomLib.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace CustomApi.Handlers
{
    internal sealed class HttpExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not HttpException)
            {
                return false;
            }

            var httpException = (HttpException)exception;

            httpContext.Response.StatusCode = httpException.StatusCode;

            await httpContext.Response.WriteAsync(exception.Message);

            return true;
        }
    }
}
