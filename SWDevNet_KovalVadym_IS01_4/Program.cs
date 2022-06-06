using System;

namespace SWDevNet_KovalVadym_IS01_4
{
    /// <summary>
    /// Decorator Design Pattern
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IClockItem clock1 = new MechanicalClock("Mech-Bo");
            Console.WriteLine(clock1.GetTime());

            Console.WriteLine("-------------------------------------");

            WithSecondsAccessories mechaWith = new WithSecondsAccessories(clock1);
            Console.WriteLine(mechaWith.GetTime());

            Console.WriteLine("-------------------------------------");

            WithoutSecondsAccessories mechaWithout = new WithoutSecondsAccessories(clock1);
            Console.WriteLine(mechaWithout.GetTime());

            Console.WriteLine("=====================================");

            IClockItem clock2 = new ElectricClock("Ele-1-22");
            Console.WriteLine(clock2.GetTime());

            Console.WriteLine("-------------------------------------");

            WithDateAccessories electWith = new WithDateAccessories(clock2);
            Console.WriteLine(electWith.GetTime());

            Console.WriteLine("-------------------------------------");

            WithoutDateAccessories electWithout = new WithoutDateAccessories(clock2);
            Console.WriteLine(electWithout.GetTime());

            //WithSecondsAccessories electWith2 = new WithSecondsAccessories(clock2);
            //Console.WriteLine(electWith.GetTime());

            //WithoutSecondsAccessories electWithout2 = new WithoutSecondsAccessories(clock2);
            //Console.WriteLine(electWithout.GetTime());

            //WithDateAccessories mechaWith2 = new WithDateAccessories(clock1);
            //Console.WriteLine(mechaWith2.GetTime());

            //WithoutDateAccessories mechaWithout2 = new WithoutDateAccessories(clock1);
            //Console.WriteLine(mechaWithout2.GetTime());

        }
    }
}
