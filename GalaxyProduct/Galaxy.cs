using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_3
{
    public enum GalaxyType
    {
        Spiral,
        Elliptical,
        Peculiar,
        Irregular
    }

    /// <summary>
    /// The 'Product' class
    /// </summary>
    class Galaxy
    {
        public List<Planet> planets { get; set; }
        public List<Luminary> luminaries { get; set; }
        public GalaxyType GalaxyType { get; set; }
        public override string ToString()
        {
            StringBuilder galaxyInfo = new StringBuilder();
            galaxyInfo.Append($"Type is {GalaxyType}");
            galaxyInfo.AppendLine($"\n=== Planets: ===");
            if (planets.Count != 0)
            {
                foreach (Planet p in planets)
                {
                    galaxyInfo.AppendLine($"{p.Name}");
                }
            }
            galaxyInfo.AppendLine($"=== Luminaries: ===");
            if (luminaries.Count != 0)
            {
                foreach (Luminary l in luminaries)
                {
                    galaxyInfo.AppendLine($"{l.Name}");
                }
            }
            return galaxyInfo.ToString();
        }
    }
}
