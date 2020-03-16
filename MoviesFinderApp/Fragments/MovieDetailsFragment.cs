
using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using MoviesFinderApp.Core;
using MoviesFinderApp.Core.Extensions;
using MoviesFinderApp.Core.Model;

namespace MoviesFinderApp.Fragments
{
    public class MovieDetailsFragment : Fragment
    {

        public MovieDetailsFragment() { }

        private readonly Movie _movie;

        public MovieDetailsFragment(Movie movie)
        {
            _movie = movie;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.movie_details_fragment, container, false);
            SetData(view);
            return view;
        }

        private void SetData(View view)
        {
            var ivImage = view.FindViewById<ImageView>(Resource.Id.ivMoviePicture);
            var cbFav = view.FindViewById<CheckBox>(Resource.Id.cbFav);
            cbFav.Click += IvFav_Click;

            var tvTitle = view.FindViewById<TextView>(Resource.Id.tvTitle);
            var tvCategory = view.FindViewById<TextView>(Resource.Id.tvCategory);
            var tvReleaseDate = view.FindViewById<TextView>(Resource.Id.tvReleaseDate);
            var tvRating = view.FindViewById<TextView>(Resource.Id.tvRating);
            var ratingbar = view.FindViewById<RatingBar>(Resource.Id.ratingBar);
            var tvDescription = view.FindViewById<TextView>(Resource.Id.tvDescription);


            tvTitle.Text = _movie.OriginalTitle;
            tvCategory.Text = "Original Language: " + _movie.OriginalLanguage.ToUpper() + "/ "+ (_movie.Adult.Value ? "Adult" : "Not Adult");
            tvReleaseDate.Text = "Released at " + (_movie.ReleaseDate.HasValue ? _movie.ReleaseDate.Value.ToShortDateString() : "N/A");
            tvRating.Text = string.Format("Popularity : {0} ", _movie.Popularity);
            ratingbar.Rating = _movie.VoteCount.Value;
            tvDescription.Text = _movie.Overview;

            ImageService.Instance
               .LoadUrl(string.Format(Config.PosterPathBaseurl, _movie.PosterPath))
               .DownSampleInDip(height: 300)
               .Into(ivImage);
        }

        private void IvFav_Click(object sender, EventArgs e)
        {
            var cbFav = sender as CheckBox;
            SetMovieAsFavouriteAsync(cbFav.Checked).FireAndForgetSafeAsync();
        }

        private async System.Threading.Tasks.Task SetMovieAsFavouriteAsync(bool @checked)
        {
            var response = await AppData.MoviesDataAccess.PostFavouriteMovie(new FavouriteMoviePostRequest
            {
                IsFavourite = @checked,
                MovieId = _movie.Id.Value.ToString()
            });
            if(response != null && ! string.IsNullOrEmpty(response.Message))
            {
                var message = @checked ? "Saved as favourite" : "Reemoved from favourite";
                this.Activity.RunOnUiThread(() =>
                {
                    Toast.MakeText(this.Activity, message, ToastLength.Short).Show();
                });
            }
        }
    }
}
