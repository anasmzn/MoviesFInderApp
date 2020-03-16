using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using MoviesFinderApp.Core.Model;

namespace MoviesFinderApp.Adapters
{
    public class MoviesAdapter : RecyclerView.Adapter
    {
        private readonly List<Movie> _items;
        private readonly Action<Movie>  _itemSelected;

        public MoviesAdapter(List<Movie> movies,Action<Movie> itemSelected)
        {
            _items = movies;
            _itemSelected = itemSelected;
        }

        public override int ItemCount => _items.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var movieVH = holder as MovieViewHolder;
            if(movieVH != null)
            {
                var movie = _items[position];
                movieVH.TextViewTitle.Text = movie.OriginalTitle;
                movieVH.Language.Text = "Original Language: "+ movie.OriginalLanguage.ToUpper();
                movieVH.ReleaseDate.Text = "Release at " + (movie.ReleaseDate.HasValue ? movie.ReleaseDate.Value.ToShortDateString() : string.Empty);
                ImageService.Instance.LoadUrl(string.Format(Core.Config.PosterPathBaseurl,movie.PosterPath)).Into(movieVH.ImageViewMovie);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var inflater = LayoutInflater.FromContext(parent.Context);
            var view = inflater.Inflate(Resource.Layout.movie_row, parent, false);
            return new MovieViewHolder(view, (position) => { _itemSelected(_items[position]); }); 
        }
    }


    public class MovieViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ImageViewMovie { get; set; }

        public TextView TextViewTitle { get; set; }

        public TextView Language { get; set; }

        public TextView ReleaseDate { get; set; }

        public MovieViewHolder(View itemView, Action<int> onClick) : base(itemView)
        {
            ImageViewMovie = itemView.FindViewById<ImageView>(Resource.Id.ivMovie);
            TextViewTitle = itemView.FindViewById<TextView>(Resource.Id.tvTitle);
            Language = itemView.FindViewById<TextView>(Resource.Id.tvLanguage);
            ReleaseDate = itemView.FindViewById<TextView>(Resource.Id.tvReleaseDate);
            itemView.Click += (s, e) => { onClick?.Invoke(AdapterPosition); };
        }
    }
}
