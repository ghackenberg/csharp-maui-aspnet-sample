using System.Net;

namespace CustomLib.Exceptions.Http
{
    public class UnauthorizedException : HttpException
    {
        public UnauthorizedException(string message = "Unauthorized") : base(HttpStatusCode.Unauthorized, message)
        {

        }
    }
}
