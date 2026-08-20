using System;
using System.Drawing;
using System.Windows.Forms;
using static IntersectionSimulation4Way.ClsRoad;

namespace IntersectionSimulation4Way
{
    public partial class UcCar : UcCircleControl
    {
        public enum enCarDestination { Forward, TurnRight, TurnLeft, UTurn }
        public enum enCarState { ApproachingIntersection, WaitingForGreenLight, Turning, Crossing, Exited }
        public int ID { get; private set; }
        public static int CarsNumberCounter { get; private set; } = 0;
        public int Speed { get; set; }
        public enCarState State { get; set; }
        public enCarDestination Destination { get; set; }
        public enRoadPosition OriginRoad { get; private set; }
        public Point TargetIntersectionPoint { get; set; }
        public Point ExitPoint { get; set; }
        private float _currentX;
        private float _currentY;

        // متغيرات لرسم منحنى الانعطاف الدائري
        private PointF _curveP0, _curveP1, _curveP2;
        private float _curveT = 0f;

        public UcCar(Point startPoint, Point targetIntersection, enCarDestination destination, Color color, int speed, enRoadPosition originRoad)
        {
            this.ID = ++CarsNumberCounter;
            this.InnerColor = color;
            this.Speed = speed;
            this.Destination = destination;
            this.OriginRoad = originRoad;
            this.State = enCarState.ApproachingIntersection;
            this.TargetIntersectionPoint = targetIntersection;
            this.ExitPoint = new Point(0, 0);
            this.Location = startPoint;
            this._currentX = startPoint.X;
            this._currentY = startPoint.Y;
            this.Size = new Size(30, 30);
        }

        public UcCar() { }

        /*public void MoveCar()
        {
            // koko ? تابع الإنهاء ؟
            if (State == enCarState.WaitingForGreenLight || State == enCarState.Exited)
                return;

            // 1. معالجة الحركة القوسية (الالتفاف)
            if (State == enCarState.Turning)
            {
                // زيادة تدريجية للمنحنى تعتمد على السرعة (لجعل الالتفاف سلساً)
                _curveT += (float)Speed / 100f;
                if (_curveT >= 1.0f)
                {
                    // انتهى الالتفاف، الآن نتابع بخط مستقيم للمخرج
                    _curveT = 1.0f;
                    State = enCarState.Crossing;
                    _currentX = _curveP2.X;
                    _currentY = _curveP2.Y;
                }
                else
                {
                    // معادلة Quadratic Bezier Curve الرياضية
                    float u = 1 - _curveT;
                    _currentX = (u * u * _curveP0.X) + (2 * u * _curveT * _curveP1.X) + (_curveT * _curveT * _curveP2.X);
                    _currentY = (u * u * _curveP0.Y) + (2 * u * _curveT * _curveP1.Y) + (_curveT * _curveT * _curveP2.Y);
                }
                UpdateLocation();
                return;
            }

            // 2. معالجة الحركة في خط مستقيم
            Point target = (State == enCarState.ApproachingIntersection) ? TargetIntersectionPoint : ExitPoint;

            float dx = target.X - _currentX;
            float dy = target.Y - _currentY;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance <= Speed)
            {
                _currentX = target.X;
                _currentY = target.Y;
                UpdateLocation();

                // koko  شو ضروري ؟ انطر الاشارة الخضراء ؟
                if (State == enCarState.ApproachingIntersection)
                    State = enCarState.WaitingForGreenLight;
                else if (State == enCarState.Crossing)
                    State = enCarState.Exited;
            }
            else
            {
                // koko
                _currentX += (dx / distance) * Speed;
                _currentY += (dy / distance) * Speed;
                UpdateLocation();
            }
        }
        */

