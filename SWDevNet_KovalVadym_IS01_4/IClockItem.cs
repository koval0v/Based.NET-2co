using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_4
{
    /// <summary>
    /// The 'Component' abstract class
    /// </summary>
    interface IClockItem
    {
        string Name { get; }
        string GetTime();
    }
}
