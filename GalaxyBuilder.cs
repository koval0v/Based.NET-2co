using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_3
{
    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    abstract class GalaxyBuilder
    {
        public Galaxy Galaxy { get; private set; }
        public void CreateGalaxy()
        {
            Galaxy = new Galaxy();
            Galaxy.planets = new List<Planet>();
            Galaxy.luminaries = new List<Luminary>();
        }
        public abstract void SetGalaxyType();
        public abstract void SetPlanets();
        public abstract void SetLuminaries();
    }
}
