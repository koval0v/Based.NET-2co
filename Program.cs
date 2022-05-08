using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SWDevNet_KovalVadym_IS01_2
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
                new Movie("The Lord of the Rings", 178, MovieGenre.Fantasy),
                new Movie("Titanic", 194, MovieGenre.Drama),
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

            // data analysing - employee
            XMLEmployeeAnalysing emp = new XMLEmployeeAnalysing(ref cinema);

            Console.WriteLine("\nXML Linq #1:");
            foreach (XElement element in emp.Nodes(3))
            {
                Console.WriteLine("--- еlement ---");
                Console.WriteLine(element);
            }

            Console.WriteLine("\nXML Linq #2:");
            foreach (XElement element in emp.NamedNodes("employee"))
            {
                Console.WriteLine("--- еlement ---");
                Console.WriteLine(element);
            }

            Console.WriteLine("\nXML Linq #3:");
            foreach (var element in emp.ElementsByAge(42))
            {
                Console.WriteLine("--- еlement ---");
                Console.WriteLine(element);
            }

            Console.WriteLine("\nXML Linq #4:");
            foreach (var element in emp.NamedNodesOrderLength("state", false))
            {
                Console.WriteLine("--- еlement ---");
                Console.WriteLine(element);
            }

            Console.WriteLine("\nXML Linq #5:");
            emp.DeleteByTitle("age");
            Console.WriteLine(emp.doc);

            // data analysing - movie
            XMLMoviesAnalysing mo = new XMLMoviesAnalysing(ref cinema);

            Console.WriteLine("\nXML Linq #6:");
            foreach (var element in mo.AttributeByDuration("title", 117))
            {
                Console.WriteLine("--- еlement ---");
                Console.WriteLine(element);
            }

            Console.WriteLine("\nXML Linq #7:");
            Console.WriteLine(mo.TheSmallestDurationElementByFirstTitleLetter('A'));

            Console.WriteLine("\nXML Linq #8:");
            foreach (var element in mo.TitlesByGenre(MovieGenre.Comedy))
            {
                Console.WriteLine("--- еlement ---");
                Console.WriteLine(element);
            }

            Console.WriteLine("\nXML Linq #9:");
            foreach (var element in mo.ElementsByDurationRange(120, 170))
            {
                Console.WriteLine("--- еlement ---");
                Console.WriteLine(element);
            }

            Console.WriteLine("\nXML Linq #10:");
            mo.AddElement(new Movie("Time", 108, MovieGenre.Horror));
            Console.WriteLine(mo.doc);

            // data analysing - hall
            XMLHallsAnalysing ha = new XMLHallsAnalysing(ref cinema);

            Console.WriteLine("\nXML Linq #11:");
            foreach (var element in ha.HallsNames())
            {
                Console.WriteLine("--- еlement ---");
                Console.WriteLine(element);
            }

            Console.WriteLine("\nXML Linq #12:");
            foreach (var element in ha.ElementsBySeatsRange(100, 130))
            {
                Console.WriteLine("--- еlement ---");
                Console.WriteLine(element);
            }

            Console.WriteLine("\nXML Linq #13:");
            Console.WriteLine(ha.TheSmallestHall());

            Console.WriteLine("\nXML Linq #14:");
            foreach (var element in ha.HallsNamesBySeatsNumber(125))
            {
                Console.WriteLine("--- еlement ---");
                Console.WriteLine(element);
            }

            Console.WriteLine("\nXML Linq #15:");
            ha.EditSeatsNumberByName("Antrasit", 91);
            Console.WriteLine(ha.doc);
        }
    }
}
