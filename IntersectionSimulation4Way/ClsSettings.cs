using System.Configuration;
using System.Drawing;

namespace IntersectionSimulation4Way
{
    public static class ClsSettings
    {
        private static string Get(string key) => ConfigurationManager.AppSettings[key];

        
        public static byte RedTrafficLightStartTime = byte.Parse(Get("RedTrafficLightStartTime"));
        public static byte GreenUlTrafficLightStartTime = byte.Parse(Get("GreenUlTrafficLightStartTime"));
        public static byte GreenFrTrafficLightStartTime = byte.Parse(Get("GreenFrTrafficLightStartTime"));
        public static byte GreenTrafficLightStartTime = byte.Parse(Get("GreenTrafficLightStartTime"));
        public static byte OrangeTrafficLightStartTime = byte.Parse(Get("OrangeTrafficLightStartTime"));

        // نقاط الخروج
        public static int LeftExitX = int.Parse(Get("LeftExitX"));
        public static int RightExitX = int.Parse(Get("RightExitX"));
        public static int UpExitY = int.Parse(Get("UpExitY"));
        public static int DownExitY = int.Parse(Get("DownExitY"));

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