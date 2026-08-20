using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static IntersectionSimulation4Way.UcCar;

namespace IntersectionSimulation4Way
{
    public class ClsRoad
    {
        public enum enRoadPosition { Bottom, Right, Top, Left }
        public List<ClsLane> Lanes { get; private set; }
        public UcTrafficLight TrafficLight { get; set; }
        public enRoadPosition Position { get; private set; }

        public ClsRoad(UcTrafficLight trafficLight, enRoadPosition position, int numberOfLanes)
        {
            if (numberOfLanes < 2 || numberOfLanes > 3)
                throw new ArgumentOutOfRangeException("Road must have between 2 and 3 lanes.");

            this.TrafficLight = trafficLight;
            this.Position = position;
            this.Lanes = new List<ClsLane>();

            InitializeLanes(numberOfLanes);
        }

        private void InitializeLanes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Point start = new Point(), end = new Point();
                List<enCarDestination> allowedDestinations = new List<enCarDestination>();

                // سحب الإحداثيات بناءً على موقع الطريق
                switch (Position)
                {
                    case enRoadPosition.Bottom:
                        start = ClsSettings.BottomRoadStarts[i];
                        end = ClsSettings.BottomRoadEnds[i];
                        break;
                    case enRoadPosition.Top:
                        start = ClsSettings.TopRoadStarts[i];
                        end = ClsSettings.TopRoadEnds[i];
                        break;
                    case enRoadPosition.Right:
                        start = ClsSettings.RightRoadStarts[i];
                        end = ClsSettings.RightRoadEnds[i];
                        break;
                    case enRoadPosition.Left:
                        start = ClsSettings.LeftRoadStarts[i];
                        end = ClsSettings.LeftRoadEnds[i];
                        break;
                }

                // تطبيق قواعد الانعطاف على الممرات (3 ممرات)
                if (count == 3)
                {
                    // الملاحظة الأولى: إضافة إمكانية المتابعة للأمام (Forward) للممر الأول (Index 0)
                    if (i == 0) allowedDestinations.AddRange(new[] { enCarDestination.TurnLeft, enCarDestination.UTurn, enCarDestination.Forward });
                    else if (i == 1) allowedDestinations.Add(enCarDestination.Forward);
                    else if (i == 2) allowedDestinations.AddRange(new[] { enCarDestination.TurnRight, enCarDestination.Forward });
                }
                else // طرق الممرين
                {
                    allowedDestinations.Add(enCarDestination.Forward);
                }

                Lanes.Add(new ClsLane(start, end, Position, allowedDestinations));
            }
        }

        public void UpdateRoad(Control parentForm)
        {
            foreach (var lane in Lanes)
            {
                lane.UpdateLane(parentForm);

                if (lane.CurrentCar != null && lane.CurrentCar.State == enCarState.WaitingForGreenLight)
                {
                    if (IsLightGreenForCar(lane.CurrentCar.Destination))
                    {
                        lane.CurrentCar.GrantGreenLight(); // إعطاء الإذن بالانطلاق وتحديد مسار الخروج
                    }
                }
            }
        }

        private bool IsLightGreenForCar(enCarDestination carDestination)
        {
            UcTrafficLight.enTrafficLightMode currentMode = TrafficLight.Mode;

            if (currentMode == UcTrafficLight.enTrafficLightMode.Green)
                return true;

            if (currentMode == UcTrafficLight.enTrafficLightMode.GreenFR &&
               (carDestination == enCarDestination.Forward || carDestination == enCarDestination.TurnRight))
                return true;

            if (currentMode == UcTrafficLight.enTrafficLightMode.GreenUL &&
               (carDestination == enCarDestination.UTurn || carDestination == enCarDestination.TurnLeft))
                return true;

            return false;
        }
        public ClsProjectState.RoadData GetRoadData()
        {
            var roadData = new ClsProjectState.RoadData
            {
                Position = this.Position
            };

            foreach (var lane in Lanes)
            {
                roadData.Lanes.Add(lane.GetLaneData());
            }

            return roadData;
        }

        
        public void RestoreRoadData(ClsProjectState.RoadData data, Control parentForm)
        {
            if (data == null || data.Lanes == null) return;

            for (int i = 0; i < Lanes.Count && i < data.Lanes.Count; i++)
            {
                Lanes[i].RestoreLaneData(data.Lanes[i], parentForm);
            }
        }
    }
}