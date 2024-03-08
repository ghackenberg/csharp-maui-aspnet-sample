using CustomLib.Exceptions;
using CustomLib.Exceptions.Http;
using CustomLib.Interfaces;
using System.Net;
using System.Text;
using System.Text.Json;

namespace CustomLib.Clients
{
    public abstract class AbstractClient<GetType, PostType, PutType> : AbstractInterface<GetType, PostType, PutType>
    {
        private string _base;

        private HttpClient _client;

        private JsonSerializerOptions _options;

        public AbstractClient(string prefix)
        {
            _base = $"{Constants.BASE}/{prefix}";

            _client = new HttpClient();

            _options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<GetType>> List()
        {
            var response = await _client.GetAsync(_base);

            return await Parse<List<GetType>>(response);
        }

        public async Task<GetType> Post(PostType data)
        {
            var requestContentData = JsonSerializer.Serialize(data, _options);

            var requestContent = new StringContent(requestContentData, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_base, requestContent);

            return await Parse<GetType>(response);
        }

        public async Task<GetType> Get(string id)
        {
            var response = await _client.GetAsync($"{_base}/{id}");

            return await Parse<GetType>(response);
        }

        public async Task<GetType> Put(string id, PutType data)
        {
            var requestContentData = JsonSerializer.Serialize(data, _options);

            var requestContent = new StringContent(requestContentData, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(_base, requestContent);

            return await Parse<GetType>(response);
        }

        public async Task<GetType> Delete(string id)
        {
            var response = await _client.DeleteAsync($"{_base}/{id}");

            return await Parse<GetType>(response);
        }

        private async Task<T> Parse<T>(HttpResponseMessage response)
        {
            // Check HTTP response status code

            if (!response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();

                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        throw new HttpBadRequestException(message);
                    case HttpStatusCode.Forbidden:
                        throw new HttpForbiddenException(message);
                    case HttpStatusCode.NotFound:
                        throw new HttpNotFoundException(message);
                    case HttpStatusCode.Unauthorized:
                        throw new HttpUnauthorizedException(message);
                    default:
                        throw new HttpException(response.StatusCode, message);
                }
            }

            // Deserialize HTTP response body content

            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<T>(responseContent, _options);

            // Check deserialized object

            if (result == null)
            {
                throw new ParseException();
            }

            // Return deserialized object

            return result;
        }
    }
}
