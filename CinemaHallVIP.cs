using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_1
{
    public class CinemaHallVIP : CinemaHall
    {
        public int VIPSeatsNumber { get; }
        public CinemaHallVIP(string name, int seatsNumber, List<Movie> nowMovies, int vipSeatsNumber) :
            base(name, seatsNumber, nowMovies)
        {
            VIPSeatsNumber = vipSeatsNumber;
        }
    }
}
