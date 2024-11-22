using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishManager.Models.Pond
{
    public class PondRequest
    {
        public string Name { get; set; }
        public double Size { get; set; }
        public double Depth { get; set; }
        public string WaterQuality { get; set; } = string.Empty;

    }
}
