using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_4
{
    /// <summary>   
    /// The 'AbstractDecorator' class   
    /// </summary>   
    abstract class ClockAccessoriesDecorator : IClockItem
    {
        public string Name { get; }

        private IClockItem _clock;
        public ClockAccessoriesDecorator(IClockItem clock)
        {
            _clock = clock;
        }
        public virtual string GetTime()
        {
            return _clock.GetTime();
        }
    }
}
