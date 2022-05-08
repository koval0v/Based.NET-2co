using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SWDevNet_KovalVadym_IS01_2
{
    public class XMLEmployeeAnalysing : XMLAnalysing
    {
        public XMLEmployeeAnalysing(ref Cinema cinema) : base(ref cinema)
        { }

        protected override XDocument InfoToXDocument()
        {
            var empAsXElements = from e in cinemaToXmlLinq.employees
                                 select
                                 new XElement("employee",
                                 new XAttribute("idCardNumber", e.IDCardNumber),
                                 new XElement("fullName", e.Name + " " + e.Surname + " " + e.Patronymic),
                                 new XElement("age", e.Age),
                                 new XElement("state", e.EmployeeState));

            XElement employeesDoc = new XElement("employees", empAsXElements);

            XDocument xdoc = new XDocument(new XComment("Employees Info"),
                employeesDoc);

            return xdoc;

        }

        /// <summary>
        /// Отримати перелік x перших дочірних вузлів 
        /// </summary>
        public IEnumerable<XElement> Nodes(int x)
        {
            IEnumerable<XElement> docNodes = doc.Root.Elements().Take(x);
            return docNodes;
        }

        /// <summary>
        /// Отримати перелік усіх вказаних дочірних вузлів
        /// </summary>
        public IEnumerable<XElement> NamedNodes(string nodeName)
        {
            IEnumerable<XElement> docNodes = doc.Root.Elements(nodeName);
            return docNodes;
        }

        /// <summary>
        /// Отримати всі значення вузла в порядку зростання/спадання за назвою
        /// </summary>
        public IEnumerable<string> NamedNodesOrderLength(string nodeName, bool desc)
        {
            if (desc)
            {
                return doc.Descendants("employee").Select(p => p.Element(nodeName).Value).Distinct().OrderByDescending(p => p.Length);
            }
            else
            {
                return doc.Descendants("employee").Select(p => p.Element(nodeName).Value).Distinct().OrderBy(p => p.Length);
            }
        }

        ///// <summary>
        ///// Отримати ПІБ елементів за віком
        ///// </summary>
        public IEnumerable<string> ElementsByAge(int age)
        {
            IEnumerable<string> element = from e in doc.Root.Elements("employee")
                                            where (int)e.Element("age") == age
                                            select e.Element("fullName").Value;
            return element;
        }

        /// <summary>
        /// Видалити вузол за назвою
        /// </summary>
        public void DeleteByTitle(string nodeName)
        {
            doc.Root.Elements("employee").Elements(nodeName).Remove();
        }
    }
}
