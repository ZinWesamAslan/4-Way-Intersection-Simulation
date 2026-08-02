using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionSimulation4Way
{
    public class ClsLane
    {
        public Queue<UcCar> Cars { get; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public ClsLane()
        {
            Cars = new Queue<UcCar>();
        }

        public void AddCar(UcCar car)
        {
            if (car != null)
            {
                Cars.Enqueue(car);
            }
        }

        public void RemoveCar()
        {
            if (Cars.Count > 0)
            {
                Cars.Dequeue();
            }
        }
    }
}
