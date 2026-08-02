using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionSimulation4Way
{
    public static class ClsSettings
    {
        // Buttom Road Start And End Points
        // Starts Points :
        public static Point Road1Lane1StartPoint = new Point(705, 741);
        public static Point Road1Lane2StartPoint = new Point(764, 741);
        public static Point Road1Lane3StartPoint = new Point(823, 741);
        // End Points :
        public static Point Road1Lane1EndPoint = new Point(705, 500);
        public static Point Road1Lane2EndPoint = new Point(764, 500);
        public static Point Road1Lane3EndPoint = new Point(823, 500);

        // Right Road Start And End Points
        // Starts Points :
        public static Point Road2Lane1StartPoint = new Point(1362, 312);
        public static Point Road2Lane2StartPoint = new Point(1362, 255);
        // End Points :
        public static Point Road2Lane1EndPoint = new Point(875, 312);
        public static Point Road2Lane2EndPoint = new Point(875, 255);

        // Up Road Start And End Points
        // Starts Points :
        public static Point Road3Lane1StartPoint = new Point(620, -36);
        public static Point Road3Lane2StartPoint = new Point(561, -36);
        public static Point Road3Lane3StartPoint = new Point(503, -36);
        // End Points :
        public static Point Road3Lane1EndPoint = new Point(620, 206);
        public static Point Road3Lane2EndPoint = new Point(561, 206);
        public static Point Road3Lane3EndPoint = new Point(503, 206);

        // Lift Road Start And End Points
        // Starts Points :
        public static Point Road4Lane1StartPoint = new Point(-63, 392);
        public static Point Road4Lane2StartPoint = new Point(-63, 449);
        // End Points :
        public static Point Road4Lane1EndPoint = new Point(450, 392);
        public static Point Road4Lane2EndPoint = new Point(450, 449);

        // UcCar Points LifeEnd 
        public static int LeftX = 1373;
        public static int RightX = -45;
        public static int UpY = -55;
        public static int DownY = 753;

        // Traffic Lights Start Time
        public static byte RedTrafficLightStartTime = 0;
        public static byte GreenUlTrafficLightStartTime = 20;
        public static byte GreenFrTrafficLightStartTime = 27;
        public static byte GreenTrafficLightStartTime = 20;
        public static byte OrangeTrafficLightStartTime = 35;

    }
}
