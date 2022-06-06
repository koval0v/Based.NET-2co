using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_4
{
    class ClockTypeException : Exception
    {
        public ClockTypeException(string message) : base(message)
        { }
    }
}
