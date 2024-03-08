using System.Net;

namespace CustomLib.Exceptions.Http
{
    public class HttpNotFoundException : HttpException
    {
        public HttpNotFoundException(string message = "Not found") : base(HttpStatusCode.NotFound, message)
        {

        }
    }
}
