using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_3
{
    /// <summary>
    /// The 'Director' class
    /// </summary>
    class GalaxyCreater
    {
        public Galaxy CreateGalaxy(GalaxyBuilder builder)
        {
            builder.CreateGalaxy();
            builder.SetGalaxyType();
            builder.SetPlanets();
            builder.SetLuminaries();

            return builder.Galaxy;
        }
    }
}
