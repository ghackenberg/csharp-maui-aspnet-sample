using System.Net;

namespace CustomLib.Exceptions.Http
{
    public class NotFoundException : HttpException
    {
        public NotFoundException(string message = "Not found") : base(HttpStatusCode.NotFound, message)
        {

        }
    }
}
