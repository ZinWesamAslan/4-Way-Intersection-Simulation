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
        
        public event Action<enTrafficLightMode> OnLightModeChanged;
        public enum enTrafficLightMode { Green, GreenUL, GreenFR, Red, Orange }

        private enTrafficLightMode _mode = enTrafficLightMode.Red;
        private float _angle = 0f;

        private int _secondsCounter = 0;
        private string _timerText = "10";
        private bool _isFourModes = true;

        public UcTrafficLight()
        {
            InitializeComponent();
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
        /// تهيئة وضع الإشارة وقيمة العداد البدائية بناءً على الحالة الحالية
        /// </summary>
        public void InitializeSimulation(bool isFourModes)
        {
            _isFourModes = isFourModes;
            ResetCounterByMode();
        }

        private void ResetCounterByMode()
        {
            switch (Mode)
            {
                case enTrafficLightMode.Red:
                    _secondsCounter = (int)ClsSettings.RedTrafficLightStartTime;
                    break;
                case enTrafficLightMode.GreenUL:
                    _secondsCounter = (int)ClsSettings.GreenUlTrafficLightStartTime;
                    break;
                case enTrafficLightMode.GreenFR:
                    _secondsCounter = (int)ClsSettings.GreenFrTrafficLightStartTime;
                    break;
                case enTrafficLightMode.Green:
                    _secondsCounter = (int)ClsSettings.GreenTrafficLightStartTime;
                    break;
                case enTrafficLightMode.Orange:
                    _secondsCounter = (int)ClsSettings.OrangeTrafficLightStartTime;
                    break;
            }
        }

        /// <summary>
        /// يتم استدعاء هذه الدالة كل ثانية من التايمر المركزي الرئيسي في الـ Form
        /// </summary>
        public void TickOneSecond()
        {
            _secondsCounter++;

            if (_isFourModes)
            {
                UpdateFourModes();
            }
            else
            {
                UpdateThreeModes();
            }

            Invalidate();
        }

        private void UpdateFourModes()
        {
            if (_secondsCounter <= ClsSettings.GreenUlTrafficLightStartTime)
            {
                if (_mode != enTrafficLightMode.Red) Mode = enTrafficLightMode.Red;
                _timerText = (ClsSettings.GreenUlTrafficLightStartTime - _secondsCounter + 1).ToString();
            }
            else if (_secondsCounter <= ClsSettings.GreenFrTrafficLightStartTime)
            {
                if (_mode != enTrafficLightMode.GreenUL) Mode = enTrafficLightMode.GreenUL;
                _timerText = (ClsSettings.GreenFrTrafficLightStartTime - _secondsCounter + 1).ToString();
            }
            else if (_secondsCounter <= ClsSettings.OrangeTrafficLightStartTime)
            {
                if (_mode != enTrafficLightMode.GreenFR) Mode = enTrafficLightMode.GreenFR;
                _timerText = (ClsSettings.OrangeTrafficLightStartTime - _secondsCounter + 1).ToString();
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
        }

        private void UpdateThreeModes()
        {
            if (_secondsCounter <= ClsSettings.GreenUlTrafficLightStartTime)
            {
                if (_mode != enTrafficLightMode.Red) Mode = enTrafficLightMode.Red;
                _timerText = (ClsSettings.GreenUlTrafficLightStartTime - _secondsCounter + 1).ToString();
            }
            else if (_secondsCounter <= ClsSettings.OrangeTrafficLightStartTime)
            {
                if (_mode != enTrafficLightMode.Green) Mode = enTrafficLightMode.Green;
                _timerText = (ClsSettings.OrangeTrafficLightStartTime - _secondsCounter + 1).ToString();
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
            OnLightModeChanged?.Invoke(mode); // إطلاق الحدث للممرات المشتركة
        }

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
                    return Color.LimeGreen;

                default:
                    return Color.White;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (Image == null)
            {
                base.OnPaint(pe);
                return;
            }

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

            using (Font font = new Font("Impact", 14f, FontStyle.Bold))
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