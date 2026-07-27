using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntersectionSimulation4Way
{
    public partial class UcCar :UcCircleControl,CanMove
    {

        // 1. Enum داخلي لحالات السيارة
        public enum enCarMode { Moving, Stopped }

        // 2. Fields & Auto-Properties (Public on the same line)
        public int ID { get; set; }
        public static int CarsNumberCounter { get; set; } = 0;
        
        public int Speed { get; set; }
        public enCarMode Mode { get; set; }

        // 3. Constructor
        public UcCar(int X, int Y, int R, int id, Color color, int speed, enCarMode mode)
        {
            this.ID = ++CarsNumberCounter;
            this.InnerColor = color;
            this.Speed = speed;
            this.Mode = mode;
            Control c = new Control();

        }

        public UcCar()
        { 
        }
            


        // 5. Interface Implementation (CanMove)
        public void GoUp() { }
        public void GoDown() { }
        public void GoRight() { }
        public void GoLift() { }

        // 6. Public Game Logic Methods
        public void Stop() { }
        public void Mdove() { }

        public void TurnU() { }
        public void TurnLift() { }
        public void TurnRight() { }

        // 7. Private Helper Methods
        private void MoveUpThenTurnLift() { }
        private void MoveUpThenTurnRight() { }
        private void MoveUpThenTurnUDown() { }
        private void MoveDownThenTurnLift() { }
        private void MoveDownThenTurnRight() { }
        private void MoveDownThenTurnUUp() { }

    }
}
