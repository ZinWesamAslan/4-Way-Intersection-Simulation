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
    public partial class FrmSimulation : System.Windows.Forms.Form
    {
        public FrmSimulation()
        {
            InitializeComponent();
            
        }

        private void FrmSimulation_Load(object sender, EventArgs e)
        {
            ucTrafficLight1.StartSimulationFourModes();
            ucTrafficLight2.StartSimulationFourModes();
            ucTrafficLight3.StartSimulationThreeModes();
            ucTrafficLight4.StartSimulationThreeModes();
        }
    }
}
