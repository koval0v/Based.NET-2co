﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_4
{
    /// <summary>   
    /// The 'ConcreteDecorator3' class  
    /// </summary>  
    class WithSecondsAccessories : ClockAccessoriesDecorator
    {
        public WithSecondsAccessories(IClockItem clock) : base(clock)
        {
            if (!clock.GetType().ToString().Contains("MechanicalClock"))
            {
                throw new ClockTypeException("Type of clock for such accessory must be mechanical");
            }
        }
        public int hoursAngle;
        public int minutesAngle;
        public int secondsAngle;
        public override string GetTime()
        {
            hoursAngle = (DateTime.Now.Hour * 360 / 12) % 360;
            minutesAngle = (DateTime.Now.Minute * 360 / 60) % 360;
            secondsAngle = (DateTime.Now.Second * 360 / 60) % 360;
            return base.GetTime() + $" Time: {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}" + "\n"
                + $"Hours angle: {hoursAngle} Minutes angle: {minutesAngle} Seconds angle: {secondsAngle}";
        }
    }
}
