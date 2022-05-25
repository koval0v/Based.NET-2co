using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_3
{
    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    class AndromedaGalaxyBuilder : GalaxyBuilder
    {
        public override void SetGalaxyType()
        {
            Galaxy.GalaxyType = GalaxyType.Elliptical;
        }
        public override void SetPlanets()
        {
            List<Planet> andromedaPlanets = new List<Planet>() {
                new Planet("PA-99-N2b")
            };
            foreach (Planet p in andromedaPlanets)
            {
                Galaxy.planets.Add(p);
            }
        }
        public override void SetLuminaries()
        {
            List<Luminary> andromedaLuminaries = new List<Luminary>() {
                new Luminary("Villus"),
                new Luminary("Areosa")
            };
            foreach (Luminary l in andromedaLuminaries)
            {
                Galaxy.luminaries.Add(l);
            }
        }
    }
}
