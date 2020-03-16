using System;
using System.Net.Http;
using System.Threading.Tasks;
using MoviesFinderApp.Core.Service.Interfaces;
using Newtonsoft.Json;

namespace MoviesFinderApp.Core.Service
{
    public class ApiService : IApiService
    {
        HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient(); //Can pass an option handler may be for runtime authorization
        }

        public Task<TResponse> Delete<TRequest, TResponse>(string url, TRequest request, string[] headers = null)
        {
            throw new NotImplementedException();
        }

        public async Task<TResponse> Get<TResponse>(string url, string[] headers = null)
        {
            try
            {
                var httpResponseMessage = await _httpClient.GetAsync(url);
                if (httpResponseMessage == null)
                    return default;
                httpResponseMessage.EnsureSuccessStatusCode();
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<TResponse>(content);
                return response;
            }
            catch(HttpRequestException hex)
            {
                //log exception here
                throw;
            }
            catch (Exception ex)
            {
                //log unknow exception
                throw;
            }
        }

        public async Task<TResponse> Post<TRequest, TResponse>(string url, TRequest request, string[] headers = null)
        {
            try
            {
                var jsonString = JsonConvert.SerializeObject(request);
                var httpContent = new StringContent(jsonString, encoding: System.Text.Encoding.UTF8);
                var httpResponseMessage = await _httpClient.PostAsync(url, httpContent);
                if (httpResponseMessage == null)
                    return default;
                httpResponseMessage.EnsureSuccessStatusCode();
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<TResponse>(content);
                return response;
            }
            catch (HttpRequestException hex)
            {
                //log exception here
                throw;
            }
            catch (Exception ex)
            {
                //log unknow exception
                throw;
            }
        }

        public Task<TResponse> Put<TRequest, TResponse>(string url, TRequest request, string[] headers = null)
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> DownloadAsync(string url)
        {

            Task<byte[]> contentsTask = _httpClient.GetByteArrayAsync(url);

            // await! control returns to the caller and the task continues to run on another thread
            var contents = await contentsTask;
            return contents;
        }
    }
}
