using System;
namespace MoviesFinderApp.Core
{
    public static class Config
    {
        public static string BaseUrl { get; set; } = "https://demo8718793.mockable.io/"; //Can be changes as per QA/dev/prod env.

        public const string GetMovies = "movies";

        public const string FavouriteMovies = "movies/favourite"; //Get and Post

        public const string PosterPathBaseurl = "https://image.tmdb.org/t/p/w300{0}";//{0} - poster path end 

    }
}
