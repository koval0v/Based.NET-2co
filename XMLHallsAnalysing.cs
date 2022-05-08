using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SWDevNet_KovalVadym_IS01_2
{
    public class XMLHallsAnalysing : XMLAnalysing
    {
        public XMLHallsAnalysing(ref Cinema cinema) : base(ref cinema)
        { }

        protected override XDocument InfoToXDocument()
        {
            var hallAsXElements = from h in cinemaToXmlLinq.cinemaHalls
                                  select
                                  new XElement("hall",
                                  new XAttribute("name", h.Name),
                                  new XElement("seatsNumber", h.SeatsNumber));

            XElement hallsDoc = new XElement("halls", hallAsXElements);

            XDocument xdoc = new XDocument(new XComment("Halls Info"),
                hallsDoc);

            return xdoc;

        }

        /// <summary>
        /// Отримати назви кінозалів
        /// </summary>
        public IEnumerable<string> HallsNames()
        {
            IEnumerable<string> docNodes = doc.Descendants("hall").Select(p => p.Attribute("name").Value);
            return docNodes;
        }

        /// <summary>
        /// Отримати елементи за діапазоном місць
        /// </summary>
        public IEnumerable<XElement> ElementsBySeatsRange(int min, int max)
        {
            IEnumerable<XElement> element = from h in doc.Root.Elements("hall")
                                            where (int)h.Element("seatsNumber") > min && (int)h.Element("seatsNumber") < max
                                            select h;
            return element;
        }

        /// <summary>
        /// Отримати елемент з найменшою кількістю місць
        /// </summary>
        public XElement TheSmallestHall()
        {
            XElement element = doc.Element("halls").Elements("hall").OrderBy(p => p.Element("seatsNumber").Value).LastOrDefault();
            return element;
        }

        /// <summary>
        /// Отримати назви залів за кількістю місць
        /// </summary>
        public IEnumerable<string> HallsNamesBySeatsNumber(int seatsNumber)
        {
            IEnumerable<string> element = from h in doc.Root.Elements("hall")
                                          where (int)h.Element("seatsNumber") == seatsNumber
                                          orderby h.Attribute("name").Value ascending
                                          select h.Attribute("name").Value.ToString();
            return element;
        }

        /// <summary>
        /// Змінити кількість місць залу за назвою
        /// </summary>
        public void EditSeatsNumberByName(string name, int newSeatsNumber)
        {
            foreach (XElement x in doc.Root.Elements("hall").ToList())
            {
                if (x.Attribute("name").Value == name)
                {
                    x.Element("seatsNumber").Value = newSeatsNumber.ToString();
                }
            }
        }
    }
}
