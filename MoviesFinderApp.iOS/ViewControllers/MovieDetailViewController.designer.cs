// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MoviesFinderApp.iOS
{
    [Register ("MovieDetailViewController")]
    partial class MovieDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton FavouritCheckbox { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imageMovie { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView MovieDesciption { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MovieLang { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MoviePopularity { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MovieReleasedDate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MovieTitle { get; set; }

        [Action ("AddToFavourite_TouchUpInsite:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AddToFavourite_TouchUpInsite (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (FavouritCheckbox != null) {
                FavouritCheckbox.Dispose ();
                FavouritCheckbox = null;
            }

            if (imageMovie != null) {
                imageMovie.Dispose ();
                imageMovie = null;
            }

            if (MovieDesciption != null) {
                MovieDesciption.Dispose ();
                MovieDesciption = null;
            }

            if (MovieLang != null) {
                MovieLang.Dispose ();
                MovieLang = null;
            }

            if (MoviePopularity != null) {
                MoviePopularity.Dispose ();
                MoviePopularity = null;
            }

            if (MovieReleasedDate != null) {
                MovieReleasedDate.Dispose ();
                MovieReleasedDate = null;
            }

            if (MovieTitle != null) {
                MovieTitle.Dispose ();
                MovieTitle = null;
            }
        }
    }
}