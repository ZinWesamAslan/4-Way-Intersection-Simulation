using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntersectionSimulation4Way
{
    public class UcCircleControl: Control
    {
        private Color _innerColor = Color.DodgerBlue;
        private Color _borderColor = Color.DimGray;
        private int _borderThickness = 2;

        #region Properties (الخصائص)

        [Category("My Properties")]
        [Description("Choose Circle Color")]
        public Color InnerColor
        {
            get => _innerColor;
            set
            {
                _innerColor = value;
                this.Invalidate(); // إعادة الرسم عند تغيير اللون
            }
        }

        [Category("My Properties")]
        [Description("Choose Cirlce Border Thickness")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }

        [Category("My Properties")]
        [Description("Choose Cirlce border Color")]
        public int BorderThickness
        {
            get => _borderThickness;
            set
            {
                _borderThickness = Math.Max(0, value);
                this.Invalidate();
            }
        }

        #endregion

        public UcCircleControl()
        {
            // تفعيل التنعيم والرسم المزدوج لمنع الوميض (Flicker) أثناء الحركة
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.ResizeRedraw, true);


            this.Size = new Size(60, 60); // حجم افتراضي متساوي (مربع لتعطي دائرة منتظمة)
            this.BackColor = Color.Transparent;
        }

        // 1. جعل العنصر دائري الشكل في الـ Designer وفي الـ Runtime
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateCircleRegion();
        }

        private void UpdateCircleRegion()
        {
            // إنشـاء المسار الدائري وقص حدود العنصر بناءً عليه
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, this.Width, this.Height);
                this.Region = new Region(path); // هذا السطر هو السر ليظهر دائرياً في الـ Designer
            }
        }

        // 2. رسم الخلفية و الحدود الدائرية
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // تنعيم حواف الدائرة

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            // رسم ملء الدائرة 
            using (SolidBrush fillBrush = new SolidBrush(_innerColor))
            {
                g.FillEllipse(fillBrush, rect);
            }

            // رسم الإطار الخارجي للدائرة 
            if (_borderThickness > 0)
            {
                using (Pen borderPen = new Pen(_borderColor, _borderThickness))
                {
                    // محاذاة القلم ليرسم داخل حدود الدائرة تماماً
                    borderPen.Alignment = PenAlignment.Inset;
                    g.DrawEllipse(borderPen, rect);
                }
            }
        }
    }
}
