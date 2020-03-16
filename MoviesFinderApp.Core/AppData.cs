using System;
using MoviesFinderApp.Core.DataAccess;
using MoviesFinderApp.Core.DataAccess.Interfaces;
using MoviesFinderApp.Core.Service;

namespace MoviesFinderApp.Core
{
    //Facade
    public class AppData
    {
        public static IMoviesDataAccess MoviesDataAccess
        {
            get
            {
                return new MoviesDataAccess(new ApiService()); //for demo only, use IoC instead with singleton resolve.
            }
        }
    }
}
