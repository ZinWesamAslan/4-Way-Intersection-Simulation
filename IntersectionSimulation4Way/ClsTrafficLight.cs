using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionSimulation4Way
{
    public abstract class ClsTrafficLight
    {
        public enum enTrafficLightMode{Red,Orange,Green}

        
        public enTrafficLightMode Mode { get; set; }

        // Constructor
        public ClsTrafficLight(enTrafficLightMode initialMode = enTrafficLightMode.Red)
        {
            Mode = initialMode;
        }
    }
}
