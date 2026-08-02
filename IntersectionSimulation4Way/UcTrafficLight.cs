using Guna.UI2.WinForms;
using IntersectionSimulation4Way.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace IntersectionSimulation4Way
{
    public partial class UcTrafficLight : Guna2PictureBox
    {
        public enum enTrafficLightMode { Green, GreenUL, GreenFR, Red, Orange }

        private enTrafficLightMode _mode = enTrafficLightMode.Red;
        private float _angle = 0f;

        // متغيرات التحكم في الوقت والتسلسل
        private Timer _timer = new Timer();
        private int _secondsCounter = 0;

        // متغير نصي يحتفظ بقيمة العد التنازلي
        private string _timerText = "10";

        public UcTrafficLight()
        {
            InitializeComponent();
            InitializeTimer();
            Mode = enTrafficLightMode.Red; // تعيين الوضع الافتراضي إلى الأحمر
        }

        [Category("Appearance")]
        [Description("Choose Traffic Light Color")]
        [DefaultValue(enTrafficLightMode.Red)]
        public enTrafficLightMode Mode
        {
            get => _mode;
            set
            {
                _mode = value;
                OnModeChanged(value);
            }
        }

        [Category("Appearance")]
        [Description("Choose Angle between 0 and 359")]
        [DefaultValue(0f)]
        public float Angle
        {
            get => _angle;
            set
            {
                if (value > 359 || value < 0)
                {
                    MessageBox.Show("Sorry, Angle Should be between 0 and 359", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    _angle = value;
                    Invalidate(); // إعادة الرسم لتطبيق الزاوية الجديدة
                }
            }
        }

        /// <summary>
        /// تهيئة المؤقت الخاص بالتحكم في الزمن
        /// </summary>
        private void InitializeTimer()
        {
            _timer.Interval = 1000; // تحدث كل ثانية
            _timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// بدء تشغيل محاكاة دورة إشارة المرور
        /// </summary>
        public void StartSimulation()
        {
            switch (Mode)
            {
                case enTrafficLightMode.Red:
                    _secondsCounter = 0; // إعادة العداد إذا كانت الإشارة حمراء
                    break;
                case enTrafficLightMode.Green:
                    _secondsCounter = 21;
                    break;
                case enTrafficLightMode.GreenUL:
                    _secondsCounter = 26;
                    break;
                case enTrafficLightMode.GreenFR:
                    _secondsCounter = 31;
                    break;
                case enTrafficLightMode.Orange:
                    _secondsCounter = 36;
                    break;
            }
            _timer.Start();
        }

        /// <summary>
        /// إيقاف المحاكاة
        /// </summary>
        public void StopSimulation()
        {
            _timer.Stop();
        }

        /// <summary>
        /// حدث المؤقت الذي ينفذ التسلسل الزمني وتحديث الرقم التنازلي
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            _secondsCounter++;

            /*
             * التسلسل الزمني الكلي (24 ثانية):
             * 1  إلى 10 ثوانٍ (10s) -> Red
             * 11 إلى 13 ثانية (3s)  -> Green
             * 14 إلى 16 ثانية (3s)  -> GreenUL
             * 17 إلى 20 ثانية (4s)  -> GreenFR
             * 21 إلى 24 ثانية (4s)  -> Orange
            */

            if (_secondsCounter <= 20)
            {
                if (_mode != enTrafficLightMode.Red) Mode =enTrafficLightMode.Red;
                _timerText = (20 - _secondsCounter + 1).ToString();
            }
            else if (_secondsCounter <= 25)
            {
                if (_mode != enTrafficLightMode.Green) Mode = enTrafficLightMode.Green;
                _timerText = (25 - _secondsCounter + 1).ToString();
            }
            else if (_secondsCounter <= 30)
            {
                if (_mode != enTrafficLightMode.GreenUL) Mode = enTrafficLightMode.GreenUL;
                _timerText = (30 - _secondsCounter + 1).ToString();
            }
            else if (_secondsCounter <= 35)
            {
                if (_mode != enTrafficLightMode.GreenFR) Mode = enTrafficLightMode.GreenFR;
                _timerText = (35 - _secondsCounter + 1).ToString();
            }
            else if (_secondsCounter <= 40)
            {
                if (_mode != enTrafficLightMode.Orange) Mode = enTrafficLightMode.Orange;
                _timerText = (40 - _secondsCounter + 1).ToString();
            }
            else
            {
                _secondsCounter = 0; // إعادة الدورة من جديد
            }

            Invalidate();
        }

        private void OnModeChanged(enTrafficLightMode mode)
        {
            switch (mode)
            {
                case enTrafficLightMode.Red:
                    this.Image = Resources.RedTrafficLight;
                    break;
                case enTrafficLightMode.Orange:
                    this.Image = Resources.OrangeTrafficLight;
                    break;
                case enTrafficLightMode.Green:
                    this.Image = Resources.GreenTrafficLight;
                    break;
                case enTrafficLightMode.GreenUL:
                    this.Image = Resources.GreenTrafficLighWithUandLiftTurn;
                    break;
                case enTrafficLightMode.GreenFR:
                    this.Image = Resources.GreenTrafficLighWithForawardAndRightTurn;
                    break;
            }
            Invalidate();
        }

        /// <summary>
        /// [جديد]: دالة مساعدة لتحديد لون النص بناءً على حالة الإشارة (Mode)
        /// </summary>
        private Color GetTextColorByMode()
        {
            switch (_mode)
            {
                case enTrafficLightMode.Red:
                    return Color.Red;

                case enTrafficLightMode.Orange:
                    return Color.Orange;

                case enTrafficLightMode.Green:
                case enTrafficLightMode.GreenUL:
                case enTrafficLightMode.GreenFR:
                    return Color.LimeGreen; // لون أخضر واضح برمجياً

                default:
                    return Color.White;
            }
        }

        /// <summary>
        /// [مُعدّل]: رسم صورة الإشارة والنص الشفاف مع تغيير لونه حسب المود بدقة عالية
        /// </summary>
        protected override void OnPaint(PaintEventArgs pe)
        {
            if (Image == null)
            {
                base.OnPaint(pe);
                return;
            }

            // تحسين جودة الرسم والنصوص أثناء الدوران
            pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pe.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            // 1. تطبيق الدوران حول مركز الكنترول
            pe.Graphics.TranslateTransform(Width / 2f, Height / 2f);
            pe.Graphics.RotateTransform(_angle);
            pe.Graphics.TranslateTransform(-Width / 2f, -Height / 2f);

            // 2. رسم صورة الإشارة
            pe.Graphics.DrawImage(Image, ClientRectangle);

            // 3. رسم النص بدون خلفية وبالموقع (X = 73, Y = 0)
            Rectangle textBounds = new Rectangle(73, 0, 27, 20);
            Color textColor = GetTextColorByMode();

            using (Font font = new Font("Segoe UI", 10f, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(textColor))
            {
                using (StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                })
                {
                    pe.Graphics.DrawString(_timerText, font, textBrush, textBounds, sf);
                }
            }
        }
    }
}