        /*public void MoveCar()
        {
            // الإنهاء المباشر إذا كانت السيارة تنتظر الإشارة أو خرجت بالفعل
            if (State == enCarState.WaitingForGreenLight || State == enCarState.Exited)
                return;

            // 1. معالجة الحركة القوسية (الالتفاف)
            if (State == enCarState.Turning)
            {
                // حساب المسافة التقريبية للمنحنى (باستخدام المسافة بين P0 و P2 والتحكم P1)
                float chord = (float)Math.Sqrt(Math.Pow(_curveP2.X - _curveP0.X, 2) + Math.Pow(_curveP2.Y - _curveP0.Y, 2));
                float controlLength = (float)(Math.Sqrt(Math.Pow(_curveP1.X - _curveP0.X, 2) + Math.Pow(_curveP1.Y - _curveP0.Y, 2)) +
                                              Math.Sqrt(Math.Pow(_curveP2.X - _curveP1.X, 2) + Math.Pow(_curveP2.Y - _curveP1.Y, 2)));

                // متوسط طول المنحنى التقريبي
                float estimatedArcLength = (chord + controlLength) / 2f;
                if (estimatedArcLength < 1f) estimatedArcLength = 1f; // تجنب القسمة على صفر

                // زيادة T بناءً على السرعة الفعلية مقسومة على طول المنحنى
                _curveT += (float)Speed / estimatedArcLength;

                if (_curveT >= 1.0f)
                {
                    _curveT = 1.0f;
                    State = enCarState.Crossing;
                    _currentX = _curveP2.X;
                    _currentY = _curveP2.Y;
                }
                else
                {
                    // معادلة Quadratic Bezier Curve
                    float u = 1 - _curveT;
                    _currentX = (u * u * _curveP0.X) + (2 * u * _curveT * _curveP1.X) + (_curveT * _curveT * _curveP2.X);
                    _currentY = (u * u * _curveP0.Y) + (2 * u * _curveT * _curveP1.Y) + (_curveT * _curveT * _curveP2.Y);
                }

                UpdateLocation();
                return;
            }

            // 2. معالجة الحركة في خط مستقيم
            Point target = (State == enCarState.ApproachingIntersection) ? TargetIntersectionPoint : ExitPoint;

            float dx = target.X - _currentX;
            float dy = target.Y - _currentY;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance <= Speed)
            {
                _currentX = target.X;
                _currentY = target.Y;
                UpdateLocation();

                if (State == enCarState.ApproachingIntersection)
                    State = enCarState.WaitingForGreenLight;
                else if (State == enCarState.Crossing)
                    State = enCarState.Exited;
            }
            else
            {
                _currentX += (dx / distance) * Speed;
                _currentY += (dy / distance) * Speed;
                UpdateLocation();
            }
        }*/

        public void MoveCar()
        {
            if (State == enCarState.WaitingForGreenLight || State == enCarState.Exited)
                return;

            // 1. معالجة الحركة القوسية (الالتفاف)
            if (State == enCarState.Turning)
            {
                // استخدام سرعة أبطأ خصيصاً للالتفاف (مثلاً 50% من السرعة الأصلية)
                float turningSpeed = (float)Speed * 0.5f;

                // زيادة T بمعدل متناسب مع السرعة المنخفضة
                // يمكن التعديل على الرقم 250f لتحديد مدى بطء الالتفاف
                _curveT += turningSpeed / 250f;

                if (_curveT >= 1.0f)
                {
                    _curveT = 1.0f;
                    State = enCarState.Crossing; // تعود للسرعة العادية بعد الانتهاء
                    _currentX = _curveP2.X;
                    _currentY = _curveP2.Y;
                }
                else
                {
                    float u = 1 - _curveT;
                    _currentX = (u * u * _curveP0.X) + (2 * u * _curveT * _curveP1.X) + (_curveT * _curveT * _curveP2.X);
                    _currentY = (u * u * _curveP0.Y) + (2 * u * _curveT * _curveP1.Y) + (_curveT * _curveT * _curveP2.Y);
                }

                UpdateLocation();
                return;
            }

            // 2. معالجة الحركة في خط مستقيم
            Point target = (State == enCarState.ApproachingIntersection) ? TargetIntersectionPoint : ExitPoint;

            float dx = target.X - _currentX;
            float dy = target.Y - _currentY;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance <= Speed)
            {
                _currentX = target.X;
                _currentY = target.Y;
                UpdateLocation();

                if (State == enCarState.ApproachingIntersection)
                    State = enCarState.WaitingForGreenLight;
                else if (State == enCarState.Crossing)
                    State = enCarState.Exited;
            }
            else
            {
                _currentX += (dx / distance) * Speed;
                _currentY += (dy / distance) * Speed;
                UpdateLocation();
            }
        }
        
        private void UpdateLocation()
        {
            this.Location = new Point((int)_currentX, (int)_currentY);
        }

