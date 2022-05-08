using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SWDevNet_KovalVadym_IS01_2
{
    public class XMLMoviesAnalysing : XMLAnalysing
    {
        public XMLMoviesAnalysing(ref Cinema cinema) : base(ref cinema)
        { }

        protected override XDocument InfoToXDocument()
        {
            var movieAsXElements = from m in cinemaToXmlLinq.movies
                                   select
                                   new XElement("movie",
                                   new XAttribute("title", m.Title),
                                   new XElement("duration", m.Duration),
                                   new XElement("genre", m.MovieGenre));

            XElement moviesDoc = new XElement("movies", movieAsXElements);

            XDocument xdoc = new XDocument(new XComment("Movies Info"),
                moviesDoc);

            return xdoc;

        }

        /// <summary>
        /// Отримати атрибут елементів за назвою фільму
        /// </summary>
        public IEnumerable<string> AttributeByDuration(string attribute, int duration)
        {
            IEnumerable<string> element = from e in doc.Root.Elements("movie")
                                          where (int)e.Element("duration") == duration
                                          select e.Attribute(attribute).Value;
            return element;
        }

        /// <summary>
        /// Отримати елемент з найменшою тривалістю за першою буквою
        /// </summary>
        public XElement TheSmallestDurationElementByFirstTitleLetter(char first)
        {
            XElement element = doc.Root.Elements("movie").OrderBy(p => p.Element("duration").Value).
                                    LastOrDefault(p => p.Attribute("title").Value.StartsWith(first));
            return element;
        }

        /// <summary>
        /// Отримати назви елементів за жанром
        /// </summary>
        public IEnumerable<string> TitlesByGenre(MovieGenre genre)
        {
            IEnumerable<string> element = from e in doc.Root.Elements("movie")
                                          where e.Element("genre").Value == genre.ToString()
                                          select e.Attribute("title").Value;
            return element;
        }

        /// <summary>
        /// Отримати елементи з тривалістю в діапазоні
        /// </summary>
        public IEnumerable<XElement> ElementsByDurationRange(int min, int max)
        {
            IEnumerable<XElement> element = doc.Root.Elements("movie").Where(p => (int)p.Element("duration") > min && (int)p.Element("duration") < max);
            return element;
        }

        /// <summary>
        /// Додати елемент
        /// </summary>
        public void AddElement(Movie movie)
        {
            XElement newMovie = new XElement("movie",
                new XAttribute("title", movie.Title),
                new XElement("duration", movie.Duration),
                new XElement("genre", movie.MovieGenre));

            doc.Root.Add(newMovie);
        }
    }
}
