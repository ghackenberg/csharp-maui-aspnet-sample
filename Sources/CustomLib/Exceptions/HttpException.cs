using System.Net;

namespace CustomLib.Exceptions
{
    public class HttpException : Exception
    {
        public int StatusCode { get; private set; }

        public HttpException(int statusCode, string? message) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpException(HttpStatusCode statusCode, string? message) : this((int)statusCode, message) { }
    }
}
