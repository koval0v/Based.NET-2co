using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_4
{
    /// <summary>
    /// The 'ConcreteComponent1' class
    /// </summary>
    class ElectricClock : IClockItem
    {
        public string Name { get; }
        public ElectricClock(string name)
        {
            Name = name;
        }

        public string GetTime()
        {
            return $"= Electric Clock \"{Name}\"= ";
        }

    }
}