        public void GrantGreenLight()
        {
            if (State == enCarState.WaitingForGreenLight)
            {
                ExecuteDestinationPath();
            }
        }

        private void ExecuteDestinationPath()
        {
            switch (Destination)
            {
                case enCarDestination.Forward:
                    GoForward();
                    State = enCarState.Crossing; // الخط المستقيم لا يحتاج لدوران
                    break;
                case enCarDestination.TurnRight: TurnRight(); break;
                case enCarDestination.TurnLeft: TurnLeft(); break;
                case enCarDestination.UTurn: MakeUTurn(); break;
            }
        }

        // ==============================================================
        // حساب نقاط الانعطاف (بداية القوس P0، منتصف القوس P1، نهاية القوس P2)
        // ==============================================================

        public void GoForward()
        {
            switch (OriginRoad)
            {
                case enRoadPosition.Bottom: this.ExitPoint = new Point((int)this._currentX, ClsSettings.UpExitY); break;
                case enRoadPosition.Top: this.ExitPoint = new Point((int)this._currentX, ClsSettings.DownExitY); break;
                case enRoadPosition.Right: this.ExitPoint = new Point(ClsSettings.LeftExitX, (int)this._currentY); break;
                case enRoadPosition.Left: this.ExitPoint = new Point(ClsSettings.RightExitX, (int)this._currentY); break;
            }
        }

        public void TurnRight()
        {
            _curveP0 = TargetIntersectionPoint;
            int arcSize = 55; // حجم قوس الانعطاف لليمين

            switch (OriginRoad)
            {
                case enRoadPosition.Bottom:
                    _curveP1 = new PointF(_curveP0.X, _curveP0.Y - arcSize);
                    _curveP2 = new PointF(_curveP0.X + arcSize, _curveP0.Y - arcSize);
                    this.ExitPoint = new Point(ClsSettings.RightExitX, (int)_curveP2.Y);
                    break;
                case enRoadPosition.Top:
                    _curveP1 = new PointF(_curveP0.X, _curveP0.Y + arcSize);
                    _curveP2 = new PointF(_curveP0.X - arcSize, _curveP0.Y + arcSize);
                    this.ExitPoint = new Point(ClsSettings.LeftExitX, (int)_curveP2.Y);
                    break;
                // الطرق الأفقية تم إجبارها على السير للأمام، لكن نترك المنطق برمجياً كحماية
                case enRoadPosition.Right:
                    _curveP1 = new PointF(_curveP0.X - arcSize, _curveP0.Y);
                    _curveP2 = new PointF(_curveP0.X - arcSize, _curveP0.Y - arcSize);
                    this.ExitPoint = new Point((int)_curveP2.X, ClsSettings.UpExitY);
                    break;
                case enRoadPosition.Left:
                    _curveP1 = new PointF(_curveP0.X + arcSize, _curveP0.Y);
                    _curveP2 = new PointF(_curveP0.X + arcSize, _curveP0.Y + arcSize);
                    this.ExitPoint = new Point((int)_curveP2.X, ClsSettings.DownExitY);
                    break;
            }
            State = enCarState.Turning;
        }

        public void TurnLeft()
        {
            _curveP0 = TargetIntersectionPoint;

            // الملاحظة الثانية: زيادة المسافة للأمام قبل الالتفاف لعدم الاصطدام بالمنصف
            int forwardPush = 182; // كانت 130، تم زيادتها لدفع القوس للأعلى/للأسفل أكثر
            int sidePush = 300;
            //int forwardPush = 180; // كانت 130، تم زيادتها لدفع القوس للأعلى/للأسفل أكثر
            //int sidePush = 145;
            //

            switch (OriginRoad)
            {
                case enRoadPosition.Bottom:
                    _curveP1 = new PointF(_curveP0.X, _curveP0.Y - forwardPush); // التمدد أكثر للأعلى
                    _curveP2 = new PointF(_curveP0.X - sidePush, _curveP0.Y - forwardPush);
                    this.ExitPoint = new Point(ClsSettings.LeftExitX, (int)_curveP2.Y);
                    break;
                case enRoadPosition.Top:
                    _curveP1 = new PointF(_curveP0.X, _curveP0.Y + forwardPush); // التمدد أكثر للأسفل
                    _curveP2 = new PointF(_curveP0.X + sidePush, _curveP0.Y + forwardPush);
                    this.ExitPoint = new Point(ClsSettings.RightExitX, (int)_curveP2.Y);
                    break;
                case enRoadPosition.Right:
                    _curveP1 = new PointF(_curveP0.X - forwardPush, _curveP0.Y); // التمدد لليسار
                    _curveP2 = new PointF(_curveP0.X - forwardPush, _curveP0.Y + sidePush);
                    this.ExitPoint = new Point((int)_curveP2.X, ClsSettings.DownExitY);
                    break;
                case enRoadPosition.Left:
                    _curveP1 = new PointF(_curveP0.X + forwardPush, _curveP0.Y); // التمدد لليمين
                    _curveP2 = new PointF(_curveP0.X + forwardPush, _curveP0.Y - sidePush);
                    this.ExitPoint = new Point((int)_curveP2.X, ClsSettings.UpExitY);
                    break;
            }
            State = enCarState.Turning;
        }

