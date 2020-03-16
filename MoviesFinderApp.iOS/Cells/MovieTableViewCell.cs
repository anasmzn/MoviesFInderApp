using FFImageLoading;
using Foundation;
using MoviesFinderApp.Core.Model;
using System;
using UIKit;

namespace MoviesFinderApp.iOS
{
    public partial class MovieTableViewCell : UITableViewCell
    {
        public MovieTableViewCell (IntPtr handle) : base (handle)
        {
        }

        public void UpdateCellData(Movie movie)
        {
            try
            {
                LabelTitle.Text = movie.OriginalTitle;
                LabelLanguage.Text = string.Format("Original language: {0} / {1}", movie.OriginalLanguage, movie.Adult.Value ? "Adult" : "Not adult");
                LabelReleaseDate.Text = string.Format("Released at " + (movie.ReleaseDate.HasValue ? movie.ReleaseDate.Value.ToShortDateString() : "N/A"));
                ImageService.Instance
                    //.LoadUrl(string.Format(Core.Config.PosterPathBaseurl, movie.PosterPath)) //Blocked by Dns/ATS on iOS
                    .LoadUrl("https://www.gstatic.com/webp/gallery/2.jpg")
                     .DownSampleInDip(height: 200)
                    .Into(ImageMovie);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}