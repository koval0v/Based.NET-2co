using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_2
{
    public class CinemaHallVIPLUX : CinemaHallVIP
    {
        public int VIPLUXSeatsNumber { get; }
        public CinemaHallVIPLUX(string name, int seatsNumber, List<Movie> nowMovies, int vipSeatsNumber, int vipLuxSeatsNumber) :
            base(name, seatsNumber, nowMovies, vipSeatsNumber)
        {
            VIPLUXSeatsNumber = vipLuxSeatsNumber;
        }
    }
}
