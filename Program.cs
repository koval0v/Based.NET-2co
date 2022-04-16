using System;
using System.Collections.Generic;
using System.Linq;

namespace SWDevNet_KovalVadym_IS01_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // list of employees
            List<Employee> employees = new List<Employee>() {
                new Employee(1303104, "Tomas", "Red", "Anderson", 23, EmployeeState.Cleaner),
                new Employee(1341141, "Coll", "Yellow", "Evans", 19, EmployeeState.Cashier),
                new Employee(1363183, "Elly", "Moon", "Dawson", 31, EmployeeState.HallController),
                new Employee(1300314, "Vick", "Sun", "Johnson", 26, EmployeeState.Administrator),
                new Employee(1341141, "Vinny", "Jo", "Mitchell", 22, EmployeeState.Cashier),
                new Employee(1363183, "Oliver", "Sun", "Bailey", 42, EmployeeState.HallController),
                new Employee(1300314, "Blake", "Bo", "Paterson", 18, EmployeeState.HallController)
            };

            // list of movies
            List<Movie> movies = new List<Movie>() {
                new Movie("Ace Ventura: Pet Detective", 86, MovieGenre.Comedy),
                new Movie("Titanic", 194, MovieGenre.Drama),
                new Movie("The Lord of the Rings", 178, MovieGenre.Fantasy),
                new Movie("Alien", 117, MovieGenre.Horror),
                new Movie("No Time To Die", 163, MovieGenre.Thriller),
                new Movie("Free Guy", 115, MovieGenre.Comedy),
                new Movie("Avatar", 162, MovieGenre.Drama)
            };

            // list of cinema halls
            List<CinemaHall> cinemaHalls = new List<CinemaHall>() {
                new CinemaHall("Ultramarin", 140, movies.Skip(2).ToList()),
                new CinemaHallVIP("Terakota", 125, movies.Skip(3).ToList(), 35),
                new CinemaHallVIPLUX("Antrasit", 90, movies.Skip(0).ToList(), 45, 30),
                new CinemaHallVIPLUX("Bluemarin", 125, movies.Skip(5).ToList(), 60, 20)
            };

            // creation of the cinema
            Cinema cinema = new Cinema("Multiplex", 2003, cinemaHalls, employees);

            // data analysing (linq)
            CinemaAnalysing c = new CinemaAnalysing(ref cinema);

            Console.WriteLine("All information about cinema:");
            Console.WriteLine(c.Info());

            Console.WriteLine("== Titles of films with duration less than n ==");
            c.MovieDurationLessThen(150);

            Console.WriteLine("\n== Titles and duration of films ordered by duration ==");
            c.SortedMoviesByDuration();

            Console.WriteLine("\n== Max duration of films (true - max, false - min) ==");
            c.MoviesMaxOrMinDuration(true);

            Console.WriteLine("\n== Information about films with genre n ==");
            c.FindMoviesByGenre(MovieGenre.Comedy);

            Console.WriteLine("\n== Finding if it`s any film with genre n ==");
            c.AnyMoviesWithGenre(MovieGenre.Mystery);

            Console.WriteLine("\n== The biggest available cinema hall title with film with title n ==");
            c.TheBiggestHallWithFilm("Titanic");

            Console.WriteLine("\n== List of VIP typed halls of cinema ==");
            c.FindVIPandVIPLUXHalls();

            Console.WriteLine("\n== Finding halls titles with n or greater films ==");
            c.FindHallsWithNumberOfFilms(5);

            Console.WriteLine("\n== Simmillar films of two cinema halls ==");
            c.CinemaHallsSimillarFilms(cinema.cinemaHalls[0], cinema.cinemaHalls[1]);

            Console.WriteLine("\n== Cinema halls information with n seats ==");
            c.CinemaHallsWithSeatsNumber(125);

            Console.WriteLine("\n== Employees with name starts with n symbol ==");
            c.EmployeesNameStartWith('V');

            Console.WriteLine("\n== List of employees with age in range n to m ==");
            c.EmployeesWithAgeInRange(20, 25);

            Console.WriteLine("\n== Younger than n age employees ==");
            c.TakeEmployeesYoungerThan(30);

            Console.WriteLine("\n== Counting employees with equal surnames ==");
            c.CountEmployeesWithSurname("Sun");

            Console.WriteLine("\n== Finding information about the oldest employee ==");
            c.TheOldestEmployee();

        }
    }
}
