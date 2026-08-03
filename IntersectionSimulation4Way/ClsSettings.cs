using System.Drawing;

namespace IntersectionSimulation4Way
{
    public static class ClsSettings
    {
        // Traffic Lights Start Time
        public static byte RedTrafficLightStartTime = 0;
        public static byte GreenUlTrafficLightStartTime = 20;
        public static byte GreenFrTrafficLightStartTime = 27;
        public static byte GreenTrafficLightStartTime = 20;
        public static byte OrangeTrafficLightStartTime = 35;

        // UcCar Points LifeEnd (نقاط خروج السيارات من الشاشة)
        public static int LeftExitX = -100;
        public static int RightExitX = 1450;
        public static int UpExitY = -100;
        public static int DownExitY = 850;

        // مصفوفات لتخزين نقاط البداية والنهاية لكل طريق لتسهيل الوصول إليها بالـ Index
        // Bottom Road (3 Lanes)
        public static Point[] BottomRoadStarts = { new Point(705, 741), new Point(764, 741), new Point(823, 741) };
        public static Point[] BottomRoadEnds = { new Point(705, 500), new Point(764, 500), new Point(823, 500) };

        // Top Road (3 Lanes)
        public static Point[] TopRoadStarts = { new Point(620, -36), new Point(561, -36), new Point(503, -36) };
        public static Point[] TopRoadEnds = { new Point(620, 206), new Point(561, 206), new Point(503, 206) };

        // Right Road (2 Lanes)
        public static Point[] RightRoadStarts = { new Point(1362, 312), new Point(1362, 255) };
        public static Point[] RightRoadEnds = { new Point(875, 312), new Point(875, 255) };

        // Left Road (2 Lanes)
        public static Point[] LeftRoadStarts = { new Point(-63, 392), new Point(-63, 449) };
        public static Point[] LeftRoadEnds = { new Point(450, 392), new Point(450, 449) };
    }
}