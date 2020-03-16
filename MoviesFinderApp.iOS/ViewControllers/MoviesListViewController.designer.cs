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
    [Register ("MoviesListViewController")]
    partial class MoviesListViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView moviesTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (moviesTableView != null) {
                moviesTableView.Dispose ();
                moviesTableView = null;
            }
        }
    }
}