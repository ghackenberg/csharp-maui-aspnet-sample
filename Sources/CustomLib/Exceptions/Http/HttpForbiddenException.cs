using System.Net;

namespace CustomLib.Exceptions.Http
{
    public class HttpForbiddenException : HttpException
    {
        public HttpForbiddenException(string message = "Forbidden") : base(HttpStatusCode.Forbidden, message)
        {

        }
    }
}
