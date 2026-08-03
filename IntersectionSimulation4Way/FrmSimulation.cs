using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static IntersectionSimulation4Way.ClsRoad;

namespace IntersectionSimulation4Way
{
    public partial class FrmSimulation : Form
    {
        private Timer _masterTimer = new Timer();
        private int _elapsedTicks = 0;

        // قائمة الطرق لسهولة تحديثها في حلقة (Loop) واحدة
        private List<ClsRoad> _roads = new List<ClsRoad>();

        public FrmSimulation()
        {
            InitializeComponent();

            // تفعيل Double Buffering لمنع الرمش (Flickering) أثناء تحرك السيارات
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void FrmSimulation_Load(object sender, EventArgs e)
        {
            // 1. تهيئة الإشارات
            UcTrafficLightDown.InitializeSimulation(isFourModes: true);
            UcTrafficLightUp.InitializeSimulation(isFourModes: true);
            UcTrafficLightLift.InitializeSimulation(isFourModes: false);
            UcTrafficLightRight.InitializeSimulation(isFourModes: false);

            // 2. تهيئة الطرق وربطها بإشاراتها والممرات الخاصة بها (3 أو 2 ممرات)
            _roads.Add(new ClsRoad(UcTrafficLightDown, enRoadPosition.Bottom, 3));
            _roads.Add(new ClsRoad(UcTrafficLightUp, enRoadPosition.Top, 3));
            _roads.Add(new ClsRoad(UcTrafficLightRight, enRoadPosition.Right, 2));
            _roads.Add(new ClsRoad(UcTrafficLightLift, enRoadPosition.Left, 2));

            // 3. إعداد المحرك الزمني المركزي (30 ميلي ثانية تعني حركة ناعمة جداً)
            _masterTimer.Interval = 30;
            _masterTimer.Tick += MasterTimer_Tick;
            _masterTimer.Start();
        }

        private void MasterTimer_Tick(object sender, EventArgs e)
        {
            _elapsedTicks += _masterTimer.Interval;

            // تحديث عدادات الإشارات كل 1 ثانية (1000 ميلي ثانية)
            if (_elapsedTicks >= 1000)
            {
                _elapsedTicks = 0;

                UcTrafficLightDown.TickOneSecond();
                UcTrafficLightUp.TickOneSecond();
                UcTrafficLightLift.TickOneSecond();
                UcTrafficLightRight.TickOneSecond();
            }

            // تحديث الطرق (والذي بدوره سيحرك السيارات ويفحص الإشارات وينشئ السيارات الجديدة)
            foreach (var road in _roads)
            {
                road.UpdateRoad(this); // نمرر الـ form (this) لكي يستطيع إضافة وحذف عناصر السيارات من الشاشة
            }
        }

        private void FrmSimulation_FormClosing(object sender, FormClosingEventArgs e)
        {
            _masterTimer.Stop();
            _masterTimer.Dispose();
        }
    }
}