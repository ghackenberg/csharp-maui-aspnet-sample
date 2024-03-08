using System.Net;

namespace CustomLib.Exceptions.Http
{
    public class BadRequestException : HttpException
    {
        public BadRequestException(string message = "Bad request") : base(HttpStatusCode.BadRequest, message)
        {

        }
    }
}
