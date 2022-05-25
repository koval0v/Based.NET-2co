using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_3
{
    /// <summary>
     /// The 'ConcreteBuilder1' class
     /// </summary>
    class MilkiWayGalaxyBuilder : GalaxyBuilder
    {
        public override void SetGalaxyType()
        {
            Galaxy.GalaxyType = GalaxyType.Spiral;
        }
        public override void SetPlanets()
        {
            List<Planet> milkywayPlanets = new List<Planet>() {
                new Planet("Mercury"),
                new Planet("Venus"),
                new Planet("Earth"),
                new Planet("Mars"),
                new Planet("Jupiter"),
                new Planet("Saturn"),
                new Planet("Uranus"),
                new Planet("Neptune")
            };
            foreach (Planet p in milkywayPlanets)
            {
                Galaxy.planets.Add(p);
            }
        }
        public override void SetLuminaries()
        {
            List<Luminary> milkywayLuminaries = new List<Luminary>() {
                new Luminary("Orion"),
                new Luminary("Auriga"),
                new Luminary("Perseus"),
                new Luminary("Scorpius")
            };
            foreach (Luminary l in milkywayLuminaries)
            {
                Galaxy.luminaries.Add(l);
            }
        }
    }
}
