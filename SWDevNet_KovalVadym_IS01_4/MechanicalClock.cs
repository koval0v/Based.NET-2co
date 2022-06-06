using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_4
{
    /// <summary>
    /// The 'ConcreteComponent2' class
    /// </summary>
    class MechanicalClock : IClockItem
    { 
        public string Name { get; }
        public MechanicalClock(string name)
        {
            Name = name;
        }

        public string GetTime()
        {
            return $"= Mechanical Clock \"{Name}\"= ";
        }
    }
}
