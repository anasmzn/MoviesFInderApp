using System;
using System.Threading.Tasks;
using MoviesFinderApp.Core.DataAccess.Interfaces;
using MoviesFinderApp.Core.Model;
using MoviesFinderApp.Core.Service.Interfaces;

namespace MoviesFinderApp.Core.DataAccess
{
    public class MoviesDataAccess : IMoviesDataAccess
    {
        private readonly IApiService _apiService;

        public MoviesDataAccess(IApiService apiService)
        {
            _apiService = apiService;
        }

        public Task<MoviesResponse> GetAllMovies()
        {
            var url = Config.BaseUrl + Config.GetMovies;
            return _apiService.Get<MoviesResponse>(url);
        }

        public Task<MoviesResponse> GetAllFavouriteMovie()
        {
            var url = Config.BaseUrl + Config.FavouriteMovies;
            return _apiService.Get<MoviesResponse>(url);
        }

        public Task<FavouriteMoviePostResponse> PostFavouriteMovie(FavouriteMoviePostRequest request)
        {
            var url = Config.BaseUrl + Config.FavouriteMovies;
            return _apiService.Post<FavouriteMoviePostRequest,FavouriteMoviePostResponse>(url, request);
        }

        public Task<byte[]> DownloadAsync(string url)
        {
            return _apiService.DownloadAsync(url);
        }
    }
}
