using System;
using System.Threading.Tasks;
using MoviesFinderApp.Core.Model;

namespace MoviesFinderApp.Core.DataAccess.Interfaces
{
    public interface IMoviesDataAccess
    {
        Task<MoviesResponse> GetAllMovies();

        Task<FavouriteMoviePostResponse> PostFavouriteMovie(FavouriteMoviePostRequest request);

        Task<MoviesResponse> GetAllFavouriteMovie();

        Task<byte[]> DownloadAsync(string url);
    }
}
