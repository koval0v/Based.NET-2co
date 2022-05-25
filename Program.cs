using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_3
{
    class Program
    {
        static void Main(string[] args)
        {
            GalaxyBuilder builder1 = new MilkiWayGalaxyBuilder();
            GalaxyBuilder builder2 = new AndromedaGalaxyBuilder();

            GalaxyCreater director = new GalaxyCreater();

            Galaxy g1 = director.CreateGalaxy(builder1);
            Console.WriteLine(g1.ToString());

            Galaxy g2 = director.CreateGalaxy(builder2);
            Console.WriteLine(g2.ToString());
        }
    }
}
