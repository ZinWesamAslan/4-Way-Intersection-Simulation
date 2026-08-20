using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static IntersectionSimulation4Way.ClsRoad;
using System.Configuration;
using System.IO;
using System.Linq;

namespace IntersectionSimulation4Way
{
    public partial class FrmSimulation : Form
    {
        private Timer _masterTimer = new Timer();
        private int _elapsedTicks = 0;

        private const string SaveFilePath = "simulation_state.json";

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
            if (!AuthenticateUser())
            {
                Application.Exit();
                return;
            }

            
            bool restored = false;
            if (File.Exists(SaveFilePath))
            {
                var dialogResult = MessageBox.Show(
                    "يوجد نقطة حفظ سابقة للمشروع. هل تريد استعادتها؟\n(اختر 'لا' لبدء محاكاة جديدة)",
                    "استعادة الحفظ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        var savedState = ClsSerializationManager.LoadState();
                        if (savedState != null)
                        {
                            RestoreSimulationState(savedState);
                            restored = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("حدث خطأ أثناء استعادة الملف، سيتم بدء محاكاة جديدة.\n" + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            if (!restored)
            {
                InitializeNewSimulation();
            }

            _masterTimer.Interval = 30;
            _masterTimer.Tick += MasterTimer_Tick;
            _masterTimer.Start();
        }

        private bool AuthenticateUser()
        {
            string storedHash = ConfigurationManager.AppSettings["PasswordHash"];
            string storedSalt = ConfigurationManager.AppSettings["PasswordSalt"];
            string storedPepper = ConfigurationManager.AppSettings["PasswordPepper"];

            string inputPassword = Microsoft.VisualBasic.Interaction.InputBox(
                "أدخل كلمة المرور لتشغيل النظام:", "تسجيل الدخول", "");

            if (string.IsNullOrEmpty(inputPassword)) return false;

            string inputHash = ClsSecurityHelper.ComputeHash(inputPassword, storedSalt, storedPepper);
            return inputHash == storedHash;
        }

        private void InitializeNewSimulation()
        {
            
            foreach (var road in _roads)
            {
                foreach (var lane in road.Lanes)
                {
                    if (lane.CurrentCar != null)
                    {
                        this.Controls.Remove(lane.CurrentCar);
                        lane.CurrentCar.Dispose();
                    }
                }
            }
            
            _roads.Clear();

            UcTrafficLightDown.InitializeSimulation(isFourModes: true);
            UcTrafficLightUp.InitializeSimulation(isFourModes: true);
            UcTrafficLightLift.InitializeSimulation(isFourModes: false);
            UcTrafficLightRight.InitializeSimulation(isFourModes: false);

            _roads.Add(new ClsRoad(UcTrafficLightDown, enRoadPosition.Bottom, 3));
            _roads.Add(new ClsRoad(UcTrafficLightUp, enRoadPosition.Top, 3));
            _roads.Add(new ClsRoad(UcTrafficLightRight, enRoadPosition.Right, 2));
            _roads.Add(new ClsRoad(UcTrafficLightLift, enRoadPosition.Left, 2));
        }

        private async void btnSaveState_Click(object sender, EventArgs e)
        {
            var currentState = new ClsProjectState
            {
                ElapsedTicks = this._elapsedTicks,
                TrafficLights = new List<ClsProjectState.TrafficLightData>
                {
                    new ClsProjectState.TrafficLightData { ControlName = UcTrafficLightDown.Name, Mode = UcTrafficLightDown.Mode, SecondsCounter = UcTrafficLightDown.SecondsCounter },
                    new ClsProjectState.TrafficLightData { ControlName = UcTrafficLightUp.Name, Mode = UcTrafficLightUp.Mode, SecondsCounter = UcTrafficLightUp.SecondsCounter },
                    new ClsProjectState.TrafficLightData { ControlName = UcTrafficLightRight.Name, Mode = UcTrafficLightRight.Mode, SecondsCounter = UcTrafficLightRight.SecondsCounter },
                    new ClsProjectState.TrafficLightData { ControlName = UcTrafficLightLift.Name, Mode = UcTrafficLightLift.Mode, SecondsCounter = UcTrafficLightLift.SecondsCounter }
                },
                Roads = _roads.Select(r => r.GetRoadData()).ToList()
            };

            await ClsSerializationManager.SaveStateAsync(currentState);
            MessageBox.Show("تم حفظ الحالة في الخلفية بنجاح!", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RestoreSimulationState(ClsProjectState state)
        {
            InitializeNewSimulation();
            this._elapsedTicks = state.ElapsedTicks;

            if (state == null) return;

            
            if (state.TrafficLights != null)
            {
                foreach (var lightData in state.TrafficLights)
                {
                    if (lightData.ControlName == UcTrafficLightDown.Name)
                        UcTrafficLightDown.RestoreLightState(lightData.Mode, lightData.SecondsCounter);
                    else if (lightData.ControlName == UcTrafficLightUp.Name)
                        UcTrafficLightUp.RestoreLightState(lightData.Mode, lightData.SecondsCounter);
                    else if (lightData.ControlName == UcTrafficLightRight.Name)
                        UcTrafficLightRight.RestoreLightState(lightData.Mode, lightData.SecondsCounter);
                    else if (lightData.ControlName == UcTrafficLightLift.Name)
                        UcTrafficLightLift.RestoreLightState(lightData.Mode, lightData.SecondsCounter);
                }
            }

            
            if (state.Roads != null)
            {
                foreach (var roadData in state.Roads)
                {
                    var matchingRoad = _roads.FirstOrDefault(r => r.Position == roadData.Position);
                    if (matchingRoad != null)
                    {
                        matchingRoad.RestoreRoadData(roadData, this);
                    }
                }
            }
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

            foreach (var road in _roads)
            {
                road.UpdateRoad(this);
            }
        }

        private void FrmSimulation_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ما فيه ديس بوز ل الشوارع ؟ 
            _masterTimer.Stop();
            _masterTimer.Dispose();
        }
    }
}