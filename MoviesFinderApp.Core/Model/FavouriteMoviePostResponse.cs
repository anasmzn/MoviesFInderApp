using System;
using Newtonsoft.Json;

namespace MoviesFinderApp.Core.Model
{
    public class FavouriteMoviePostResponse
    {
        [JsonProperty("message")] 
        public string Message { get; set; }
    }

    public class FavouriteMoviePostRequest
    {
        [JsonProperty("movieId")]
        public string MovieId { get; set; }

        [JsonProperty("isFavourite")]
        public bool IsFavourite { get; set; }
    }

}
