using System.Net;

namespace CustomLib.Exceptions.Http
{
    public class HttpUnauthorizedException : HttpException
    {
        public HttpUnauthorizedException(string message = "Unauthorized") : base(HttpStatusCode.Unauthorized, message)
        {

        }
    }
}
