using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_1.Exceptions
{
    class WrongEmployeeInfoException : Exception
    {
        public WrongEmployeeInfoException(string message) : base(message)
        { }
    }
}
