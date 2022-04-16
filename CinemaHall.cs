using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_1
{
    public class CinemaHall
    {
        public string Name { get; }
        public int SeatsNumber { get; }
        public List<Movie> movies;
        public CinemaHall(string name, int seatsNumber, List<Movie> nowMovies)
        {
            Name = name;
            SeatsNumber = seatsNumber;
            movies = new List<Movie>();
            foreach (Movie m in nowMovies)
            {
                movies.Add(m);
            }
        }
    }
}
