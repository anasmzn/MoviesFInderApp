using System;
using System.Collections;
using System.Collections.Generic;
using Foundation;
using MoviesFinderApp.Core.Model;
using UIKit;

namespace MoviesFinderApp.iOS.DataSource
{
    public class MoviesDataSource : UITableViewDataSource
    {
        private readonly IList<Movie> _movies;
        private const string CellIdentifier = "movie_cell";
        private readonly Action<int> _rowSelected;

        public MoviesDataSource(IList<Movie> movies)
        {
            _movies = movies;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
           var cell =  tableView.DequeueReusableCell(CellIdentifier, indexPath) as MovieTableViewCell;
            cell.UpdateCellData(_movies[indexPath.Row]);
           return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
           return _movies.Count;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public Movie GetMovie(int row)
        {
            return _movies[row];
        }
    }
}