        public void MakeUTurn()
        {
            _curveP0 = TargetIntersectionPoint;

            // الملاحظة الثالثة: تكبير مسافة الالتفاف للـ U-Turn
            int forwardDist = 135; // زادت المسافة للدخول أعمق في التقاطع (كانت 80)
            int sideDist = 85;    // زادت الإزاحة ليتناسب الدوران مع عرض الشارع المعاكس (كانت 70)

            switch (OriginRoad)
            {
                case enRoadPosition.Bottom:
                    _curveP1 = new PointF(_curveP0.X - (sideDist / 2f), _curveP0.Y - forwardDist);
                    _curveP2 = new PointF(_curveP0.X - sideDist, _curveP0.Y);
                    this.ExitPoint = new Point((int)_curveP2.X, ClsSettings.DownExitY);
                    break;
                case enRoadPosition.Top:
                    _curveP1 = new PointF(_curveP0.X + (sideDist / 2f), _curveP0.Y + forwardDist);
                    _curveP2 = new PointF(_curveP0.X + sideDist, _curveP0.Y);
                    this.ExitPoint = new Point((int)_curveP2.X, ClsSettings.UpExitY);
                    break;
                case enRoadPosition.Right:
                    _curveP1 = new PointF(_curveP0.X - forwardDist, _curveP0.Y + (sideDist / 2f));
                    _curveP2 = new PointF(_curveP0.X, _curveP0.Y + sideDist);
                    this.ExitPoint = new Point(ClsSettings.RightExitX, (int)_curveP2.Y);
                    break;
                case enRoadPosition.Left:
                    _curveP1 = new PointF(_curveP0.X + forwardDist, _curveP0.Y - (sideDist / 2f));
                    _curveP2 = new PointF(_curveP0.X, _curveP0.Y - sideDist);
                    this.ExitPoint = new Point(ClsSettings.LeftExitX, (int)_curveP2.Y);
                    break;
            }
            State = enCarState.Turning;
        }
        public ClsProjectState.CarData GetCarData()
        {
            return new ClsProjectState.CarData
            {
                ID = this.ID,
                ColorArgb = this.InnerColor.ToArgb(),
                Speed = this.Speed,
                State = this.State,
                Destination = this.Destination,
                OriginRoad = this.OriginRoad,
                TargetIntersectionPoint = this.TargetIntersectionPoint,
                ExitPoint = this.ExitPoint,
                CurrentX = this._currentX,
                CurrentY = this._currentY,
                CurveP0 = this._curveP0,
                CurveP1 = this._curveP1,
                CurveP2 = this._curveP2,
                CurveT = this._curveT
            };
        }

        public static UcCar FromCarData(ClsProjectState.CarData data)
        {
            if (data == null) return null;

            UcCar car = new UcCar
            {
                ID = data.ID,
                InnerColor = Color.FromArgb(data.ColorArgb),
                Speed = data.Speed,
                State = data.State,
                Destination = data.Destination,
                OriginRoad = data.OriginRoad,
                TargetIntersectionPoint = data.TargetIntersectionPoint,
                ExitPoint = data.ExitPoint,
                _currentX = data.CurrentX,
                _currentY = data.CurrentY,
                _curveP0 = data.CurveP0,
                _curveP1 = data.CurveP1,
                _curveP2 = data.CurveP2,
                _curveT = data.CurveT,
                Size = new Size(30, 30)
            };
            car.UpdateLocation();
            return car;
        }
    }
}