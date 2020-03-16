using System;
using System.Threading.Tasks;

namespace MoviesFinderApp.Core.Service.Interfaces
{
    public interface IApiService
    {
        Task<TResponse> Get<TResponse>(string url, string[] headers = null);

        Task<TResponse> Post<TRequest,TResponse>(string url, TRequest request,  string[] headers = null);

        Task<TResponse> Put<TRequest, TResponse>(string url, TRequest request, string[] headers = null);

        Task<TResponse> Delete<TRequest, TResponse>(string url, TRequest request, string[] headers = null);

        Task<byte[]> DownloadAsync(string url);
    }
}
