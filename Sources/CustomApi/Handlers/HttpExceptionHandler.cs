using CustomLib.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace CustomApi.Handlers
{
    /// <summary>
    /// Converts HTTP exceptions into corresponding HTTP responses.
    /// </summary>
    public class HttpExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken
        )
        {
            // Step 1: Filter HTTP exceptions

            if (exception is not HttpException)
            {
                return false;
            }

            // Step 2: Convert HTTP exception to HTTP response

            var httpException = (HttpException)exception;

            httpContext.Response.StatusCode = httpException.StatusCode;

            await httpContext.Response.WriteAsync(exception.Message);

            return true;
        }
    }
}
