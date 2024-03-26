using CustomLib.Exceptions;
using CustomLib.Exceptions.Http;
using CustomLib.Interfaces;
using System.Net;
using System.Text;
using System.Text.Json;

namespace CustomSdk.Clients
{
    public abstract class AbstractClient<GetType, QueryType, PostType, PutType> : AbstractInterface<GetType, QueryType, PostType, PutType>
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

        /// <summary>
        /// List all objects, which have been created and not deleted.
        /// </summary>
        /// <param name="data">The query data.</param>
        /// <returns>The objects.</returns>
        public async Task<List<GetType>> List(QueryType query)
        {
            var queryString = (query == null ? "" : query.ToString());

            // Send HTTP request and recieve HTTP response

            var response = await _client.GetAsync($"{_base}?{queryString}");

            // Parse HTTP response

            return await Parse<List<GetType>>(response);
        }

        /// <summary>
        /// Create a new object.
        /// </summary>
        /// <param name="data">The new object data.</param>
        /// <returns>The new object.</returns>
        public async Task<GetType> Post(PostType data)
        {
            // Send HTTP request and recieve HTTP response

            var requestContentData = JsonSerializer.Serialize(data, _options);

            var requestContent = new StringContent(requestContentData, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_base, requestContent);

            // Parse HTTP response

            return await Parse<GetType>(response);
        }

        /// <summary>
        /// Get an existing object.
        /// </summary>
        /// <param name="id">The existing object ID.</param>
        /// <returns>The existing object.</returns>
        public async Task<GetType> Get(string id)
        {
            // Send HTTP request and recieve HTTP response

            var response = await _client.GetAsync($"{_base}/{id}");

            // Parse HTTP response

            return await Parse<GetType>(response);
        }

        /// <summary>
        /// Update an existing object.
        /// </summary>
        /// <param name="id">The existing object ID.</param>
        /// <param name="data">The updated object data.</param>
        /// <returns>The updated object.</returns>
        public async Task<GetType> Put(string id, PutType data)
        {
            // Send HTTP request and recieve HTTP response

            var requestContentData = JsonSerializer.Serialize(data, _options);

            var requestContent = new StringContent(requestContentData, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"{_base}/{id}", requestContent);

            // Parse HTTP response

            return await Parse<GetType>(response);
        }

        /// <summary>
        /// Delete an existing object.
        /// </summary>
        /// <param name="id">The existing object ID.</param>
        /// <returns>The deleted object.</returns>
        public async Task<GetType> Delete(string id)
        {
            // Send HTTP request and recieve HTTP response

            var response = await _client.DeleteAsync($"{_base}/{id}");

            // Parse HTTP response

            return await Parse<GetType>(response);
        }

        /// <summary>
        /// Check the HTTP response status code and parse the HTTP response body content.
        /// </summary>
        /// <typeparam name="T">The C# type of the HTTP response body content.</typeparam>
        /// <param name="response">The HTTP response object.</param>
        /// <returns>The parsed HTTP response body content.</returns>
        /// <exception cref="BadRequestException">The HTTP response status code 400 was returned.</exception>
        /// <exception cref="UnauthorizedException">The HTTP response status code 401 was returned.</exception>
        /// <exception cref="ForbiddenException">The HTTP response status code 403 was returned.</exception>
        /// <exception cref="NotFoundException">The HTTP response status code 404 was returned.</exception>
        /// <exception cref="HttpException">Another HTTP response status code was returned.</exception>
        /// <exception cref="ParseException">The HTTP response body content could not be parsed.</exception>
        private async Task<T> Parse<T>(HttpResponseMessage response)
        {
            // Check HTTP response status code

            if (!response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();

                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        throw new BadRequestException(message);
                    case HttpStatusCode.Forbidden:
                        throw new ForbiddenException(message);
                    case HttpStatusCode.NotFound:
                        throw new NotFoundException(message);
                    case HttpStatusCode.Unauthorized:
                        throw new UnauthorizedException(message);
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
