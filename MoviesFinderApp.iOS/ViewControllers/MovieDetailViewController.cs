using FFImageLoading;
using Foundation;
using MoviesFinderApp.Core;
using MoviesFinderApp.Core.Model;
using System;
using UIKit;
using MoviesFinderApp.Core.Extensions;
using System.Threading.Tasks;

namespace MoviesFinderApp.iOS
{
    public partial class MovieDetailViewController : UIViewController
    {
        public MovieDetailViewController (IntPtr handle) : base (handle)
        {
        }

        public Movie Movie { get; internal set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            if(Movie != null)
            {
                FavouritCheckbox.SetImage(UIImage.FromBundle("favorite_checked.png"), UIControlState.Selected);
                FavouritCheckbox.SetImage(UIImage.FromBundle("favorite_uncheck.png"), UIControlState.Normal);
                UpdateDataAsync();
            }
        }

        private void UpdateDataAsync()
        {
            MovieDesciption.Text = Movie.Overview;
            MovieReleasedDate.Text = "Relased at " + Movie.ReleaseDate.Value.ToShortDateString();
            MovieLang.Text = "Original Language: " + Movie.OriginalLanguage + "/ " + ((Movie.Adult.HasValue && Movie.Adult.Value) ? "Adult" : "Not Adult");
            MoviePopularity.Text = "Popularity " + Movie.Popularity.Value;
            MovieTitle.Text = Movie.OriginalTitle;
            ImageService.Instance
                // .LoadUrl(string.Format(Core.Config.PosterPathBaseurl, Movie.PosterPath))
                 .LoadUrl("https://www.gstatic.com/webp/gallery/2.jpg")
                 .DownSampleInDip(300)
                .Into(imageMovie);
        }

        partial void AddToFavourite_TouchUpInsite(UIButton sender)
        {
            Core.Model.FavouriteMoviePostRequest request = new FavouriteMoviePostRequest();
            request.MovieId = Movie.Id.Value.ToString();
            sender.Selected = request.IsFavourite =  !sender.Selected;
            PostFavouriteRequestAsync(request).FireAndForgetSafeAsync();
        }

        private async Task PostFavouriteRequestAsync(FavouriteMoviePostRequest request)
        {
            try
            {
                var response = await AppData.MoviesDataAccess.PostFavouriteMovie(request);
                if(response != null)
                {
                    var message = request.IsFavourite ? "Saved as favourite" : "Removed from favourite";
                    BeginInvokeOnMainThread(() =>
                    {
                        var alert = UIAlertController.Create("Favourite movie", message, UIAlertControllerStyle.Alert);
                        var alertAction = UIAlertAction.Create("OK", UIAlertActionStyle.Default, null);
                        alert.AddAction(alertAction);
                        this.PresentViewController(alert,true,null);
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}