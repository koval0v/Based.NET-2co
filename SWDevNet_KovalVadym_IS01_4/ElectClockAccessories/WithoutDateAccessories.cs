using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_4
{
    class WithoutDateAccessories : ClockAccessoriesDecorator
    {
        public WithoutDateAccessories(IClockItem clock) : base(clock)
        {
            if (!clock.GetType().ToString().Contains("ElectricClock"))
            {
                throw new ClockTypeException("Type of clock for such accessory must be electric");
            }
        }
        public override string GetTime()
        {
            return base.GetTime() + $" Time: {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";
        }
    }
}
