using Foundation;
using MoviesFinderApp.Core;
using System;
using UIKit;
using MoviesFinderApp.Core.Extensions;
using System.Linq;
using MoviesFinderApp.iOS.DataSource;
using MoviesFinderApp.Core.Model;
using System.Collections.Generic;

namespace MoviesFinderApp.iOS
{
    public partial class MoviesListViewController : UIViewController
    {
        public MoviesListViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            moviesTableView.DataSource = new MoviesDataSource(new List<Movie>());
            GetAndSetMoviesDataAsync().FireAndForgetSafeAsync();
        }

        private async System.Threading.Tasks.Task GetAndSetMoviesDataAsync()
        {
            try
            {
                 var movieResponse = await AppData.MoviesDataAccess.GetAllMovies();
                if (movieResponse?.Movies != null && movieResponse.Movies.Any())
                {
                    moviesTableView.DataSource = new MoviesDataSource(movieResponse.Movies);
                    moviesTableView.ReloadData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            var controller = segue.DestinationViewController as MovieDetailViewController;
            var datasource = moviesTableView.DataSource as MoviesDataSource;
            var index = moviesTableView.IndexPathForSelectedRow.Row;
            var movie = datasource.GetMovie(index);
            controller.Movie = movie;
        }
    }

}