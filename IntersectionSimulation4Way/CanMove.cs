using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionSimulation4Way
{
    public interface CanMove
    {
        void GoUp();
        void GoDown();
        void GoRight();
        void GoLift();
    }
}
