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
    [Register ("MovieTableViewCell")]
    partial class MovieTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ImageMovie { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelLanguage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelReleaseDate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ImageMovie != null) {
                ImageMovie.Dispose ();
                ImageMovie = null;
            }

            if (LabelLanguage != null) {
                LabelLanguage.Dispose ();
                LabelLanguage = null;
            }

            if (LabelReleaseDate != null) {
                LabelReleaseDate.Dispose ();
                LabelReleaseDate = null;
            }

            if (LabelTitle != null) {
                LabelTitle.Dispose ();
                LabelTitle = null;
            }
        }
    }
}