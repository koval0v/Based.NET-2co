using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_2
{
    public enum MovieGenre
    {
        Comedy,
        Drama,
        Fantasy,
        Horror,
        Thriller,
        Mystery
    }

    public class Movie
    {
        public string Title { get; }
        public int Duration { get; }
        public MovieGenre MovieGenre { get; }

        public Movie(string title, int duration, MovieGenre movieGenre)
        {
            Title = title;
            Duration = duration;
            MovieGenre = movieGenre;
        }

    }
}
