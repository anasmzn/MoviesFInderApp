
using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using MoviesFinderApp.Adapters;
using MoviesFinderApp.Core;
using MoviesFinderApp.Core.Extensions;
using MoviesFinderApp.Core.Model;

namespace MoviesFinderApp.Fragments
{
    public class MoviesListFragment : Fragment
    {
        public MoviesListFragment()
        {

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view  = inflater.Inflate(Resource.Layout.movies_list_fragemnt, container, false);
            var recyclerView = view as RecyclerView;
            recyclerView?.SetLayoutManager(new LinearLayoutManager(recyclerView.Context));
            GetAndSetDataAsync(recyclerView).FireAndForgetSafeAsync();
            return recyclerView;
        }

        private async System.Threading.Tasks.Task GetAndSetDataAsync(RecyclerView recyclerView)
        {
            try
            {
                var moviesResponse = await AppData.MoviesDataAccess.GetAllMovies();
                if (moviesResponse?.Movies != null && moviesResponse.Movies.Any())
                {
                    this.Activity.RunOnUiThread(() =>
                    {
                        recyclerView?.SetAdapter(new MoviesAdapter(moviesResponse.Movies, itemSelected: ItemSelected));
                    });
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void ItemSelected(Movie movie)
        {
            var movieDetailsFeagment = new MovieDetailsFragment(movie);
            this.FragmentManager
                .BeginTransaction()
                .Add(Resource.Id.fragmentContainer,movieDetailsFeagment, "movieDetailsFeagment")
                .AddToBackStack("movieDetailsFeagment")
                .Commit();
        }

        private List<Movie> GetMockData()
        {
            return new List<Movie>
            {
                new Movie
                {
                     OriginalTitle = "DC Showcase: The Phantom Stranger",
                      ReleaseDate = DateTime.Today.AddDays(-30),
                      OriginalLanguage = "English"
                },
                new Movie
                {
                     OriginalTitle = "The Final Moments",
                      ReleaseDate = DateTime.Today.AddDays(-300),
                      OriginalLanguage = "Hindi"
                },
                new Movie
                {
                     OriginalTitle = "Denomination: Dread",
                      ReleaseDate = DateTime.Today.AddDays(-300),
                      OriginalLanguage = "Arabic"
                },
                new Movie
                {
                     OriginalTitle = "DC Showcase: The Phantom Stranger",
                      ReleaseDate = DateTime.Today.AddDays(-30),
                      OriginalLanguage = "English"
                },
                new Movie
                {
                     OriginalTitle = "The Final Moments",
                      ReleaseDate = DateTime.Today.AddDays(-300),
                      OriginalLanguage = "Hindi"
                },
                new Movie
                {
                     OriginalTitle = "Denomination: Dread",
                      ReleaseDate = DateTime.Today.AddDays(-300),
                      OriginalLanguage = "Arabic"
                }
            };
        }
    }
}
