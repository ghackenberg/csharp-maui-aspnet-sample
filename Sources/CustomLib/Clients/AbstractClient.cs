using CustomLib.Exceptions;
using CustomLib.Interfaces;
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

        public async Task<List<GetType>?> List()
        {
            var response = await _client.GetAsync(_base);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpException(response.StatusCode, await response.Content.ReadAsStringAsync());
            }

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<GetType>>(content, _options);
        }

        public async Task<GetType?> Post(PostType data)
        {
            var requestContentData = JsonSerializer.Serialize(data, _options);

            var requestContent = new StringContent(requestContentData, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_base, requestContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpException(response.StatusCode, await response.Content.ReadAsStringAsync());
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<GetType>(responseContent, _options);
        }

        public async Task<GetType?> Get(string id)
        {
            var response = await _client.GetAsync($"{_base}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpException(response.StatusCode, await response.Content.ReadAsStringAsync());
            }

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<GetType>(content, _options);
        }

        public async Task<GetType?> Put(string id, PutType data)
        {
            var requestContentData = JsonSerializer.Serialize(data, _options);

            var requestContent = new StringContent(requestContentData, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(_base, requestContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpException(response.StatusCode, await response.Content.ReadAsStringAsync());
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<GetType>(responseContent, _options);
        }

        public async Task<GetType?> Delete(string id)
        {
            var response = await _client.DeleteAsync($"{_base}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpException(response.StatusCode, await response.Content.ReadAsStringAsync());
            }

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<GetType>(content, _options);
        }
    }
}
