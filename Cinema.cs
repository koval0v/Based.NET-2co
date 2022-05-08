using SWDevNet_KovalVadym_IS01_2.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SWDevNet_KovalVadym_IS01_2
{
    public enum CinemaRange
    {
        VideoFilms,
        WidescreenFilms,
        StereoFormatEquipment
    }

    public class Cinema
    {
        public string Name { get; set; }
        public int TotalSeatsNumber { get; set; }
        public int ConstructionYear { get; set; }
        public List<CinemaHall> cinemaHalls;
        public List<Employee> employees;
        public List<Movie> movies;
        public CinemaRange cinemaRange { get; set; }
        public Cinema(string name, int constructionYear, List<CinemaHall> nowCinemaHalls, List<Employee> nowEmployees)
        {
            Name = name;

            if (constructionYear > DateTime.Now.Year)
            {
                throw new CinemaInfoException("Year of construction cann`t be greater than current year");
            }
            else
            {
                ConstructionYear = constructionYear;
            }

            cinemaHalls = new List<CinemaHall>();
            foreach (CinemaHall c in nowCinemaHalls)
            {
                cinemaHalls.Add(c);
                TotalSeatsNumber += c.SeatsNumber;
            }

            employees = new List<Employee>();
            foreach (Employee e in nowEmployees)
            {
                employees.Add(e);
            }

            cinemaRange = SetCinemaRange();

            List<Movie> moviesNoDistinct = new List<Movie>();
            foreach (CinemaHall cinemaHall in nowCinemaHalls)
            {
                foreach (Movie movie in cinemaHall.movies)
                {
                    moviesNoDistinct.Add(movie);
                }
            }
            movies = moviesNoDistinct.Distinct().ToList();
        }

        private CinemaRange SetCinemaRange()
        {
            if (cinemaHalls.Any(c => c.GetType().ToString().Contains("CinemaHallVIPLUX")))
            {
                return CinemaRange.StereoFormatEquipment;
            }
            else if (cinemaHalls.Any(c => c.GetType().ToString().Contains("CinemaHallVIP")))
            {
                return CinemaRange.WidescreenFilms;
            }
            else
            {
                return CinemaRange.VideoFilms;
            }
        }
    }
}
