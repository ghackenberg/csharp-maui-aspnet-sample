using System.Net;

namespace CustomLib.Exceptions.Http
{
    public class HttpBadRequestException : HttpException
    {
        public HttpBadRequestException(string message = "Bad request") : base(HttpStatusCode.BadRequest, message)
        {

        }
    }
}
