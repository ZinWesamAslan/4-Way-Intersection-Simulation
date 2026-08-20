using System;
using System.Collections.Generic;
using System.Drawing;
using static IntersectionSimulation4Way.ClsRoad;
using static IntersectionSimulation4Way.UcCar;
using static IntersectionSimulation4Way.UcTrafficLight;

namespace IntersectionSimulation4Way
{
    [Serializable]
    public class ClsProjectState
    {
        public int ElapsedTicks { get; set; }

        public List<TrafficLightData> TrafficLights { get; set; } = new List<TrafficLightData>();

        public List<RoadData> Roads { get; set; } = new List<RoadData>();

        public class TrafficLightData
        {
            public string ControlName { get; set; }
            public enTrafficLightMode Mode { get; set; }
            public int SecondsCounter { get; set; }
        }

        public class RoadData
        {
            public enRoadPosition Position { get; set; }
            public List<LaneData> Lanes { get; set; } = new List<LaneData>();
        }

        public class LaneData
        {
            public int SpawnDelayTicks { get; set; }
            public CarData CurrentCar { get; set; }
        }

        public class CarData
        {
            public int ID { get; set; }
            public int ColorArgb { get; set; }
            public int Speed { get; set; }
            public enCarState State { get; set; }
            public enCarDestination Destination { get; set; }
            public enRoadPosition OriginRoad { get; set; }
            public Point TargetIntersectionPoint { get; set; }
            public Point ExitPoint { get; set; }
            public float CurrentX { get; set; }
            public float CurrentY { get; set; }
            public PointF CurveP0 { get; set; }
            public PointF CurveP1 { get; set; }
            public PointF CurveP2 { get; set; }
            public float CurveT { get; set; }
        }
    }
}