using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_2.Exceptions
{
    class EmployeeInfoException : Exception
    {
        public EmployeeInfoException(string message) : base(message)
        { }
    }
}
