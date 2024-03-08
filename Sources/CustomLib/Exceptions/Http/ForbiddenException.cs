using System.Net;

namespace CustomLib.Exceptions.Http
{
    public class ForbiddenException : HttpException
    {
        public ForbiddenException(string message = "Forbidden") : base(HttpStatusCode.Forbidden, message)
        {

        }
    }
}
