using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SWDevNet_KovalVadym_IS01_2
{
    public abstract class XMLAnalysing
    {
        protected Cinema cinemaToXmlLinq;
        public XDocument doc { get; private set; }
        public XMLAnalysing(ref Cinema cinema)
        {
            cinemaToXmlLinq = cinema;
            doc = InfoToXDocument();
        }
        protected abstract XDocument InfoToXDocument();

    }
}
