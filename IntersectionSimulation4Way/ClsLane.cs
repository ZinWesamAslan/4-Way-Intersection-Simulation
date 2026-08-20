using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static IntersectionSimulation4Way.UcCar;
using static IntersectionSimulation4Way.ClsRoad;

namespace IntersectionSimulation4Way
{
    public class ClsLane
    {
        //public List<UcCar> Cars = new List<UcCar>();
        public UcCar CurrentCar { get; private set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public enRoadPosition RoadPosition { get; private set; }
        public List<enCarDestination> AllowedDestinations { get; private set; }

        private static Random _rnd = new Random();
        private int _spawnDelayTicks = 0; // متغير التأخير لتباعد السيارات

        public ClsLane(Point startPoint, Point endPoint, enRoadPosition roadPosition, List<enCarDestination> allowedDestinations)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.RoadPosition = roadPosition;
            this.AllowedDestinations = allowedDestinations;
        }

        public void UpdateLane(Control parentForm)
        {
            if (CurrentCar == null)
            {
                // توليد عشوائي متباعد للسيارات
                if (_spawnDelayTicks <= 0)
                {
                    SpawnNewCar(parentForm);
                    _spawnDelayTicks = _rnd.Next(20, 150); // تأخير عشوائي قبل احتمالية خروج السيارة التالية
                }
                else
                {
                    _spawnDelayTicks--;
                }
            }
            else
            {
                CurrentCar.MoveCar();

                if (CurrentCar.State == enCarState.Exited)
                {
                    parentForm.Controls.Remove(CurrentCar);
                    CurrentCar.Dispose();
                    CurrentCar = null;
                }
            }
        }

        private void SpawnNewCar(Control parentForm)
        {
            Color randomColor = Color.FromArgb(_rnd.Next(50, 255), _rnd.Next(50, 255), _rnd.Next(50, 255));

            // اختيار وجهة عشوائية للسيارة من ضمن الوجهات المخصصة لهذا الممر تحديداً
            enCarDestination destination = AllowedDestinations[_rnd.Next(AllowedDestinations.Count)];
            int speed = _rnd.Next(3, 5); // سرعة عشوائية للسيارة

            // تمرير الطريق الأساسي للسيارة لتعرف كيف تنعطف
            CurrentCar = new UcCar(StartPoint, EndPoint, destination, randomColor, speed, RoadPosition);

            parentForm.Controls.Add(CurrentCar);
            CurrentCar.BringToFront();
        }

        // hheeeerrrr
        public ClsProjectState.LaneData GetLaneData()
        {
            return new ClsProjectState.LaneData
            {
                SpawnDelayTicks = this._spawnDelayTicks,
                CurrentCar = this.CurrentCar?.GetCarData()
            };
        }

        // hheeeerrrr
        public void RestoreLaneData(ClsProjectState.LaneData data, Control parentForm)
        {
            if (CurrentCar != null)
            {
                parentForm.Controls.Remove(CurrentCar);
                CurrentCar.Dispose();
                CurrentCar = null;
            }

            if (data == null) return;

            this._spawnDelayTicks = data.SpawnDelayTicks;
            if (data.CurrentCar != null)
            {
                this.CurrentCar = UcCar.FromCarData(data.CurrentCar);
                parentForm.Controls.Add(this.CurrentCar);
                this.CurrentCar.BringToFront();
            }
        }
    }
}