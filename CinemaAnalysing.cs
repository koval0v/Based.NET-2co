using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_1
{
    public class CinemaAnalysing
    {
        private Cinema cinemaToLinq;
        private const string CINEMA_INFO_TEMPLATE = "Cinema \"{1}\"{0}Total seats number: {2}{0}Construction year: {3}{0}Cinema range: {4}{0}" +
            "{0}Available movies information:{0}{5}{0}" +
            "Available halls information:{0}{6}{0}" +
            "Employees information:{0}{7}{0}";
        private const string EMPLOYEE_INFO_TEMPLATE = "ID: {0} -> Info: {1} {2} {3}";
        private const string MOVIE_INFO_TEMPLATE = "Title: {0} -> Duration: {1} -> Movie genre: {2}";
        private const string MOVIE_IN_HALLS_INFO_TEMPLATE = "Hall title: {0} -> Seats number: {1}";
        public CinemaAnalysing(ref Cinema cinema)
        {
            cinemaToLinq = cinema;
        }

        public string Info()
        {
            return string.Format(CINEMA_INFO_TEMPLATE,
                Environment.NewLine,
                cinemaToLinq.Name,
                cinemaToLinq.TotalSeatsNumber,
                cinemaToLinq.ConstructionYear,
                cinemaToLinq.cinemaRange,
                MoviesInfo(),
                HallsInfo(),
                EmployeesInfo()
                );
        }

        public string EmployeesInfo()
        {
            var employeesPositions = from employee in cinemaToLinq.employees
                          group employee by employee.EmployeeState;

            StringBuilder employeesInfo = new StringBuilder();
            foreach (var position in employeesPositions)
            {
                employeesInfo.AppendLine(position.Key.ToString());

                foreach (var person in position)
                {
                    employeesInfo.AppendLine(string.Format(
                        EMPLOYEE_INFO_TEMPLATE,
                        person.IDCardNumber,
                        person.Name,
                        person.Surname,
                        person.Patronymic
                        ));
                }
                employeesInfo.AppendLine();
            }
            return employeesInfo.ToString();
        }

        public string MoviesInfo()
        {
            StringBuilder moviesInfo = new StringBuilder();
            foreach (var movie in cinemaToLinq.movies)
            {
                moviesInfo.AppendLine(string.Format(
                    MOVIE_INFO_TEMPLATE,
                    movie.Title,
                    movie.Duration,
                    movie.MovieGenre
                    ));
            }
            return moviesInfo.ToString();
        }

        public string HallsInfo()
        {
            StringBuilder moviesInHallsInfo = new StringBuilder();
            foreach (var hall in cinemaToLinq.cinemaHalls)
            {
                moviesInHallsInfo.AppendLine(string.Format(
                    MOVIE_IN_HALLS_INFO_TEMPLATE,
                    hall.Name,
                    hall.SeatsNumber
                    ));
            }
            return moviesInHallsInfo.ToString();
        }

        /* movie linq 1 */
        public void MovieDurationLessThen(int duration)
        {
            var moviesWithLessDuration = from m in cinemaToLinq.movies
                                 where m.Duration < duration 
                                 select m.Title;
            foreach (var x in moviesWithLessDuration)
                Console.WriteLine(x);
        }

        /* movie linq 2 */
        public void SortedMoviesByDuration()
        {
            var moviesSortedByDuration = cinemaToLinq.movies.OrderBy(p => p.Duration);
            foreach (var x in moviesSortedByDuration)
                Console.WriteLine(x.Title + " " + x.Duration);
        }

        /* movie linq 3 */
        public void MoviesMaxOrMinDuration(bool max)
        {
            if (max)
                Console.WriteLine(cinemaToLinq.movies.Max(p => p.Duration));
            else
                Console.WriteLine(cinemaToLinq.movies.Min(p => p.Duration));
        }

        /* movie linq 4 */
        public void FindMoviesByGenre(MovieGenre genreToFind)
        {
            var moviesFindByGenre = cinemaToLinq.movies.Select(p => new
            {
                Title = p.Title,
                Duration = p.Duration,
                MovieGenre = p.MovieGenre
            }).Where(p => p.MovieGenre == genreToFind);
            foreach (var x in moviesFindByGenre)
                Console.WriteLine(x.Title + " " + x.Duration + " " + x.MovieGenre);
        }

        /* movie linq 5 */
        public void AnyMoviesWithGenre(MovieGenre genreToAny)
        {
            Console.WriteLine(cinemaToLinq.movies.Any(p => p.MovieGenre == genreToAny));
        }

        /* hall linq 1 */
        public void TheBiggestHallWithFilm(string filmTitleToFind)
        {
            CinemaHall theBiggest = cinemaToLinq.cinemaHalls.OrderByDescending(p => p.SeatsNumber).FirstOrDefault(p => p.movies.Any(
                p => p.Title == filmTitleToFind));
            Console.WriteLine(theBiggest.Name + " " + theBiggest.SeatsNumber);
        }

        /* hall linq 2 */
        public void FindVIPandVIPLUXHalls()
        {
            var typedHalls = cinemaToLinq.cinemaHalls.OfType<CinemaHallVIP>();
            foreach (var x in typedHalls)
                Console.WriteLine(x.Name + " " + x.SeatsNumber + " " + x.VIPSeatsNumber);
        }

        /* hall linq 3 */
        public void FindHallsWithNumberOfFilms(int filmsQuantity)
        {
            var findHallsWithNumberOfFilms = from hall in cinemaToLinq.cinemaHalls
                                     where hall.movies.Count() >= filmsQuantity
                                     select hall.Name;
            foreach (var x in findHallsWithNumberOfFilms)
                Console.WriteLine(x);

        }

        /* hall linq 4 */
        public void CinemaHallsSimillarFilms(CinemaHall compareHallFirst, CinemaHall compareHallSecond)
        {
            var cinemaHallsSimillarFilms = compareHallFirst.movies.Intersect(compareHallSecond.movies);
            foreach (var x in cinemaHallsSimillarFilms)
                Console.WriteLine(x.Title);

        }

        /* hall linq 5 */
        public void CinemaHallsWithSeatsNumber(int seatsQuantity)
        {
            var cinemaHallsWithSeatsNumber = from hall in cinemaToLinq.cinemaHalls
                                             let info = hall.Name + " " + hall.SeatsNumber
                                             where hall.SeatsNumber == seatsQuantity
                                             orderby hall.SeatsNumber descending
                                             select info;
            foreach (var x in cinemaHallsWithSeatsNumber)
                Console.WriteLine(x);
        }

        /* employee linq 1 */
        public void EmployeesNameStartWith(char first)
        {
            var selectedEmployees = from emp in cinemaToLinq.employees
                                    where emp.Name.ToUpper().StartsWith(first)
                                    orderby emp.Name
                                    select new { Name = emp.Name, Surname = emp.Surname, Patronymic = emp.Patronymic };
            foreach (var x in selectedEmployees)
                Console.WriteLine(x.Name + " " + x.Surname);
        }

        /* employee linq 2 */
        public void EmployeesWithAgeInRange(int minAge, int maxAge)
        {
            var employeesWithBirthdayLater = from emp in cinemaToLinq.employees
                                where emp.Age >= minAge && emp.Age <= maxAge
                                orderby emp.Name
                                select new { IDCardNumber = emp.IDCardNumber, Name = emp.Name,
                                    Surname = emp.Surname, Patronymic = emp.Patronymic };
            foreach (var x in employeesWithBirthdayLater)
                Console.WriteLine(x.IDCardNumber + " " + x.Name + " " + x.Surname + " " + x.Patronymic);
        }

        /* employee linq 3 */
        public void TakeEmployeesYoungerThan(int age)
        {
            var youngerEmployees = cinemaToLinq.employees.OrderBy(p => p.Age).TakeWhile(p => p.Age <= age);
            foreach (var x in youngerEmployees)
                Console.WriteLine(x.IDCardNumber + " " + x.Name + " " + x.Surname + " " + x.Patronymic + " " + x.Age);
        }

        /* employee linq 4 */
        public void CountEmployeesWithSurname(string surname)
        {
            Console.WriteLine(cinemaToLinq.employees.Where(p => p.Surname == surname).Count());
        }

        /* employee linq 5 */
        public void TheOldestEmployee()
        {
            var theOldest = cinemaToLinq.employees.OrderBy(p => p.Age).LastOrDefault();
            Console.WriteLine(theOldest.Name + " " + theOldest.Surname + " " + theOldest.Patronymic + " " + theOldest.Age + " " +
                theOldest.EmployeeState);
        }

    }
}
