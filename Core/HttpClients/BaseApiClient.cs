using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.HttpClients
{
    public abstract class BaseApiClient
    {
        private readonly HttpClient _client;
        public BaseApiClient(string baseUrl)
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        protected async Task<ApiResponse<T>> GetAsync<T>(string url)
        {
            var requestUrl = $"{_client.BaseAddress}/{url}";

            var result = await _client.GetAsync(requestUrl);

            return JsonConvert.DeserializeObject<ApiResponse<T>>(await result.Content.ReadAsStringAsync());
        }


        protected async Task<ApiResponse> PostAsync(string url, object body)
        {
            var requestUrl = $"{_client.BaseAddress}/{url}";

            var result = await _client.PostAsync(requestUrl, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<ApiResponse>(await result.Content.ReadAsStringAsync());
        }

        protected async Task<ApiResponse<T>> PostAsync<T>(string url, object body)
        {
            var requestUrl = $"{_client.BaseAddress}/{url}";

            var result = await _client.PostAsync(requestUrl, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<ApiResponse<T>>(await result.Content.ReadAsStringAsync());
        }

        protected async Task<ApiResponse> PutAsync(string url, object body)
        {
            var requestUrl = $"{_client.BaseAddress}/{url}";

            var result = await _client.PutAsync(requestUrl, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<ApiResponse>(await result.Content.ReadAsStringAsync());
        }

        protected async Task<ApiResponse<T>> PutAsync<T>(string url, object body)
        {
            var requestUrl = $"{_client.BaseAddress}/{url}";

            var result = await _client.PutAsync(requestUrl, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<ApiResponse<T>>(await result.Content.ReadAsStringAsync());
        }
    }
}
